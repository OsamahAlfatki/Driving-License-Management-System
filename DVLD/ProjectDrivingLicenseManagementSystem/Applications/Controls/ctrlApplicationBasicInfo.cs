using BusinessLayer;
using ProjectDrivingLicenseManagementSystem.Global_Classes;
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
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }
        private int _ApplicationID;
        private clsApplication _Application;

        public int ApplicationID
        {
            get
            {
                return _ApplicationID;
            }
        }


        private void _FillApplicationInfo()
        {
            lblAppID.Text = _Application.ApplicationID.ToString();
            lblApplicationt.Text = _Application.FullName;
            lblStatus.Text = _Application.StatusText();
            lblCreatedUserID.Text = _Application.ApplicationUserID.ToString();
            lblType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblFees.Text = _Application.Fees.ToString();
            lblStatusDate.Text = clsFormat.ToShortDateString(_Application.LastStatusDate);
            lblAppDate.Text = clsFormat.ToShortDateString(_Application.ApplicationDate);


        }
       

        public void LoadApplicationInfo(int AppID)
        {

            _Application = clsApplication.FindBaseApplication(AppID);
            if (_Application == null)
            {
                MessageBox.Show("Error,Application with ID= " + _Application.ApplicationID + " Is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                _FillApplicationInfo();
            }
        }
      
     public void ResetDefualtValues()
        {

            lblAppID.Text = "[????]";
            lblApplicationt.Text = "[????]";
            lblStatus.Text = "[????]";
            lblCreatedUserID.Text = "[????]";
            lblType.Text = "[????]";
            lblFees.Text = "[????]";
            lblStatusDate.Text = "[????]";
            lblAppDate.Text = "[????]";
                               
        }
        private void lklViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPersonDetails frm =new FrmPersonDetails(_Application.ApplicationPersonID);
            frm.ShowDialog();
            _FillApplicationInfo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
