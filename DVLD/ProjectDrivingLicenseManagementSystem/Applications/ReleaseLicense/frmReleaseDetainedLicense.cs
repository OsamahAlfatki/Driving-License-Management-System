using BusinessLayer;
using ProjectDrivingLicenseManagementSystem.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDrivingLicenseManagementSystem.License
{
    public partial class frmReleaseDetainedLicense : Form
    {
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }
        private int _LicenseID = -1;
        private int _ApplicationID = -1;
        public frmReleaseDetainedLicense(int LicenseID)
        {
            InitializeComponent();
           _LicenseID = LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        void ReleaseDetainedLicense()
        {



            if (MessageBox.Show("Are You sure You want to Release this  License", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }

            _ApplicationID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Release(clsGlobal.CurrentUser.UserId);

            if (_ApplicationID != -1)
            {
                MessageBox.Show(" Detained License Release Successfully", " Detained License Release ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblReleaseLicenseApplicationID.Text=_ApplicationID.ToString();
                llShowLicenseInfo.Enabled = true;
                btnReleaseLicense.Enabled = false;
                return;

            }

            else
            {
                MessageBox.Show("Error, License not Release   ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
              
            

        }
        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense();
            
        }

            
      
        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {

            lblCreatedUserName.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationTypes.ReleaseDetainedLicense).ApplicationTypeFees.ToString();
            if (_LicenseID != -1)
            {
                ctrlDriverLicenseInfoWithFilter1.LoadLicense(_LicenseID);
                ctrlDriverLicenseInfoWithFilter1.FilterEnabled = false;
            }
           
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;

            if (_LicenseID == -1)
            {
                return;
            }
            if (!clsDetainedLicense.IsLicenseDetained(_LicenseID))
            {
                MessageBox.Show("Error,Selected License is not Detained","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReleaseLicense.Enabled = false;
                return;
            }

            lblDetainID.Text=ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainLicenseInfo.DetainID.ToString();
            lblDetainDate.Text = clsFormat.ToShortDateString(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainLicenseInfo.DetainDate);
            lblFineFees.Text=ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainLicenseInfo.FineFees.ToString();
            lblTotalFees.Text=(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainLicenseInfo.FineFees+Convert.ToSingle(lblApplicationFees.Text)).ToString();
            btnReleaseLicense.Enabled= true;    
            lblLicenseID.Text = _LicenseID.ToString();
            llShowLicenseHistory.Enabled= true; 

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Driver.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmDriverLicenseInfo LicenseInfo = new frmDriverLicenseInfo(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID);
            LicenseInfo.ShowDialog();
        }

        private void frmReleaseDetainedLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithFilter1.SetFoucs();
        }
    }
}
