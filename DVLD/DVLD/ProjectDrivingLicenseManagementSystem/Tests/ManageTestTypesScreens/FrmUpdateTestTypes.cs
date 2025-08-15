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
    public partial class FrmUpdateTestTypes : Form
    {
        private clsTestTypes _TestType;
        clsTestTypes.enTestType _TestTypeID;
        public FrmUpdateTestTypes(clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;

        }

    

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error,Not valid inputs check your inputs ,look at red icon(s)", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                _TestType.TestTypeTitle = txtTitle.Text.Trim();
                _TestType.TestTypeFees = Convert.ToSingle(txtFees.Text.Trim());
                _TestType.TestTypeDescription = txtTestTypeDescription.Text.Trim();


                if (_TestType.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data  dose not Saved Check Your Input", "Data not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "This Field Can not Be Empty");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);

            }
        }

        private void txtTestTypeDescription_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtTestTypeDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeDescription, "This Field Can not Be Empty");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeDescription, null);

            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This Field Can not Be Empty");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            }
            if (!clsValidate.IsNumber(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "This Field should contain only numbers");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            }
        }

        private void FrmUpdateTestTypes_Load(object sender, EventArgs e)
        {
            _TestType = clsTestTypes.Find(_TestTypeID);

            if (_TestType != null)
            {
                lblTestTypeID.Text = Convert.ToInt32(_TestType.ID).ToString();
                txtTitle.Text = _TestType.TestTypeTitle;
                txtTestTypeDescription.Text = _TestType.TestTypeDescription;
                txtFees.Text = _TestType.TestTypeFees.ToString();


            }

            else
            {
                MessageBox.Show("Error,Test with Type ID = "+_TestTypeID+" is not found ", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
