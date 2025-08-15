﻿using System;
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
    public partial class frmDriverLicenseInfo : Form
    {
        public frmDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private int _LicenseID = -1;
        public frmDriverLicenseInfo (int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoacLicenseInfo(_LicenseID);

        }
    }
}
