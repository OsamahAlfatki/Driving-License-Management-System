using BusinessLayer;
using ProjectDrivingLicenseManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class ctrlScheduleTest : UserControl
    {
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }
       
        enum enMode
        {
            AddNew = 0, Update
        }
        enum enCreationMode
        {
            FirstTime, ScheduleRetakeTest
        }
        enCreationMode _CreationMode = enCreationMode.FirstTime;

        private int _LDLAppID = -1;
        private int _TestAppointmentID = -1;

        private clsLocalDrivingLicenseApplications _LDLApplication;
        private clsTestTypes.enTestType _TestTypeID;
        private clsTestAppointment _TestAppointment;
        enMode _Mode = enMode.AddNew;
        public clsTestTypes.enTestType TestTypeID
        {

            get { return _TestTypeID; }



            set
            {
                _TestTypeID = value;


                switch (_TestTypeID)
                {
                    case clsTestTypes.enTestType.VisitionTest:
                        gbTests.Text = "Vision Test";
                        pbImageByTestType.Image = Resources.Vision_512;
                        break;
                    case clsTestTypes.enTestType.WritenTest:
                        gbTests.Text = "Written Test";
                        pbImageByTestType.Image = Resources.Written_Test_512;
                        break ;
                    case clsTestTypes.enTestType.StreetTest:
                        gbTests.Text = "Street Test";
                        pbImageByTestType.Image = Resources.Schedule_Test_512;
                        break;

                }

            }

        }

         
        private void btnSave_Click(object sender, EventArgs e)
        {

            if(!_HandleRetakeTestConstraint()) 
                return;

            _TestAppointment.LDLAppID = _LDLAppID;
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.IsLocked = false;
            _TestAppointment.UserID = clsGlobal.CurrentUser.UserId;
            _TestAppointment.PaidFees = clsTestTypes.Find(_TestTypeID).TestTypeFees;
            _TestAppointment.AppointmentDate = dtDate.Value;
            if (_TestAppointment.Save())
            {
                MessageBox.Show("Data Saved", "Data Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                dtDate.Enabled = false;
                _Mode = enMode.Update;
                return;
            }

            else
            {
                MessageBox.Show("Error", "Data Not Saved ,Check your inputs or the Application that you choose ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
     
        private bool _HandleHasActiveTestAppoinmentConstraint()
        {
            if(_Mode==enMode.AddNew&&clsLocalDrivingLicenseApplications.IsThereScheduleTestAppoinment(_LDLAppID,_TestTypeID)) 
                {
                    MessageBox.Show("Error: You are already has Test appointment ","Not Allowed",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                return true; ;
                }
                return false;
        }

        private bool _HandlePreviousTestAppointmentConstraint()
        {
            if (!_LDLApplication.DoesPassPreviousTests(TestTypeID))
            {
                lblUserMessage.Text = "Error:You can not schedule test, You should pass pervious Test first";
                dtDate.Enabled=false;
                lblUserMessage.Visible = true;
                btnSave.Enabled = false;
                return false ;
            }
            else
            {
                btnSave.Enabled=true;
                lblUserMessage.Visible=false;
                dtDate.Enabled = true;
            }
            return true; 

        }

        private bool _HandleLookedTestAppointmentConstraint()
        {
            if (clsTestAppointment.IsPersonHasLockedTestAppointmentByTestAppointmentID(_TestAppointmentID))
            {
                lblUserMessage.Text = "Person already sat for the test ,appointment loacked.";
                lblUserMessage.Visible = true;
                dtDate.Enabled = false;
                btnSave.Enabled = false;
                return false ;

            }

            return true;



        }

        private bool _HandleRetakeTestConstraint()
        {
            if (_CreationMode == enCreationMode.FirstTime)
                return true;
               
                clsApplication Application = new clsApplication();

                Application.ApplicationTypeID = (int)clsApplication.enApplicationTypes.RetakeTest;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                Application.ApplicationPersonID = _LDLApplication.ApplicationPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.LastStatusDate = DateTime.Now;
                Application.ApplicationUserID = clsGlobal.CurrentUser.UserId;
               
                if (!Application.Save())
                {
                _TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Error: Faild to create Application ","Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    lblRetakeTestAppointmentApplicationID.Text = Application.ApplicationID.ToString();
                    _TestAppointment.RetakeTestApplicationID = Application.ApplicationID;
                    MessageBox.Show("Data saved Successfully  ", "Sucessed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;

                }

            
        }

        private bool _LoadTestApointmentData()
        {


            _TestAppointment = clsTestAppointment.FindTestAppointmentByAppointmentID(_TestAppointmentID);
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: Test Appointment with ID= " + _TestAppointmentID + "  Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if(DateTime.Compare(DateTime.Now,_TestAppointment.AppointmentDate)<0)
                dtDate.MinDate = DateTime.Now;
            else
            {
                dtDate.MinDate=_TestAppointment.AppointmentDate;
            }

            dtDate.Value=_TestAppointment.AppointmentDate;

            lblFees.Text = _TestAppointment.PaidFees.ToString();
            if (_TestAppointment.RetakeTestApplicationID != -1)
            {
                gbRetakeTestInfo.Enabled = true;
                lblRetakeTestAppointmentApplicationID.Text=_TestAppointment.RetakeTestApplicationID.ToString();
                lblApplicationFees.Text=_TestAppointment.RetakeTestApplicationInfo.Fees.ToString();
                lblApplicationTotalFees.Text=_TestAppointment.PaidFees+_TestAppointment.RetakeTestApplicationInfo.Fees.ToString();
                return true;
            }
            else
            {
                gbRetakeTestInfo.Enabled = false;
                lblRetakeTestAppointmentApplicationID.Text = "N\\A";

            }
            return true;
             
            
        }
        public void LoadInfo( int LDLAppID ,int TestAppointmentID=-1)
        {


            if (TestAppointmentID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode= enMode.Update;
            }
            
            _TestAppointmentID=TestAppointmentID;
            _LDLAppID= LDLAppID;
            dtDate.MinDate = DateTime.Now;

            _LDLApplication=clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationInfoByID( LDLAppID );

            if(_LDLApplication == null)
            {
                MessageBox.Show("Error: Application with ID = " + _LDLAppID + " Not Found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (_LDLApplication.DoesAttendTest(_TestTypeID))
            {
                _CreationMode = enCreationMode.ScheduleRetakeTest;
            }
            else
                _CreationMode = enCreationMode.FirstTime;


            if (_CreationMode == enCreationMode.FirstTime)
            {
                gbRetakeTestInfo.Enabled=false;
                lblTitle.Text = "Schedule Test";
                lblRetakeTestAppointmentApplicationID.Text = "0";
                lblApplicationFees.Text = "0";
            }

            else
            {

                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule  Retake Test";
                lblApplicationFees.Text=clsApplicationType.Find((int)clsApplication.enApplicationTypes.RetakeTest).ApplicationTypeFees.ToString();
                lblRetakeTestAppointmentApplicationID.Text = "N\\A";

            }

            lblLDLAppID.Text=_LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLiscenseClassName.Text = _LDLApplication.LicenseClassInfo.LicenseClassName;
            lblNumberOfTrials.Text=_LDLApplication.TotalTrailsPerTest(_TestTypeID).ToString();
            lblFees.Text=clsTestTypes.Find(_TestTypeID).TestTypeFees.ToString();
            lblName.Text=_LDLApplication.FullName;

            if (_Mode == enMode.AddNew)
            {
                _TestAppointment = new clsTestAppointment();
                lblUserMessage.Visible = false;
                return;
            }

            else
            {
                if (!_LoadTestApointmentData())
                    return;
            }




            if (!_HandleLookedTestAppointmentConstraint())
                return;

            if(!_HandleHasActiveTestAppoinmentConstraint())
                return ;

            if(!_HandlePreviousTestAppointmentConstraint())
                return ;

           


          
            


        }
      
    }


}
