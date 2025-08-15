namespace ProjectDrivingLicenseManagementSystem.License
{
    partial class frmListDetainedLicenses
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
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.Label = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvDetainedLicensesList = new System.Windows.Forms.DataGridView();
            this.cmsDetainedLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsiReleasedDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilterDetainedLicenseBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.cbIsReleased = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicensesList)).BeginInit();
            this.cmsDetainedLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(87, 493);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(15, 16);
            this.lblNumberOfRecords.TabIndex = 22;
            this.lblNumberOfRecords.Text = "0";
            // 
            // Label
            // 
            this.Label.AutoSize = true;
            this.Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label.Location = new System.Drawing.Point(-1, 490);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(82, 16);
            this.Label.TabIndex = 21;
            this.Label.Text = "# Records:";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Close_32;
            this.btnClose.Location = new System.Drawing.Point(813, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 43);
            this.btnClose.TabIndex = 20;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvDetainedLicensesList
            // 
            this.dgvDetainedLicensesList.AllowUserToAddRows = false;
            this.dgvDetainedLicensesList.AllowUserToDeleteRows = false;
            this.dgvDetainedLicensesList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetainedLicensesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicensesList.ContextMenuStrip = this.cmsDetainedLicenses;
            this.dgvDetainedLicensesList.Location = new System.Drawing.Point(2, 279);
            this.dgvDetainedLicensesList.Name = "dgvDetainedLicensesList";
            this.dgvDetainedLicensesList.ReadOnly = true;
            this.dgvDetainedLicensesList.Size = new System.Drawing.Size(924, 200);
            this.dgvDetainedLicensesList.TabIndex = 19;
            // 
            // cmsDetainedLicenses
            // 
            this.cmsDetainedLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowPersonDetails,
            this.tmsiShowLicenseDetails,
            this.tsmiShowPersonLicenseHistory,
            this.tmsiReleasedDetainedLicense});
            this.cmsDetainedLicenses.Name = "cmsDetainedLicenses";
            this.cmsDetainedLicenses.Size = new System.Drawing.Size(242, 156);
            this.cmsDetainedLicenses.Opening += new System.ComponentModel.CancelEventHandler(this.cmsDetainedLicenses_Opening);
            // 
            // tsmiShowPersonDetails
            // 
            this.tsmiShowPersonDetails.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.PersonDetails_32;
            this.tsmiShowPersonDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowPersonDetails.Name = "tsmiShowPersonDetails";
            this.tsmiShowPersonDetails.Size = new System.Drawing.Size(241, 38);
            this.tsmiShowPersonDetails.Text = "Show Person Details";
            this.tsmiShowPersonDetails.Click += new System.EventHandler(this.tsmiShowPersonDetails_Click);
            // 
            // tmsiShowLicenseDetails
            // 
            this.tmsiShowLicenseDetails.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.License_View_32;
            this.tmsiShowLicenseDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tmsiShowLicenseDetails.Name = "tmsiShowLicenseDetails";
            this.tmsiShowLicenseDetails.Size = new System.Drawing.Size(241, 38);
            this.tmsiShowLicenseDetails.Text = "Show License Details";
            this.tmsiShowLicenseDetails.Click += new System.EventHandler(this.tmsiShowLicenseDetails_Click);
            // 
            // tsmiShowPersonLicenseHistory
            // 
            this.tsmiShowPersonLicenseHistory.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.PersonLicenseHistory_32;
            this.tsmiShowPersonLicenseHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiShowPersonLicenseHistory.Name = "tsmiShowPersonLicenseHistory";
            this.tsmiShowPersonLicenseHistory.Size = new System.Drawing.Size(241, 38);
            this.tsmiShowPersonLicenseHistory.Text = "Show Person License History";
            this.tsmiShowPersonLicenseHistory.Click += new System.EventHandler(this.tsmiShowPersonLicenseHistory_Click);
            // 
            // tmsiReleasedDetainedLicense
            // 
            this.tmsiReleasedDetainedLicense.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Release_Detained_License_32;
            this.tmsiReleasedDetainedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tmsiReleasedDetainedLicense.Name = "tmsiReleasedDetainedLicense";
            this.tmsiReleasedDetainedLicense.Size = new System.Drawing.Size(241, 38);
            this.tmsiReleasedDetainedLicense.Text = "Release Detained License";
            this.tmsiReleasedDetainedLicense.Click += new System.EventHandler(this.tmsiReleasedDetainedLicense_Click);
            // 
            // cbFilterDetainedLicenseBy
            // 
            this.cbFilterDetainedLicenseBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterDetainedLicenseBy.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbFilterDetainedLicenseBy.FormattingEnabled = true;
            this.cbFilterDetainedLicenseBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No",
            "Full Name",
            "Release Application ID"});
            this.cbFilterDetainedLicenseBy.Location = new System.Drawing.Point(95, 245);
            this.cbFilterDetainedLicenseBy.Name = "cbFilterDetainedLicenseBy";
            this.cbFilterDetainedLicenseBy.Size = new System.Drawing.Size(174, 27);
            this.cbFilterDetainedLicenseBy.TabIndex = 17;
            this.cbFilterDetainedLicenseBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterDetainedLicenseBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Filter By : ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Detain_512;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(375, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(172, 177);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(360, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "List Detained Licenses";
            // 
            // btnDetain
            // 
            this.btnDetain.BackgroundImage = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Detain_32;
            this.btnDetain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetain.Location = new System.Drawing.Point(862, 215);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(64, 53);
            this.btnDetain.TabIndex = 24;
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.BackgroundImage = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Release_Detained_License_32;
            this.btnRelease.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelease.Location = new System.Drawing.Point(785, 215);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(64, 53);
            this.btnRelease.TabIndex = 25;
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // cbIsReleased
            // 
            this.cbIsReleased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsReleased.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsReleased.FormattingEnabled = true;
            this.cbIsReleased.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cbIsReleased.Location = new System.Drawing.Point(297, 244);
            this.cbIsReleased.Name = "cbIsReleased";
            this.cbIsReleased.Size = new System.Drawing.Size(136, 27);
            this.cbIsReleased.TabIndex = 34;
            this.cbIsReleased.Visible = false;
            this.cbIsReleased.SelectedIndexChanged += new System.EventHandler(this.cbIsReleased_SelectedIndexChanged);
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(308, 244);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(191, 24);
            this.txtValue.TabIndex = 35;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // frmListDetainedLicenses
            // 
            this.AcceptButton = this.btnRelease;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(938, 537);
            this.Controls.Add(this.cbIsReleased);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.Label);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvDetainedLicensesList);
            this.Controls.Add(this.cbFilterDetainedLicenseBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListDetainedLicenses";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Detained Licenses";
            this.Load += new System.EventHandler(this.frmManageDetainLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicensesList)).EndInit();
            this.cmsDetainedLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label Label;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvDetainedLicensesList;
        private System.Windows.Forms.ComboBox cbFilterDetainedLicenseBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.ContextMenuStrip cmsDetainedLicenses;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem tmsiShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem tmsiReleasedDetainedLicense;
        private System.Windows.Forms.ComboBox cbIsReleased;
        private System.Windows.Forms.TextBox txtValue;
    }
}