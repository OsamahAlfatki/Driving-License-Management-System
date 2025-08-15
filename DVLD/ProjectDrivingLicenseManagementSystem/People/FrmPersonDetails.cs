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
    public partial class FrmPersonDetails : Form
    {
      
        public FrmPersonDetails(int? PersonID)

        {
            InitializeComponent();
            ctrlPersonInfo1.LoadPersonInfo(PersonID);
            
        }

      public  FrmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            ctrlPersonInfo1.LoadPersonInfo(NationalNo);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
