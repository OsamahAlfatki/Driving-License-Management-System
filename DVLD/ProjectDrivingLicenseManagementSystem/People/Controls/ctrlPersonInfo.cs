using ProjectDrivingLicenseManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Windows.Forms.VisualStyles;
using ProjectDrivingLicenseManagementSystem.Properties;
using ProjectDrivingLicenseManagementSystem.License;
using BusinessLayer;
namespace ProjectDrivingLicenseManagementSystem
{
    public partial class ctrlPersonInfo : UserControl
    {
        public ctrlPersonInfo()
        {
            InitializeComponent();
        }
        clsPerson _Person;
        enum enGender
        {
            Male=0,Female=1
        }

        public int? PersonID
        {
            get
            {
               return  _Person.PersonID;
            }
        }

        public clsPerson SelectedPerson
        {
            get
            {
                return _Person;
            }
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person=clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("Error,Person With National No= "+NationalNo+" Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
            

        }
        public void LoadPersonInfo(int? PersonID)
        {

            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("Error,Person With PersonID=" + PersonID + "Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();

        }
      public void ResetPersonInfo()
        {
            _ResetPersonInfo();
        }
        private void _ResetPersonInfo()
        {
            lblPersonID.Text = "-1";
            lblAddress.Text = "[???]";
            lblCountry.Text = "[???]";
            lblEmail.Text = "[???]";
            lblName.Text = "[???]";
            lblNationalNo.Text = "[???]";
            pbGender.Image = Resources.Man_32;
            lblGender.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            llEditPersonInfo.Visible = false;
            
        }
        private void _FillPersonImage()
        {
            if ((enGender)_Person.Gender == enGender.Male)
            {
                pbPhoto.Image = Resources.Male_512;
                pbGender.Image = Resources.Man_32;

            }
            else
            {
                pbPhoto.Image = Resources.Female_512;
                pbGender.Image = Resources.Woman_32;

            }

            if (_Person.ImagePath != "")
            {
                if (File.Exists(_Person.ImagePath))
                {
                    pbPhoto.ImageLocation = _Person.ImagePath;
                }
                else
                {
                    
                    
                    MessageBox.Show("Error,Can not find Image= " + _Person.ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }
        private void _FillPersonInfo()
        {
            llEditPersonInfo.Enabled = true;
            lblPersonID.Text = Convert.ToString(_Person.PersonID);
            lblNationalNo.Text = _Person.NationalNo;
            lblName.Text = _Person.FullName();

            lblGender.Text = Convert.ToString((enGender)_Person.Gender);
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblAddress.Text = _Person.Address;
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblDateOfBirth.Text = _Person.BirthOfDate.ToShortDateString();

            _FillPersonImage();

        }
    
        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAdd_EditPerson frmAdd_EditPerson = new FrmAdd_EditPerson(_Person.PersonID);
            frmAdd_EditPerson.ShowDialog();

            LoadPersonInfo(_Person.PersonID);

        }

    }
}
