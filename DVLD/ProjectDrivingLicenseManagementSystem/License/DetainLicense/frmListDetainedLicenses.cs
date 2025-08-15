using BusinessLayer;
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

namespace ProjectDrivingLicenseManagementSystem.License
{
    public partial class frmListDetainedLicenses : Form
    {
        DataTable _dtAllDetainedLicenses;
        
       
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }
       

        private void _PerformFilterOperation()
        {
            string FilterColumn = "";
            switch (cbFilterDetainedLicenseBy.Text)
            {

                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;
                case "Is Relaesed":
                    cbIsReleased.SelectedIndex = 0;
                    cbIsReleased.Focus();
                    break;
                default:
                    FilterColumn = "";
                    break;


            }
            if(cbFilterDetainedLicenseBy.Text=="Detain ID"|| cbFilterDetainedLicenseBy.Text == "Release Application ID" && FilterColumn != "")
            {
                _dtAllDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] ={1}", FilterColumn, Convert.ToInt32( txtValue.Text));
                lblNumberOfRecords.Text=_dtAllDetainedLicenses.Rows.Count.ToString();
                return;
            }

            if(cbFilterDetainedLicenseBy.Text == "National No" || cbFilterDetainedLicenseBy.Text == "Full Name" && FilterColumn != "")
            {
                _dtAllDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, txtValue.Text);
                lblNumberOfRecords.Text = _dtAllDetainedLicenses.Rows.Count.ToString();
            }

        }
      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageDetainLicenses_Load(object sender, EventArgs e)
        {
            _dtAllDetainedLicenses = clsDetainedLicense.GetAllDetainedLicense();
            if (_dtAllDetainedLicenses != null)
            {

                cbIsReleased.Visible = false;
                txtValue.Visible = false;
                cbFilterDetainedLicenseBy.SelectedIndex = 0;
                dgvDetainedLicensesList.DataSource = _dtAllDetainedLicenses;

                dgvDetainedLicensesList.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicensesList.Columns[0].Width = 80;
                dgvDetainedLicensesList.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicensesList.Columns[1].Width = 80;

                dgvDetainedLicensesList.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicensesList.Columns[2].Width = 120;

                dgvDetainedLicensesList.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicensesList.Columns[3].Width = 80;

                dgvDetainedLicensesList.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicensesList.Columns[4].Width = 80;

                dgvDetainedLicensesList.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicensesList.Columns[5].Width = 120;

                dgvDetainedLicensesList.Columns[6].HeaderText = "N.No";
                dgvDetainedLicensesList.Columns[6].Width = 80;

                dgvDetainedLicensesList.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicensesList.Columns[7].Width =250;

                dgvDetainedLicensesList.Columns[8].HeaderText = "Release App ID";
                dgvDetainedLicensesList.Columns[8].Width = 120;

                lblNumberOfRecords.Text = dgvDetainedLicensesList.RowCount.ToString();
            }


        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtAllDetainedLicenses.DefaultView.RowFilter=null;
            string FilterValue = "", FilterColumn = "IsReleased";
            switch (cbIsReleased.Text)
            {
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
                _dtAllDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] ={1}", FilterColumn, Convert.ToInt32(FilterValue));
                lblNumberOfRecords.Text = _dtAllDetainedLicenses.Rows.Count.ToString();
               
            }
            lblNumberOfRecords.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();

        }

        private void cbFilterDetainedLicenseBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            _dtAllDetainedLicenses.DefaultView.RowFilter = null;

            txtValue.Visible = (cbFilterDetainedLicenseBy.Text != "None" && cbFilterDetainedLicenseBy.Text != "Is Released");
            if (txtValue.Visible)
            {
                txtValue.Focus();
            }
            cbIsReleased.Visible = (cbFilterDetainedLicenseBy.Text == "Is Released");
            if (cbIsReleased.Visible)
            {
                cbIsReleased.SelectedIndex= 0;
                cbIsReleased.Focus();
            }
            if (_dtAllDetainedLicenses == null)
            {
                MessageBox.Show("The List Is empty ,there is no data to filter", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            lblNumberOfRecords.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();

        }

        private void cmsDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            if (_dtAllDetainedLicenses==null)
            {
                MessageBox.Show("The List Is empty ,there is no data to filter", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
          
            cmsDetainedLicenses.Items[3].Enabled = !(bool)dgvDetainedLicensesList.CurrentRow.Cells[3].Value;    

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frmDetainLicense = new frmDetainLicense();
            frmDetainLicense.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseLicense = new frmReleaseDetainedLicense();
            frmReleaseLicense.ShowDialog();
            frmManageDetainLicenses_Load(null, null);
        }

        private void tsmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            FrmPersonDetails frmPersonDetails = new FrmPersonDetails(Convert.ToString(dgvDetainedLicensesList.CurrentRow.Cells[6].Value));
            frmPersonDetails.ShowDialog();
        }

        private void tmsiShowLicenseDetails_Click(object sender, EventArgs e)
        {
            frmDriverLicenseInfo frmDriverLicenseInfo = new frmDriverLicenseInfo(Convert.ToInt32(dgvDetainedLicensesList.CurrentRow.Cells[1].Value));
            frmDriverLicenseInfo.ShowDialog();
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            frmPersonLicenseHistory frmPersonLicenseHistory = new frmPersonLicenseHistory(clsPerson.Find(Convert.ToString(dgvDetainedLicensesList.CurrentRow.Cells[6].Value)).PersonID);
            frmPersonLicenseHistory.ShowDialog();
        }

        private void tmsiReleasedDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frmReleaseLicense = new frmReleaseDetainedLicense(Convert.ToInt32(dgvDetainedLicensesList.CurrentRow.Cells[1].Value)) ;
                frmReleaseLicense.ShowDialog();
            frmManageDetainLicenses_Load(null, null);

        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtValue.Text))
            {
                _dtAllDetainedLicenses.DefaultView.RowFilter= null;
                lblNumberOfRecords.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();

                return;
            }
            _PerformFilterOperation();
            lblNumberOfRecords.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();

        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterDetainedLicenseBy.Text == "Detain ID" || cbFilterDetainedLicenseBy.Text == "Release Application ID")
            {
                e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
            }
        }
    }
}
