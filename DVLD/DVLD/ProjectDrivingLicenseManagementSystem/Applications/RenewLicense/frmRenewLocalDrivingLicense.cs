using BusinessLayer;
using ProjectDrivingLicenseManagementSystem.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class frmRenewLocalDrivingLicense : Form
    {
        private int _NewLicenseID = -1;
        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        void RenewLicense()
        {
            clsLicense _License;
          _License=  ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Renew(txtNotes.Text, clsGlobal.CurrentUser.UserId);

            if (_License!=null)
            {
                MessageBox.Show(" License Renewed Successfully with ID= " + _License.LicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblRenewedLicenseID.Text = _License.LicenseID.ToString();
                _NewLicenseID=_License.LicenseID;
                      lblRenewedLocalLicenseApplicationID.Text = _License.ApplicationID.ToString();
                llShowNewLicenseInfo.Enabled = true;
                btnRenewLicense.Enabled = false;
                return;
            }

            else
            {
                MessageBox.Show("Error, License not issued check your Choice  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

       
        }
        private void btnRenewLicense_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You sure You want to Issue the  License", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                RenewLicense();
            }
        }

    

    
        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.SetFoucs();
            lblApplicationDate.Text=clsFormat.ToShortDateString(DateTime.Now);
            lblCreatedUserID.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text=clsApplicationType.Find((int)clsApplication.enApplicationTypes.ReNewDrivingLicense).ApplicationTypeFees.ToString();
            lblTotalFees.Text = lblApplicationFees.Text;

        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _NewLicenseID = obj;
            llShowLicenseHistory.Enabled = (_NewLicenseID != -1);

            if(_NewLicenseID == -1)
            {
                MessageBox.Show("License Not Found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                ctrlDriverLicenseInfoWithFilter1.ResetDefualtValues();
                return;
            }

            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive||ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License Is Deactivated or Detained You can not Renew it  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;

            }
            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License Is not  yet Expired ,it will expire on : " +clsFormat.ToShortDateString( ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnRenewLicense.Enabled = false;
                llShowLicenseHistory.Enabled = true;
                llShowNewLicenseInfo.Enabled = false;
                return;

            }
            lblOldLicenseID.Text = ctrlDriverLicenseInfoWithFilter1.LicenseID.ToString();
            lblExpirationDate.Text = clsFormat.ToShortDateString(DateTime.Now.AddYears(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ValidatyLength));
            lblLicenseFees.Text = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.PaidFees.ToString();
            lblTotalFees.Text =(Convert.ToSingle(lblApplicationFees.Text)+Convert.ToSingle(lblLicenseFees.Text)).ToString();
            lblIssueDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            btnRenewLicense.Enabled = true;
            llShowLicenseHistory.Enabled = true;
            llShowNewLicenseInfo.Enabled = false;


        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDriverLicenseInfo LicenseInfo = new frmDriverLicenseInfo(_NewLicenseID);
            LicenseInfo.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Driver.PersonID);
            frm.ShowDialog();
        }
    }
}
