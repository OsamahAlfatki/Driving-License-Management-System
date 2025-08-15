using BusinessLayer;
using ProjectDrivingLicenseManagementSystem.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class FrmUpdateApplicationTypes : Form
    {
        clsApplicationType _ApplicationType;
        private int _ApplicationTypeID;
        public FrmUpdateApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                MessageBox.Show("Erorr,not valide inputs check red icon(s) to see ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            {
                _ApplicationType.ApplicationTypeTitle = txtTitle.Text;
                _ApplicationType.ApplicationTypeFees = Convert.ToSingle(txtFees.Text);

                if (_ApplicationType.Save())
                {
                    MessageBox.Show("Data Saved Successfully","Data Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data  dose not Saved Check Your Input", "Data not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }


        private void FrmUpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationType != null)
            {
                lblApplicationTypeID.Text = _ApplicationType.ApplicationTypeID.ToString();
                txtTitle.Text = _ApplicationType.ApplicationTypeTitle.ToString();
                txtFees.Text = _ApplicationType.ApplicationTypeFees.ToString();

            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This Field Can not be null");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            }

            if (!clsValidate.IsNumber(txtFees.Text))
            {
                e.Cancel= true;
                errorProvider1.SetError(txtFees, "This field should be only numbers");

            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {

            
            if (string.IsNullOrEmpty(txtTitle.Text ))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "This Field Can not be null");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);

            }

        }
    }
}
