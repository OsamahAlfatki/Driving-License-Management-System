using BusinessLayer;
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
using DVLDSettings;
using System.Diagnostics;

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
            
        }
       
           private int _LogCounter = 0;

        private void btnClose_Click(object sender, EventArgs e)
     {
       this.Close();
     }

    
        private void btnLogin_Click(object sender, EventArgs e)
        {


            if(string.IsNullOrEmpty(txtUserName.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {

                MessageBox.Show("Invalid ,You should not put any field empty", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (_LogCounter == 3)
            {
                MessageBox.Show("You are Locked you try 3 times to log  ,try next time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

              return ;
            }

            clsUser _User= clsUser.Find(txtUserName.Text,txtPassword.Text);
            if (_User!=null)
            {
                if (_User.IsActive)
                {
                    if (chkbRememberMe.Checked)
                    {
                        
                        clsGlobal.RemebrUserByUserNameAndPassword(txtUserName.Text, txtPassword.Text);

                    }
                    else
                    {
                        clsGlobal.RemebrUserByUserNameAndPassword("", "");

                    }

                    clsGlobal.CurrentUser = _User;
                    frmMainForm frmMainForm = new frmMainForm(this);
                    this.Hide();

                    frmMainForm.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Your Account Is not Active Please Contact Your Admin Username ", "Account Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
            }
        
            else
            {
                _LogCounter++;
                if (_LogCounter == 3)
                {
                    //MessageBox.Show("You are Locked you try 3 times to log  ,try next time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    clsSettings.LogEvents(EventLogEntryType.FailureAudit,$"User : {clsGlobal.CurrentUser.UserName}  had tried 3 faild attemps to log to the system");
                   // btnLogin.Enabled = false;
                   
                }
                MessageBox.Show("Invalid Username or password","Wrong Credintials",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUserName.Focus();
            }
           
        }

        private void frmLoginScreen_Load(object sender, EventArgs e)
        {
            string Password = "", UserName = "";

            if(clsGlobal.GetStoredCredetional(ref UserName,ref Password))
            {
                txtPassword.Text = Password;
                txtUserName.Text = UserName;
                chkbRememberMe.Checked = true;
            }
            else
            {
                chkbRememberMe.Checked = false;

            }
        }

    }
}
