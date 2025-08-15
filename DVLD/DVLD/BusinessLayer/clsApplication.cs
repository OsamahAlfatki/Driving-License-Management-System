using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class clsApplication
    {
       public enum enApplicationTypes
        {
            AddNewLicense=1,ReNewDrivingLicense=2,ReplacementForLost=3,ReplacementForDamaged=4, ReleaseDetainedLicense,NewInternationalLicense,RetakeTest
        }

     public enum enMode
        {
            AddNew, Update
        }
        public enMode Mode = enMode.AddNew;

        public enum enApplicationStatus
        {
            New=1,Canceled,Completed
        }
        public int ApplicationID {  get; set; }
      public  int ApplicationTypeID {  get; set; }
        public DateTime ApplicationDate {  get; set; }
        public float Fees {  get; set; }
        public int ApplicationUserID {  get; set; }
        public int? ApplicationPersonID{  get; set; }
        public clsPerson PersonInfo { get; set; }
        public DateTime LastStatusDate {  get; set; }
        public clsApplicationType ApplicationTypeInfo { get; set; }
        public  clsUser CreatedUserInfo {  get; set; }
        public enApplicationStatus ApplicationStatus {  get; set; }
        public string FullName
        {
            get
            {
                return clsPerson.Find(ApplicationPersonID).FullName();
            }
        }
        public string StatusText()
        {
            switch (ApplicationStatus)
            {
                case enApplicationStatus.New:

                    return "New";
                    case enApplicationStatus.Canceled:
                    return "Canceled";
                    case enApplicationStatus.Completed:
                    return "Completed";
                default:
                    return "Unknown";
            }
        }
        public clsApplication()
        {
            this.ApplicationDate = DateTime.Now;
            this.Fees = 0;
            this.ApplicationUserID = 0;
            this.LastStatusDate = DateTime.Now;
            this.ApplicationTypeID=-1;
            this.ApplicationID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
           Mode = enMode.AddNew;
        }

        private clsApplication(int ApplicationID,int PersonApplicationID,int
            UserApplicationID,enApplicationStatus ApplicationStatus ,int ApplicationType,DateTime ApplicationDate,float Fees,DateTime LastStatusDate)
        {
            this.ApplicationDate=ApplicationDate;
            this.ApplicationID=ApplicationID;
            this.ApplicationPersonID=PersonApplicationID;
            this.PersonInfo = clsPerson.Find(ApplicationPersonID);
            this.ApplicationUserID = UserApplicationID;
            this.LastStatusDate=LastStatusDate;
            this.Fees=Fees;
            this.ApplicationStatus = ApplicationStatus;
            this.ApplicationTypeID = ApplicationType;
            this.ApplicationTypeInfo=clsApplicationType.Find(ApplicationTypeID);
            this.CreatedUserInfo=clsUser.Find(ApplicationUserID);
            Mode=enMode.Update;
        }
      

        public bool _AddNewApplication()
        {
            ApplicationID =ApplicationsData.AddNewApplication(ApplicationTypeID,ApplicationPersonID,ApplicationUserID,
                ApplicationDate,(int)ApplicationStatus,Fees,LastStatusDate);
          
            return ApplicationID!=-1;
        }
        
     
        public bool Save()
        {
            switch (Mode)
            {
             
                case enMode.AddNew:

                    if (_AddNewApplication())
                    {
                        Mode=enMode.Update; 
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateApplicationData();
                   
                default:
                    return false;

            }

        }

        bool _UpdateApplicationData()
        {
            return ApplicationsData.UpdateApplicationByApplicationID(this.ApplicationID, this.LastStatusDate,(int) this.ApplicationStatus);

        }
        public  bool Cancel()
        {
            return ApplicationsData.UpdateApplicationByApplicationID(this.ApplicationID,this.LastStatusDate, 2);
        }
        public bool SetComplete()
        {
            return ApplicationsData.UpdateApplicationByApplicationID(this.ApplicationID, this.LastStatusDate, 3);

        }
        public static bool IsPersonHaveAnApplicationAlready(int PersonID,int ApplicationTypeID)
        {
            return ApplicationsData.IsPersonHaveActiveApplication(PersonID,ApplicationTypeID);
        }
      
        public static bool DoesPersonHaveApplicationForLicenseClass(int PersonID,int LicenseClass,clsApplication.enApplicationTypes ApplicationTypeID)
        {
            return ApplicationsData.IsPersonHasApplicationByLicenseClassID(PersonID, LicenseClass, (int)ApplicationTypeID);
        }
     public bool IsPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return ApplicationsData.IsPersonHaveActiveApplication(this.ApplicationPersonID, ApplicationTypeID);

        }
        public static int GetActiveApplication(int personID,int ApplicationTypeID)
        {
            return ApplicationsData.GetActiveApplication(personID,ApplicationTypeID);
        }
        public static  int GetActiveApplicationForLicenseClass(int? PersonID,clsApplication.enApplicationTypes ApplicationTypeID,int LicenseClassID)
        {
           return ApplicationsData.GetActiveApplicationForLicenseClass(PersonID, LicenseClassID,(int)ApplicationTypeID);
        }
        public int GetActiveApplication()
        {
            return ApplicationsData.GetActiveApplication(this.ApplicationPersonID,(int)ApplicationTypeID);
        }
        public  bool Delete()
        {
            return ApplicationsData.DeleteApplication(this.ApplicationID);
        }
       public static clsApplication FindBaseApplication(int ID)
        {
            int ApplicationTypeID = -1, ApplicationPersonID = -1, UserID = -1, Status = 1;
            float Fees = 0;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            if (ApplicationsData.FindApplicationInfoByID(ID,ref ApplicationTypeID,ref ApplicationPersonID,ref UserID,ref Status,ref ApplicationDate,ref LastStatusDate,ref Fees))
            {
                return new clsApplication(ID, ApplicationPersonID, UserID,(enApplicationStatus) Status, ApplicationTypeID, ApplicationDate, Fees, LastStatusDate);
            }
            return null;
        }
        
        public static  bool IsApplicationExist(int ApplicationID)
        {
            return ApplicationsData.IsApplicationExist(ApplicationID);
        }
     
    }
}
