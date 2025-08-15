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
using System.Xml;

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class FrmManageUsers : Form
    {
       
         private static DataTable _dtUserData ;


        public FrmManageUsers()
        {
            InitializeComponent();
            
        }

        private void _PerformFilter()
        {
            string FilterColumn = "";
            switch (cbUserFilterType.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                     case "User Name":
                    FilterColumn = "UserName";
                    break;
                     case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                     case "Full Name":
                    FilterColumn = "FullName";
                    break;
               
                default:
                    break;

            }

            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                _dtUserData.DefaultView.RowFilter = null;

                lblNumberOfRecords.Text = _dtUserData.DefaultView.Count.ToString();

                return;
            }
            if (cbUserFilterType.Text == "Person ID" || cbUserFilterType.Text == "User ID")
            {
                _dtUserData.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, int.Parse(txtFilterValue.Text));
                lblNumberOfRecords.Text = _dtUserData.DefaultView.Count.ToString();


                return;
            }
            else
            {
                _dtUserData.DefaultView.RowFilter = string.Format("{0} like '{1}%'", FilterColumn, txtFilterValue.Text);
                lblNumberOfRecords.Text = _dtUserData.DefaultView.Count.ToString();


            }

        }
        private void FrmManageUsers_Load(object sender, EventArgs e)
        {
            
            _dtUserData = clsUser.GetAllUsersList();
            cbUserFilterType.SelectedIndex = 0;
            dgvUsersList.DataSource = _dtUserData;
            if (dgvUsersList.Rows.Count > 0)
            {
                dgvUsersList.Columns[0].HeaderText = "User ID";
                dgvUsersList.Columns[0].Width = 120;

                dgvUsersList.Columns[1].HeaderText = "Person ID";
                dgvUsersList.Columns[1].Width = 120;

                dgvUsersList.Columns[2].HeaderText = "User Name";
                dgvUsersList.Columns[2].Width = 150;

                dgvUsersList.Columns[3].HeaderText = "Full Name";
                dgvUsersList.Columns[3].Width = 350;

                dgvUsersList.Columns[4].HeaderText = "Is Active";
                dgvUsersList.Columns[4].Width = 120;

                lblNumberOfRecords.Text = dgvUsersList.RowCount.ToString();
            }

        }
     

        private void cbUserFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtUserData.DefaultView.RowFilter = null;

            if (cbUserFilterType.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActiveFilterBy.Visible = true;

                cbIsActiveFilterBy.Focus();
                cbIsActiveFilterBy.SelectedIndex = 0;
                return;
            }
            cbIsActiveFilterBy.Visible= false;
            txtFilterValue.Visible = (cbUserFilterType.Text != "None" && cbUserFilterType.Text != "Is Active");
            if (txtFilterValue.Visible)
            {
                txtFilterValue.Focus();
            }
        }
     
    
        private void cbIsActiveFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = "";

            switch (cbIsActiveFilterBy.Text)
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
                    break;

            }
            if (FilterValue != "")
            {
                _dtUserData.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, Convert.ToInt32(FilterValue));
                lblNumberOfRecords.Text = _dtUserData.DefaultView.Count.ToString();
                return;
            }
            _dtUserData.DefaultView.RowFilter = null;
            lblNumberOfRecords.Text = _dtUserData.DefaultView.Count.ToString();




        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdateNewUser frmAdd_UpdateNewUser = new FrmAdd_UpdateNewUser();
            frmAdd_UpdateNewUser.ShowDialog();
            FrmManageUsers_Load(null,null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Delete This User", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes) {
                {
                    if (clsUser.DeleteUserById(Convert.ToInt32(dgvUsersList.CurrentRow.Cells[0].Value))){
                        MessageBox.Show("User Deleted Successfully","Deleted Successfully",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmManageUsers_Load(null,null);

                    }
                    else
                    {
                        MessageBox.Show("User not Deleted ", "Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdateNewUser frmAdd_UpdateNewUser= new FrmAdd_UpdateNewUser(Convert.ToInt32(dgvUsersList.CurrentRow.Cells[0].Value));
            frmAdd_UpdateNewUser.ShowDialog();
            FrmManageUsers_Load(null, null);
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdd_UpdateNewUser frmAdd_UpdateNewUser = new FrmAdd_UpdateNewUser();
            frmAdd_UpdateNewUser.ShowDialog();
            FrmManageUsers_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(Convert.ToInt32(dgvUsersList.CurrentRow.Cells[0].Value));
            frmChangePassword.ShowDialog();
            FrmManageUsers_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frmUserInfo = new frmUserInfo(Convert.ToInt32(dgvUsersList.CurrentRow.Cells[0].Value));
            frmUserInfo.ShowDialog();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Function will be here next time", "Explain", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Function will be here next time", "Explain", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

     

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _dtUserData.DefaultView.RowFilter = null;
            lblNumberOfRecords.Text = _dtUserData.DefaultView.Count.ToString();

            if (txtFilterValue.Text == string.Empty)
            {
                _dtUserData.DefaultView.RowFilter = null;
                return;
            }
            _PerformFilter();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbUserFilterType.Text == "Person ID" || cbUserFilterType.Text == "User ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
