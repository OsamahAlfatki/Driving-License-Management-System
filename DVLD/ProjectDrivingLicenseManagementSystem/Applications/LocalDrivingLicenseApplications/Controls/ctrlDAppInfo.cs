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
    public partial class ctrlDAppInfo : UserControl
    {

        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        
        public int LocalDrivingLicenseApplicationID { get
            {
                return _LocalDrivingLicenseApplicationID;
            } 
        }
        private int _LicenseID=-1;
        public ctrlDAppInfo()
        {
            InitializeComponent();
        }
        public void LoadLocalDrivingLicenseInfoByID(int LDLAppID)
        {
            _LocalDrivingLicenseApplicationID = LDLAppID;
            _LocalDrivingLicenseApplication=clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationInfoByID(LDLAppID);
            if(_LocalDrivingLicenseApplication == null)
            {
                _ResetDefualtValues();
                MessageBox.Show("Error,Application with ID= " + _LocalDrivingLicenseApplicationID + " Is not found ", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();

        }


        public void LoadLocalDrivingLicenseApplicationInfoByAppID(int AppID)
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationInfoByID(AppID);
            if (_LocalDrivingLicenseApplication == null)
            {
                _ResetDefualtValues();
                MessageBox.Show("Error,Application with ID= " + AppID + " Is not found ", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillLocalDrivingLicenseApplicationInfo();

        }

        private void _ResetDefualtValues()
        {
            lblAppliedForLicense.Text =  "[???]";
            lblAppliedForLicense.Text = "[???]";
            ctrlApplicationBasicInfo1.ResetDefualtValues();
            lblPassedTests.Text = "0/3";
        }
        private void _FillLocalDrivingLicenseApplicationInfo()
        {
            lblAppliedForLicense.Text=clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).LicenseClassName;
            lblDRivingLocalAppID.Text=_LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblPassedTests.Text = _LocalDrivingLicenseApplication.GetPassedTestCount().ToString() + "/3";
            _LicenseID = _LocalDrivingLicenseApplication.GetActiveLicense();
            ctrlApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicenseApplication.ApplicationID);
            llShowLicenseInfo.Enabled = (_LicenseID != -1);
        }
      
     
        private void lklShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationInfoByID(
                Convert.ToInt32(lblDRivingLocalAppID.Text)).PersonInfo.PersonID);
            frm.ShowDialog();
        }

    }
}
