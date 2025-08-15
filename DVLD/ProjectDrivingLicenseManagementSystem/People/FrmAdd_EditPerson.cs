using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ProjectDrivingLicenseManagementSystem.Properties;
using ProjectDrivingLicenseManagementSystem.Global_Classes;
namespace ProjectDrivingLicenseManagementSystem
{
    public partial class FrmAdd_EditPerson : Form
    {
        public delegate void DataBackEventHandler(object Sender, int? PersonID);
        public event DataBackEventHandler DataBack;

        enum enGender
        {
            Male = 0, Female
        }
        clsPerson _Person;
        enGender _Gender;
        int? _PersonID;

        enum enMode
        {
            AddNew = 0, Update = 1
        }
        enMode _Mode = enMode.AddNew;

        public FrmAdd_EditPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public FrmAdd_EditPerson(int? PersonID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _PersonID = PersonID;

        }
        private void _SetDefualtValues()
        {

            _LoadCountriesData();
            if (_Mode == enMode.AddNew)
            {
                _Person = new clsPerson();
                lblMode.Text = "Add New Person";
            }
            else
            {
                lblMode.Text = "Update  Person";

            }
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtNationalNo.Text = "";
            if (rbGenderOptionFemale.Checked)
            {
                pbPersonImage.Image = Resources.Female_512;
            }
            else
            {
                pbPersonImage.Image = Resources.Male_512;
            }

            cbPersonCountry.SelectedIndex = cbPersonCountry.FindString("Yemen");
            llRemovePersonImage.Visible = (pbPersonImage.ImageLocation != null);
            dtDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtDateOfBirth.Value = dtDateOfBirth.MaxDate;
            txtFirstName.Focus();
            llRemovePersonImage.Visible = false;
        }
        private void _LoadPersonData()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("Person with ID=" + _PersonID + " Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtFirstName.Text = _Person.FirstName;
            txtNationalNo.Text = _Person.NationalNo;
            txtLastName.Text = _Person.LastName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            cbPersonCountry.SelectedIndex = cbPersonCountry.FindString(_Person._Countryinfo.CountryName);
            txtEmail.Text = _Person.Email;
            dtDateOfBirth.Value = _Person.BirthOfDate;
            lblPersonID.Text = _Person.PersonID.ToString();
            if (File.Exists(_Person.ImagePath))
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;

            }
            else
            {

                if (_Person.Gender == Convert.ToInt16(enGender.Female))
                {
                    rbGenderOptionFemale.Checked = true;
                    pbPersonImage.Image = Resources.Female_512;
                }
                else
                {
                    rbGenderOptionMale.Checked = true;
                    pbPersonImage.Image = Resources.Male_512;

                }
                return;
            }
            llRemovePersonImage.Visible = (pbPersonImage.ImageLocation != null);

        }

        private void FrmAdd_EditPerson_Load(object sender, EventArgs e)
        {
            _SetDefualtValues();
            if (_Mode == enMode.Update)
                _LoadData();
        }




        private void _LoadData()
        {
            _SetDefualtValues();
            _LoadPersonData();

        }


        private void _LoadCountriesData()
        {
            DataTable dataTable = new DataTable();
            dataTable = clsPerson.GetAllCountriesList();
            foreach (DataRow row in dataTable.Rows) {
                cbPersonCountry.Items.Add(row["CountryName"]);
            }
            cbPersonCountry.SelectedIndex = 20;

        }

        private bool _HandlePersonImage()
        {
            string SoucreFile = "";
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != null)
                {
                    try
                    {

                        File.Delete(_Person.ImagePath);
                    }
                    catch (Exception )
                    {


                    }
                }
                if (pbPersonImage.ImageLocation != null)
                {
                    SoucreFile = pbPersonImage.ImageLocation.ToString();
                    if (clsUtil.CopyImagesInProject(ref SoucreFile))
                    {
                        _Person.ImagePath = SoucreFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
            
            }
            return true;

        }
    
  
      
       
        private void rbGenderOptionMale_CheckedChanged(object sender, EventArgs e)
        {
            _Gender = enGender.Male;
            if (pbPersonImage.ImageLocation==null)
            {
                pbPersonImage.BackgroundImage = Resources.Male_512;
            }
        }

        private void rbGenderOptionFemale_CheckedChanged(object sender, EventArgs e)
        {
            _Gender = enGender.Female;
            if (pbPersonImage.ImageLocation==null)
            {
                pbPersonImage.BackgroundImage = Resources.Female_512;
            }

        }

        private void linkSetPersonImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Select an Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif"

            };
         

            openFileDialog1.FileName = @"C:\Users\asus\Pictures";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               pbPersonImage.ImageLocation=openFileDialog1.FileName;
                llRemovePersonImage.Visible = true;
                return;

            }


        }

        private void LblkRemovePersonImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            if (rbGenderOptionFemale.Checked)
            {
                pbPersonImage.Image=Resources.Female_512;
            }
            else
            {
                pbPersonImage.Image = Resources.Male_512;

            }
            llRemovePersonImage.Visible = false;
        }


        private void btnSave_Click_1(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error in data input fileds check your fields,check red symbol", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_HandlePersonImage())
                return;

            _Person.NationalNo = txtNationalNo.Text;
            _Person.Email = string.IsNullOrEmpty( txtEmail.Text)?null:txtEmail.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = string.IsNullOrEmpty(txtThirdName.Text) ? null : txtEmail.Text;
            _Person.LastName = txtLastName.Text;

            _Person.BirthOfDate = dtDateOfBirth.Value;
            _Person.Phone = txtPhone.Text;
            _Person.Gender = Convert.ToInt16(_Gender);
            _Person.Address = txtAddress.Text;
            _Person.NationalityCountryID = clsCountry.Find(cbPersonCountry.Text).ID;


            if (pbPersonImage.ImageLocation != null)
            {
                _Person.ImagePath = pbPersonImage.ImageLocation;
            }
            else
            {
                _Person.ImagePath = null;
            }


            if (Convert.ToBoolean(_Person.Save()))
            {
                MessageBox.Show("Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblMode.Text = "Update Person";
                _Mode = enMode.Update;
                lblPersonID.Text = _Person.PersonID.ToString();
               DataBack?.Invoke(this,_Person.PersonID);

            }
            else
            {
                MessageBox.Show(" Data not saved !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            TextBox Text = (TextBox)sender;
            if (string.IsNullOrEmpty(Text.Text.Trim()))
            {
                e.Cancel = true;
                errorPForComponents.SetError(Text, "This Fileld Is requierd");
                return;
            }
            else
            {
                e.Cancel = false;
                errorPForComponents.SetError(Text,null);
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            if(txtEmail.Text.Trim().Length == 0)
            {
                
                return;
            }
            
            
                if (!clsValidate.ValidateEmail(txtEmail.Text.Trim()))
                {
                e.Cancel= true;
                    errorPForComponents.SetError(txtEmail, "Invalid Email");
                    return;
                }
                else
                {
                    errorPForComponents.SetError(txtEmail, null);
                }
            
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorPForComponents.SetError(txtNationalNo, "This Fileld Is requierd");
                return;
            }
            else
            {
                errorPForComponents.SetError(txtNationalNo, null);
            }


            if (clsPerson.IsPersonExist(txtNationalNo.Text.Trim()) && txtNationalNo.Text != _Person.NationalNo.Trim())
            {

                e.Cancel = true;
                errorPForComponents.SetError(txtNationalNo, "This NationalNumber is Already Used,Choose another one");
                return;
            }
            else
            {
                errorPForComponents.SetError(txtNationalNo, null);
            }


        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsNumber(e.KeyChar) && e.KeyChar != (char)8;
        }
    }
}

