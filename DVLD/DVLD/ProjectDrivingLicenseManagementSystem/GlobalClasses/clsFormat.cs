using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDrivingLicenseManagementSystem.Global_Classes
{
    internal class clsFormat
    {
        public static string ToShortDateString(DateTime date)
        {
            return date.ToString("dd-MMM-yyyy");
        }
    }
}
