namespace ProjectDrivingLicenseManagementSystem
{
    partial class frmListTestAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListTestAppointments));
            this.lblTestTypeTitle = new System.Windows.Forms.Label();
            this.dgvAppointmentsList = new System.Windows.Forms.DataGridView();
            this.cmsTestAppointmentsProperties = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.btnScheduleTestOrRetakeTest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbTestTypeImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlDAppInfo1 = new ProjectDrivingLicenseManagementSystem.ctrlDAppInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentsList)).BeginInit();
            this.cmsTestAppointmentsProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTestTypeTitle
            // 
            this.lblTestTypeTitle.AutoSize = true;
            this.lblTestTypeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestTypeTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTestTypeTitle.Location = new System.Drawing.Point(214, 82);
            this.lblTestTypeTitle.Name = "lblTestTypeTitle";
            this.lblTestTypeTitle.Size = new System.Drawing.Size(308, 31);
            this.lblTestTypeTitle.TabIndex = 0;
            this.lblTestTypeTitle.Text = "Vision Test Appointment";
            // 
            // dgvAppointmentsList
            // 
            this.dgvAppointmentsList.AllowUserToAddRows = false;
            this.dgvAppointmentsList.AllowUserToDeleteRows = false;
            this.dgvAppointmentsList.AllowUserToOrderColumns = true;
            this.dgvAppointmentsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointmentsList.ContextMenuStrip = this.cmsTestAppointmentsProperties;
            this.dgvAppointmentsList.GridColor = System.Drawing.SystemColors.Control;
            this.dgvAppointmentsList.Location = new System.Drawing.Point(9, 490);
            this.dgvAppointmentsList.Name = "dgvAppointmentsList";
            this.dgvAppointmentsList.ReadOnly = true;
            this.dgvAppointmentsList.Size = new System.Drawing.Size(702, 114);
            this.dgvAppointmentsList.TabIndex = 4;
            // 
            // cmsTestAppointmentsProperties
            // 
            this.cmsTestAppointmentsProperties.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEdit,
            this.cmsTakeTest});
            this.cmsTestAppointmentsProperties.Name = "cmsTestAppointmentsProperties";
            this.cmsTestAppointmentsProperties.Size = new System.Drawing.Size(137, 80);
            this.cmsTestAppointmentsProperties.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTestAppointmentsProperties_Opening);
            // 
            // cmsEdit
            // 
            this.cmsEdit.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.edit_32;
            this.cmsEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsEdit.Name = "cmsEdit";
            this.cmsEdit.Size = new System.Drawing.Size(136, 38);
            this.cmsEdit.Text = "Edit";
            this.cmsEdit.Click += new System.EventHandler(this.cmsEdit_Click);
            // 
            // cmsTakeTest
            // 
            this.cmsTakeTest.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Test_32;
            this.cmsTakeTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsTakeTest.Name = "cmsTakeTest";
            this.cmsTakeTest.Size = new System.Drawing.Size(136, 38);
            this.cmsTakeTest.Text = "Take Test";
            this.cmsTakeTest.Click += new System.EventHandler(this.cmsTakeTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 466);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Appointments:";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(98, 619);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(15, 16);
            this.lblNumberOfRecords.TabIndex = 5;
            this.lblNumberOfRecords.Text = "0";
            // 
            // btnScheduleTestOrRetakeTest
            // 
            this.btnScheduleTestOrRetakeTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScheduleTestOrRetakeTest.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Schedule_Test_32;
            this.btnScheduleTestOrRetakeTest.Location = new System.Drawing.Point(656, 450);
            this.btnScheduleTestOrRetakeTest.Name = "btnScheduleTestOrRetakeTest";
            this.btnScheduleTestOrRetakeTest.Size = new System.Drawing.Size(55, 38);
            this.btnScheduleTestOrRetakeTest.TabIndex = 9;
            this.btnScheduleTestOrRetakeTest.UseVisualStyleBackColor = true;
            this.btnScheduleTestOrRetakeTest.Click += new System.EventHandler(this.btnScheduleTestOrRetakeTest_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(618, 609);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 37);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbTestTypeImage
            // 
            this.pbTestTypeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbTestTypeImage.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Vision_512;
            this.pbTestTypeImage.Location = new System.Drawing.Point(303, 2);
            this.pbTestTypeImage.Name = "pbTestTypeImage";
            this.pbTestTypeImage.Size = new System.Drawing.Size(100, 80);
            this.pbTestTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestTypeImage.TabIndex = 1;
            this.pbTestTypeImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 619);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "# Records :";
            // 
            // ctrlDAppInfo1
            // 
            this.ctrlDAppInfo1.Location = new System.Drawing.Point(12, 112);
            this.ctrlDAppInfo1.Name = "ctrlDAppInfo1";
            this.ctrlDAppInfo1.Size = new System.Drawing.Size(715, 329);
            this.ctrlDAppInfo1.TabIndex = 10;
            // 
            // frmListTestAppointments
            // 
            this.AcceptButton = this.btnScheduleTestOrRetakeTest;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(728, 651);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlDAppInfo1);
            this.Controls.Add(this.btnScheduleTestOrRetakeTest);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAppointmentsList);
            this.Controls.Add(this.pbTestTypeImage);
            this.Controls.Add(this.lblTestTypeTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListTestAppointments";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vision Test Appointment";
            this.Load += new System.EventHandler(this.frmListTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointmentsList)).EndInit();
            this.cmsTestAppointmentsProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTestTypeTitle;
        private System.Windows.Forms.PictureBox pbTestTypeImage;
        private System.Windows.Forms.DataGridView dgvAppointmentsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsTestAppointmentsProperties;
        private System.Windows.Forms.ToolStripMenuItem cmsTakeTest;
        private System.Windows.Forms.Button btnScheduleTestOrRetakeTest;
        private System.Windows.Forms.ToolStripMenuItem cmsEdit;
        private ctrlDAppInfo ctrlDAppInfo1;
        private System.Windows.Forms.Label label1;
    }
}