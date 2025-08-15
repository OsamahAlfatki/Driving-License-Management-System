using ProjectDrivingLicenseManagementSystem;
using ProjectDrivingLicenseManagementSystem.License;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public partial class frmMainForm : Form
    {
        private frmLoginScreen _FrmloginScreen;
        public frmMainForm(frmLoginScreen frm)
        {
            InitializeComponent();
            //UCPersonInfo uCPersonInfo = new UCPersonInfo(10);
            _FrmloginScreen = frm;
            
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPeopleManagement  frmPeopleMangment = new FrmPeopleManagement();
            frmPeopleMangment.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Users Implementation is not here we will put it next time");

        }

        private void peopleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmPeopleManagement frmPeopleManagement = new FrmPeopleManagement();
            frmPeopleManagement.ShowDialog();
        }

       
        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Application Implementation is not here we will put it next time","Alert",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }


        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Account Implementation is not here we will put it next time", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void msiDrivers_Click(object sender, EventArgs e)
        {
            frmListDrivers listDrivers = new frmListDrivers();
            listDrivers.ShowDialog();

        }

        private void msiUsers_Click(object sender, EventArgs e)
        {
           FrmManageUsers frmManageUsers = new FrmManageUsers();
           
            frmManageUsers.ShowDialog();

            

        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {

        }

        private void signOugtToolStripMenuItem_Click(object sender, EventArgs e)
        {

            clsGlobal.CurrentUser = null;
          
           _FrmloginScreen.Show
                ();
            this.Close();


        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frmUserInfo = new frmUserInfo(clsGlobal.CurrentUser.UserId);
            frmUserInfo.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(clsGlobal.CurrentUser.UserId);
            frmChangePassword.ShowDialog();
        }

        private void manageApplicationsTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageApplicationTypes frmManageApplicationTypes = new FrmManageApplicationTypes();
            frmManageApplicationTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmManageListTestTypes  ManageListTestTypes=new FrmManageListTestTypes();
            ManageListTestTypes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication NewLocalDrivingLicenseApplication=new frmAddUpdateLocalDrivingLicenseApplication();
            NewLocalDrivingLicenseApplication.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplication frmManageLocal=new frmListLocalDrivingLicenseApplication();   
            frmManageLocal.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicenseApplication frm= new frmAddNewInternationalLicenseApplication();    
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenseApplication frm=new frmListInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicense frm=new frmRenewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void replacementForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementForLostOrDamagedLicense frm =new frmReplacementForLostOrDamagedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm= new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm= new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainedLicesneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm= new frmReleaseDetainedLicense();
            frm.ShowDialog();
            
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseDetainedLicense = new frmReleaseDetainedLicense();  
            frmReleaseDetainedLicense.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplication frm= new frmListLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void frmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _FrmloginScreen.Show();
        }
    }
}
