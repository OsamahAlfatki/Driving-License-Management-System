using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class frmListLocalDrivingLicenseApplication : Form
    {
        public frmListLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }
        DataTable _dtLDLApplications;

       
        private clsLocalDrivingLicenseApplications _LDLApplication;

        private void _LoadData()
        {
            _dtLDLApplications = clsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplication();
            cbManageLAppFilterTypes.SelectedIndex = 0;
            if(_dtLDLApplications != null)
            {
                dgvManageLocalDrivingLicenseApplications.DataSource = _dtLDLApplications;
                lblNumberOfRecords.Text=dgvManageLocalDrivingLicenseApplications.Rows.Count.ToString();

                dgvManageLocalDrivingLicenseApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvManageLocalDrivingLicenseApplications.Columns[0].Width = 120;
                dgvManageLocalDrivingLicenseApplications.Columns[1].HeaderText = "Driving Class";
                dgvManageLocalDrivingLicenseApplications.Columns[1].Width = 220;
                dgvManageLocalDrivingLicenseApplications.Columns[2].HeaderText = "NationalNo";
                dgvManageLocalDrivingLicenseApplications.Columns[2].Width = 150;
                dgvManageLocalDrivingLicenseApplications.Columns[3].HeaderText = "Full name";
                dgvManageLocalDrivingLicenseApplications.Columns[3].Width = 350;
                dgvManageLocalDrivingLicenseApplications.Columns[4].HeaderText = "Application Date";
                dgvManageLocalDrivingLicenseApplications.Columns[4].Width = 150;
                dgvManageLocalDrivingLicenseApplications.Columns[5].HeaderText = "Passed Tests";
                dgvManageLocalDrivingLicenseApplications.Columns[5].Width= 50;
                dgvManageLocalDrivingLicenseApplications.Columns[6].HeaderText = "Status";
                dgvManageLocalDrivingLicenseApplications.Columns[6].Width = 100;
                
            }
        }
    
        private void frmManageLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _LoadData();

            
        }
       
        private void _PerformFilterOperations()
        {
            string FilterColumn = "";
            switch (cbManageLAppFilterTypes.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Status":
                    cbStatusFilterType.Visible = true;
                    cbStatusFilterType.SelectedIndex = 0;
                    break;
                default:
                    break;

            }

            if (cbManageLAppFilterTypes.Text!= "L.D.L.AppID" && FilterColumn != "")
            {
                _dtLDLApplications.DefaultView.RowFilter=string.Format("[{0}] like '{1}%'",FilterColumn,txtFilterSerach.Text);
                lblNumberOfRecords.Text = dgvManageLocalDrivingLicenseApplications.Rows.Count.ToString();

            }
            else
            {
                _dtLDLApplications.DefaultView.RowFilter=string.Format("[{0}] = {1}",FilterColumn,(txtFilterSerach.Text));
                lblNumberOfRecords.Text = dgvManageLocalDrivingLicenseApplications.Rows.Count.ToString();
            }


        }

     
        
        private void cbManageLAppFilterTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterSerach.Visible = (cbManageLAppFilterTypes.Text != "None" && cbManageLAppFilterTypes.Text != "Status");
            if (cbManageLAppFilterTypes.Text == "None")
            {
                _dtLDLApplications.DefaultView.RowFilter = null;
                lblNumberOfRecords.Text = dgvManageLocalDrivingLicenseApplications.Rows.Count.ToString();
                return;

            }

            _PerformFilterOperations();
           


        }
        private void _FilterApplicationByStatus()

        {

            string FilterValue = "New", FilterColumn = "Status";
            switch (cbStatusFilterType.Text)
            {

                case "New":
                    FilterValue = "New";
                    break;
                case "Canceled":
                    FilterValue="Cancelled";
                    break;
                case "Completed":
               FilterValue ="Completed";
                    break;
                    default :
                    FilterValue = "";
                    break;
            }

            _dtLDLApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}",FilterColumn,FilterValue);



        }
       
     

        private void cbStatusFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {

            _FilterApplicationByStatus();
        }

        private void btnAddNewLocalDVApp_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication AddNewLDLApp=new frmAddUpdateLocalDrivingLicenseApplication(
                );
            AddNewLDLApp.ShowDialog();
            frmManageLocalDrivingLicenseApplication_Load(null,null);
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure You want to cancel this Application ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            _LDLApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationInfoByID(Convert.ToInt32(dgvManageLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value));
            if (_LDLApplication != null)
            {
                if (_LDLApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManageLocalDrivingLicenseApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Application not Cancelled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }
      
        private void cmsManageLocalLicenseApplications_Opening(object sender, CancelEventArgs e)
        {
           int LocalDrivingLicenseApplicationID = (int)dgvManageLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value;
            _LDLApplication=clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationInfoByID(LocalDrivingLicenseApplicationID);
            int TotalPassedTests= (int)dgvManageLocalDrivingLicenseApplications.CurrentRow.Cells[5].Value;

            bool IsLicesneExist = _LDLApplication.IsIssuedLicense();
           
            editApplicationToolStripMenuItem.Enabled = (_LDLApplication.ApplicationStatus == clsLocalDrivingLicenseApplications.enApplicationStatus.New);
            cancelApplicationToolStripMenuItem.Enabled = (_LDLApplication.ApplicationStatus == clsLocalDrivingLicenseApplications.enApplicationStatus.New);

            deleteApplicationToolStripMenuItem.Enabled = (!IsLicesneExist);

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && (_LDLApplication.ApplicationStatus == clsLocalDrivingLicenseApplications.enApplicationStatus.New);


            bool DoesPassVistionTest = _LDLApplication.DoesPassedTestType(clsTestTypes.enTestType.VisitionTest);
            bool DoesPassWritenTest = _LDLApplication.DoesPassedTestType(clsTestTypes.enTestType.WritenTest);
            bool DoesPassStreetTest = _LDLApplication.DoesPassedTestType(clsTestTypes.enTestType.StreetTest);

            showLicenseToolStripMenuItem.Enabled =IsLicesneExist;
            showPersonHistoryLicenseToolStripMenuItem.Enabled = IsLicesneExist;
            scheduleTestToolStripMenuItem.Enabled=((TotalPassedTests<3)&&!IsLicesneExist&&_LDLApplication.ApplicationStatus==clsLocalDrivingLicenseApplications.enApplicationStatus.New);
            if (scheduleTestToolStripMenuItem.Enabled)
            {
                ScheduleVisionTest.Enabled = !DoesPassVistionTest;
                scheduleWrittenTest.Enabled = DoesPassVistionTest && !DoesPassWritenTest;
                ScheduleStreetTest.Enabled = DoesPassVistionTest && DoesPassWritenTest;
            }

        }

        private void ScheduleVisionTest_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestTypes.enTestType.VisitionTest);

            frmManageLocalDrivingLicenseApplication_Load(null, null);

        }

        private void scheduleWrittenTest_Click(object sender, EventArgs e)
        {

       
            _ScheduleTest(clsTestTypes.enTestType.WritenTest);
            frmManageLocalDrivingLicenseApplication_Load(null, null);

        }

        private void _ScheduleTest(clsTestTypes.enTestType TestTypeID)
        {
            frmListTestAppointments frm = new frmListTestAppointments((int)dgvManageLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value, TestTypeID);
            frm.ShowDialog();
        }
        private void ScheduleStreetTest_Click(object sender, EventArgs e)
        {

        
            _ScheduleTest(clsTestTypes.enTestType.StreetTest);
            frmManageLocalDrivingLicenseApplication_Load(null, null);

        }

     

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            frmIssueDrivingLicenseFirstTime IssueDrivingLicenseFirstTime = new frmIssueDrivingLicenseFirstTime(
                Convert.ToInt32(dgvManageLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value));
            IssueDrivingLicenseFirstTime.ShowDialog();
            frmManageLocalDrivingLicenseApplication_Load(null, null);
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication((int)dgvManageLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageLocalDrivingLicenseApplication_Load(null,null);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LicenseID = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationInfoByID((int)dgvManageLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value).GetActiveLicense();


            if (LicenseID != -1)
            {
                frmDriverLicenseInfo DriverLicenseInfo = new frmDriverLicenseInfo(LicenseID);
                DriverLicenseInfo.ShowDialog();
            }

            else
            {
                MessageBox.Show("Error: License Not found","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void showPersonHistoryLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonLicenseHistory licenseHistory = new frmPersonLicenseHistory(clsPerson.Find(dgvManageLocalDrivingLicenseApplications.CurrentRow.Cells[2].Value.ToString()).PersonID);
            licenseHistory.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            frmApplicationInfoLocalDrivingLicense frmApplicationInfoLocalDrivingLicense =
               new frmApplicationInfoLocalDrivingLicense(Convert.ToInt32(dgvManageLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value));
            frmApplicationInfoLocalDrivingLicense.ShowDialog();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You sure You want to Delete this Application ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            _LDLApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationInfoByID((int)dgvManageLocalDrivingLicenseApplications.CurrentRow.Cells[0].Value);

            if (_LDLApplication != null)
            {
                if (_LDLApplication.Delete()) 

                {
                    MessageBox.Show("Application Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManageLocalDrivingLicenseApplication_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Application not Deleted ,Because there is Data Linked to it ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

           
        }

        private void txtFilterSerach_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterSerach.Text))
            {
                _dtLDLApplications.DefaultView.RowFilter= null;
                return;
            }
            _PerformFilterOperations();

        }

        private void txtFilterSerach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbManageLAppFilterTypes.Text=="L.D.L.AppID")
            e.Handled = !char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar);
        }
    }
}
