using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class frmListTestAppointments : Form
    {
        public frmListTestAppointments()
        {
            InitializeComponent();
        }
        private DataTable _dtLicenseTestAppointments;
       
       private int _LDLAppID = -1;
        clsTestTypes.enTestType _TestTypeID=clsTestTypes.enTestType.VisitionTest;
        public frmListTestAppointments(int LDLAPPID, clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            this._LDLAppID = LDLAPPID;
            this._TestTypeID = TestTypeID;
           
        }

        
     
        private void _SetTestTypeImageAndTitle() {

            switch (_TestTypeID) {
                case clsTestTypes.enTestType.VisitionTest:
                lblTestTypeTitle.Text = "Vision Test Appointment";
                this.Text = lblTestTypeTitle.Text;
                pbTestTypeImage.BackgroundImage = Properties.Resources.Vision_Test_32;
                return;

            case clsTestTypes.enTestType.WritenTest:

                lblTestTypeTitle.Text = "Written Test Appointment";
                this.Text = lblTestTypeTitle.Text;
                pbTestTypeImage.BackgroundImage = Properties.Resources.Written_Test_512;
                return;


            case clsTestTypes.enTestType.StreetTest:
                lblTestTypeTitle.Text = "Street Test Appointment";
                this.Text = lblTestTypeTitle.Text;
                pbTestTypeImage.BackgroundImage = Properties.Resources.driving_test_512;
                return;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnScheduleTestOrRetakeTest_Click(object sender, EventArgs e)
        {
            if (clsLocalDrivingLicenseApplications.IsThereScheduleTestAppoinment(_LDLAppID, _TestTypeID))
            {
                MessageBox.Show("Person Already has test appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsLocalDrivingLicenseApplications.DoesPassedTestType(_LDLAppID,_TestTypeID))
            {
                MessageBox.Show("Person Passed test Already ,You can not add Appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmScheduleTest ScheduleTestOrReschedule = new frmScheduleTest( _LDLAppID,_TestTypeID);
            ScheduleTestOrReschedule.ShowDialog();  
            frmListTestAppointments_Load(null, null);


        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {

           
            
               
                frmScheduleTest ScheduleTestOrReschedule = new frmScheduleTest(_LDLAppID,_TestTypeID,Convert.ToInt32(dgvAppointmentsList.CurrentRow.Cells[0].Value));
                ScheduleTestOrReschedule.ShowDialog();
                frmListTestAppointments_Load(null, null);


            
        }

        private void cmsTakeTest_Click(object sender, EventArgs e)
        
        {
            frmTakeTest TakeTest = new frmTakeTest(Convert.ToInt32(dgvAppointmentsList.CurrentRow.Cells[0].Value), _TestTypeID);
            TakeTest.ShowDialog();
            frmListTestAppointments_Load(null,null);
        }

        private void cmsTestAppointmentsProperties_Opening(object sender, CancelEventArgs e)
        {
            if (clsTestAppointment.IsPersonHasLockedTestAppointmentByTestAppointmentID(Convert.ToInt32(dgvAppointmentsList.CurrentRow.Cells[0].Value))){
                cmsTakeTest.Enabled = false;
                return;
            }
            cmsTakeTest.Enabled = true;


        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {

            ctrlDAppInfo1.LoadLocalDrivingLicenseInfoByID(_LDLAppID);
            _dtLicenseTestAppointments= clsTestAppointment.GetApplicationTestAppointmentperTestType(_LDLAppID, (int)_TestTypeID);

            if (_dtLicenseTestAppointments != null)
            {
                dgvAppointmentsList.DataSource = _dtLicenseTestAppointments;
                lblNumberOfRecords.Text = dgvAppointmentsList.RowCount.ToString();


                dgvAppointmentsList.Columns[0].HeaderText = "Test Appointment ID";
                dgvAppointmentsList.Columns[0].Width = 100;
                 dgvAppointmentsList.Columns[1].HeaderText = "Appointment Date";
                dgvAppointmentsList.Columns[1].Width = 150;
                 dgvAppointmentsList.Columns[2].HeaderText = "Paid Fees";
                dgvAppointmentsList.Columns[2].Width = 100;
                 dgvAppointmentsList.Columns[3].HeaderText = "Is Locked";
                dgvAppointmentsList.Columns[3].Width = 80;
                

            }

            
        }
    }
}
