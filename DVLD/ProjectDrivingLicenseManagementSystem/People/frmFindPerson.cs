using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDrivingLicenseManagementSystem.People
{
    public partial class frmFindPerson : Form
    {
        public delegate void DataBackEventHandler(object Sender, int? PersonID);
        public DataBackEventHandler DataBack;
        public frmFindPerson()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack.Invoke(this, ctrlFindPersonByFilter1.PersonID);
            this.Close();

        }
    }
}
