namespace ProjectDrivingLicenseManagementSystem
{
    partial class frmListLocalDrivingLicenseApplication
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListLocalDrivingLicenseApplication));
            this.label2 = new System.Windows.Forms.Label();
            this.cbManageLAppFilterTypes = new System.Windows.Forms.ComboBox();
            this.cbStatusFilterType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.dgvManageLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonHistoryLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbManageLocalDrivingLicenseApplications = new System.Windows.Forms.PictureBox();
            this.btnAddNewLocalDVApp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtFilterSerach = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageLocalDrivingLicenseApplications)).BeginInit();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageLocalDrivingLicenseApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(341, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 23);
            this.label2.TabIndex = 35;
            this.label2.Text = "Local Driving License Applications";
            // 
            // cbManageLAppFilterTypes
            // 
            this.cbManageLAppFilterTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManageLAppFilterTypes.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManageLAppFilterTypes.FormattingEnabled = true;
            this.cbManageLAppFilterTypes.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No",
            "Full Name",
            "Status"});
            this.cbManageLAppFilterTypes.Location = new System.Drawing.Point(89, 253);
            this.cbManageLAppFilterTypes.Name = "cbManageLAppFilterTypes";
            this.cbManageLAppFilterTypes.Size = new System.Drawing.Size(196, 26);
            this.cbManageLAppFilterTypes.TabIndex = 31;
            this.cbManageLAppFilterTypes.SelectedIndexChanged += new System.EventHandler(this.cbManageLAppFilterTypes_SelectedIndexChanged);
            // 
            // cbStatusFilterType
            // 
            this.cbStatusFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusFilterType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatusFilterType.FormattingEnabled = true;
            this.cbStatusFilterType.Items.AddRange(new object[] {
            "New",
            "Canceled",
            "Completed"});
            this.cbStatusFilterType.Location = new System.Drawing.Point(312, 252);
            this.cbStatusFilterType.Name = "cbStatusFilterType";
            this.cbStatusFilterType.Size = new System.Drawing.Size(136, 27);
            this.cbStatusFilterType.TabIndex = 32;
            this.cbStatusFilterType.Visible = false;
            this.cbStatusFilterType.SelectedIndexChanged += new System.EventHandler(this.cbStatusFilterType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Italic);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(1, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 29;
            this.label1.Text = "Filter By : ";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(118, 536);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(21, 22);
            this.lblNumberOfRecords.TabIndex = 28;
            this.lblNumberOfRecords.Text = "0";
            // 
            // dgvManageLocalDrivingLicenseApplications
            // 
            this.dgvManageLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvManageLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvManageLocalDrivingLicenseApplications.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvManageLocalDrivingLicenseApplications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvManageLocalDrivingLicenseApplications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManageLocalDrivingLicenseApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManageLocalDrivingLicenseApplications.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvManageLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManageLocalDrivingLicenseApplications.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvManageLocalDrivingLicenseApplications.Location = new System.Drawing.Point(12, 287);
            this.dgvManageLocalDrivingLicenseApplications.Name = "dgvManageLocalDrivingLicenseApplications";
            this.dgvManageLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgvManageLocalDrivingLicenseApplications.RowHeadersWidth = 45;
            this.dgvManageLocalDrivingLicenseApplications.Size = new System.Drawing.Size(982, 242);
            this.dgvManageLocalDrivingLicenseApplications.StandardTab = true;
            this.dgvManageLocalDrivingLicenseApplications.TabIndex = 27;
            // 
            // cmsApplications
            // 
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.scheduleTestToolStripMenuItem,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonHistoryLicenseToolStripMenuItem});
            this.cmsApplications.Name = "cmsManageLocalLicenseApplications";
            this.cmsApplications.Size = new System.Drawing.Size(260, 314);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsManageLocalLicenseApplications_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showApplicationDetailsToolStripMenuItem.Image")));
            this.showApplicationDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(259, 38);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(256, 6);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.edit_32;
            this.editApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(259, 38);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Delete_32_2;
            this.deleteApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(259, 38);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Delete_32;
            this.cancelApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(259, 38);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // scheduleTestToolStripMenuItem
            // 
            this.scheduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScheduleVisionTest,
            this.scheduleWrittenTest,
            this.ScheduleStreetTest});
            this.scheduleTestToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Schedule_Test_32;
            this.scheduleTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleTestToolStripMenuItem.Name = "scheduleTestToolStripMenuItem";
            this.scheduleTestToolStripMenuItem.Size = new System.Drawing.Size(259, 38);
            this.scheduleTestToolStripMenuItem.Text = "Sechdule Test";
            // 
            // ScheduleVisionTest
            // 
            this.ScheduleVisionTest.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Vision_Test_32;
            this.ScheduleVisionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleVisionTest.Name = "ScheduleVisionTest";
            this.ScheduleVisionTest.Size = new System.Drawing.Size(206, 38);
            this.ScheduleVisionTest.Text = "Sechdule Vision Test";
            this.ScheduleVisionTest.Click += new System.EventHandler(this.ScheduleVisionTest_Click);
            // 
            // scheduleWrittenTest
            // 
            this.scheduleWrittenTest.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Written_Test_32;
            this.scheduleWrittenTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleWrittenTest.Name = "scheduleWrittenTest";
            this.scheduleWrittenTest.Size = new System.Drawing.Size(206, 38);
            this.scheduleWrittenTest.Text = " Schedule Written Test";
            this.scheduleWrittenTest.Click += new System.EventHandler(this.scheduleWrittenTest_Click);
            // 
            // ScheduleStreetTest
            // 
            this.ScheduleStreetTest.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Street_Test_32;
            this.ScheduleStreetTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ScheduleStreetTest.Name = "ScheduleStreetTest";
            this.ScheduleStreetTest.Size = new System.Drawing.Size(206, 38);
            this.ScheduleStreetTest.Text = " Sechdule Street Test";
            this.ScheduleStreetTest.Click += new System.EventHandler(this.ScheduleStreetTest_Click);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("issueDrivingLicenseFirstTimeToolStripMenuItem.Image")));
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(259, 38);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First time)";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Enabled = false;
            this.showLicenseToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.License_View_32;
            this.showLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(259, 38);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonHistoryLicenseToolStripMenuItem
            // 
            this.showPersonHistoryLicenseToolStripMenuItem.Enabled = false;
            this.showPersonHistoryLicenseToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonHistoryLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonHistoryLicenseToolStripMenuItem.Name = "showPersonHistoryLicenseToolStripMenuItem";
            this.showPersonHistoryLicenseToolStripMenuItem.Size = new System.Drawing.Size(259, 38);
            this.showPersonHistoryLicenseToolStripMenuItem.Text = "Show Person History License";
            this.showPersonHistoryLicenseToolStripMenuItem.Click += new System.EventHandler(this.showPersonHistoryLicenseToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Local_32;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(558, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 47);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // pbManageLocalDrivingLicenseApplications
            // 
            this.pbManageLocalDrivingLicenseApplications.BackgroundImage = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Applications;
            this.pbManageLocalDrivingLicenseApplications.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbManageLocalDrivingLicenseApplications.Location = new System.Drawing.Point(406, 22);
            this.pbManageLocalDrivingLicenseApplications.Name = "pbManageLocalDrivingLicenseApplications";
            this.pbManageLocalDrivingLicenseApplications.Size = new System.Drawing.Size(158, 174);
            this.pbManageLocalDrivingLicenseApplications.TabIndex = 36;
            this.pbManageLocalDrivingLicenseApplications.TabStop = false;
            // 
            // btnAddNewLocalDVApp
            // 
            this.btnAddNewLocalDVApp.BackgroundImage = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.New_Application_64;
            this.btnAddNewLocalDVApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewLocalDVApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewLocalDVApp.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnAddNewLocalDVApp.Location = new System.Drawing.Point(928, 221);
            this.btnAddNewLocalDVApp.Name = "btnAddNewLocalDVApp";
            this.btnAddNewLocalDVApp.Size = new System.Drawing.Size(65, 53);
            this.btnAddNewLocalDVApp.TabIndex = 33;
            this.btnAddNewLocalDVApp.UseVisualStyleBackColor = true;
            this.btnAddNewLocalDVApp.Click += new System.EventHandler(this.btnAddNewLocalDVApp_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(882, 536);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 43);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtFilterSerach
            // 
            this.txtFilterSerach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterSerach.Location = new System.Drawing.Point(315, 253);
            this.txtFilterSerach.Name = "txtFilterSerach";
            this.txtFilterSerach.Size = new System.Drawing.Size(212, 26);
            this.txtFilterSerach.TabIndex = 39;
            this.txtFilterSerach.TextChanged += new System.EventHandler(this.txtFilterSerach_TextChanged);
            this.txtFilterSerach.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterSerach_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 536);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 22);
            this.label3.TabIndex = 40;
            this.label3.Text = "# Records :  ";
            // 
            // frmListLocalDrivingLicenseApplication
            // 
            this.AcceptButton = this.btnAddNewLocalDVApp;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1006, 591);
            this.ContextMenuStrip = this.cmsApplications;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilterSerach);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbManageLocalDrivingLicenseApplications);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNewLocalDVApp);
            this.Controls.Add(this.cbManageLAppFilterTypes);
            this.Controls.Add(this.cbStatusFilterType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.dgvManageLocalDrivingLicenseApplications);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListLocalDrivingLicenseApplication";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Driving License Application";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageLocalDrivingLicenseApplications)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageLocalDrivingLicenseApplications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbManageLocalDrivingLicenseApplications;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewLocalDVApp;
        private System.Windows.Forms.ComboBox cbManageLAppFilterTypes;
        private System.Windows.Forms.ComboBox cbStatusFilterType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.DataGridView dgvManageLocalDrivingLicenseApplications;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonHistoryLicenseToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem ScheduleStreetTest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtFilterSerach;
        private System.Windows.Forms.Label label3;
    }
}