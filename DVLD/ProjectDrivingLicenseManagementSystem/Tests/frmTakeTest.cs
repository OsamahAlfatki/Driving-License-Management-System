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
    public partial class frmTakeTest : Form
    {
        public frmTakeTest()
        {
            InitializeComponent();
        }
        private int _TestAppointmentID = -1;

        private clsTest _Test;
        private clsTestTypes.enTestType _TestTypeID;

        public frmTakeTest(int TestAppoinmentID, clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppoinmentID;
            _TestTypeID = TestTypeID;

        }


        bool GetTestResult()
        {
            if (rbFail.Checked)
            {
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Save? After that you can not change the Pass/Fail After You Save", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
              if(!string.IsNullOrEmpty(txtNotes.Text))
                _Test.Notes = txtNotes.Text;

                _Test.TestAppointmentID = _TestAppointmentID;
                _Test.TestResult = GetTestResult();
                _Test.UserID = clsGlobal.CurrentUser.UserId;
            
                if (_Test.Save())
                {
                   ctrlScheduledTest1.lblTestID.Text = _Test.TestID.ToString();
                    MessageBox.Show("Data Saved Successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   btnSave.Enabled = false;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Data not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            




        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.TestTypeID = _TestTypeID;
            ctrlScheduledTest1.LoadScheduledTestInfo(_TestAppointmentID);

            if (_TestAppointmentID == -1)
            {
                btnSave.Enabled = false;

            }
            else
            {
                btnSave.Enabled = true;
            }

            if (ctrlScheduledTest1.TestID == -1)
            {
                _Test = new clsTest();

                return;
            }



            _Test = clsTest.Find(ctrlScheduledTest1.TestID);
            if (_Test != null)
            {
                if (_Test.TestResult == true)
                    rbPass.Checked = true;
                else
                {
                    rbFail.Checked = true;
                }
                txtNotes.Text=_Test.Notes;
                txtNotes.Enabled = false;
                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPass.Enabled = false;
            }
        }

       
    }
}
