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
    public partial class frmDriverInternationalInfo : Form
    {
        public frmDriverInternationalInfo(int LicenseID)
        {
            InitializeComponent();
            ctrlInternationalLicenseInfo1.LoadInfo(LicenseID);
        }

        private void frmDriverInternationalInfo_Load(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
