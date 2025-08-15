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
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        enum enMode
        {
            AddNew,Update
        }
        enMode _Mode;
        private clsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication=new clsLocalDrivingLicenseApplications();
        private int _LDLAppID;
        private int? _OnPersonSelected = -1;
        private void _ResetDefualtValues()
        {
            _FillLicenseClassData();
            if (_Mode == enMode.AddNew)
            {
                this.Text = "New Local Driving License Application"; ;
                lblApplicationMode.Text = "New Local Driving License Application";
                lblApplicationDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplications();
                lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationTypes.AddNewLicense).ApplicationTypeFees.ToString();
                lblUserName.Text = clsGlobal.CurrentUser.UserName;
                cbLicenseClass.SelectedIndex = 2;
                btnSave.Enabled = false;
                // tpApplicationInfo
                tcAddEditLDLApp.SelectedTab = tcAddEditLDLApp.TabPages["tpPersonInfo"];
                
            }
            else
            {

                this.Text = "Update Local Driving License Application"; ;
                lblApplicationMode.Text = "Update Local Driving License Application";
                ctrlFindPersonByFilter1.FilterEnabled = false;

            }

         
        }
        public frmAddUpdateLocalDrivingLicenseApplication(int LDLAppID)
        {
            InitializeComponent();
        
            _LDLAppID = LDLAppID;
            
                _Mode = enMode.Update;

            
            
            
        }
      private  void _LoadData()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.FindLocalDrivingLicenseApplicationInfoByID(_LDLAppID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Application with ID = " +_LDLAppID+" Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();

            }
            
            
               ctrlFindPersonByFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicationPersonID);
           
                lblApplicationDate.Text = clsFormat.ToShortDateString(_LocalDrivingLicenseApplication.ApplicationDate) ;
                lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationTypes.AddNewLicense).ApplicationTypeFees.ToString();
                lblUserName.Text = clsUser.Find(_LocalDrivingLicenseApplication.ApplicationUserID).UserName;
                lblDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
               // cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.FindLicenseClassNameByLicenseClassID(_LocalDrivingLicenseApplication.LicenseClassID));
               
        }
       
        void Save()
        {

            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;
            int ActiveApplicationID = clsApplication.GetActiveApplicationForLicenseClass(ctrlFindPersonByFilter1.PersonID, clsApplication.enApplicationTypes.AddNewLicense, LicenseClassID);

            if (ActiveApplicationID != -1)
            {

                MessageBox.Show("Choose Another LicenseClass,Person Has Already Application with License Class  Like This ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }
         
            


            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
                    _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
                    _LocalDrivingLicenseApplication.ApplicationPersonID = ctrlFindPersonByFilter1.PersonID;
                    _LocalDrivingLicenseApplication.ApplicationUserID = clsGlobal.CurrentUser.UserId;
                   _LocalDrivingLicenseApplication.LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;
                _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
                    _LocalDrivingLicenseApplication.Fees = Convert.ToSingle(lblFees.Text);
                _LocalDrivingLicenseApplication.ApplicationTypeID = (int)clsApplication.enApplicationTypes.AddNewLicense;

                
                if (_LocalDrivingLicenseApplication.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblDLApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                    this.Text = "Update Local Driving License Application"; ;
                    lblApplicationMode.Text = "Update Local Driving License Application";


                _Mode = enMode.Update;

                }
                else
                {
                    MessageBox.Show("Data Not Saved ", "Fail To Save", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
               
            

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           Save();
        }
        private void _FillLicenseClassData()
        {

            DataTable dt = new DataTable();
            dt = clsLicenseClass.GetAllLicenseClassData();
            foreach (DataRow Row in dt.Rows)
            {
                cbLicenseClass.Items.Add(Row["ClassName"]);
            }

        }
        private void FrmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
         _ResetDefualtValues();
            if(_Mode==enMode.Update)
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.AddNew)
            {

                tcAddEditLDLApp.SelectedTab = tcAddEditLDLApp.TabPages["tpApplicationInfo"];
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                return;

            }


            if (ctrlFindPersonByFilter1.PersonID == -1)
            {
                MessageBox.Show("Error,Find Person First,Find person first to go to Application ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFindPersonByFilter1.FilterFocus();
                return;
            }
            else
            {

                tcAddEditLDLApp.SelectedTab = tcAddEditLDLApp.TabPages["tpApplicationInfo"];
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
            }


           
        }

        private void ctrlFindPersonByFilter1_OnPersonSelected(int? obj)
        {
            _OnPersonSelected=obj;
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlFindPersonByFilter1.FilterFocus();
        }

        private void tpApplicationInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
