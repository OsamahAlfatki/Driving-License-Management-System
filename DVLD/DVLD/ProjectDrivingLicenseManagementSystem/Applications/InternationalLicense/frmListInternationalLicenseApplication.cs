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

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class frmListInternationalLicenseApplication : Form
    {
        public frmListInternationalLicenseApplication()
        {
            InitializeComponent();
        }
        DataTable _dtInternationalLicense;
     
        private void _PerformFilter()
        {
            string FilterColumn = "";
            switch (cbManageInternationalAppFilterTypes.Text)
            {
                case "License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;
                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;
                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;
                    default:
                    FilterColumn = "";
                    break;

            }


            if (FilterColumn != "" && txtFilterValue.Text.Trim().Length > 0)
            {
                _dtInternationalLicense.DefaultView.RowFilter=string.Format("[{0}] = {1}",FilterColumn,Convert.ToInt32(txtFilterValue.Text));
                lblNumberOfRecords.Text=_dtInternationalLicense.DefaultView.Count.ToString();
                return;
            }

        }
     
     
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonDetails frm = new FrmPersonDetails(clsDriver.FindDriverInfoByDriverID((int)dgvManageInternationalLicenseApplication.CurrentRow.Cells[2].Value).PersonID);
                frm.ShowDialog();

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverInternationalInfo frm = new frmDriverInternationalInfo(Convert.ToInt32(dgvManageInternationalLicenseApplication.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
                frmPersonLicenseHistory frm = new frmPersonLicenseHistory(clsDriver.FindDriverInfoByDriverID((int)dgvManageInternationalLicenseApplication.CurrentRow.Cells[2].Value).PersonID);
                frm.ShowDialog();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnAddInternationalLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicenseApplication frm = new frmAddNewInternationalLicenseApplication();
            frm.ShowDialog();
            frmListInternationalLicenseApplication_Load(null, null);
        }

        private void cbManageInternationalAppFilterTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtInternationalLicense == null)
            {
                MessageBox.Show("Error ,there is no data to filter ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _dtInternationalLicense.DefaultView.RowFilter = null;
            lblNumberOfRecords.Text = _dtInternationalLicense.DefaultView.Count.ToString();
            txtFilterValue.Visible = (cbManageInternationalAppFilterTypes.Text != "None"&&cbManageInternationalAppFilterTypes.Text!="Is Active");
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Focus();
            }
            cbIsActive.Visible = (cbManageInternationalAppFilterTypes.Text == "Is Active");
           if(cbManageInternationalAppFilterTypes.Text=="Is Active")
            {
                cbIsActive.SelectedIndex = 0;
                cbIsActive.Focus();
            }
           
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _dtInternationalLicense.DefaultView.RowFilter = null;
            _PerformFilter();
            lblNumberOfRecords.Text = _dtInternationalLicense.DefaultView.Count.ToString();

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar); 
        }

        private void frmListInternationalLicenseApplication_Load(object sender, EventArgs e)
        {


            _dtInternationalLicense = clsInternationalLicense.GetInternationalLicenseApplications();

            if (_dtInternationalLicense != null)
            {
                dgvManageInternationalLicenseApplication.DataSource = _dtInternationalLicense;
                cbManageInternationalAppFilterTypes.SelectedIndex = 0;

                dgvManageInternationalLicenseApplication.Columns[0].HeaderText = "Int License ID";
                dgvManageInternationalLicenseApplication.Columns[0].Width = 100;
                dgvManageInternationalLicenseApplication.Columns[1].HeaderText = "Application ID";
                dgvManageInternationalLicenseApplication.Columns[1].Width = 100;

                dgvManageInternationalLicenseApplication.Columns[2].HeaderText = "Driver ID";
                dgvManageInternationalLicenseApplication.Columns[2].Width = 100;

                dgvManageInternationalLicenseApplication.Columns[3].HeaderText = "L.License ID";
                dgvManageInternationalLicenseApplication.Columns[3].Width = 100;

                dgvManageInternationalLicenseApplication.Columns[4].HeaderText = "Issue Date";
                dgvManageInternationalLicenseApplication.Columns[4].Width = 160;

                dgvManageInternationalLicenseApplication.Columns[5].HeaderText = "Expiration Date";
                dgvManageInternationalLicenseApplication.Columns[5].Width = 160;

                dgvManageInternationalLicenseApplication.Columns[6].HeaderText = "Is Active";
                dgvManageInternationalLicenseApplication.Columns[6].Width = 100;

                lblNumberOfRecords.Text = dgvManageInternationalLicenseApplication.Rows.Count.ToString();
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtInternationalLicense.DefaultView.RowFilter = null;
            string FilterValue = "", FilterColumn = "IsActive";
            switch (cbIsActive.Text)
            {
                case "All":
                    FilterValue = "";
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;

                case "No":
                    FilterValue = "0";
                    break;

                    default:
                    FilterValue = "";
                    break;
            }

            if (FilterValue != "")
            {
                _dtInternationalLicense.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, FilterValue);
                    

            }
            lblNumberOfRecords.Text = _dtInternationalLicense.DefaultView.Count.ToString();

        }
    }
}
