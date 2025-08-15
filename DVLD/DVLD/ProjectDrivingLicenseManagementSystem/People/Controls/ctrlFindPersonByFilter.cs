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
    public partial class ctrlFindPersonByFilter:UserControl
    {

        public event Action<int?> OnPersonSelected;
        protected virtual void SelectedPerson(int personId)
        {
            Action<int?>Handler=OnPersonSelected;
            if (Handler != null)
            {
                Handler(personId);
            }
        }
        public ctrlFindPersonByFilter()
        {
            InitializeComponent();
        }
        

       //private int _PersonID=-1;
        public int? PersonID
        {
           
            get
            {
                return ctrlPersonInfo2.PersonID;
            }


        }

        public clsPerson SelectedPersonInfo
        {
            get
            {
                return ctrlPersonInfo2.SelectedPerson;
            }
        }
        bool _ShowAddPerson = true;
        bool _FilterEnabled=true;

        bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson=value;
                btnAddNewPerson.Enabled=_ShowAddPerson;
            }
        }

      public   bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;

            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
      
        void FindNow()
        {
            switch (cbFilterPersonDataBy.Text)
            {
                case "Person ID":

                    ctrlPersonInfo2.LoadPersonInfo(Convert.ToInt32(txtValue.Text));
                    break;
                case "National No":
                    ctrlPersonInfo2.LoadPersonInfo(txtValue.Text);
                    break;
            }

            if (OnPersonSelected != null&&FilterEnabled)
            {
                OnPersonSelected(ctrlPersonInfo2.PersonID);
            }
        }
      
        private void cbFilterPersonDataBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue.Text = "";
            txtValue.Focus();

        }
        public void LoadPersonInfo(int? PersonID)
        {

            cbFilterPersonDataBy.SelectedIndex = 1;
            txtValue.Text = PersonID.ToString();
            FindNow();
        }

        public void FilterFocus()
        {
            txtValue.Focus();
        }
        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("You can not find ,you have validate error ,check red symbol","Validation Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FindNow();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            FrmAdd_EditPerson frmAdd_EditPerson=new FrmAdd_EditPerson();
            frmAdd_EditPerson.DataBack += PersonDataBack;
            frmAdd_EditPerson.ShowDialog();
        }

        private void PersonDataBack(object sender, int? PersonID)
        {
            ctrlPersonInfo2.LoadPersonInfo(PersonID);
        }

        private void ctrlFindPersonByFilter_Load(object sender, EventArgs e)
        {
            cbFilterPersonDataBy.SelectedIndex = 0;
            txtValue.Focus();
            
        }

        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtValue, "This Field is Required!");

            }
            else
            {
                errorProvider1.SetError(txtValue, null);
            }
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFindPerson.PerformClick();
                
            }

            if (cbFilterPersonDataBy.Text == "Person ID")
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }

        }
    }
}
