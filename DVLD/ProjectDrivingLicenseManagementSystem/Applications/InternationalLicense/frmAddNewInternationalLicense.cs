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
    public partial class frmAddNewInternationalLicenseApplication : Form
    {
        public frmAddNewInternationalLicenseApplication()
        {
            InitializeComponent();
            

        }
        private int _InternationalLicenseID = -1;
        private int _ApplicationID = -1;

        void IssueLicense()
        {
            clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            InternationalLicense.ApplicationDate = DateTime.Now;
           InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.ApplicationTypeID = (int)clsApplication.enApplicationTypes.NewInternationalLicense;
            InternationalLicense.ApplicationUserID = clsGlobal.CurrentUser.UserId;
            InternationalLicense.ApplicationPersonID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Driver.PersonID;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.Fees = clsApplicationType.Find((int)clsApplication.enApplicationTypes.NewInternationalLicense).ApplicationTypeFees;
            InternationalLicense.DriverID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.LDLID = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IsActive = true;
            InternationalLicense.LastStatusDate= DateTime.Now;
            InternationalLicense.UserID= clsGlobal.CurrentUser.UserId;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(clsInternationalLicense.GetDefualtValidityLength());
            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to issue international License   ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("International License Issued Successfully with ID= " + InternationalLicense.InternationalLicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblInternationalApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            _ApplicationID=InternationalLicense.ApplicationID;
                btnIssueLicense.Enabled = false;
                llShowLicenseInfo.Enabled = true ;
            
          

        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure You want to Issue the  License", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                IssueLicense();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmAddNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text=clsFormat.ToShortDateString(DateTime.Now);
            lblCreatedUserName.Text=clsGlobal.CurrentUser.UserName;
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationTypes.NewInternationalLicense).ApplicationTypeFees.ToString();
            lblIssueDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            lblExpirationDate.Text = clsFormat.ToShortDateString(DateTime.Now.AddYears(clsInternationalLicense.GetDefualtValidityLength()));
            ctrlDriverLicenseInfoWithFilter1.SetFoucs();
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int LocalLicenseID=obj;

            if (LocalLicenseID == -1)
            {
                return;
            }
            lblLocalLicenseID.Text = LocalLicenseID.ToString(); 
            llShowLicenseHistory.Enabled=true;
            int ActiveLicenseID = clsInternationalLicense.GetActiveInternationalLicense(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);
            if (ActiveLicenseID!=-1) { 
                MessageBox.Show("Error,Person has an International License already ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
            if (!clsLicense.IsLicenseExistByID(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Driver.PersonID, 3))
            {
                MessageBox.Show("Error, Person Should Has License class 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained||!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Error, Local License Deactivated or Detained ,Active License and Make Application  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Error, Local License is expired renew it  and try again  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            
            btnIssueLicense.Enabled = true;

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Driver.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmDriverInternationalInfo frm = new frmDriverInternationalInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
