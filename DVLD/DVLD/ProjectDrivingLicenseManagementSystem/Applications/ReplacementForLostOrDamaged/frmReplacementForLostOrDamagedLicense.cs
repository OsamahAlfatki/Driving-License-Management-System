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
using static System.Net.Mime.MediaTypeNames;

namespace ProjectDrivingLicenseManagementSystem.License
{
    public partial class frmReplacementForLostOrDamagedLicense : Form
    {
        public frmReplacementForLostOrDamagedLicense()
        {
            InitializeComponent();

        }

        int _NewLicenseID = -1;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReplacementForLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            lblCreatedUserName.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = clsApplicationType.Find(Convert.ToInt32((clsApplication.enApplicationTypes)GetReplacementIssueReason())).ApplicationTypeFees.ToString();
            ctrlDriverLicenseInfoWithFilter1.SetFoucs();
        }

      
        int GetReplacementIssueReason()
        {
            return rbReplaceForDamaged.Checked ? 3 : 4;
        }
        void ReplaceLicense()
        {


            clsLicense _License = ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace((clsLicense.enIssueReason)GetReplacementIssueReason(),clsGlobal.CurrentUser.UserId);
          
                if (_License==null)
                {
                MessageBox.Show("Error, License not issued check your Choice  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;}


                MessageBox.Show(" License Replaced Successfully with ID= " + _License.LicenseID, "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblReplacedLicenseID.Text = _License.LicenseID.ToString();
                    lblLicenseReplacementApplicationID.Text = _License.ApplicationID.ToString();
                    llShowNewLicenseInfo.Enabled = true;
                    btnIssueReplacementLicense.Enabled = false;
            _NewLicenseID=_License.LicenseID;
                    return;
               
            
         

        }
        private void rbReplaceForDamaged_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Replacement For Damaged License";
            lblReplacmentTypeTitle.Text = "Replacement For Damaged License";
            lblApplicationFees.Text = clsApplicationType.Find(Convert.ToInt32((clsApplication.enApplicationTypes)GetReplacementIssueReason())).ApplicationTypeFees.ToString();

        }

        private void rbReplaceForLost_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "Replacement For Lost License";
            lblReplacmentTypeTitle.Text = "Replacement For Lost License";
            lblApplicationFees.Text = clsApplicationType.Find(Convert.ToInt32((clsApplication.enApplicationTypes)GetReplacementIssueReason())).ApplicationTypeFees.ToString();


        }


     
        private void btnIssueReplacementLicense_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You sure You want to Issue the  License", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                ReplaceLicense();
            }
        }

        private void ctrlDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {

            _NewLicenseID= obj;

            llShowLicenseHistory.Enabled=(_NewLicenseID != -1);

            if (_NewLicenseID ==-1)
            {
                MessageBox.Show("License with Id=  " + _NewLicenseID +" Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnIssueReplacementLicense.Enabled=false; ;
                return;
            }


            if (!ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive||ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License Is Deactivated or Detained ,Choose Another Active Lessons  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacementLicense.Enabled = false;
                return;

            }
            if (ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License Is  Expired ,You can not replace it ,You can Renew The license ", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnIssueReplacementLicense.Enabled = false;
                llShowLicenseHistory.Enabled = true;
                return;

            }
            lblOldLicenseID.Text = _NewLicenseID.ToString();
            
            btnIssueReplacementLicense.Enabled = true;
            llShowLicenseHistory.Enabled = true;
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(ctrlDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Driver.PersonID);
            frm.ShowDialog();
        }

        private void llShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmDriverLicenseInfo LicenseInfo = new frmDriverLicenseInfo(_NewLicenseID);
            LicenseInfo.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
