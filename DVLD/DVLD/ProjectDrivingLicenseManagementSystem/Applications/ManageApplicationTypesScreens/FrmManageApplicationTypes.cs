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
    public partial class FrmManageApplicationTypes : Form
    {
        private DataTable _dtAllApplicationTypes;
        public FrmManageApplicationTypes()
        {
            InitializeComponent();
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


     
     
        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpdateApplicationTypes UpdateApplicationTypes = new FrmUpdateApplicationTypes(Convert.ToInt32(dgvManageApplicationTypes.CurrentRow.Cells[0].Value));
            UpdateApplicationTypes.ShowDialog();
            FrmManageApplicationTypes_Load(null, null);
        }

        private void FrmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypesData();
            dgvManageApplicationTypes.DataSource = clsApplicationType.GetAllApplicationTypesData();
            if (dgvManageApplicationTypes.Rows.Count > 0)
            {
                dgvManageApplicationTypes.Columns[0].HeaderText = "ID";
                dgvManageApplicationTypes.Columns[0].Width = 120;
                
                dgvManageApplicationTypes.Columns[1].HeaderText = "Title";
                dgvManageApplicationTypes.Columns[1].Width = 450;
                
                dgvManageApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvManageApplicationTypes.Columns[2].Width = 120;

                lblNumberOfRecords.Text=dgvManageApplicationTypes.Rows.Count.ToString();
            }

        }
    }
}
