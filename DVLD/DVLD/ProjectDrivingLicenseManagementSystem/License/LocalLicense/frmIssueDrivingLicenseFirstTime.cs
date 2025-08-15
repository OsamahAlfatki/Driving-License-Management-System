using BusinessLayer;
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
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        public frmIssueDrivingLicenseFirstTime()
        {
            InitializeComponent();
        }
        private int _LDLAppID = -1;
        private clsLocalDrivingLicenseApplications _LDLApplication;
           public frmIssueDrivingLicenseFirstTime(int LDLAPPID)
        {
            InitializeComponent();
       _LDLAppID= LDLAPPID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueLicense_Click(object sender, EventArgs e)

        {

            int LicenseID = _LDLApplication.IssueDrivingLicenseForTheFirstTime(txtNotes.Text, clsGlobal.CurrentUser.UserId);
            if (LicenseID!=-1)
            {
                MessageBox.Show("License Issued Successfully with LicenseID=" + LicenseID, "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            MessageBox.Show("License Not Issued Check Your Select " , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmIssueDrivingLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LDLApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationInfoByID(_LDLAppID);

            if (_LDLApplication == null)
            {

                MessageBox.Show("Error: Application with ID = " + _LDLAppID + " Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!_LDLApplication.PassedAllTest())
            {

                MessageBox.Show("Error: You can not Issue License , Application Should Passed All Tests " , "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            int LicenseID = _LDLApplication.GetActiveLicense();
            if (LicenseID != -1)
            {
                MessageBox.Show("Error: You can not Issue License , Person Already Have License with ID= "+LicenseID , "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlDAppInfo1.LoadLocalDrivingLicenseInfoByID(_LDLAppID);
        }
    }
}
