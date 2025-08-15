using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  class clsLocalDrivingLicenseApplications:clsApplication
    {
        enum enMode
        {
            AddNew,Update
        }
        enum enTestTypes
        {
            VisionTest = 1, WritingTest, StreetTest
        }
        enMode Mode=enMode.AddNew;
    public int LocalDrivingLicenseApplicationID {  get; set; }
    public int LicenseClassID {  get; set; }    
      
        public string PersonFullName
        {

            get
            {
                return base.PersonInfo.FullName();
            }
        }
        public clsLicenseClass LicenseClassInfo { get; set; }  
        public clsLocalDrivingLicenseApplications()
        {
            this.LicenseClassID = -1;
            this.LocalDrivingLicenseApplicationID= -1;
           Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplications(int LDLAppID,int LicenseClassID, int ApplicationID,int? ApplicationPersonID,int ApplicationTypeID,enApplicationStatus Status,int UserID,DateTime ApplicationDate,DateTime ApplicationLastStatusDate)
        {
            this.LocalDrivingLicenseApplicationID = LDLAppID;
            this.LicenseClassID = LicenseClassID;
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = Status;
            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = ApplicationLastStatusDate;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            this.ApplicationUserID = UserID;
            Mode = enMode.Update;

        }

        private bool _AddNewDrivingLicenseApplication()
        {
            
            
                this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);
            
            return this.LocalDrivingLicenseApplicationID!=-1;
        }

        public static DataTable GetAllLocalDrivingLicenseApplication()
        {
            return LocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplicationData();
        }

        private bool _UpdateLocalDrivingLicenseApplication()

        {
            return LocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplicationByID(this.LocalDrivingLicenseApplicationID,this.ApplicationID ,this.LicenseClassID);
        }

       
        public bool Save()
        {
            base .Mode=(clsApplication.enMode)Mode;
            if (!base.Save())
            {
                return false;   
            }
            switch (Mode)
            {

                case enMode.AddNew:
                    if (_AddNewDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();
                    
                default:
                    return false;
            }
        }

        public static clsLocalDrivingLicenseApplications FindLocalDrivingLicenseApplicationByAppID(int AppID)
        {

            int LDLAppID = 0, LicenseClassID = 0;
            bool IsFound = LocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByAppID(AppID,ref LDLAppID,ref LicenseClassID);
            if (IsFound)
            {
                clsApplication Application = clsApplication.FindBaseApplication(AppID);


                return new clsLocalDrivingLicenseApplications(LDLAppID, LicenseClassID, AppID, Application.ApplicationPersonID, Application.ApplicationTypeID, Application.ApplicationStatus, Application.ApplicationUserID,
                    Application.ApplicationDate, Application.LastStatusDate);

            }

            return null;
        }

        public static clsLocalDrivingLicenseApplications FindLocalDrivingLicenseApplicationInfoByID(int ID)
        {
            int ApplicationID = 0, LicenseClassID = 0;
            bool IsFound = LocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationByLDLAppID(ID, ref ApplicationID, ref LicenseClassID);
            if (IsFound)
            {
                clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);


                return new clsLocalDrivingLicenseApplications(ID,LicenseClassID, ApplicationID,Application.ApplicationPersonID,Application.ApplicationTypeID,Application.ApplicationStatus,Application.ApplicationUserID,
                    Application.ApplicationDate,Application.LastStatusDate);

            }
            
            return null;
        }
        public  bool Delete()
        {
            bool IsLocalDrivingLicenseAppDelete=false;
            bool IsApplicationDelete=false;

            IsLocalDrivingLicenseAppDelete= LocalDrivingLicenseApplicationData.DeleteLocalDrivingApplicationByLocalDrivingAppID(this.LocalDrivingLicenseApplicationID);

            if (!IsLocalDrivingLicenseAppDelete)
            {
                return false;
            }

            return IsApplicationDelete = base.Delete();
                
                }







        public int IssueDrivingLicenseForTheFirstTime(string Notes,int CreatedBuUserID)
        {

            int DriverID = -1;

            clsDriver Driver = clsDriver.FindDriverByPersonID(ApplicationPersonID);

            if (Driver == null)
            {
                Driver=new clsDriver();
                Driver.PersonID= ApplicationPersonID;
                Driver.UserID=CreatedBuUserID;
                Driver.CreatedDate= DateTime.Now;
                if (Driver.Save())
                    DriverID = Driver.DriverID;

                else
                {
                    return -1;

                }
            }

            else
            {
                DriverID=Driver.DriverID;
            }

            clsLicense License= new clsLicense();
            License.DriverID= DriverID;
            License.Notes = Notes;
            License.LicenseClassID=LicenseClassID;
            License.PaidFees = LicenseClassInfo.Fees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.IssueDate = DateTime.Now;
            License.CreatedByUserID =CreatedBuUserID;
            License.ExpirationDate = DateTime.Now.AddYears(LicenseClassInfo.ValidatyLength);
            License.ApplicationID=this.ApplicationID;

            if (License.Save())
            {
                this.SetComplete();
                return License.LicenseID;
            }
            return -1;
        }
        public int GetActiveLicense()
        {
           return clsLicense.GetActiveLicenseByPersonID(ApplicationPersonID, LicenseClassID);
        }

        public bool DoesPassedTestType(clsTestTypes.enTestType TestTypeID)
        {
           return LocalDrivingLicenseApplicationData.DoesPassedTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool DoesPassedTestType(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID)
        {
           return LocalDrivingLicenseApplicationData.DoesPassedTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }

        public static byte TotalTrailsPerTest(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public  byte TotalTrailsPerTest( clsTestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool DoesPassPreviousTests( clsTestTypes.enTestType TestTypeID)
        {
            switch (TestTypeID)
            {

                case clsTestTypes.enTestType.VisitionTest:
                    return true;
                case clsTestTypes.enTestType.WritenTest:

                 return  this.DoesPassedTestType(clsTestTypes.enTestType.VisitionTest);

                case clsTestTypes.enTestType.StreetTest:
                    return this.DoesPassedTestType( clsTestTypes.enTestType.WritenTest);
                default:
                    return false;
            }
           

        }
        public bool DoesAttendTest(clsTestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationData.DoesAttendTest(this.LocalDrivingLicenseApplicationID,(int)TestTypeID);
        }

        public static bool DoesAttendTest(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationData.DoesAttendTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static bool IsThereScheduleTestAppoinment(int LDLAppID,clsTestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationData.IsThereActiveTestAppointment(LDLAppID, (int)TestTypeID);
        }
        public  bool IsThereScheduleTestAppoinment(clsTestTypes.enTestType TestTypeID)
        {
            return LocalDrivingLicenseApplicationData.IsThereActiveTestAppointment(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }


        public byte GetPassedTestCount()
        {
            return clsTest.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }

        public static byte GetPassedTestCount(int LDLAppID)
        {
            return clsTest.GetPassedTestCount(LDLAppID);
        }

        public static bool PassedAllTests(int LDLAppID)
        {
            return clsTest.PassedAllTests(LDLAppID);
        }

        public bool PassedAllTest()
        {
            return clsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }
        public bool IsIssuedLicense()
        {
            return GetActiveLicense() != -1;


        }
       
    }
}
