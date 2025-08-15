namespace ProjectDrivingLicenseManagementSystem
{
    partial class FrmPeopleManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPeopleManagement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPeopleList = new System.Windows.Forms.DataGridView();
            this.cmsPersonsListsData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterPersonDataBy = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopleList)).BeginInit();
            this.cmsPersonsListsData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPeopleList
            // 
            this.dgvPeopleList.AllowUserToAddRows = false;
            this.dgvPeopleList.AllowUserToDeleteRows = false;
            this.dgvPeopleList.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvPeopleList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dgvPeopleList, "dgvPeopleList");
            this.dgvPeopleList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPeopleList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPeopleList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPeopleList.ContextMenuStrip = this.cmsPersonsListsData;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeopleList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPeopleList.Name = "dgvPeopleList";
            this.dgvPeopleList.ReadOnly = true;
            this.dgvPeopleList.StandardTab = true;
            // 
            // cmsPersonsListsData
            // 
            this.cmsPersonsListsData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator2,
            this.addNewPersonToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deletToolStripMenuItem,
            this.sendEmailToolStripMenuItem,
            this.makeCallToolStripMenuItem});
            this.cmsPersonsListsData.Name = "cmsPersonsListsData";
            resources.ApplyResources(this.cmsPersonsListsData, "cmsPersonsListsData");
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.PersonDetails_32;
            resources.ApplyResources(this.showDetailsToolStripMenuItem, "showDetailsToolStripMenuItem");
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.AddPerson_32;
            resources.ApplyResources(this.addNewPersonToolStripMenuItem, "addNewPersonToolStripMenuItem");
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.edit_32;
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deletToolStripMenuItem
            // 
            this.deletToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Delete_32;
            resources.ApplyResources(this.deletToolStripMenuItem, "deletToolStripMenuItem");
            this.deletToolStripMenuItem.Name = "deletToolStripMenuItem";
            this.deletToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.send_email_32;
            resources.ApplyResources(this.sendEmailToolStripMenuItem, "sendEmailToolStripMenuItem");
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Click += new System.EventHandler(this.sendEmailToolStripMenuItem_Click);
            // 
            // makeCallToolStripMenuItem
            // 
            this.makeCallToolStripMenuItem.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.call_32;
            resources.ApplyResources(this.makeCallToolStripMenuItem, "makeCallToolStripMenuItem");
            this.makeCallToolStripMenuItem.Name = "makeCallToolStripMenuItem";
            this.makeCallToolStripMenuItem.Click += new System.EventHandler(this.makeCallToolStripMenuItem_Click);
            // 
            // lblNumberOfRecords
            // 
            resources.ApplyResources(this.lblNumberOfRecords, "lblNumberOfRecords");
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbFilterPersonDataBy
            // 
            this.cbFilterPersonDataBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbFilterPersonDataBy, "cbFilterPersonDataBy");
            this.cbFilterPersonDataBy.FormattingEnabled = true;
            this.cbFilterPersonDataBy.Items.AddRange(new object[] {
            resources.GetString("cbFilterPersonDataBy.Items"),
            resources.GetString("cbFilterPersonDataBy.Items1"),
            resources.GetString("cbFilterPersonDataBy.Items2"),
            resources.GetString("cbFilterPersonDataBy.Items3"),
            resources.GetString("cbFilterPersonDataBy.Items4"),
            resources.GetString("cbFilterPersonDataBy.Items5"),
            resources.GetString("cbFilterPersonDataBy.Items6"),
            resources.GetString("cbFilterPersonDataBy.Items7"),
            resources.GetString("cbFilterPersonDataBy.Items8"),
            resources.GetString("cbFilterPersonDataBy.Items9"),
            resources.GetString("cbFilterPersonDataBy.Items10")});
            this.cbFilterPersonDataBy.Name = "cbFilterPersonDataBy";
            this.cbFilterPersonDataBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterPersonDataBy_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.People_400;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Close_32;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_2);
            // 
            // btnAddNewPerson
            // 
            resources.ApplyResources(this.btnAddNewPerson, "btnAddNewPerson");
            this.btnAddNewPerson.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.Add_Person_40;
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // txtValue
            // 
            resources.ApplyResources(this.txtValue, "txtValue");
            this.txtValue.Name = "txtValue";
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // FrmPeopleManagement
            // 
            this.AcceptButton = this.btnAddNewPerson;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnClose;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbFilterPersonDataBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.dgvPeopleList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPeopleManagement";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FrmPeopleManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeopleList)).EndInit();
            this.cmsPersonsListsData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPeopleList;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterPersonDataBy;
        private System.Windows.Forms.ContextMenuStrip cmsPersonsListsData;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeCallToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
    }
}