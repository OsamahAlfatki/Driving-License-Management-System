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
using System.IO;

namespace ProjectDrivingLicenseManagementSystem.License.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        private int _LicenseID = -1;
      private  clsLicense _License;

        public int LicenseID
        {
            get
            {
                return _LicenseID;
            }
        }


        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return _License;
            }

        }
        public void ResetDefualtValues()
        {

            lblFullName.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblLicenseID.Text = "[???]";
            lblDriverID.Text = "[???]";
            lblClass.Text = "[???]";
            lblIsActive.Text = "[???]";
            lblIsDetained.Text = "[???]";
            lblIssueReason.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            lblExpirationDate.Text = "[???]";
            lblIssueDate.Text = "[???]";
        }
        private void _LoadPersonImage()
        {
            if (_License.Driver.PersonInfo.Gender == 0)
            {
                lblGendor.Text = "Male";
                pbGendor.Image = Resources.person_boy;
                pbPersonImage.Image = Resources.Male_512;
            }
            else
            {

                lblGendor.Text = "Female";
                pbGendor.Image = Resources.Woman_32;

                pbPersonImage.Image = Resources.Female_512;
            }
            string ImagePath = _License.Driver.PersonInfo.ImagePath;
            if (File.Exists(ImagePath))
            {
                if (ImagePath != "")
                {
                    pbPersonImage.ImageLocation = ImagePath;
                    pbPersonImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show("Could not find Person Image with ImagePath = " + ImagePath + "  Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }



        }
        public void LoacLicenseInfo(int LicenseID)
        {
            _LicenseID=LicenseID;
             _License = clsLicense.Find(LicenseID);

            if (_License == null)
            {
                MessageBox.Show("Error : License with ID= " + LicenseID + "  Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefualtValues();
                return;
            }
          
                lblFullName.Text = _License.Driver.PersonInfo.FullName();
                lblNationalNo.Text = _License.Driver.PersonInfo.NationalNo;
                lblLicenseID.Text = _License.LicenseID.ToString();
                lblDriverID.Text = _License.DriverID.ToString();
                lblClass.Text = _License.LicenseClassInfo.LicenseClassName;
                lblIsActive.Text = _License.IsActive == true ? "Yes" : "No";
                lblIsDetained.Text = _License.IsDetained == true ? "Yes" : "No";
                lblIssueReason.Text = _License.IssueReasonText;
                lblDateOfBirth.Text = clsFormat.ToShortDateString(_License.Driver.PersonInfo.BirthOfDate);
                lblExpirationDate.Text = clsFormat.ToShortDateString(_License.ExpirationDate);
                lblIssueDate.Text = clsFormat.ToShortDateString(_License.IssueDate);
               lblNotes.Text= _License.Notes;
            _LoadPersonImage();
        }
      
    }
}
