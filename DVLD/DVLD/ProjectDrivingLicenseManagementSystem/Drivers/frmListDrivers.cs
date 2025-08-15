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


    public partial class frmListDrivers : Form
    {
        public frmListDrivers()
        {
            InitializeComponent();
          
        }

       
        DataTable _dtAllDrivers;
      
       private  void _PerformFiltration()
        {
            string Filtercolumn = "";
            
            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    Filtercolumn = "DriverID";
                    break;
                case "Person ID":
                    Filtercolumn = "PersonID";
                    break;
                case "Full Name":
                    Filtercolumn = "FullName";
                    break;
                case "National No":
                    Filtercolumn = "NationalNo";
                    break;
                case "None":
                    Filtercolumn = "";
                    break;
                default:
                    Filtercolumn = "";
                    break;
            }



            if(cbFilterBy.Text == "Driver ID" || cbFilterBy.Text == "Person ID"&&Filtercolumn!="")
            {
                _dtAllDrivers.DefaultView.RowFilter=string.Format("[{0}] = {1}",Filtercolumn,txtValue.Text);

                return;
            }
            if(cbFilterBy.Text == "National No" || cbFilterBy.Text == "Full Name"&&Filtercolumn!="")
            {
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", Filtercolumn, txtValue.Text);

                return;
            }

        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _dtAllDrivers=clsDriver.GetAllDriversData();
            if (_dtAllDrivers != null)
            {
                dgvDriversList.DataSource= _dtAllDrivers;
                lblNumberOfRecords.Text = dgvDriversList.Rows.Count.ToString();
                dgvDriversList.Columns[0].HeaderText = "Driver ID";
                dgvDriversList.Columns[0].Width = 80;

                dgvDriversList.Columns[1].HeaderText = "Person ID";
                dgvDriversList.Columns[1].Width = 80;
                
                dgvDriversList.Columns[2].HeaderText = "National No";
                dgvDriversList.Columns[2].Width = 80;
                
                dgvDriversList.Columns[3].HeaderText = "Full Name";
                dgvDriversList.Columns[3].Width = 250;
                  
                dgvDriversList.Columns[4].HeaderText = "Date";
                dgvDriversList.Columns[4].Width = 250;
                  
                dgvDriversList.Columns[5].HeaderText = "Active Licenses";
                dgvDriversList.Columns[5].Width = 80
                    ;
                lblNumberOfRecords.Text=_dtAllDrivers.DefaultView.Count.ToString();
            }
        }

        private void cbFilterPersonDataBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue.Visible = cbFilterBy.Text != "None";
            if(txtValue.Visible )
                txtValue.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text=="Driver ID" || cbFilterBy.Text == "Person ID")
            {
                e.Handled=!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar);
            }
         
                
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            _dtAllDrivers.DefaultView.RowFilter = null;
            lblNumberOfRecords.Text = _dtAllDrivers.DefaultView.Count.ToString();


            if (string.IsNullOrEmpty(txtValue.Text))
            {
                _dtAllDrivers.DefaultView.RowFilter = null;
                return;
            }
            _PerformFiltration();
            lblNumberOfRecords.Text = _dtAllDrivers.DefaultView.Count.ToString();

        }


        private void tsmShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            frmPersonLicenseHistory frm= new frmPersonLicenseHistory((int)dgvDriversList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();   
        }

        private void tsmShowPersonDetails_Click(object sender, EventArgs e)
        {

            FrmPersonDetails frm = new FrmPersonDetails(PersonID: (int)dgvDriversList.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }
    }
}