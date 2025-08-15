namespace ProjectDrivingLicenseManagementSystem
{
    partial class frmListInternationalLicenseApplication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListInternationalLicenseApplication));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbManageInternationalListAppliccation = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbManageInternationalAppFilterTypes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.dgvManageInternationalLicenseApplication = new System.Windows.Forms.DataGridView();
            this.cmsListInternationalApplication = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddInternationalLicenseApplication = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageInternationalListAppliccation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageInternationalLicenseApplication)).BeginInit();
            this.cmsListInternationalApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(484, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 35);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // pbManageInternationalListAppliccation
            // 
            this.pbManageInternationalListAppliccation.BackgroundImage = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Applications;
            this.pbManageInternationalListAppliccation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbManageInternationalListAppliccation.Location = new System.Drawing.Point(320, 12);
            this.pbManageInternationalListAppliccation.Name = "pbManageInternationalListAppliccation";
            this.pbManageInternationalListAppliccation.Size = new System.Drawing.Size(158, 174);
            this.pbManageInternationalListAppliccation.TabIndex = 45;
            this.pbManageInternationalListAppliccation.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(244, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 23);
            this.label2.TabIndex = 44;
            this.label2.Text = "International License Application";
            // 
            // cbManageInternationalAppFilterTypes
            // 
            this.cbManageInternationalAppFilterTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManageInternationalAppFilterTypes.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManageInternationalAppFilterTypes.FormattingEnabled = true;
            this.cbManageInternationalAppFilterTypes.Items.AddRange(new object[] {
            "None",
            "License ID",
            "Driver ID",
            "Application ID",
            "Local License ID",
            "Is Active"});
            this.cbManageInternationalAppFilterTypes.Location = new System.Drawing.Point(113, 250);
            this.cbManageInternationalAppFilterTypes.Name = "cbManageInternationalAppFilterTypes";
            this.cbManageInternationalAppFilterTypes.Size = new System.Drawing.Size(196, 26);
            this.cbManageInternationalAppFilterTypes.TabIndex = 42;
            this.cbManageInternationalAppFilterTypes.SelectedIndexChanged += new System.EventHandler(this.cbManageInternationalAppFilterTypes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Italic);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(25, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "Filter By : ";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(129, 508);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(21, 22);
            this.lblNumberOfRecords.TabIndex = 39;
            this.lblNumberOfRecords.Text = "0";
            // 
            // dgvManageInternationalLicenseApplication
            // 
            this.dgvManageInternationalLicenseApplication.AllowUserToAddRows = false;
            this.dgvManageInternationalLicenseApplication.AllowUserToDeleteRows = false;
            this.dgvManageInternationalLicenseApplication.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvManageInternationalLicenseApplication.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvManageInternationalLicenseApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManageInternationalLicenseApplication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvManageInternationalLicenseApplication.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvManageInternationalLicenseApplication.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvManageInternationalLicenseApplication.ContextMenuStrip = this.cmsListInternationalApplication;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvManageInternationalLicenseApplication.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvManageInternationalLicenseApplication.Location = new System.Drawing.Point(24, 289);
            this.dgvManageInternationalLicenseApplication.Name = "dgvManageInternationalLicenseApplication";
            this.dgvManageInternationalLicenseApplication.ReadOnly = true;
            this.dgvManageInternationalLicenseApplication.RowHeadersWidth = 45;
            this.dgvManageInternationalLicenseApplication.Size = new System.Drawing.Size(733, 212);
            this.dgvManageInternationalLicenseApplication.StandardTab = true;
            this.dgvManageInternationalLicenseApplication.TabIndex = 38;
            // 
            // cmsListInternationalApplication
            // 
            this.cmsListInternationalApplication.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailsToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsListInternationalApplication.Name = "cmsListInternationalApplication";
            this.cmsListInternationalApplication.ShowItemToolTips = false;
            this.cmsListInternationalApplication.Size = new System.Drawing.Size(242, 118);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showPersonDetailsToolStripMenuItem.Image")));
            this.showPersonDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            this.showLicenseDetailsToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.License_View_32;
            this.showLicenseDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            this.showLicenseDetailsToolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.showLicenseDetailsToolStripMenuItem.Text = " Show License Details";
            this.showLicenseDetailsToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailsToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(241, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(644, 507);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 43);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(20, 507);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 22);
            this.label3.TabIndex = 49;
            this.label3.Text = "# Records :  ";
            // 
            // btnAddInternationalLicenseApplication
            // 
            this.btnAddInternationalLicenseApplication.BackgroundImage = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.New_Application_64;
            this.btnAddInternationalLicenseApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddInternationalLicenseApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInternationalLicenseApplication.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddInternationalLicenseApplication.Location = new System.Drawing.Point(690, 233);
            this.btnAddInternationalLicenseApplication.Name = "btnAddInternationalLicenseApplication";
            this.btnAddInternationalLicenseApplication.Size = new System.Drawing.Size(67, 50);
            this.btnAddInternationalLicenseApplication.TabIndex = 50;
            this.btnAddInternationalLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddInternationalLicenseApplication.Click += new System.EventHandler(this.btnAddInternationalLicenseApplication_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilterValue.Location = new System.Drawing.Point(332, 250);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(165, 26);
            this.txtFilterValue.TabIndex = 51;
            this.txtFilterValue.Visible = false;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbIsActive
            // 
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(332, 250);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(121, 28);
            this.cbIsActive.TabIndex = 52;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // frmListInternationalLicenseApplication
            // 
            this.AcceptButton = this.btnAddInternationalLicenseApplication;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(777, 575);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.btnAddInternationalLicenseApplication);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbManageInternationalListAppliccation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbManageInternationalAppFilterTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.dgvManageInternationalLicenseApplication);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListInternationalLicenseApplication";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List International License Application";
            this.Load += new System.EventHandler(this.frmListInternationalLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageInternationalListAppliccation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManageInternationalLicenseApplication)).EndInit();
            this.cmsListInternationalApplication.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbManageInternationalListAppliccation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbManageInternationalAppFilterTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.DataGridView dgvManageInternationalLicenseApplication;
        private System.Windows.Forms.ContextMenuStrip cmsListInternationalApplication;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddInternationalLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbIsActive;
    }
}