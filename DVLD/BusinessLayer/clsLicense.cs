using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.SessionState;

namespace BusinessLayer
{
    public class clsLicense
{
        public clsDriver Driver { get; }
        public int DriverID {  get; set; }
       public int LicenseClassID {  get; set; }
           public  enum enIssueReason
          {
             FirstTime=1,RenewLicense,ReplacementForDamaged,ReplacementForLost
          }
           public enIssueReason IssueReason { get; set; }
            public int  LicenseID {  get; set; }
              
            public DateTime IssueDate {  get; set; }       
            public DateTime ExpirationDate {  get; set; }   
            public string Notes {  get; set; }               
            public float PaidFees {  get; set; }               
            public bool IsActive {  get; set; }       
        public int ApplicationID { get; set; }
            public int CreatedByUserID {  get; set; }
         public clsLicenseClass LicenseClassInfo;

       public string IssueReasonText
        {
            get
            {
                return IssueReasontext(this.IssueReason);
            }
        }
        public clsDetainedLicense DetainLicenseInfo { get; set; }   
        public bool IsDetained
        {
            

            get
            {
                return clsDetainedLicense.IsLicenseDetained(LicenseID);
            }
          
        }
       enum enMode
        {

            AddNew,Update
        }
        enMode _Mode=enMode.AddNew;
                   
        public clsLicense() {
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this._Mode = enMode.AddNew;    
            this.PaidFees = 0;
            this.LicenseID = -1;
            this.IsActive = false;
            this.IssueDate = new DateTime();
            this.ExpirationDate = new DateTime();
            this.Notes = "";
            this.CreatedByUserID = -1;
            this.ApplicationID = -1;
        }

        private clsLicense(int LicenseID, int ApplicationID, int UserID,int DriverID,int LicenseClassID,float PaidFees,enIssueReason IssueReason,bool IsActive,string Notes,DateTime IssueDate,DateTime ExpirationDate)
        {


            this.DriverID = DriverID;
            this.Driver=clsDriver.FindDriverInfoByDriverID(DriverID);
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo=clsLicenseClass.Find(LicenseClassID);
            this.ApplicationID=ApplicationID;
            this.PaidFees = PaidFees;
            this.LicenseID = LicenseID;
            this.IsActive = IsActive;
            this.IssueDate =IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.CreatedByUserID=UserID;
            this.IssueReason= IssueReason;
            DetainLicenseInfo=clsDetainedLicense.FindByLicenseID(LicenseID);
            _Mode = enMode.Update;

        }

        private bool _AddNewDrivingLicense()
        {


           
                this.LicenseID = LicensesData.AddNewDrivingLicense(ApplicationID, DriverID, LicenseClassID, IssueDate,ExpirationDate, this.Notes, this.PaidFees, IsActive, (byte)this.IssueReason, this.CreatedByUserID);


            return LicenseID != -1;
        }

        private bool _UpdateDrivingLicense()
        {
            return LicensesData.UpdateLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive,(Byte) IssueReason, CreatedByUserID);
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDrivingLicense())
                    { 
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                       return false;
                    }

                    case enMode.Update:
                  return _UpdateDrivingLicense();
                    default:
                    
                    return false;  
            }
        }


        public static clsLicense Find(int LicenseID)
        {
            int DriverID = -1, LicenseClassID = -1, ApplicationID = -1, UserID = -1;
            float Fees = 0;
            DateTime IssueDate=new DateTime(), ExpirationDate=new DateTime  ();
            string Notes = "";
            bool IsActive = false;
            byte IssueReason = 0;

            if (LicensesData.GetLicenseInfoByID(LicenseID,ref ApplicationID, ref DriverID,ref LicenseClassID,ref UserID,ref Fees,
            ref IssueDate, ref ExpirationDate, ref Notes,ref IsActive, ref IssueReason)){
                return new clsLicense(LicenseID,ApplicationID,UserID,DriverID,LicenseClassID,Fees,(enIssueReason)IssueReason,IsActive,Notes,IssueDate,ExpirationDate);
            }
            return null;
        }
      

        public static bool IsLicenseExistByID(int? PersonID,int LicenseClassID)
        {
            return LicensesData.GetActiveLicenseByPersonID(PersonID, LicenseClassID) != -1;
        }

        public static DataTable GetAllLicensesData()
        {
            return LicensesData.GetAllLicenses();
        }

        public static DataTable GetAllDriverLicenses(int DriverID)
        {
            return LicensesData.GetDriverLicenses(DriverID);
        }

        public bool IsLicenseExpired()
        {
            return ExpirationDate < DateTime.Now;
        }

        public static int GetActiveLicenseByPersonID(int? PersonID,int LicenseClassID)
        {
            return LicensesData.GetActiveLicenseByPersonID(PersonID , LicenseClassID);
        }



        public bool DeActivatedCurrentLicense()
        {
            return LicensesData.DeActivatedLicenseByLicenseID(LicenseID);
        }

        public string IssueReasontext(enIssueReason Reason)
        {
            switch (Reason)
            {
                case enIssueReason.RenewLicense:
                    return "Renew License";
                case enIssueReason.ReplacementForLost:
                    return "Replacement for Lost";
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.ReplacementForDamaged:
                    return "Replacement for Damaged";
                default:
                    return "Not Valid";
            }
        }


        public clsLicense Replace(enIssueReason reason, int UserID)
        {

            clsApplication Application = new clsApplication();

            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationPersonID = Driver.PersonID;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            Application.ApplicationTypeID = (int)reason;
            Application.ApplicationUserID = UserID;
            Application.LastStatusDate = DateTime.Now;
            Application.Fees = clsApplicationType.Find((int)reason).ApplicationTypeFees;

            if (!Application.Save())
            {
                return null;
            }
            clsLicense License = new clsLicense();
            License.ApplicationID = Application.ApplicationID;
            License.Notes = Notes;
            License.CreatedByUserID = UserID;
            License.LicenseClassID = this.LicenseClassID;
            License.PaidFees = this.PaidFees;
            License.IsActive = true;

            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(LicenseClassInfo.ValidatyLength);
            License.IssueReason = IssueReason;
            License.DriverID = this.DriverID;
            if (License.Save())
            {
                DeActivatedCurrentLicense();
                Application.SetComplete();
                return License;
            }

            return null;

        }


        public clsLicense Renew(string Notes,int UserID)
        {
            clsApplication Application = new clsApplication();
        
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationPersonID=Driver.PersonID;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            Application.ApplicationTypeID =(int) clsApplication.enApplicationTypes.ReNewDrivingLicense;
            Application.ApplicationUserID = UserID;
            Application.LastStatusDate= DateTime.Now;
            Application.Fees = clsApplicationType.Find((int)clsApplication.enApplicationTypes.ReNewDrivingLicense).ApplicationTypeFees;

            if (!Application.Save())
            {
                return null;
            }
            clsLicense License=new clsLicense();
            License.ApplicationID = Application.ApplicationID;
            License.Notes = Notes;
            License.CreatedByUserID = UserID;
            License.LicenseClassID = this.LicenseClassID;
            License.PaidFees =this.PaidFees;
            License.IsActive = true;
            License.IssueDate= DateTime.Now;
            License.ExpirationDate= DateTime.Now.AddYears(LicenseClassInfo.ValidatyLength);
            License.IssueReason = enIssueReason.RenewLicense;
            License.DriverID=this.DriverID;
            if(License.Save())
            {
                DeActivatedCurrentLicense();
                Application.SetComplete();
                return License;
            }

            return null;

        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return LicensesData.GetDriverLicenses(DriverID);
        }

        public int Release(int UserID)
        {
            clsApplication Applicaion=new clsApplication();
            Applicaion.ApplicationTypeID =(int) clsApplication.enApplicationTypes.ReleaseDetainedLicense;
            Applicaion.ApplicationPersonID=Driver.PersonID;
            Applicaion.ApplicationStatus=clsApplication.enApplicationStatus.New;
            Applicaion.ApplicationUserID=UserID;
            Applicaion.LastStatusDate= DateTime.Now;
            Applicaion.ApplicationDate= DateTime.Now;
            Applicaion.Fees=clsApplicationType.Find((int)clsApplication.enApplicationTypes.ReleaseDetainedLicense).ApplicationTypeFees;

            if (!Applicaion.Save())
            {
                return -1;
            }
            if (DetainLicenseInfo != null)
            {
                DetainLicenseInfo.ReleaseApplicationID=Applicaion.ApplicationID;
                DetainLicenseInfo.IsReleased = true;
                DetainLicenseInfo.ReleasedDate= DateTime.Now;
                DetainLicenseInfo.ReleasedByUserID=UserID;

                if (DetainLicenseInfo.Release())
                {
                    return DetainLicenseInfo.ReleaseApplicationID;
                }
            }
            return -1;

        }


        public int Detain(float FineFees,int UserID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.FineFees= FineFees;
            detainedLicense.CreatedByUserID= UserID;
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate= DateTime.Now;
            if (!detainedLicense.Save())
            {
                return -1;
            }
            return detainedLicense.DetainID;

        }
      
        //public static bool IsPersonHasLicenseByPersonIDAndLicenseClassID(int PersonID, int LicenseClassID)
        //{
        //    return LicensesData.IsPersonHasLicenseByPersonIDAndLicenseClassID(PersonID, LicenseClassID);
        //}

        //public static bool IsLicenseDetainedOrDeactivatedByID(int LicenseID)
        //{
        //    return LicensesData.IsLicenseDetainedOrDiActivatedByLicenseID(LicenseID);
        //}

        //public static bool IsDetainedNotReleasedByDetainID(int DetainID)
        //{
        //    return LicensesData.IsDetainedNotReleasedByDetainID(DetainID);
        //}
        //public static bool IsLicenseDetained(int LicenseID)
        //{
        //    return LicensesData.IsLicenseDetainedByID(LicenseID);
        //}

        //public static bool DetainedLicenseByID(ref int DetainID,int LicenseID,int UserID,Double FineFees,byte IsReleased,DateTime DetainDate)
        //{
        //    return LicensesData.DetainLicenseByID(ref DetainID,LicenseID, UserID, FineFees, IsReleased, DetainDate) ;
        //}
        ////public static bool DeActivatedLicenseByLicenseID(int LicenseID)
        ////{
        ////    return LicensesData.DeActivatedLicenseByLicenseID(LicenseID);
        ////}
        //public static DataTable GetAllDetainedLicensesList()
        //{
        //    return LicensesData.GetAllDetainedLicensesList();
        //}


        //public static bool ReleaseDetainedLicenseByDetainID(int DetainID,int ReleasedByUserID, int ReleaseApplicationID, byte IsRelease, DateTime ReleaseDate)
        //{
        //    return LicensesData.ReleaseDetainedLicense(DetainID, ReleasedByUserID, ReleaseApplicationID, IsRelease, ReleaseDate);
        //}
        //public static bool FindDetainedLicenseInfoByLicenseID(int LicensesID,ref int DetainID,ref int UserID,ref Double FineFees,ref DateTime DetainDate)
        //{
        //    return LicensesData.FindDetainedLicenseInfoByLicenseID(LicensesID, ref DetainID, ref UserID, ref DetainDate, ref FineFees);
        //}


    }
}
