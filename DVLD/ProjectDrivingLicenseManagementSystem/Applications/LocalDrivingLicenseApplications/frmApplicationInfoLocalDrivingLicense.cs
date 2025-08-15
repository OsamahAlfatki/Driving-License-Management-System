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
    public partial class frmApplicationInfoLocalDrivingLicense : Form
    {
        private int _ApplicationID = -1;
        public frmApplicationInfoLocalDrivingLicense()
        {
            InitializeComponent();
        }
        public frmApplicationInfoLocalDrivingLicense(int AppID)
        {
            InitializeComponent();
            _ApplicationID = AppID;
          
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmApplicationInfoLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlDAppInfo1.LoadLocalDrivingLicenseApplicationInfoByAppID(_ApplicationID);

        }
    }
}
