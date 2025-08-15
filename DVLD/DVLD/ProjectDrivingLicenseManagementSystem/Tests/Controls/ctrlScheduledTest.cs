using BusinessLayer;
using ProjectDrivingLicenseManagementSystem.Global_Classes;
using ProjectDrivingLicenseManagementSystem.Properties;
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
    public partial class ctrlScheduledTest : UserControl
    {
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }


        public int _LDLAppID = 0;
        private clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisitionTest;
        private clsLocalDrivingLicenseApplications _LDLApplication;
        private int _TestID = -1;
        private int _TestAppoinmentID;
        private clsTestAppointment _TestAppoinment;

        public clsTestTypes.enTestType TestTypeID
        {

        get { return _TestTypeID; }
            set
            {


                _TestTypeID = value;

                switch (TestTypeID)
                {
                    case clsTestTypes.enTestType.VisitionTest:
                        gbTests.Text = "Vision Test";
                        pbImageByTestType.BackgroundImage = Resources.Vision_512;
                        break;
                    case clsTestTypes.enTestType.WritenTest:
                        gbTests.Text = "Written Test";
                        pbImageByTestType.BackgroundImage = Resources.Written_Test_512;
                        break;
                    case clsTestTypes.enTestType.StreetTest:
                        gbTests.Text = "Street Test";
                        pbImageByTestType.BackgroundImage = Resources.Schedule_Test_512;
                        break;

                }

            }

        }

        public int TestID
        {
            get
            {
                return _TestID;
            }

        }
        public int TestApoinmentID
        {
            get
            {
                return _TestAppoinmentID;
            }
        }
        void _SetApplicationType(int Trials)
        {

            if (Trials > 0)
            {
                
                lblTestType.Text = "Schedule Retake Test";
                return;
            }

            if (Trials == 0)
            {
                lblTestType.Text = "Schedule  Test";

                return;
            }
        }
        public void LoadScheduledTestInfo(int TestApoinmentID)
        {
            _TestAppoinment=clsTestAppointment.FindTestAppointmentByAppointmentID(TestApoinmentID);

            if(_TestAppoinment == null)
            {
                MessageBox.Show("Error: Test Appoinment with ID= " + _TestAppoinmentID + " Not Found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LDLAppID=_TestAppoinment.LDLAppID;

            clsLocalDrivingLicenseApplications _LDLApplication=clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationInfoByID(_LDLAppID);


            if(_LDLApplication == null)
            {
                MessageBox.Show("Error: Local Driving License Application  with ID= " + _LDLAppID + " Not Found ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblLDLAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLiscenseClassName.Text = _LDLApplication.LicenseClassInfo.LicenseClassName;
            lblNumberOfTrials.Text = _LDLApplication.TotalTrailsPerTest(TestTypeID).ToString();
            lblFees.Text = clsTestTypes.Find(TestTypeID).TestTypeFees.ToString();
            lblName.Text = _LDLApplication.FullName;
            lblDate.Text = clsFormat.ToShortDateString(_LDLApplication.ApplicationDate);
            _TestTypeID= _TestAppoinment.TestTypeID;
            _TestID= _TestAppoinment.TestID;
            lblTestID.Text = (_TestAppoinment.TestID != -1) ? _TestAppoinment.TestID.ToString() : "Not Taken Yet";

            _SetApplicationType(_LDLApplication.TotalTrailsPerTest(TestTypeID));
            

        }
    }
}
