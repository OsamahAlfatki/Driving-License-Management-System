using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTestTypes
    {
        enum enMode
        {
            AddNew,Update
        }
        enMode _Mode= enMode.AddNew;
       public enum enTestType
        {
            VisitionTest=1,WritenTest,StreetTest
        }
        
        public enTestType ID {  get; set; }
        public string TestTypeTitle {  get; set; }
        public string TestTypeDescription {  get; set; }
        public float TestTypeFees {  get; set; }

        public clsTestTypes() {
            ID = enTestType.VisitionTest;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0;
        
        }
        private clsTestTypes(clsTestTypes.enTestType ID, string TestTypeTitle,string TestTypeDescription, float TestTypeFees)
        {
            this.ID = ID;
            this.TestTypeTitle= TestTypeTitle;
            this.TestTypeDescription= TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

        }
        public static clsTestTypes Find(clsTestTypes.enTestType TestTypeID)
        {
            string TestTypeTitle = "", TestTypeDescription = "";
            float TestTypeFees = 0;
            if (ManageTestTypesData.FindTestTypeDataByID(Convert.ToInt32(TestTypeID),ref TestTypeTitle,ref TestTypeDescription,ref TestTypeFees))
            {
                return new clsTestTypes(TestTypeID, TestTypeTitle,TestTypeDescription, TestTypeFees);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewTestType()
        {

            return ManageTestTypesData.AddNewTestType(TestTypeTitle, TestTypeDescription, TestTypeFees) != -1;
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {
                        _Mode = enMode.Update;
                        return true;

                    }
                    return false;
                    case enMode.Update:
                    return _UpdateTestType();
                    default:
                    return false;
            }
        }
        private bool _UpdateTestType()
        {
            return ManageTestTypesData.UpdateTestTypeDataByTestID(Convert.ToInt32(this.ID), this. TestTypeTitle, this.TestTypeDescription, this.TestTypeFees);
        }

        public static DataTable GetAllTestTypesData()
        {
            return ManageTestTypesData.GetAllTestTypesList();
        }

    }
}
