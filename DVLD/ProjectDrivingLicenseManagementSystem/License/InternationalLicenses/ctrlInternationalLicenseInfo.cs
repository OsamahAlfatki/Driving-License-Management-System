using BusinessLayer;
using ProjectDrivingLicenseManagementSystem.Global_Classes;
using ProjectDrivingLicenseManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        private int _InternationalLicenseID = -1;
        private clsInternationalLicense _InternationalLicense;

        public int InterationalLicenseID
        {
            get
            {
                return _InternationalLicenseID;
            }

        }
        private void _LoadPersonImage()
        {



           
            if (_InternationalLicense.DriverInfo.PersonInfo.Gender == 0)
            {
                pbPhoto.Image = Resources.Male_512;
                lblGender.Text = "Male";
            }
            else
            {

                pbPhoto.Image = Resources.Male_512;
                lblGender.Text = "Male";

            }
            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;
            if (File.Exists(ImagePath))
            {
                pbPhoto.Load(ImagePath);
            }
            else
            {
                MessageBox.Show("Error , Image with Path = "+ImagePath+" Not Found ","Image path not Found ",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        public void LoadInfo(int LicenseID)
        {
            _InternationalLicenseID= LicenseID; 
            _InternationalLicense=clsInternationalLicense.FindByLicenseID(LicenseID);
            if (_InternationalLicense == null)
            {
                MessageBox.Show("Error , International License with ID = " + _InternationalLicenseID + " Not Found ", "License Not Found ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblApplicationID.Text=_InternationalLicense.ApplicationID.ToString ();
            lblDateOfBirth.Text = clsFormat.ToShortDateString(_InternationalLicense.DriverInfo.PersonInfo.BirthOfDate);
            lblExpirationDate.Text = clsFormat.ToShortDateString(_InternationalLicense.ExpirationDate);
            lblIssueDate.Text = clsFormat.ToShortDateString(_InternationalLicense.IssueDate);
            lblName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName();
            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblLocalLicenseID.Text=_InternationalLicense.LDLID.ToString();
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblInternationalLicenseID.Text=LicenseID.ToString();
           _LoadPersonImage();
        }
    }
}
