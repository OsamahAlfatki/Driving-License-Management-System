using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DVLDSettings;
namespace BusinessLayer
{
    public static class clsGlobal
    {
        public static clsUser CurrentUser;
        public static string KeyPath= @"HKEY_CURRENT_USER\SOFTWARE\RegisterUsers";
        public static string UserNameKeyName = "CurrentUser";
        public static string PassowrdKeyName = "Password";
        public static bool GetStoredCredetional(ref string UserName, ref string Password)
        {

            try
            {
                UserName = Registry.GetValue(KeyPath, UserNameKeyName, null) as string;
                Password= Registry.GetValue(KeyPath, PassowrdKeyName, null) as string ;

                

               


                if (UserName!=null&&Password != null)
                {
                    

                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured :" + ex.Message);
                return false;


            }


        }

        public static bool RemebrUserByUserNameAndPassword(string userName, string password)
        {
            try
            {

              
                Registry.SetValue(KeyPath, UserNameKeyName, userName);
                Registry.SetValue(KeyPath, PassowrdKeyName,password);
                return true;

            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occured :" + ex.Message);
                return false;


            }

        }
      

    }
}
