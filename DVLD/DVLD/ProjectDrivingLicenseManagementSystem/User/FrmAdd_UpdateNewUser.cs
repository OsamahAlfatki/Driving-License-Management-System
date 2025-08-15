using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class FrmAdd_UpdateNewUser : Form
    {
        public FrmAdd_UpdateNewUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        enum enMode
        {
            AddNew=0,Update=1
        }
        enMode _Mode;
        clsUser _User;
        private int _UserID = -1;
       public FrmAdd_UpdateNewUser(int UserID)
        {
            InitializeComponent();
            _Mode=enMode.Update;
            _UserID=UserID;
          
        }

        private void _ReSetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblUserMode.Text = "Add New User";
                this.Text = "Add User";
              
                ctrlFindPersonByFilter1.FilterEnabled = true;
                _User = new clsUser();  
                btnSave.Enabled = false;
                tpLoginInfo.Enabled = false;

            }
            else
            {
                this.Text = "Update User";
                lblUserMode.Text = "Update User";
                _User =clsUser.Find(_UserID);
                tpLoginInfo.Enabled = true ;

            }
            tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpPersonInfo"];
            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            chkbIsActive.Checked = true;

        }
        private void _LoadUserData()
        {
          
            if(_User == null)
            {
                MessageBox.Show("Error,No User found with ID = "+_UserID,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                return;
            }
            
                ctrlFindPersonByFilter1.cbFilterPersonDataBy.SelectedIndex = 1;
                ctrlFindPersonByFilter1.LoadPersonInfo(_User.PersonID);
               ctrlFindPersonByFilter1.FilterEnabled = false;
                lblUserID.Text=_User.UserId.ToString();
                txtUserName.Text = _User.UserName.ToString();
                txtPassword.Text = _User.Password.ToString();
                txtConfirmPassword.Text=_User.Password.ToString();
                chkbIsActive.Checked =_User.IsActive;


        }

    

      
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true ;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }
            if (ctrlFindPersonByFilter1.PersonID != -1)
            {

                if (clsUser.IsUserExistByPersonID(ctrlFindPersonByFilter1.PersonID))
                {
                    MessageBox.Show("This Person is Already a User,Choose Another Person ", "" +
                        "Select Another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlFindPersonByFilter1.FilterFocus();
                    return;
                }
                else
                {

                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true ;
                }

               }

            else
            {

                MessageBox.Show("Error,Please select a person ", "not valid select", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFindPersonByFilter1.FilterFocus();
                btnSave.Enabled = false ;
                tpLoginInfo.Enabled = false ;

            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error,inputs not falid check your inputs","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
   
                return;

            }
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = chkbIsActive.Checked;
            _User.PersonID = ctrlFindPersonByFilter1.PersonID;


            if (_User.Save())
            {
                MessageBox.Show("Data Saved Successfully","Data Saved",MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblUserID.Text = _User.UserId.ToString();
                lblUserMode.Text = "Update User";
                this.Text = "Update User";
                _Mode = enMode.Update;
            }
            else
            {
                MessageBox.Show("Data  dose not Saved ", "Data not saved", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAdd_UpdateNewUser_Load(object sender, EventArgs e)
        {
            _ReSetDefualtValues();
            if(_Mode == enMode.Update)
             _LoadUserData();
            
        }

   
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
               // e.Cancel= true;
                errpAddUserOrUpdatesErrors.SetError(txtUserName, "You can not put this field balnk");
                return;
            }
            else
            {
                errpAddUserOrUpdatesErrors.SetError(txtUserName, null);
            }
            if (_Mode == enMode.AddNew) {
                if (clsUser.IsUserExist(txtUserName.Text.Trim()))
                {
                   // e.Cancel =true;
                    errpAddUserOrUpdatesErrors.SetError(txtUserName, "This User name is already used ,choose another one");
                  return ;
                }
                else
                {
                    errpAddUserOrUpdatesErrors.SetError(txtUserName, null);

                }


            }
            

            else
            {
                if (txtUserName.Text != _User.UserName)
                {
                    if (clsUser.IsUserExist(txtUserName.Text.Trim()))
                    {
                       e.Cancel = true;
                        errpAddUserOrUpdatesErrors.SetError(txtUserName, "This User name is already used ,choose another one");
                        return;
                    }

                    else
                    {
                        errpAddUserOrUpdatesErrors.SetError(txtUserName, null);
                    }
                }
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                errpAddUserOrUpdatesErrors.SetError(txtPassword, "You can not put this field balnk");

            }
            else
            {
                errpAddUserOrUpdatesErrors.SetError(txtPassword, null);
            }
        }


        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel= true;
                errpAddUserOrUpdatesErrors.SetError(txtConfirmPassword, "Confirm password should be the same with password");
            }
            else
            {
                errpAddUserOrUpdatesErrors.SetError(txtConfirmPassword, null);

            }
        }

        private void FrmAdd_UpdateNewUser_Activated(object sender, EventArgs e)
        {
            ctrlFindPersonByFilter1.FilterFocus();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
