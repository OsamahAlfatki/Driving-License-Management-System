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
using System.Security.Cryptography;
using DVLDSettings;

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class frmChangePassword : Form
    {
        private int _UserID = -1;
        private clsUser _User;
       public frmChangePassword(int  UserID)
        {
            InitializeComponent();
            _UserID=UserID;
        }

        private void _LoadUserInfo()
        {
            _User = clsUser.Find(_UserID);
            if (_User == null) {
                MessageBox.Show("Erorr,User with ID= " + _UserID + " Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                return;
            }

            ctrlUserCardInfo1.LoadUserInfo(_User.UserId);

        }
        private void _ResetDefualtValues()
        {
            txtConfirmPassword.Text = "";
            txtNewPassword.Text = "";
            txtCurrentPassword.Text = "";
            txtCurrentPassword.Focus();
        }
     

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error,You can not save data, Check Red icons to see the error  ","Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtConfirmPassword.Text;
                if (_User.Save())
                {
                    MessageBox.Show("Password changed  Successfully","Data Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    _ResetDefualtValues();
                clsGlobal.RemebrUserByUserNameAndPassword("", "");
                return;
                }
                else
                {
                    MessageBox.Show("Data Not ", "Data dose not  Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                e.Cancel = true;
                errorPChangePasswordCondition.SetError(txtCurrentPassword, "This Fieled is required");
                return;
            }
            else
            {
                
                errorPChangePasswordCondition.SetError(txtCurrentPassword, null);
            }
            if (clsSettings.EncryptPasswordByHashing( txtCurrentPassword.Text) != _User.Password)
            {
                e.Cancel=true;
                errorPChangePasswordCondition.SetError(txtCurrentPassword, "Current Password is Wrong");
                return;
            }
            else
            {
                errorPChangePasswordCondition.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                errorPChangePasswordCondition.SetError(txtNewPassword, "This Fieled is required");
                return;
            }
            else
            {
                errorPChangePasswordCondition.SetError(txtNewPassword, null);
            }


        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                errorPChangePasswordCondition.SetError(txtConfirmPassword, "Confirm Password should be the same with New Password");
                return;

            }
            else
            {
                errorPChangePasswordCondition.SetError(txtConfirmPassword, null);
            }


        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            _LoadUserInfo();
        }
    }
}
