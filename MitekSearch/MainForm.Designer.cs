namespace MitekSearch
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnConnectMain = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.tbCheckNumber = new System.Windows.Forms.TextBox();
            this.pbImage1 = new System.Windows.Forms.PictureBox();
            this.pbImage2 = new System.Windows.Forms.PictureBox();
            this.pbImage3 = new System.Windows.Forms.PictureBox();
            this.pbImage4 = new System.Windows.Forms.PictureBox();
            this.pbImage5 = new System.Windows.Forms.PictureBox();
            this.pbImage6 = new System.Windows.Forms.PictureBox();
            this.btnGetImages = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnSaveImages = new System.Windows.Forms.Button();
            this.btnConnectSF = new System.Windows.Forms.Button();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.cbOrgName = new System.Windows.Forms.ComboBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.dgvInfo = new System.Windows.Forms.DataGridView();
            this.tcMitekDGV = new System.Windows.Forms.TabControl();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.tabIQAFront = new System.Windows.Forms.TabPage();
            this.dgvIQAFront = new System.Windows.Forms.DataGridView();
            this.tabIQABack = new System.Windows.Forms.TabPage();
            this.dgvIQABack = new System.Windows.Forms.DataGridView();
            this.rbMySnap = new System.Windows.Forms.RadioButton();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnCopyDate = new System.Windows.Forms.Button();
            this.lblToDate = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).BeginInit();
            this.tcMitekDGV.SuspendLayout();
            this.tabResults.SuspendLayout();
            this.tabIQAFront.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIQAFront)).BeginInit();
            this.tabIQABack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIQABack)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnectMain
            // 
            this.btnConnectMain.Location = new System.Drawing.Point(10, 10);
            this.btnConnectMain.Name = "btnConnectMain";
            this.btnConnectMain.Size = new System.Drawing.Size(140, 50);
            this.btnConnectMain.TabIndex = 0;
            this.btnConnectMain.Text = "Connect to Main";
            this.btnConnectMain.UseVisualStyleBackColor = true;
            this.btnConnectMain.Click += new System.EventHandler(this.btnMainConnect_Click);
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(6, 556);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 1;
            // 
            // dtFrom
            // 
            this.dtFrom.Enabled = false;
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(180, 18);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(95, 20);
            this.dtFrom.TabIndex = 2;
            // 
            // tbAmount
            // 
            this.tbAmount.Enabled = false;
            this.tbAmount.Location = new System.Drawing.Point(180, 44);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(225, 20);
            this.tbAmount.TabIndex = 3;
            this.tbAmount.Text = "Amount:";
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            // 
            // tbCheckNumber
            // 
            this.tbCheckNumber.Enabled = false;
            this.tbCheckNumber.Location = new System.Drawing.Point(180, 69);
            this.tbCheckNumber.Name = "tbCheckNumber";
            this.tbCheckNumber.Size = new System.Drawing.Size(225, 20);
            this.tbCheckNumber.TabIndex = 4;
            this.tbCheckNumber.Text = "Check Number:";
            this.tbCheckNumber.TextChanged += new System.EventHandler(this.tbCheckNumber_TextChanged);
            // 
            // pbImage1
            // 
            this.pbImage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage1.Location = new System.Drawing.Point(10, 140);
            this.pbImage1.Name = "pbImage1";
            this.pbImage1.Size = new System.Drawing.Size(280, 135);
            this.pbImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage1.TabIndex = 5;
            this.pbImage1.TabStop = false;
            this.pbImage1.Visible = false;
            this.pbImage1.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // pbImage2
            // 
            this.pbImage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage2.Location = new System.Drawing.Point(295, 140);
            this.pbImage2.Name = "pbImage2";
            this.pbImage2.Size = new System.Drawing.Size(280, 135);
            this.pbImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage2.TabIndex = 6;
            this.pbImage2.TabStop = false;
            this.pbImage2.Visible = false;
            this.pbImage2.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // pbImage3
            // 
            this.pbImage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage3.Location = new System.Drawing.Point(10, 280);
            this.pbImage3.Name = "pbImage3";
            this.pbImage3.Size = new System.Drawing.Size(280, 135);
            this.pbImage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage3.TabIndex = 7;
            this.pbImage3.TabStop = false;
            this.pbImage3.Visible = false;
            this.pbImage3.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // pbImage4
            // 
            this.pbImage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage4.Location = new System.Drawing.Point(295, 280);
            this.pbImage4.Name = "pbImage4";
            this.pbImage4.Size = new System.Drawing.Size(280, 135);
            this.pbImage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage4.TabIndex = 8;
            this.pbImage4.TabStop = false;
            this.pbImage4.Visible = false;
            this.pbImage4.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // pbImage5
            // 
            this.pbImage5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage5.Location = new System.Drawing.Point(10, 420);
            this.pbImage5.Name = "pbImage5";
            this.pbImage5.Size = new System.Drawing.Size(280, 135);
            this.pbImage5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage5.TabIndex = 9;
            this.pbImage5.TabStop = false;
            this.pbImage5.Visible = false;
            this.pbImage5.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // pbImage6
            // 
            this.pbImage6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage6.Location = new System.Drawing.Point(295, 420);
            this.pbImage6.Name = "pbImage6";
            this.pbImage6.Size = new System.Drawing.Size(280, 135);
            this.pbImage6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage6.TabIndex = 10;
            this.pbImage6.TabStop = false;
            this.pbImage6.Visible = false;
            this.pbImage6.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // btnGetImages
            // 
            this.btnGetImages.Enabled = false;
            this.btnGetImages.Location = new System.Drawing.Point(435, 47);
            this.btnGetImages.Name = "btnGetImages";
            this.btnGetImages.Size = new System.Drawing.Size(140, 31);
            this.btnGetImages.TabIndex = 11;
            this.btnGetImages.Text = "Get Images";
            this.btnGetImages.UseVisualStyleBackColor = true;
            this.btnGetImages.Click += new System.EventHandler(this.btnGetImages_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(435, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(140, 31);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search Mitek";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(10, 140);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(813, 415);
            this.dgvResults.TabIndex = 13;
            this.dgvResults.DoubleClick += new System.EventHandler(this.btnGetImages_Click);
            // 
            // btnSaveImages
            // 
            this.btnSaveImages.Enabled = false;
            this.btnSaveImages.Location = new System.Drawing.Point(435, 84);
            this.btnSaveImages.Name = "btnSaveImages";
            this.btnSaveImages.Size = new System.Drawing.Size(140, 31);
            this.btnSaveImages.TabIndex = 15;
            this.btnSaveImages.Text = "Save Images and Info";
            this.btnSaveImages.UseVisualStyleBackColor = true;
            this.btnSaveImages.Click += new System.EventHandler(this.btnSaveImages_Click);
            // 
            // btnConnectSF
            // 
            this.btnConnectSF.Location = new System.Drawing.Point(10, 65);
            this.btnConnectSF.Name = "btnConnectSF";
            this.btnConnectSF.Size = new System.Drawing.Size(140, 50);
            this.btnConnectSF.TabIndex = 16;
            this.btnConnectSF.Text = "Connect to SchoolsFirst";
            this.btnConnectSF.UseVisualStyleBackColor = true;
            this.btnConnectSF.Click += new System.EventHandler(this.btnConnectSF_Click);
            // 
            // tbResults
            // 
            this.tbResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbResults.Location = new System.Drawing.Point(10, 140);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ReadOnly = true;
            this.tbResults.Size = new System.Drawing.Size(565, 415);
            this.tbResults.TabIndex = 17;
            this.tbResults.Text = "No Images Found";
            this.tbResults.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbResults.Visible = false;
            // 
            // cbOrgName
            // 
            this.cbOrgName.Enabled = false;
            this.cbOrgName.FormattingEnabled = true;
            this.cbOrgName.Location = new System.Drawing.Point(180, 94);
            this.cbOrgName.Name = "cbOrgName";
            this.cbOrgName.Size = new System.Drawing.Size(225, 21);
            this.cbOrgName.TabIndex = 18;
            this.cbOrgName.Text = "Please Select ...";
            this.cbOrgName.SelectionChangeCommitted += new System.EventHandler(this.cbOrgName_SelectionChangeCommitted);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.ForeColor = System.Drawing.Color.Black;
            this.lblFromDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFromDate.Location = new System.Drawing.Point(177, 4);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(62, 14);
            this.lblFromDate.TabIndex = 19;
            this.lblFromDate.Text = "From Date:";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImage.Location = new System.Drawing.Point(170, 120);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(247, 16);
            this.lblImage.TabIndex = 20;
            this.lblImage.Text = "Click on an Image below to view it larger.";
            this.lblImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLogo
            // 
            this.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(600, 10);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(223, 105);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 21;
            this.pbLogo.TabStop = false;
            // 
            // dgvInfo
            // 
            this.dgvInfo.AllowUserToAddRows = false;
            this.dgvInfo.AllowUserToDeleteRows = false;
            this.dgvInfo.AllowUserToResizeRows = false;
            this.dgvInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgvInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvInfo.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInfo.ColumnHeadersVisible = false;
            this.dgvInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvInfo.MultiSelect = false;
            this.dgvInfo.Name = "dgvInfo";
            this.dgvInfo.ReadOnly = true;
            this.dgvInfo.RowHeadersVisible = false;
            this.dgvInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInfo.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvInfo.Size = new System.Drawing.Size(243, 414);
            this.dgvInfo.TabIndex = 22;
            // 
            // tcMitekDGV
            // 
            this.tcMitekDGV.Controls.Add(this.tabResults);
            this.tcMitekDGV.Controls.Add(this.tabIQAFront);
            this.tcMitekDGV.Controls.Add(this.tabIQABack);
            this.tcMitekDGV.Location = new System.Drawing.Point(581, 120);
            this.tcMitekDGV.Name = "tcMitekDGV";
            this.tcMitekDGV.SelectedIndex = 0;
            this.tcMitekDGV.Size = new System.Drawing.Size(251, 440);
            this.tcMitekDGV.TabIndex = 23;
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.dgvInfo);
            this.tabResults.Location = new System.Drawing.Point(4, 22);
            this.tabResults.Margin = new System.Windows.Forms.Padding(0);
            this.tabResults.Name = "tabResults";
            this.tabResults.Size = new System.Drawing.Size(243, 414);
            this.tabResults.TabIndex = 0;
            this.tabResults.Text = "Mitek Results";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // tabIQAFront
            // 
            this.tabIQAFront.Controls.Add(this.dgvIQAFront);
            this.tabIQAFront.Location = new System.Drawing.Point(4, 22);
            this.tabIQAFront.Name = "tabIQAFront";
            this.tabIQAFront.Size = new System.Drawing.Size(243, 414);
            this.tabIQAFront.TabIndex = 1;
            this.tabIQAFront.Text = "IQA Front";
            this.tabIQAFront.UseVisualStyleBackColor = true;
            // 
            // dgvIQAFront
            // 
            this.dgvIQAFront.AllowUserToAddRows = false;
            this.dgvIQAFront.AllowUserToDeleteRows = false;
            this.dgvIQAFront.AllowUserToResizeRows = false;
            this.dgvIQAFront.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgvIQAFront.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvIQAFront.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvIQAFront.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvIQAFront.ColumnHeadersVisible = false;
            this.dgvIQAFront.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvIQAFront.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIQAFront.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIQAFront.Location = new System.Drawing.Point(0, 0);
            this.dgvIQAFront.MultiSelect = false;
            this.dgvIQAFront.Name = "dgvIQAFront";
            this.dgvIQAFront.ReadOnly = true;
            this.dgvIQAFront.RowHeadersVisible = false;
            this.dgvIQAFront.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvIQAFront.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvIQAFront.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvIQAFront.Size = new System.Drawing.Size(243, 414);
            this.dgvIQAFront.TabIndex = 23;
            // 
            // tabIQABack
            // 
            this.tabIQABack.Controls.Add(this.dgvIQABack);
            this.tabIQABack.Location = new System.Drawing.Point(4, 22);
            this.tabIQABack.Name = "tabIQABack";
            this.tabIQABack.Size = new System.Drawing.Size(243, 414);
            this.tabIQABack.TabIndex = 2;
            this.tabIQABack.Text = "IQA Back";
            this.tabIQABack.UseVisualStyleBackColor = true;
            // 
            // dgvIQABack
            // 
            this.dgvIQABack.AllowUserToAddRows = false;
            this.dgvIQABack.AllowUserToDeleteRows = false;
            this.dgvIQABack.AllowUserToResizeRows = false;
            this.dgvIQABack.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgvIQABack.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvIQABack.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvIQABack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvIQABack.ColumnHeadersVisible = false;
            this.dgvIQABack.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvIQABack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIQABack.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIQABack.Location = new System.Drawing.Point(0, 0);
            this.dgvIQABack.MultiSelect = false;
            this.dgvIQABack.Name = "dgvIQABack";
            this.dgvIQABack.ReadOnly = true;
            this.dgvIQABack.RowHeadersVisible = false;
            this.dgvIQABack.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvIQABack.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvIQABack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvIQABack.Size = new System.Drawing.Size(243, 414);
            this.dgvIQABack.TabIndex = 24;
            // 
            // rbMySnap
            // 
            this.rbMySnap.AutoSize = true;
            this.rbMySnap.Enabled = false;
            this.rbMySnap.Location = new System.Drawing.Point(446, 120);
            this.rbMySnap.Name = "rbMySnap";
            this.rbMySnap.Size = new System.Drawing.Size(129, 17);
            this.rbMySnap.TabIndex = 24;
            this.rbMySnap.TabStop = true;
            this.rbMySnap.Text = "MiSnap Transaction? ";
            this.rbMySnap.UseVisualStyleBackColor = true;
            this.rbMySnap.Click += new System.EventHandler(this.rbMySnap_Click);
            // 
            // dtTo
            // 
            this.dtTo.Enabled = false;
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(310, 18);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(95, 20);
            this.dtTo.TabIndex = 25;
            // 
            // btnCopyDate
            // 
            this.btnCopyDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyDate.Location = new System.Drawing.Point(281, 18);
            this.btnCopyDate.Name = "btnCopyDate";
            this.btnCopyDate.Size = new System.Drawing.Size(23, 20);
            this.btnCopyDate.TabIndex = 26;
            this.btnCopyDate.Text = ">";
            this.btnCopyDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCopyDate.UseVisualStyleBackColor = true;
            this.btnCopyDate.Click += new System.EventHandler(this.btnCopyDate_Click);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.Black;
            this.lblToDate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblToDate.Location = new System.Drawing.Point(310, 4);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(47, 14);
            this.lblToDate.TabIndex = 27;
            this.lblToDate.Text = "To Date:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(435, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 31);
            this.btnBack.TabIndex = 28;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 572);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.btnCopyDate);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.rbMySnap);
            this.Controls.Add(this.tcMitekDGV);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.cbOrgName);
            this.Controls.Add(this.btnConnectSF);
            this.Controls.Add(this.btnSaveImages);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnGetImages);
            this.Controls.Add(this.tbCheckNumber);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnConnectMain);
            this.Controls.Add(this.pbImage2);
            this.Controls.Add(this.pbImage3);
            this.Controls.Add(this.pbImage4);
            this.Controls.Add(this.pbImage5);
            this.Controls.Add(this.pbImage6);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.pbImage1);
            this.Controls.Add(this.tbResults);
            this.Controls.Add(this.dgvResults);
            this.MaximumSize = new System.Drawing.Size(850, 611);
            this.MinimumSize = new System.Drawing.Size(850, 611);
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.Text = "Mitek Transaction Search";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInfo)).EndInit();
            this.tcMitekDGV.ResumeLayout(false);
            this.tabResults.ResumeLayout(false);
            this.tabIQAFront.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIQAFront)).EndInit();
            this.tabIQABack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIQABack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnectMain;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.TextBox tbCheckNumber;
        private System.Windows.Forms.PictureBox pbImage1;
        private System.Windows.Forms.PictureBox pbImage2;
        private System.Windows.Forms.PictureBox pbImage3;
        private System.Windows.Forms.PictureBox pbImage4;
        private System.Windows.Forms.PictureBox pbImage5;
        private System.Windows.Forms.PictureBox pbImage6;
        private System.Windows.Forms.Button btnGetImages;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.Button btnSaveImages;
        private System.Windows.Forms.Button btnConnectSF;
        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.ComboBox cbOrgName;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.DataGridView dgvInfo;
        private System.Windows.Forms.TabControl tcMitekDGV;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.TabPage tabIQAFront;
        private System.Windows.Forms.DataGridView dgvIQAFront;
        private System.Windows.Forms.TabPage tabIQABack;
        private System.Windows.Forms.DataGridView dgvIQABack;
        //private System.Windows.Forms.TabPage tabResultsFront;
        //private System.Windows.Forms.TabPage tabResultsBack;
        //private System.Windows.Forms.DataGridView dgvResultsFront;
        //private System.Windows.Forms.DataGridView dgvResultsBack;
        private System.Windows.Forms.RadioButton rbMySnap;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnCopyDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Button btnBack;
    }
}

