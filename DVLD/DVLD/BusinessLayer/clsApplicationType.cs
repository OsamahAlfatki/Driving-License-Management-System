using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplicationType
    {

        public int ApplicationTypeID {  get; set; }
        public string ApplicationTypeTitle {  get; set; }
        public float ApplicationTypeFees {  get; set; }

        enum enMode
        {
            AddNew=1,Update
        }
        enMode _Mode;
     public clsApplicationType() {
            ApplicationTypeID = -1;
            ApplicationTypeTitle = "";
            ApplicationTypeFees = 0;
            _Mode=enMode.AddNew;

        }

        private clsApplicationType (int ApplicationTypeID, string ApplicationTypeTitle, int ApplicationTypeFees)  {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;
            _Mode=enMode.Update;
            }
     
        private bool _AddApplicationType()
        {
           ApplicationTypeID= ApplicationsTypesData.AddNewApplicationType(ApplicationTypeTitle, ApplicationTypeFees);

            return ApplicationTypeID != -1;
        }
        private  bool _UpdateApplicationTypeData()
        {
            return ApplicationsTypesData.UpdateApplicationTypeDataByAppID(this.ApplicationTypeID,this.ApplicationTypeTitle,this.ApplicationTypeFees);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddApplicationType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _UpdateApplicationTypeData();

                default:
                    return false;
            }
        }
        public static DataTable GetAllApplicationTypesData()
        {
           return ApplicationsTypesData.GetAllApplicationTypesList();
        }
        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            int ApplicationFees = 0;
            if (ApplicationsTypesData.FindApplicationTypeByApplicationTypeID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees))
            {
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
            }
            else
            {
                return null;
            }
        }

    }
}
