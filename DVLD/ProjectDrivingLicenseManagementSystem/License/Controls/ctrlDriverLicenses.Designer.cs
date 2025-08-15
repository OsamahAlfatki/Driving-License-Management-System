namespace ProjectDrivingLicenseManagementSystem
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbDriverLicense = new System.Windows.Forms.GroupBox();
            this.tbDriverLicense = new System.Windows.Forms.TabControl();
            this.tbLocal = new System.Windows.Forms.TabPage();
            this.lblNumberOfLocalLicenseHistoryRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDriverLicenses = new System.Windows.Forms.DataGridView();
            this.cmsLisenseInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbInternational = new System.Windows.Forms.TabPage();
            this.lblNumberOfInternationalRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvInternationalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.gbDriverLicense.SuspendLayout();
            this.tbDriverLicense.SuspendLayout();
            this.tbLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriverLicenses)).BeginInit();
            this.cmsLisenseInfo.SuspendLayout();
            this.tbInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDriverLicense
            // 
            this.gbDriverLicense.Controls.Add(this.tbDriverLicense);
            this.gbDriverLicense.Location = new System.Drawing.Point(3, 3);
            this.gbDriverLicense.Name = "gbDriverLicense";
            this.gbDriverLicense.Size = new System.Drawing.Size(873, 259);
            this.gbDriverLicense.TabIndex = 0;
            this.gbDriverLicense.TabStop = false;
            this.gbDriverLicense.Text = "Driver Licenses";
            // 
            // tbDriverLicense
            // 
            this.tbDriverLicense.Controls.Add(this.tbLocal);
            this.tbDriverLicense.Controls.Add(this.tbInternational);
            this.tbDriverLicense.Location = new System.Drawing.Point(6, 19);
            this.tbDriverLicense.Name = "tbDriverLicense";
            this.tbDriverLicense.SelectedIndex = 0;
            this.tbDriverLicense.Size = new System.Drawing.Size(861, 240);
            this.tbDriverLicense.TabIndex = 0;
            // 
            // tbLocal
            // 
            this.tbLocal.Controls.Add(this.lblNumberOfLocalLicenseHistoryRecords);
            this.tbLocal.Controls.Add(this.label5);
            this.tbLocal.Controls.Add(this.label1);
            this.tbLocal.Controls.Add(this.dgvDriverLicenses);
            this.tbLocal.Location = new System.Drawing.Point(4, 22);
            this.tbLocal.Name = "tbLocal";
            this.tbLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tbLocal.Size = new System.Drawing.Size(853, 214);
            this.tbLocal.TabIndex = 0;
            this.tbLocal.Text = "Local";
            this.tbLocal.UseVisualStyleBackColor = true;
            // 
            // lblNumberOfLocalLicenseHistoryRecords
            // 
            this.lblNumberOfLocalLicenseHistoryRecords.AutoSize = true;
            this.lblNumberOfLocalLicenseHistoryRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfLocalLicenseHistoryRecords.Location = new System.Drawing.Point(93, 192);
            this.lblNumberOfLocalLicenseHistoryRecords.Name = "lblNumberOfLocalLicenseHistoryRecords";
            this.lblNumberOfLocalLicenseHistoryRecords.Size = new System.Drawing.Size(15, 16);
            this.lblNumberOfLocalLicenseHistoryRecords.TabIndex = 9;
            this.lblNumberOfLocalLicenseHistoryRecords.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "# Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Local License History:";
            // 
            // dgvDriverLicenses
            // 
            this.dgvDriverLicenses.AllowUserToAddRows = false;
            this.dgvDriverLicenses.AllowUserToDeleteRows = false;
            this.dgvDriverLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDriverLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDriverLicenses.ContextMenuStrip = this.cmsLisenseInfo;
            this.dgvDriverLicenses.Location = new System.Drawing.Point(6, 34);
            this.dgvDriverLicenses.Name = "dgvDriverLicenses";
            this.dgvDriverLicenses.ReadOnly = true;
            this.dgvDriverLicenses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvDriverLicenses.Size = new System.Drawing.Size(841, 150);
            this.dgvDriverLicenses.TabIndex = 0;
            // 
            // cmsLisenseInfo
            // 
            this.cmsLisenseInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLisenseInfo.Name = "cmsLisenseInfo";
            this.cmsLisenseInfo.Size = new System.Drawing.Size(186, 42);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.License_View_32;
            this.showLicenseInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(185, 38);
            this.showLicenseInfoToolStripMenuItem.Text = "&Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // tbInternational
            // 
            this.tbInternational.Controls.Add(this.lblNumberOfInternationalRecords);
            this.tbInternational.Controls.Add(this.label2);
            this.tbInternational.Controls.Add(this.label3);
            this.tbInternational.Controls.Add(this.dgvInternationalLicenseHistory);
            this.tbInternational.Location = new System.Drawing.Point(4, 22);
            this.tbInternational.Name = "tbInternational";
            this.tbInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tbInternational.Size = new System.Drawing.Size(853, 214);
            this.tbInternational.TabIndex = 1;
            this.tbInternational.Text = "International";
            this.tbInternational.UseVisualStyleBackColor = true;
            // 
            // lblNumberOfInternationalRecords
            // 
            this.lblNumberOfInternationalRecords.AutoSize = true;
            this.lblNumberOfInternationalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfInternationalRecords.Location = new System.Drawing.Point(97, 187);
            this.lblNumberOfInternationalRecords.Name = "lblNumberOfInternationalRecords";
            this.lblNumberOfInternationalRecords.Size = new System.Drawing.Size(15, 16);
            this.lblNumberOfInternationalRecords.TabIndex = 7;
            this.lblNumberOfInternationalRecords.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "# Records:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "International License History:";
            // 
            // dgvInternationalLicenseHistory
            // 
            this.dgvInternationalLicenseHistory.AllowUserToAddRows = false;
            this.dgvInternationalLicenseHistory.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenseHistory.ContextMenuStrip = this.cmsLisenseInfo;
            this.dgvInternationalLicenseHistory.Location = new System.Drawing.Point(3, 33);
            this.dgvInternationalLicenseHistory.Name = "dgvInternationalLicenseHistory";
            this.dgvInternationalLicenseHistory.ReadOnly = true;
            this.dgvInternationalLicenseHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvInternationalLicenseHistory.Size = new System.Drawing.Size(841, 150);
            this.dgvInternationalLicenseHistory.TabIndex = 1;
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDriverLicense);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(873, 265);
            this.gbDriverLicense.ResumeLayout(false);
            this.tbDriverLicense.ResumeLayout(false);
            this.tbLocal.ResumeLayout(false);
            this.tbLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriverLicenses)).EndInit();
            this.cmsLisenseInfo.ResumeLayout(false);
            this.tbInternational.ResumeLayout(false);
            this.tbInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDriverLicense;
        private System.Windows.Forms.TabControl tbDriverLicense;
        private System.Windows.Forms.TabPage tbLocal;
        private System.Windows.Forms.TabPage tbInternational;
        private System.Windows.Forms.DataGridView dgvDriverLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvInternationalLicenseHistory;
        private System.Windows.Forms.Label lblNumberOfInternationalRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfLocalLicenseHistoryRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cmsLisenseInfo;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}
