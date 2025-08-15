using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using System.Xml.Linq;
using BusinessLayer;
using Microsoft.SqlServer.Server;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProjectDrivingLicenseManagementSystem
{
    public partial class FrmPeopleManagement : Form
    {  
        public static DataTable _dtAllPeople=clsPerson.GetAllPersonsData();
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName","Gender","CountryName", "DateOfBirth", "Phone", "Email");

        public FrmPeopleManagement()
        {
            InitializeComponent();
        }
        private void _RefreshAllPeopleList()
        {


            _dtAllPeople = clsPerson.GetAllPersonsData();
          _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName", "Gender","CountryName", "DateOfBirth", "Phone", "Email");;

            dgvPeopleList.DataSource =_dtPeople;

            lblNumberOfRecords.Text = dgvPeopleList.Rows.Count.ToString();


        }

        private void FrmPeopleManagement_Load(object sender, EventArgs e)
        {
            cbFilterPersonDataBy.SelectedIndex = 0;
            lblNumberOfRecords.Text=_dtPeople.Rows.Count.ToString();
           // _dtAllPeople = clsPerson.GetAllPersonsData();
            //_dtPeople
            dgvPeopleList.DataSource=_dtPeople;
            if (dgvPeopleList.Rows.Count > 0)
            {
                dgvPeopleList.Columns[0].HeaderText = "Person ID";
                dgvPeopleList.Columns[0].Width = 120;
                dgvPeopleList.Columns[1].HeaderText = "National No";
                dgvPeopleList.Columns[1].Width = 120;
                dgvPeopleList.Columns[2].HeaderText = "First Namw";
                dgvPeopleList.Columns[2].Width = 140;
                dgvPeopleList.Columns[3].HeaderText = "Second Name";
                dgvPeopleList.Columns[3].Width = 140;
                dgvPeopleList.Columns[4].HeaderText = "Third Name";
                dgvPeopleList.Columns[4].Width = 140;
                dgvPeopleList.Columns[5].HeaderText = "Last Name";
                dgvPeopleList.Columns[5].Width = 140;
                dgvPeopleList.Columns[6].HeaderText = "Gender";
                dgvPeopleList.Columns[6].Width = 120;
                dgvPeopleList.Columns[7].HeaderText = "Nationality";
                dgvPeopleList.Columns[7].Width = 120;
                dgvPeopleList.Columns[8].HeaderText = "Date Of Birth";
                dgvPeopleList.Columns[8].Width = 170;
                dgvPeopleList.Columns[9].HeaderText = "Phone";
                dgvPeopleList.Columns[9].Width = 150;
                 dgvPeopleList.Columns[10].HeaderText = "Email";
                dgvPeopleList.Columns[10].Width = 170;

            }

        }

        private void cbFilterPersonDataBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue.Visible = (cbFilterPersonDataBy.Text != "None");
            if (txtValue.Visible)
            {
                txtValue.Text = "";
                txtValue.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdd_EditPerson frmAdd_EditPerson = new FrmAdd_EditPerson();
            frmAdd_EditPerson.ShowDialog();
            _RefreshAllPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAdd_EditPerson frmAdd_EditPerson = new FrmAdd_EditPerson(Convert.ToUInt16(dgvPeopleList.CurrentRow.Cells[0].Value));
            frmAdd_EditPerson.ShowDialog();
            _RefreshAllPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You to Delete This Person ", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
             
                    if (clsPerson.DeletePersonByID(Convert.ToInt16(dgvPeopleList.CurrentRow.Cells[0].Value)))
                    {
                        MessageBox.Show("Person that have " + dgvPeopleList.CurrentRow.Cells[0].Value + " Deleted Successfully " , "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefreshAllPeopleList();
                    }
                    else
                    {
                    MessageBox.Show("Person  dose not Deleted there is data linked to it ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
            }

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Function will be here next time","Explain",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void makeCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Function will be here next time", "Explain", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {


            FrmPersonDetails frm = new FrmPersonDetails( Convert.ToInt16(
                dgvPeopleList.CurrentRow.Cells[0].Value));
            frm.ShowDialog();   
        }

     

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

            FrmAdd_EditPerson frmAdd_EditPerson = new FrmAdd_EditPerson();
            frmAdd_EditPerson.ShowDialog();

            _RefreshAllPeopleList();
        }

        private void btnClose_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterPersonDataBy.Text=="Person ID")
            {
                e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterPersonDataBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                      case "National No":
                    FilterColumn = "NationalNo";
                    break;
                      case "First Name":
                    FilterColumn = "FirstName";
                    break;
                      case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                      case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                      case "Last Name":
                    FilterColumn = "LastName";
                    break;
                      case "Gender":
                    FilterColumn = "Gender";
                    break;
                 case "Nationality":
                    FilterColumn = "CountryName";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break; 
                case "Email":
                    FilterColumn = "Email";
                    break;
                    default:
                    break;


            }
                

            if (txtValue.Text.Trim() == string.Empty || FilterColumn=="")
            {
                _dtPeople.DefaultView.RowFilter = null;
                lblNumberOfRecords.Text=_dtPeople.Rows.Count.ToString();
                return;
            }

            if(cbFilterPersonDataBy.Text=="Person ID")
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}]= {1}", FilterColumn, int.Parse(txtValue.Text));
                lblNumberOfRecords.Text=_dtPeople.Rows.Count.ToString();

            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, txtValue.Text);
                lblNumberOfRecords.Text = _dtPeople.Rows.Count.ToString();

            }
        }
    }
}
