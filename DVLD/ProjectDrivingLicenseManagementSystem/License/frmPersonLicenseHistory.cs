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
    public partial class frmPersonLicenseHistory : Form
    {
        public frmPersonLicenseHistory()
        {
            InitializeComponent();
        }
        private int? _PersonID = -1;
        public frmPersonLicenseHistory(int? PersonID)
        {
            InitializeComponent();
         _PersonID = PersonID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID == -1)
            {
                ctrlFindPersonByFilter1.FilterEnabled = true;
                ctrlFindPersonByFilter1.FilterFocus();
                return;
            }
            ctrlFindPersonByFilter1.FilterEnabled=false;    
            ctrlFindPersonByFilter1.LoadPersonInfo(_PersonID);
            ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);


        }

        private void ctrlFindPersonByFilter1_OnPersonSelected(int? obj)
        {
            _PersonID=obj;
            if (obj == -1)
            {

                ctrlDriverLicenses1.Clear();

            }
            else
            {
            ctrlDriverLicenses1.LoadInfoByPersonID(_PersonID);

            }
        }

        private void ctrlDriverLicenses1_Load(object sender, EventArgs e)
        {

        }
    }
}
