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

namespace ProjectDrivingLicenseManagementSystem.User
{
    public partial class ctrlUserCardInfo : UserControl
    {

        private clsUser _User;
        private int _UserID = -1;
        public int UserID
        {
            get
            {
                return _UserID;
            }
        }

        public ctrlUserCardInfo()
        {
            InitializeComponent();
        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User=clsUser.Find(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("Error ,User with ID ="+_UserID,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }

        private void _FillUserInfo()
        {
            if (_User != null)
            {
                lblUserID.Text = _User.UserId.ToString();
                lblUsername.Text = _User.UserName.ToString();
                lblIsActive.Text = (_User.IsActive == true) ? "Yes" : "No";
                ctrlPersonInfo1.LoadPersonInfo(_User.PersonID);
            }
            else
            {
                _ResetPersonInfo();
            }
        }

        private void _ResetPersonInfo()
        {
            
                lblUserID.Text =   "[???]";
                lblUsername.Text = "[???]";
                lblIsActive.Text = "[???]";
                ctrlPersonInfo1.ResetPersonInfo();
            
        }
    }
}
