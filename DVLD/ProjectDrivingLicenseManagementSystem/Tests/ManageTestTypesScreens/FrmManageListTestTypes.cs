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
    public partial class FrmManageListTestTypes : Form
    {
        private DataTable _dtAllTestTypes;
        public FrmManageListTestTypes()
        {
            InitializeComponent();
        }


        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateTestTypes UpdateTestTypes = new FrmUpdateTestTypes((clsTestTypes.enTestType) dgvManageTestTypes.CurrentRow.Cells[0].Value);
            UpdateTestTypes.ShowDialog();
            FrmManageListTestTypes_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmManageListTestTypes_Load(object sender, EventArgs e)
        {
            _dtAllTestTypes=clsTestTypes.GetAllTestTypesData();
            if (_dtAllTestTypes != null)
            {
                dgvManageTestTypes.DataSource = _dtAllTestTypes;
                lblNumberOfRecords.Text = dgvManageTestTypes.Rows.Count.ToString();

                dgvManageTestTypes.Columns[0].HeaderText = "ID";
                dgvManageTestTypes.Columns[0].Width = 100;

                dgvManageTestTypes.Columns[1].HeaderText = "Title";
                dgvManageTestTypes.Columns[1].Width = 120;

                dgvManageTestTypes.Columns[2].HeaderText = "Description";
                dgvManageTestTypes.Columns[2].Width = 300;

                dgvManageTestTypes.Columns[3].HeaderText = "Fees";
                dgvManageTestTypes.Columns[3].Width = 100;
                
            }
        }
    }
}
