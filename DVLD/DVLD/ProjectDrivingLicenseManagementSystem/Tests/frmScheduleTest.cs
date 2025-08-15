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
    public partial class frmScheduleTest : Form
    {

        public frmScheduleTest()
        {
            InitializeComponent();
          
        }
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _AppointmentID = -1;
        private clsTestTypes.enTestType _TestTypeID;
        public  frmScheduleTest(int LDLAppID,clsTestTypes.enTestType TestTypeID,int AppointmentID=-1)
        {

            InitializeComponent();
            _LocalDrivingLicenseApplicationID= LDLAppID;
            _AppointmentID= AppointmentID;
            _TestTypeID= TestTypeID;
        }
        private void frmScheduleTestOrReschedule_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID,_AppointmentID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
