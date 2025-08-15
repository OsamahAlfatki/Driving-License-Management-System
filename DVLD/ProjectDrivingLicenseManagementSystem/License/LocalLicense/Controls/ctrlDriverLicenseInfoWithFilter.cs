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

namespace ProjectDrivingLicenseManagementSystem.License.LocalLicense.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public event  Action<int>OnLicenseSelected;
        private void LicenseSelected(int LicenseID)
        {
            Action<int> Handelr = OnLicenseSelected;
            if (Handelr != null)
            {
                Handelr(LicenseID);
            }

        }
        private int _LicenseID = -1;
        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            set { _FilterEnabled = value;
            
            gbFilter.Enabled = value;
            }
            get
            {
                return _FilterEnabled;
            }
        }
        public int LicenseID
        {
            get
            {
                return ctrlDriverLicenseInfo1.LicenseID;
            }

        }

        public void ResetDefualtValues()
        {
            ctrlDriverLicenseInfo1.ResetDefualtValues();
        }
        public clsLicense SelectedLicenseInfo
        {
            get
            {
                return ctrlDriverLicenseInfo1.SelectedLicenseInfo;
            }
        }


        public void LoadLicense(int LicenseID)
        {
            _LicenseID = LicenseID;   
            txtLicenseID.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.LoacLicenseInfo(LicenseID);
           
            if(OnLicenseSelected != null && FilterEnabled)
            {
                OnLicenseSelected(LicenseID);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields Are not falids check red icon(s) ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _LicenseID = int.Parse(txtLicenseID.Text.Trim());
            LoadLicense(_LicenseID);
        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This Field Is required");
            }
            else
            {
                errorProvider1.SetError(txtLicenseID, null);

            }


        }
        public void SetFoucs()
        {
            txtLicenseID.Focus();
        }
        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled=!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar);
            if(e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }
        }

    }
}
