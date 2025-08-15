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
    public partial class ctrlDriverLicenses : UserControl
    {

        DataTable _dtLocalLicenses;
        DataTable _dtInternationalLicenses;
        int _DriverID = -1;
        clsDriver _Driver;
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }


        public void LoadInfo(int DriverID)
        {
            _Driver = clsDriver.FindDriverInfoByDriverID(DriverID);
            if (_Driver == null)
            {
                MessageBox.Show("Driver with ID= "+ DriverID+"  Not Found","Not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _DriverID = _Driver.DriverID;
            _LoadLocalLicenses();
            _LoadInternationalLicenses();

        }
       private void _LoadInternationalLicenses()
        {

                _dtInternationalLicenses = clsDriver.GetDriverInternationalLicenses(_DriverID);

            dgvInternationalLicenseHistory.DataSource = _dtInternationalLicenses;

            if (dgvInternationalLicenseHistory !=null)
            {

                dgvInternationalLicenseHistory.Columns[0].HeaderText = "Int License ID";
               dgvInternationalLicenseHistory.Columns[0].Width = 100;

                dgvInternationalLicenseHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenseHistory.Columns[1].Width = 100;

                dgvInternationalLicenseHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicenseHistory.Columns[2].Width = 120;

                dgvInternationalLicenseHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicenseHistory.Columns[3].Width = 140;

                dgvInternationalLicenseHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicenseHistory.Columns[4].Width = 140;

                dgvInternationalLicenseHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicenseHistory.Columns[5].Width = 100;

                lblNumberOfInternationalRecords.Text = dgvInternationalLicenseHistory.Rows.Count.ToString();
            }
        }
        void _LoadLocalLicenses()
        {
            _dtLocalLicenses=clsDriver.GetLicenses(_DriverID);
            if (_dtLocalLicenses!= null)
            {
                dgvDriverLicenses.DataSource =_dtLocalLicenses;



                dgvDriverLicenses.Columns[0].HeaderText = "Lice ID";
                dgvDriverLicenses.Columns[0].Width = 70;
                dgvDriverLicenses.Columns[1].HeaderText = "AppID ID";
                dgvDriverLicenses.Columns[1].Width = 70;

                dgvDriverLicenses.Columns[2].HeaderText = "Class Name";
                dgvDriverLicenses.Columns[2].Width = 200;

                dgvDriverLicenses.Columns[3].HeaderText = "Issue Date";
                dgvDriverLicenses.Columns[3].Width = 120;

                dgvDriverLicenses.Columns[4].HeaderText = "Expiration Date";
                dgvDriverLicenses.Columns[4].Width = 120;

                dgvDriverLicenses.Columns[5].HeaderText = "Is Active";
                dgvDriverLicenses.Columns[5].Width = 70;

                lblNumberOfLocalLicenseHistoryRecords.Text = dgvDriverLicenses.Rows.Count.ToString();
            }
        }
      public  void LoadInfoByPersonID(int? PersonID)
        {

            _Driver = clsDriver.FindDriverByPersonID(PersonID);
            
            if (_Driver == null)
            {
                MessageBox.Show("No driver linked with Person ID" + PersonID , "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DriverID=_Driver.DriverID;
            _LoadLocalLicenses();
            _LoadInternationalLicenses();

        }


        public void Clear()
        {
            _dtInternationalLicenses.Clear();
            _dtLocalLicenses.Clear();
        }
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbDriverLicense.SelectedIndex == 0)
            {
                frmDriverLicenseInfo frm = new frmDriverLicenseInfo(Convert.ToInt32(dgvDriverLicenses.CurrentRow.Cells[0].Value));
                frm.ShowDialog();
                return;
            }
            frmDriverInternationalInfo F=new frmDriverInternationalInfo(Convert.ToInt32(dgvInternationalLicenseHistory.CurrentRow.Cells[0].Value));   
            F.ShowDialog();

        }
    }
}
