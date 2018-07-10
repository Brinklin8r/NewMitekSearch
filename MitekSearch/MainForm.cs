/*##############################################################################
#
# Mitek Search:
#	This Program queries the Mitek Database (Main / SchoolsFirst) for Deposits
#   and displays the results for viewing and saving to the file structure.
#
# Coded By:
#	Chris Brinkley
#
# Inspired by the Poweshell Scripts created by Chris Boise
# * Extract Check Images from Mitek database -- ALPHA RELEASE.ps1
#
# Version:
#
#   2.0.0   - 12/29/2016 -  Refactoring Code
#                           Read from encrypted config File (BPConfigApp)
#                           Search Date Range added
#
#   1.2.0   - ##/##/#### -  NEVER RELEASED! 
#                           Is MySnap?
#                           re-Compile for .NET 4
#   1.1.0   - 04/26/2016 -  Adjusted button alignemnts and visuals
#                           Added Click prompt above Images
#                           Added Double Click show Images to row
#           - Doug          Increase size of window
#           - Katie         Validates Amount and Check Number text on change
#                           Opens Folder where images are saved.
#                           Double Click on ZoomWindow rotates image 90*
#                           TransactionInfo displays when images are displayed
#                           TransactionInfo is saved when images are saved
#	1.0.0 	- 04/21/2016 -	Initial Build.
#
##############################################################################*/

using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using ConfigurationSetttings;

namespace MitekSearch {
    public partial class MainForm : Form {
        enum appState {
            Initial,
            Connect,
            ConnectSF,
            Search,
            Images,
            ImageError
        }

        DBQueryClass.Connect dbClass = new DBQueryClass.Connect();
        string imageFilePath = "";
        ConfigSettings _confSet = new ConfigSettings();


        public MainForm() {
            InitializeComponent();
            setVisibility(appState.Initial);

            imageFilePath = _confSet.GetValue("ImageOutPath");
        }

        private void btnMainConnect_Click(object sender, EventArgs e) {
            lblResult.Text = dbClass.ConnectToDB("MobileDeposit");
            dgvResults.DataSource = null;
            setVisibility(appState.Connect);
            populateListBox();
        }

        private void btnConnectSF_Click(object sender, EventArgs e) {
            lblResult.Text = dbClass.ConnectToDB("MobileDepositSF");
            dgvResults.DataSource = null;
            setVisibility(appState.ConnectSF);
            populateListBox(true);
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            Cursor = Cursors.WaitCursor; // change cursor to hourglass type
            setVisibility(appState.Search);
            getTransactions();
            Cursor = Cursors.Arrow; // change cursor to normal type
        }

        private void btnGetImages_Click(object sender, EventArgs e) {

            //Get Transaction id from selected row
            if (dgvResults.SelectedRows.Count != 0) {
                int tranID = (int)(dgvResults.SelectedRows[0].Cells[0].Value);
                showImages(tranID);
                showInfo(tranID);
            } else {
                return;
            }

        }

        private void btnSaveImages_Click(object sender, EventArgs e) {

            if (!Directory.Exists(imageFilePath)) {
                Directory.CreateDirectory(imageFilePath);
            }

            // Get the Transaction ID from the file path.  It is the last folder
            string[] directories = imageFilePath.Split(Path.DirectorySeparatorChar);
            string tranID = directories[directories.Length - 1];

            pbImage1.Image.Save(
                imageFilePath + @"\" + tranID + @"-Original-Front.bmp",
                System.Drawing.Imaging.ImageFormat.Bmp);
            pbImage2.Image.Save(
                imageFilePath + @"\" + tranID + @"-Original-Back.bmp",
                System.Drawing.Imaging.ImageFormat.Bmp);
            pbImage3.Image.Save(
                imageFilePath + @"\" + tranID + @"-GreyScaleCleanedUP-Front.bmp",
                System.Drawing.Imaging.ImageFormat.Bmp);
            pbImage4.Image.Save(
                imageFilePath + @"\" + tranID + @"-GreyScaleCleanedUP-Back.bmp",
                System.Drawing.Imaging.ImageFormat.Bmp);
            pbImage5.Image.Save(
                imageFilePath + @"\" + tranID + @"-Bitonal-Back.bmp",
                System.Drawing.Imaging.ImageFormat.Bmp);
            pbImage6.Image.Save(
                imageFilePath + @"\" + tranID + @"-Bitonal-Back.bmp",
                System.Drawing.Imaging.ImageFormat.Bmp);



            saveMitekInfo(dgvInfo);
            saveMitekInfo(dgvIQAFront);
            saveMitekInfo(dgvIQABack);
            //saveMitekInfo(dgvResultsFront);
            //saveMitekInfo(dgvResultsBack);

            lblResult.Text = "Images saved to " + imageFilePath;

            // Open Folder Images are saved into.
            Process.Start(imageFilePath);

        }

        private void tbAmount_TextChanged(object sender, EventArgs e) {
            double _dTemp = 0.0;

            // If not valid reset to Inital Text
            if (!double.TryParse(tbAmount.Text, out _dTemp)) {
                tbAmount.Text = "Amount:";
            }
            setVisibility(appState.Search);
        }

        private void tbCheckNumber_TextChanged(object sender, EventArgs e) {
            int _iTemp = 0;

            // If not valid reset to Inital Text
            if (!int.TryParse(tbCheckNumber.Text, out _iTemp)) {
                tbCheckNumber.Text = "Check Number:";
            }
            setVisibility(appState.Search);
        }

        private void pbImage_Click(object sender, EventArgs e) {
            PictureBox _temp = new PictureBox();
            _temp = (PictureBox)sender;
            showImageForm(_temp.Image);
        }

        private void saveMitekInfo(DataGridView dgv) {
            //Build the CSV file data as a Comma separated string.
            string csv = string.Empty;

            ////Add the Header row for CSV file.
            //foreach (DataGridViewColumn column in dgv.Columns) {
            //    csv += column.HeaderText + ',';
            //}

            ////Add new line.
            //csv += "\r\n";

            //Adding the Rows
            foreach (DataGridViewRow row in dgv.Rows) {
                foreach (DataGridViewCell cell in row.Cells) {
                    //Add the Data rows.
                    csv += cell.Value.ToString().Replace(",", ";") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }
            //Exporting to CSV.
            File.WriteAllText(imageFilePath + @"\" + dgv.Name.ToString() + @".csv", csv);
        }

        private void showImageForm(Image _image) {
            Form NewConfig = new ImageZoom();
            NewConfig.BackgroundImage = _image;
            NewConfig.ShowDialog();
        }

        private void populateListBox(bool SchoolsFirst = false) {
            cbOrgName.Items.Clear();
            cbOrgName.Text = "Please Select ...";

            if (SchoolsFirst) {
                cbOrgName.Text = "SchoolsFirst FCU";
            } else {
                string sqlCommandString = @"SELECT distinct OrganizationName" +
                    @" FROM Transactions order by OrganizationName";
                SqlCommand cmd = new SqlCommand(
                    sqlCommandString,
                    dbClass.GetSQLConn());
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    cbOrgName.Items.Add(dr[0].ToString());
                }
                dr.Close();
            }
        }

        private void setVisibility(appState currentState) {

            switch (currentState) {
                case appState.Initial:
                    // All off except Connection Buttons and DataGrid
                    btnConnectMain.Enabled = true;
                    btnConnectSF.Enabled = true;

                    btnBack.Visible = false;
                    dtFrom.Enabled = false;
                    btnCopyDate.Enabled = false;
                    dtTo.Enabled = false;
                    tbAmount.Enabled = false;
                    tbCheckNumber.Enabled = false;
                    cbOrgName.Enabled = false;

                    btnSearch.Enabled = false;
                    btnGetImages.Enabled = false;
                    btnSaveImages.Enabled = false;

                    dgvResults.Visible = true;
                    tbResults.Visible = false;
                    pbImage1.Visible = false;
                    pbImage2.Visible = false;
                    pbImage3.Visible = false;
                    pbImage4.Visible = false;
                    pbImage5.Visible = false;
                    pbImage6.Visible = false;
                    rbMySnap.Visible = false;

                    dgvInfo.Visible = false;
                    tcMitekDGV.Visible = false;

                    lblImage.Visible = false;

                    break;
                case appState.Connect:
                    // Conencted to DB, Enable Search and Criteria
                    btnBack.Visible = false;
                    btnConnectMain.Enabled = false;
                    btnConnectSF.Enabled = true;
                    goto ConnectContinue;

                case appState.ConnectSF:
                    btnBack.Visible = false;
                    btnConnectMain.Enabled = true;
                    btnConnectSF.Enabled = false;

                ConnectContinue:
                    dtFrom.Enabled = true;
                    btnCopyDate.Enabled = true;
                    dtTo.Enabled = true;
                    tbAmount.Enabled = true;
                    tbCheckNumber.Enabled = true;
                    cbOrgName.Enabled = true;

                    btnSearch.Enabled = true;
                    btnGetImages.Enabled = false;
                    btnSaveImages.Enabled = false;

                    dgvResults.Visible = true;
                    tbResults.Visible = false;
                    pbImage1.Visible = false;
                    pbImage2.Visible = false;
                    pbImage3.Visible = false;
                    pbImage4.Visible = false;
                    pbImage5.Visible = false;
                    pbImage6.Visible = false;
                    rbMySnap.Visible = false;

                    dgvInfo.Visible = false;
                    tcMitekDGV.Visible = false;

                    lblImage.Visible = false;

                    break;
                case appState.Search:
                    // Search Complete, enable GetImages btn
                    dtFrom.Enabled = true;
                    btnCopyDate.Enabled = true;
                    dtTo.Enabled = true;
                    tbAmount.Enabled = true;
                    tbCheckNumber.Enabled = true;
                    cbOrgName.Enabled = true;

                    btnBack.Visible = false;
                    btnSearch.Enabled = true;
                    btnGetImages.Enabled = true;
                    btnSaveImages.Enabled = false;

                    dgvResults.Visible = true;
                    tbResults.Visible = false;
                    pbImage1.Visible = false;
                    pbImage2.Visible = false;
                    pbImage3.Visible = false;
                    pbImage4.Visible = false;
                    pbImage5.Visible = false;
                    pbImage6.Visible = false;
                    rbMySnap.Visible = false;

                    dgvInfo.Visible = false;
                    tcMitekDGV.Visible = false;

                    lblImage.Visible = false;

                    break;
                case appState.Images:
                    // Show Images and enable SaveImages btn
                    btnBack.Visible = true;
                    dtFrom.Enabled = true;
                    btnCopyDate.Enabled = true;
                    dtTo.Enabled = true;
                    tbAmount.Enabled = true;
                    tbCheckNumber.Enabled = true;
                    cbOrgName.Enabled = true;

                    btnSearch.Enabled = true;
                    btnGetImages.Enabled = false;
                    btnSaveImages.Enabled = true;

                    dgvResults.Visible = false;
                    tbResults.Visible = false;
                    pbImage1.Visible = true;
                    pbImage2.Visible = true;
                    pbImage3.Visible = true;
                    pbImage4.Visible = true;
                    pbImage5.Visible = true;
                    pbImage6.Visible = true;
                    rbMySnap.Visible = true;

                    dgvInfo.Visible = true;
                    tcMitekDGV.Visible = true;
                    tcMitekDGV.SelectedTab = tabResults;

                    lblImage.Visible = true;

                    break;
                case appState.ImageError:
                    // No Images
                    dtFrom.Enabled = true;
                    btnCopyDate.Enabled = true;
                    dtTo.Enabled = true;
                    tbAmount.Enabled = true;
                    tbCheckNumber.Enabled = true;
                    cbOrgName.Enabled = true;

                    btnSearch.Enabled = true;
                    btnGetImages.Enabled = false;
                    btnSaveImages.Enabled = false;

                    dgvResults.Visible = false;
                    tbResults.Visible = true;
                    pbImage1.Visible = false;
                    pbImage2.Visible = false;
                    pbImage3.Visible = false;
                    pbImage4.Visible = false;
                    pbImage5.Visible = false;
                    pbImage6.Visible = false;
                    rbMySnap.Visible = false;

                    dgvInfo.Visible = false;
                    tcMitekDGV.Visible = false;

                    lblImage.Visible = false;

                    break;
                default:
                    break;
            }

        }

        private void showImages(int tranID) {
            string sqlCommandString = @"SELECT ImageBlob,ImageType" +
            @" FROM TransactionImages" +
            @" WHERE TransactionID = @tranID";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                new SqlCommand(sqlCommandString, dbClass.GetSQLConn()));
            dataAdapter.SelectCommand.Parameters.AddWithValue(
                "@tranID",
                tranID.ToString());

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            lblResult.Text = "Images for TransactionID:  " + tranID.ToString();

            imageFilePath += @"\MitekImages\" + tranID.ToString();

            if (dataSet.Tables[0].Rows.Count == 6) {
                setVisibility(appState.Images);

                Byte[] data = new Byte[0];
                data = (Byte[])(dataSet.Tables[0].Rows[0]["ImageBlob"]);
                MemoryStream mem = new MemoryStream(data);
                pbImage1.Image = Image.FromStream(mem);

                data = (Byte[])(dataSet.Tables[0].Rows[1]["ImageBlob"]);
                mem = new MemoryStream(data);
                pbImage2.Image = Image.FromStream(mem);

                data = (Byte[])(dataSet.Tables[0].Rows[2]["ImageBlob"]);
                mem = new MemoryStream(data);
                pbImage3.Image = Image.FromStream(mem);

                data = (Byte[])(dataSet.Tables[0].Rows[3]["ImageBlob"]);
                mem = new MemoryStream(data);
                pbImage4.Image = Image.FromStream(mem);

                data = (Byte[])(dataSet.Tables[0].Rows[4]["ImageBlob"]);
                mem = new MemoryStream(data);
                pbImage5.Image = Image.FromStream(mem);

                data = (Byte[])(dataSet.Tables[0].Rows[5]["ImageBlob"]);
                mem = new MemoryStream(data);
                pbImage6.Image = Image.FromStream(mem);

                checkMySnap(tranID);

            } else {
                setVisibility(appState.ImageError);
            }
        }

        private void checkMySnap(int tranID) {
            bool _isMySnap = false;
            string sqlCommandString = @"SELECT [MiSnapInfoFront] " +
                @"FROM [TransactionData] " +
                @"WHERE [MiSnapInfoFront] like 'ascii{%' and " +
                @"[MiSnapInfoRear] like 'ascii{%' and " +
                @"TransactionID  = @tranID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                new SqlCommand(sqlCommandString, dbClass.GetSQLConn()));
            dataAdapter.SelectCommand.Parameters.AddWithValue(
                "@tranID",
                tranID.ToString());

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count != 0) _isMySnap = true;
            rbMySnap.Checked = _isMySnap;
            rbMySnap.Enabled = _isMySnap;
            rbMySnap.TabIndex = tranID;
        }

        private void showInfo(int tranID) {
            string _tranInfo = "";

            string sqlCommandString = @"SELECT ProcessingResult" +
            @" FROM TransactionData" +
            @" WHERE TransactionID = @tranID";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                new SqlCommand(sqlCommandString, dbClass.GetSQLConn()));
            dataAdapter.SelectCommand.Parameters.AddWithValue(
                "@tranID",
                tranID.ToString());

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet,"TranInfo");
            _tranInfo = 
                dataSet.Tables["TranInfo"].Rows[0].ItemArray[0].ToString();
            XDocument _xmlTranInfo = XDocument.Parse(_tranInfo);

            var _xmls = _xmlTranInfo.Root.Elements().ToArray(); // split into elements

            XmlReader _xmlResults = _xmlTranInfo.CreateReader();
            XmlReader _xmlIQAFront = _xmls[1].CreateReader();
            XmlReader _xmlIQABack = _xmls[2].CreateReader();
            //XmlReader _xmlIQAResultsFront = _xmls[3].CreateReader();
            //XmlReader _xmlIQAResultsBack = _xmls[4].CreateReader();

            setMitekInfo(_xmlResults, dgvInfo);
            setMitekInfo(_xmlIQAFront, dgvIQAFront);
            setMitekInfo(_xmlIQABack, dgvIQABack);
            //setMitekInfo(_xmlIQAResultsFront, dgvResultsFront);
            //setMitekInfo(_xmlIQAResultsBack, dgvResultsBack);



        }

        private void setMitekInfo(XmlReader xmlReader, DataGridView dgv) {

            DataSet ds = new DataSet();
            ds.ReadXml(xmlReader);
            ds = flipDS(ds);
            dgv.DataSource = ds.Tables[0];
        }

        private DataSet flipDS(DataSet my_DataSet) {
            DataSet ds = new DataSet();

            foreach (DataTable dt in my_DataSet.Tables) {
                DataTable table = new DataTable();

                for (int i = 0; i <= dt.Rows.Count; i++) {
                    table.Columns.Add(Convert.ToString(i));
                }

                DataRow r;
                for (int k = 0; k < dt.Columns.Count; k++) {
                    r = table.NewRow();
                    r[0] = dt.Columns[k].ToString();
                    for (int j = 1; j <= dt.Rows.Count; j++) { r[j] = dt.Rows[j - 1][k]; }
                    table.Rows.Add(r);
                }
                ds.Tables.Add(table);
            }

            return ds;

        }

        private void getTransactions() {
            string _sqlCommandString = @"SELECT TransactionID, DT_Submitted," +
                " cast(Amount as decimal(9,2)) as Amount, RoutingNumber," +
                " AccountNumber, CheckNumber, OrganizationName" +
                " FROM Transactions" +
                " WHERE DT_Submitted BETWEEN cast(@whereFromDate as datetime) AND " +
                " dateadd(day,1,cast(@whereToDate as datetime))";

            string _whereFromDate = dtFrom.Value.ToString("yyyy-MM-dd");
            string _whereToDate = dtTo.Value.ToString("yyyy-MM-dd");
            string _whereAmount = tbAmount.Text;
            string _whereCheckNumber = tbCheckNumber.Text;
            string _whereOrgName = "";
            try {
                _whereOrgName = cbOrgName.SelectedItem.ToString();
            } catch {

            }

            double _dTemp = 0.0;
            int _iTemp = 0;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                _sqlCommandString,
                dbClass.GetSQLConn());
            dataAdapter.SelectCommand.Parameters.AddWithValue(
                "@whereFromDate",
                _whereFromDate);
            dataAdapter.SelectCommand.Parameters.AddWithValue(
                "@whereToDate",
                _whereToDate);

            if (double.TryParse(_whereAmount, out _dTemp)) {
                dataAdapter.SelectCommand.CommandText +=
                    @" and amount = @whereAmount";
                dataAdapter.SelectCommand.Parameters.AddWithValue(
                    "@whereAmount",
                    _whereAmount);
            }
            if (int.TryParse(_whereCheckNumber, out _iTemp)) {
                dataAdapter.SelectCommand.CommandText +=
                    @" and CheckNumber like concat('%', @whereCheckNumber)";
                dataAdapter.SelectCommand.Parameters.AddWithValue(
                    "@whereCheckNumber",
                    _whereCheckNumber);
            }
            if (_whereOrgName != "") {
                dataAdapter.SelectCommand.CommandText +=
                    @" and OrganizationName = @whereOrgName";
                dataAdapter.SelectCommand.Parameters.AddWithValue(
                    "@whereOrgName",
                    _whereOrgName);
            }
            dataAdapter.SelectCommand.CommandText += " ORDER BY TransactionID";

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Transactions");
            dgvResults.DataSource = dataSet.Tables["Transactions"];

            lblResult.Text = "Matched Transactions:  " +
                dataSet.Tables["Transactions"].Rows.Count.ToString();

        }

        private void rbMySnap_Click(object sender, EventArgs e) {
            string sqlCommandString = @"SELECT [MiSnapInfoFront] , [MiSnapInfoRear]" +
               @"FROM [TransactionData] " +
               @"WHERE [MiSnapInfoFront] like 'ascii{%' and " +
               @"[MiSnapInfoRear] like 'ascii{%' and " +
               @"TransactionID  = @tranID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                new SqlCommand(sqlCommandString, dbClass.GetSQLConn()));
            dataAdapter.SelectCommand.Parameters.AddWithValue(
                "@tranID",
                rbMySnap.TabIndex.ToString());

            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            string msFront = dataSet.Tables[0].Rows[0]["MiSnapInfoFront"].ToString();
            string msBack = dataSet.Tables[0].Rows[0]["MiSnapInfoRear"].ToString();

            Form _MiSnapInfoForm = new MiSnapInfo(msFront, msBack);
            _MiSnapInfoForm.ShowDialog();
        }

        private void pbLogo_Click(object sender, EventArgs e) {

        }

        private void btnCopyDate_Click(object sender, EventArgs e) {
            dtTo.Value = dtFrom.Value;
        }

        private void btnBack_Click(object sender, EventArgs e) {
            setVisibility(appState.Search);
        }

        private void cbOrgName_SelectionChangeCommitted(object sender, EventArgs e) {
            setVisibility(appState.Search);
        }
    }
}                      
