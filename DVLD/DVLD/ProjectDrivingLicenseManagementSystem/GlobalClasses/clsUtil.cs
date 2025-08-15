using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace ProjectDrivingLicenseManagementSystem.Global_Classes
{
    internal class clsUtil
    {
        public static string GenerateGuid()
        {
            Guid guid = new Guid();

            return guid.ToString();
        }
        public static string ReplaceFileNameWihGuid(string SourceFile)
        {
            FileInfo fileInfo = new FileInfo(SourceFile);

            return GenerateGuid() + fileInfo.Extension;

        }

        public static bool CreateFolderDirectryIfDoseNotExits(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {


                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return false;
            }
            return true;

        }

        public static bool CopyImagesInProject(ref string SourceFile)
        {
            string DestDirectory = @"C:\DVLD Person Images\";
            string DestintionFile = "";

            if (!CreateFolderDirectryIfDoseNotExits(DestDirectory)) {
                return false;
            }
            try
            {
                DestintionFile = DestDirectory + ReplaceFileNameWihGuid(SourceFile);

                File.Copy(SourceFile, DestintionFile, true);
            }
            catch (IOException iox)
            {
              MessageBox.Show("Error:" + iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            SourceFile=DestintionFile;
            return true;

        }
    }
}
