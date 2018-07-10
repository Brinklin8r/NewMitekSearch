<###############################################################################
#                                                                              #
 
 Purpose: Given the ECE Sequence Number for an item in IP Hub, extract the
 transaction id and check images from the Mitek database for checks that have
 been processed through the hosted environment. 
  
 Mitek stores check images in the database as binary BLOBs.  
 
 Six images are stored per transaction id, and are referenced by a numeric Imagetype.

 The Imagetypes are:
 	1 : Original color image in jpg format.  Front side of check.
 	2 : Original color image in jpg format.  Rear side of check.
 	3 : Gray-scale, cropped image, in jpg format.  Front side of check.
 	4 : Gray-scale, cropped image, in jpg format.  Rear side of check.
 	5 : Bitonal, cropped image, in tif format.  Front side of check.
 	6 : Bitonal, cropped image, in tif format.  Rear side of check.

 Check images are stored in a folder name "MitekImages" on the desktop of the
 user account that is running this script. 
 
 References:
 
 Connecting to SQL and storing query results in an array.
 http://simonhartcher.com/2009/08/13/howto-query-mssql-and-send-html-email-using-powershell/

 SQL Data Adapter Class 
 http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqldataadapter.aspx

 Exporting SQL BLOB to file:
 http://social.technet.microsoft.com/wiki/contents/articles/890.export-sql-server-blob-data-with-powershell.aspx
  
 Written By:
 Chris Boisse
  
 Version 1.0: 2-XX-2013
  
 To Do:
 
 1) Breakout logic into functions.
 
 2) Better handle multiple transaction id's being returned.  This should be a very rare
 	occurrence of a transaction being 
 
 2) Provide the ability to export transactions for customers who host their own
 IP Hub. User will need to input dollar amount, transaction time, and MICR line
 information.
  
# 	                                                                           #
###############################################################################>

function ConvertMICR ([string] $MICR)
<# Reformat MICR line for use in a SQL query using wildcard %'s.
Converts non-numeric characters to %'s.
Add % to front and back of string, and remove consecutive wildcards.
#>

	{
	$MICR = "%" + [regex]::Replace($MICR, "[^0-9]", "%") + "%";
	$MICR = [regex]::Replace($MICR, "%+", "%");
	
	return $MICR;
	}

$DatabaseServer = "prod-db1.dc.bluepoint.com"; #Name of SQL Server
$IPHubDatabase = "check21"; #Name of IPHub database
$MitekDatabase = "MobileDeposit"; #Name of Mitek Mobile Deposit database
$Uid = "sa"; #SQL login userid
$Pwd = "sa_bps1"; #SQL login password
$DestFolder = [Environment]::GetFolderPath("Desktop")+"\MitekImages\"; #Folder that images are saved to.
$BufferSize = 8192; #Buffer used for reading check images
$ECESequenceNum = "700529"; #ECE Sequence Number of item in IP Hub.
$TransactionId = "";  #Transaction ID 
$ScriptStatus = ""; #Stores the scripts status messages.

$ScriptStatus = "Server: " + $DatabaseServer + "`r`n";
$ScriptStatus = $ScriptStatus + "IPHub Database: " + $IPHubDatabase + "`r`n";
$ScriptStatus = $ScriptStatus + "Mitek Database: " + $MitekDatabase + "`r`n";
$ScriptStatus = $ScriptStatus + "Destination Folder: " + $DestFolder + "`r`n";
$ScriptStatus = $ScriptStatus + "ECE Sequence Number: " + $TransactionId + "`r`n";

# Check if Destination folder exists. Create it if it doesn't.
if(!(Test-Path -Path $DestFolder))
	{
	new-item -Path $DestFolder –itemtype directory
	}

<# *** Query IPHub by ECE Seq Num. Get ImageRcvdDate, Item Amount, and Raw Micr Line *** #>

$QueryItemInfoFromIPHub = "SELECT imagercvddate, itemamount, rawmicrline FROM MerchantPostedItems WHERE ItemRecID = {0}" -f $ECESequenceNum;

#Connection Object
$SqlConnection = New-Object System.Data.SqlClient.SqlConnection
$SqlConnection.ConnectionString="Server={0};Database={1};uid={2};pwd={3};Integrated Security=False" -f $DatabaseServer, $IPHubdatabase, $Uid, $Pwd

#Data Adapter which will gather the data using our query
$da = New-Object System.Data.SqlClient.SqlDataAdapter($QueryItemInfoFromIPHub, $SqlConnection)

#DataSet which will hold the data we have gathered
$ds = New-Object System.Data.DataSet

#Out-Null is used so the number of affected rows isn't printed
$da.Fill($ds) | Out-Null
#Close the database connection
$SQLConnection.Close()

#Get ImageRcvdDate from query results.
[datetime]$ImageRcvdDate = $ds.Tables[0].Rows[0][0]

$StartTime = Get-Date -Date $ImageRcvdDate.AddMinutes(-5) -Format "yyyy-MM-dd HH:mm:00"
$EndTime = Get-Date -Date $ImageRcvdDate.AddMinutes(5) -Format "yyyy-MM-dd HH:mm:00"

#Get ItemAmount from query results and convert to 2 decimal points
$ItemAmount = $ds.Tables[0].Rows[0][1].ToString("f2")

#Get MICR from query results, reformat with SQL wildcard %'s.  Add wildcard to front and back of string, and remove consecutive wildcards.
$MICR = $ds.Tables[0].Rows[0][2];
$MICR = "%" + [regex]::Replace($MICR, "[^0-9]", "%") + "%";
$MICR = [regex]::Replace($MICR, "%+", "%");

<#  *** Get TransactionID from Mitek Database using Item Information from Hub  *** #>


<# SQL Query to find the Transaction ID by:
	1) Get Transactions ID's from Transactions table using dollar amount and timestamp that IPHub received the image data.
	2) From this result set, search the ProcessingResults column for the MICR line that matches this item.
	
	For performance reasons, search for items that 
 #>

$QueryTransactionID="
declare @tmpTransactionIDTable table (TransactionID int);
declare @tmpTransactionDataTable table (TransactionID int, ProcessingResult text);
insert into @tmpTransactionIDTable (TransactionID)
select TransactionID from Transactions
where DT_Processed between '{0}' and '{1}' and Amount = '{2}'
insert into @tmpTransactionDataTable (TransactionID, ProcessingResult)
select b.TransactionID, ProcessingResult
from TransactionData a
inner join @tmpTransactionIDTable b
on a.TransactionID=b.TransactionID;
select * from @tmpTransactionDataTable
where ProcessingResult like '{3}';" -f $StartTime, $EndTime, $ItemAmount, $MICR

#Connection Object
$SqlConnection2 = New-Object System.Data.SqlClient.SqlConnection
$SqlConnection2.ConnectionString="Server={0};Database={1};uid={2};pwd={3};Integrated Security=False" -f $DatabaseServer, $MitekDatabase, $Uid, $Pwd

#Data Adapter which will gather the data using our query
$da2 = New-Object System.Data.SqlClient.SqlDataAdapter($QueryTransactionID, $SqlConnection2)

#DataSet which will hold the data we have gathered
$ds2 = New-Object System.Data.DataSet

#Out-Null is used so the number of affected rows isn't printed
$da2.Fill($ds2) | Out-Null
#Close the database connection
$SQLConnection2.Close()

#Get ImageRcvdDate from query results.
$TransactionId = $ds2.Tables[0].Rows[0][0]

<# ***  Pull Images From Mitek Server Based Using Transaction ID *** #>

# Open Connection to Mitek Database


$Connection = New-Object Data.SqlClient.SqlConnection; 
$Connection.ConnectionString="Server={0};Database={1};uid={2};pwd={3};Integrated Security=False" -f $DatabaseServer, $MitekDatabase, $Uid, $Pwd
$Connection.Open();


for ($ImageTypeCount=1; $ImageTypeCount -le 6; $ImageTypeCount++)
{
# Select-Statement for name & blob 
$SqlQueryToBlob = "SELECT ImageBlob FROM TransactionImages WHERE transactionid = '{0}' and Imagetype = '{1}'" -f $TransactionId, $ImageTypeCount;
Write-Host $SqlQueryToBlob

	switch ($ImageTypeCount)
			{
				1 {$Filename="TransID-{0}-OriginalImageFront.jpg" -f $TransactionId}
				2 {$Filename="TransID-{0}-OriginalImageRear.jpg" -f $TransactionId}
				3 {$Filename="TransID-{0}-CleanedUpImageFront.jpg" -f $TransactionId}
				4 {$Filename="TransID-{0}-CleanedUpImageRear.jpg" -f $TransactionId}
				5 {$Filename="TransID-{0}-BitonalImageFront.tif" -f $TransactionId}
				6 {$Filename="TransID-{0}-BitonalImageRear.tif" -f $TransactionId}
				default {$Filename="ErrorInPowerShellScript"}
			}

if(!(Test-Path -Path ($DestFolder+$TransactionID+"\")   ))
	{
	New-Item -Path ($DestFolder+$TransactionID+"\") -ItemType directory;
	}
	
#New-Item -Path ($DestFolder+$TransactionID+"\") -ItemType directory;
$Path=$DestFolder+$TransactionID+"\"+$Filename;

# New Command and Reader 
$cmd = New-Object Data.SqlClient.SqlCommand $SqlQueryToBlob, $Connection; 
$rd = $cmd.ExecuteReader(); 

# Create a byte array for the stream. 
$ImageBlobArray = [array]::CreateInstance('Byte', $BufferSize) 

# Looping through records 
	While ($rd.Read()) 
		{ 
		Write-Output ("Exporting: {0}" -f $Filename); 
		# New BinaryWriter 
		$fs = New-Object System.IO.FileStream ($Path), Create, Write;
		
		$bw = New-Object System.IO.BinaryWriter $fs; 
		$start = 0; 
		
		# Read first byte stream 
		$received = $rd.GetBytes(0, $start, $ImageBlobArray, 0, $BufferSize - 1);

		While ($received -gt 0)
				{
				$bw.Write($ImageBlobArray, 0, $received); 
				$bw.Flush(); 
				$start += $received; 

				# Read next byte stream 
				$received = $rd.GetBytes(0, $start, $ImageBlobArray, 0, $BufferSize - 1);
				}
	$bw.Close(); 
	$fs.Close(); 
		} # End while loop
# Closing & Disposing all objects 
$fs.Dispose(); 
$rd.Close(); 
$cmd.Dispose(); 

Write-Output ("Finished"); 

Write-Host $MICR
Write-Host $ItemAmount
Write-Host $StartTime
Write-Host $EndTime
Write-Host ""
Write-Host $QueryTransactionID
Write-Host ""
Write-Host $TransactionId
} # End For Loop

$Connection.Close();