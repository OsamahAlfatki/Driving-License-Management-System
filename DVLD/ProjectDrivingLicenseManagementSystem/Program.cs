using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDrivingLicenseManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            // Application.Run(new FrmPeopleManagement());
            // Application.Run(new FrmPersonDetails());
           // Application.Run(new frmMainForm());
          // Application.Run(new Form1());
          //Application.Run(new FrmManageUsers());
        // Application.Run(new FrmAdd_UpdateNewUser());
       Application.Run(new frmLoginScreen());
            //Application.Run(new frmScheduleTestOrReschedule());
            //Application.Run( new FrmNewLocalDrivingLicenseApplication() );
            //Application.Run(new frmManageLocalDrivingLicenseApplication());
           // Application.Run(new frmDriverInternationalInfo(18));
        }
    }
}
