using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTest
    {
      

        enum enMode
        {
            AddNew,Update
        }
        enMode _Mode= enMode.AddNew;
        public int TestID {  get; set; }
        public int TestAppointmentID {  get; set; }
        public bool TestResult {  get; set; }
        public string Notes {  get; set; }
        public int UserID {  get; set; }
       public clsTestAppointment TestAppointment;
     
      public  clsTest()
        {
            this.TestAppointmentID=-1;
            this.TestID=-1;
            this.TestResult=false;
            this.Notes = "";
          _Mode= enMode.AddNew; 

        }
        private clsTest(int TestID,int TestAppointmentID,int UserID,string Notes,bool TestResult)
        {
            this.TestID= TestID;
            this.Notes= Notes;
            this.UserID= UserID;
            this.TestResult = TestResult;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointment=clsTestAppointment.FindTestAppointmentByAppointmentID(this.TestAppointmentID);
            _Mode = enMode.Update;


        }
        private bool _AddNew()
        {
                
                this.TestID = TestsData.AddNewTest(TestAppointmentID, TestResult, Notes, UserID);

            return TestID != -1;
        }

        private bool _UpdateTest()
        {
            return TestsData.UpdateTest(this.TestID,this.TestAppointmentID,this.TestResult,this.Notes,this.UserID);
        }


        public static clsTest Find(int TestID)
        {
            int TestAppointmentID = -1, UserID = -1;
            bool TestResult = false;
            string Notes = "";
            if(TestsData.GetTestInfo(TestID,ref TestAppointmentID,ref TestResult,ref Notes,ref UserID)){
                return new clsTest(TestID, TestAppointmentID, UserID, Notes, TestResult);
            }
            return null;
        }

        public static clsTest FindLastTestByPersonIDAndLicenseClassIDAndTestTypeID(int PersonID,int LicensesClassID,clsTestTypes.enTestType TestTypeID)
        {

            int TestAppointmentID = -1, UserID = -1, TestID = -1;
            bool TestResult = false;
            string Notes = "";
            if (TestsData.GetLastTestByPersonIDAndLicenseClassAndTestType(PersonID,(int)TestTypeID,LicensesClassID,ref TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref UserID)){
                return new clsTest(TestID, TestAppointmentID, UserID, Notes, TestResult);
            }
            return null;
        }
        public static DataTable GetAllTests()
        {
           return TestsData.GetAllTests();
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if(_AddNew())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    case enMode.Update:
                    return _UpdateTest();
                    default:
                    return false;

            }


        }

        public static byte GetPassedTestCount(int LDLAppID)
        {
            return TestsData.GetPassedTestCount(LDLAppID);
        }

        public static  bool PassedAllTests(int LDLAppID)
        {
            return GetPassedTestCount(LDLAppID) == 3;
        }

    }
}
