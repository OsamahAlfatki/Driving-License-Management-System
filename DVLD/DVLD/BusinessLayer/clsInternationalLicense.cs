using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsInternationalLicense:clsApplication
    {
        public int InternationalLicenseID { get; set; }
        public int LDLID { get; set; }
        public int DriverID {  get; set; }  
     public   clsDriver DriverInfo { get; set; }
        public bool IsActive {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserID {  get; set; }    
        enum enMode
        {
            AddNew,Update
        }
        enMode _Mode=enMode.AddNew;
        public clsInternationalLicense() { 
        this.InternationalLicenseID = 0;
            this.LDLID = 0;
            this.DriverID = 0;
            this.IsActive = true;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            _Mode = enMode.AddNew;
            this.UserID = -1;
        }

        private clsInternationalLicense(
            
            int InternationalLicenseID,int LocalLicenseID,int ApplicationID,int UserID,int DriverID,
            int? ApplicationPersonID,clsApplication.enApplicationStatus ApplicationStatus,int ApplicationTypeID,float ApplicationFees,
            DateTime ApplicationDate,DateTime ApplicationLastStatusDate,
            bool IsActive,DateTime IssueDate,DateTime ExpirationDate)
        {


            base.ApplicationID = ApplicationID;
            base.ApplicationStatus = ApplicationStatus;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID= ApplicationTypeID;
            base.ApplicationUserID = UserID;
            base.Fees = ApplicationFees;
            base.ApplicationPersonID= ApplicationPersonID;
            base.LastStatusDate = ApplicationLastStatusDate;

            this.IssueDate=IssueDate;
            this.ExpirationDate=ExpirationDate;
            this.IsActive =IsActive;
            this.LDLID= LocalLicenseID;
            this.DriverID= DriverID;
            this.DriverInfo=clsDriver.FindDriverInfoByDriverID(this.DriverID);

            _Mode = enMode.Update;
        }



        public static clsInternationalLicense FindByLicenseID(int LicenseID)
        {
            int LocalLicenseID = -1, ApplicationID = -1, UserID = -1, DriverID = -1;
            bool IsActive=false;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;

            if (clsInternationalLicenseData.GetInternationalLicenseInfoByLicenseID(LicenseID, ref DriverID, ref LocalLicenseID, ref UserID, ref IssueDate, ref ExpirationDate, ref ApplicationID, ref IsActive))
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);
                if (Application != null)
                {
                    return new clsInternationalLicense(LicenseID, LocalLicenseID, ApplicationID, UserID,
                        DriverID, Application.ApplicationPersonID, Application.ApplicationStatus, 
                        Application.ApplicationTypeID, Application.Fees, Application.ApplicationDate, 
                        Application.LastStatusDate, IsActive, IssueDate, ExpirationDate);
                }
                return null;
            }
            return null;
                
                
                                
        }

        public static int GetDefualtValidityLength()
        {
            return clsInternationalLicenseData.GetInternationalLicenseValidityLength();
         }
        private bool _AddNewInternationalLicense()
        {
          this.InternationalLicenseID=  clsInternationalLicenseData.AddnternationalLicense(this.ApplicationID, this.DriverID, this.IssueDate, 
              this.ExpirationDate, this.IsActive, this.UserID, this.LDLID);
            return InternationalLicenseID != -1;
        }

        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(this.InternationalLicenseID, ApplicationID, this.DriverID,
                this.IssueDate, this.ExpirationDate, this.IsActive, this.UserID, this.LDLID);
        }
        public bool Save()
        {
            base.Mode = (clsApplication.enMode) _Mode;
            if (!base.Save())
            {
                return false;
            }
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInternationalLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;

                    case enMode.Update: 
                    return _UpdateInternationalLicense();

                default:
                    return false;
            }
        }
        public static int GetActiveInternationalLicense(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationaLicense(DriverID);
        }

        
    
        public static DataTable GetInternationalLicenseHistory(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicense(DriverID);
        }

        public static DataTable GetInternationalLicenseApplications()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenseApplication();
        }
    }
}
