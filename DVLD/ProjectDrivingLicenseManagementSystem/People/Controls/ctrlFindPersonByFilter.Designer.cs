

using System.Web.UI;
using ProjectDrivingLicenseManagementSystem;

namespace ProjectDrivingLicenseManagementSystem
{
    partial class ctrlFindPersonByFilter
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
            this.cbFilterPersonDataBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFilter = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnFindPerson = new System.Windows.Forms.Button();
            this.ctrlPersonInfo2 = new ProjectDrivingLicenseManagementSystem.ctrlPersonInfo();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtValue = new System.Windows.Forms.TextBox();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbFilterPersonDataBy
            // 
            this.cbFilterPersonDataBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterPersonDataBy.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cbFilterPersonDataBy.FormattingEnabled = true;
            this.cbFilterPersonDataBy.Items.AddRange(new object[] {
            "National No",
            "Person ID"});
            this.cbFilterPersonDataBy.Location = new System.Drawing.Point(87, 44);
            this.cbFilterPersonDataBy.Name = "cbFilterPersonDataBy";
            this.cbFilterPersonDataBy.Size = new System.Drawing.Size(174, 27);
            this.cbFilterPersonDataBy.TabIndex = 9;
            this.cbFilterPersonDataBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterPersonDataBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Italic);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(4, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Find By : ";
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.txtValue);
            this.gbFilter.Controls.Add(this.btnAddNewPerson);
            this.gbFilter.Controls.Add(this.btnFindPerson);
            this.gbFilter.Controls.Add(this.cbFilterPersonDataBy);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Modern No. 20", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.ForeColor = System.Drawing.Color.Black;
            this.gbFilter.Location = new System.Drawing.Point(6, 2);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(699, 86);
            this.gbFilter.TabIndex = 11;
            this.gbFilter.Text = "Filter";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.AddPerson_32;
            this.btnAddNewPerson.Location = new System.Drawing.Point(503, 39);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(46, 35);
            this.btnAddNewPerson.TabIndex = 12;
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.Image = global::ProjectDrivingLicenseManagementSystem.Properties.Resources.SearchPerson;
            this.btnFindPerson.Location = new System.Drawing.Point(451, 39);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.Size = new System.Drawing.Size(46, 35);
            this.btnFindPerson.TabIndex = 11;
            this.btnFindPerson.UseVisualStyleBackColor = true;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // ctrlPersonInfo2
            // 
            this.ctrlPersonInfo2.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonInfo2.Location = new System.Drawing.Point(2, 94);
            this.ctrlPersonInfo2.Name = "ctrlPersonInfo2";
            this.ctrlPersonInfo2.Size = new System.Drawing.Size(706, 261);
            this.ctrlPersonInfo2.TabIndex = 12;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(267, 44);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(178, 24);
            this.txtValue.TabIndex = 13;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // ctrlFindPersonByFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPersonInfo2);
            this.Controls.Add(this.gbFilter);
            this.Name = "ctrlFindPersonByFilter";
            this.Size = new System.Drawing.Size(721, 377);
            this.Load += new System.EventHandler(this.ctrlFindPersonByFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddNewPerson;
        public Guna.UI2.WinForms.Guna2GroupBox gbFilter;
        public System.Windows.Forms.Button btnFindPerson;
        public System.Windows.Forms.ComboBox cbFilterPersonDataBy;
        //private BusinessLayer.UCPersonInfo ucPersonInfo1;
        private System.Windows.Forms.TextBox txtValue;
        private ctrlPersonInfo ctrlPersonInfo2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
