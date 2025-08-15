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

namespace ProjectDrivingLicenseManagementSystem.License
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
          
        }
        private int _LicenseID = -1;
        private int _DetainID = -1;
       
      
        private void btnDetainLicense_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("You can not detain check red icon(s) to know What is   ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are You sure You want to Detain the  License", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }
          _DetainID= ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text),clsGlobal.CurrentUser.UserId);
            if (_DetainID != -1)
            {
                MessageBox.Show(" License Detained  Successfully with ID= " + _DetainID, "License Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llShowLicenseInfo.Enabled = true;
                btnDetainLicense.Enabled = false;
            }
            else { 
            
            MessageBox.Show("Error, License not Detained  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } 
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblCreatedUserName.Text = clsGlobal.CurrentUser.UserName;
            lblDetainDate.Text =clsFormat.ToShortDateString(DateTime.Now);
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;

            if (_LicenseID == -1)
            {
                MessageBox.Show("Error License with ID = "+ _LicenseID + " Not Found","not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            llShowLicenseHistory.Enabled = true;
            lblLicenseID.Text=ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is  Already Detained   " , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtFineFees.Focus();
            btnDetainLicense.Enabled = true;

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Driver.PersonID);
            frm.ShowDialog();
        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.SetFoucs();
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "This Field is Required");
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);

            }
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
        }

        private void llShowLicenseInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmDriverLicenseInfo LicenseInfo = new frmDriverLicenseInfo(ctrlDriverLicenseInfoWithFilter1.LicenseID);
            LicenseInfo.ShowDialog();
        }
    }
}
