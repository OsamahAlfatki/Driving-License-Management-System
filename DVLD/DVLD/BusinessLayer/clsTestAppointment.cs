using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTestAppointment
    {
        public int TestAppointmentID {  get; set; }
        public int UserID {  get; set; }
        public int LDLAppID {  get; set; }
        public float PaidFees {  get; set; }
        public bool IsLocked {  get; set; }
        public DateTime AppointmentDate{  get; set; }
        public clsTestTypes.enTestType TestTypeID
        {
            get; set;
        }
       public int RetakeTestApplicationID {  get; set; }
        public clsApplication RetakeTestApplicationInfo { get; set; }
        enum enMode
        {
            AddNew=0,Update
        }

        public int TestID
        {
            get
            {
                return _GetTestID();
            }
        }
        enMode _Mode= enMode.AddNew;    
        public clsTestAppointment()
        {
            this.UserID = -1;
            this.AppointmentDate = new DateTime();
            this.PaidFees = 0;
            this.IsLocked = true;
            this.TestAppointmentID = -1;
            this.RetakeTestApplicationID = -1;
            this.TestTypeID = 0;
            _Mode = enMode.AddNew;

        }
        clsTestAppointment(int testAppointmentID, int userID,int LDlAppID, float paidFees, bool isLocked, DateTime appointmentDate,clsTestTypes.enTestType TestTypeID,int RetakeTestApplicationID)
        {
           this. TestAppointmentID = testAppointmentID;
           this. UserID = userID;
            this.PaidFees = paidFees;
            this.IsLocked = isLocked;
            this.AppointmentDate = appointmentDate;
           this.TestTypeID= TestTypeID;
            this.RetakeTestApplicationID= RetakeTestApplicationID;
            this.RetakeTestApplicationInfo = clsApplication.FindBaseApplication(RetakeTestApplicationID);
            this.LDLAppID = LDlAppID;
            _Mode = enMode.Update;
        }
  
        public static clsTestAppointment FindLastTestAppointment(int LDLAppID,int TestTypeID)
        {

            int UserID = 0, ID = 0, RetakeTestApplicationID = 0;
            bool IsLocked = false;
            float PaidFees = 0;
            DateTime AppointmentDate = DateTime.Now;

            if (TestAppointmentsData.GetLastTestAppointment(LDLAppID,TestTypeID,ref ID ,ref UserID, ref AppointmentDate, ref PaidFees,
                ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(ID, UserID, LDLAppID, PaidFees, IsLocked, AppointmentDate, (clsTestTypes.enTestType) TestTypeID, RetakeTestApplicationID);
            }
            return null;
        }
        public static clsTestAppointment FindTestAppointmentByAppointmentID(int ID)
        {

            int  UserID = 0, LDLAppID = 0, TestTypeID = 0, RetakeTestApplicationID = 0;
            bool IsLocked=false;
            float PaidFees = 0;
            DateTime AppointmentDate= DateTime.Now;
            
            if (TestAppointmentsData.GetTestAppointmentByID(ID,ref LDLAppID,ref UserID,ref AppointmentDate,ref PaidFees,
                ref IsLocked,ref RetakeTestApplicationID,ref TestTypeID))
            {
                return new clsTestAppointment(ID, UserID,LDLAppID, PaidFees, IsLocked, AppointmentDate, (clsTestTypes.enTestType)TestTypeID, RetakeTestApplicationID);
            }
            return null;
        }
      private  bool _UpdateTestAppointmentDataByTestAppointmentID()
        {
            return TestAppointmentsData.UpdateTestAppointmentByTestAppointmentID(this.TestAppointmentID, this.AppointmentDate,this.IsLocked);
        }
        public bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = TestAppointmentsData.AddNewTestAppointment(this.LDLAppID, (int)TestTypeID, this.UserID, this.AppointmentDate, this.PaidFees, this.IsLocked, this.RetakeTestApplicationID);
            return TestAppointmentID != -1;
        }


        public static DataTable GetAllTestAppointmentData()
        {
            return TestAppointmentsData.GetAllTestAppointmentData();
        }
        public static DataTable GetApplicationTestAppointmentperTestType(int LDLAppID,int TestTypeID)
        {
            return TestAppointmentsData.GetTestAppointmentsDataPerTestType(LDLAppID,TestTypeID);
        }
        public DataTable GetApplicationTestAppointmentPerTestType(clsTestTypes.enTestType TestType)
        {
            return TestAppointmentsData.GetTestAppointmentsDataPerTestType(this.LDLAppID, (int)TestType);
        }

     
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateTestAppointmentDataByTestAppointmentID();
                    
                default:
                    return false;

            }
            
        }

        private int _GetTestID()
        {
            return TestAppointmentsData.GetTestID(TestAppointmentID);
        }

       









        public static bool IsPersonHasLockedTestAppointmentByTestAppointmentID(int ID)
        {
            return TestAppointmentsData.IsPersonHasLockedAppointmentByTestAppointmentID(ID);
        }
        public static bool IsPersonHasTestAppointmentAlreadyByLDLAppIDAndTestType(int LDLAppID, int TestTypeID)
        {
            return TestAppointmentsData.IsPersonHaveTestAppointmentByLDLAppIDAndTestType(LDLAppID, TestTypeID);
        }
        public static bool MakeTestAppointmentLockedByTestAppointmentID(int ID)
        {
            return TestAppointmentsData.MakeTestAppointmentLockedByID(ID);
        }
        


    }
}
