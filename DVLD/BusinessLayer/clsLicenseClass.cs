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
    public class clsLicenseClass
    {

        public int LicenseClassID {  get; set; }
        public string LicenseClassName { get; set; }
        public string LicenseDescription {  get; set; }

        public byte MinimumAge {  get; set; }
        
        public byte ValidatyLength {  get; set; }

        public float Fees {  get; set; }

        enum enMode
        {
            AddNew,Update
        }
        enMode _Mode= enMode.AddNew;
        public clsLicenseClass() { 
        this. LicenseClassID = 0;
            this.ValidatyLength = 0;
            this.Fees = 0;
            this.MinimumAge = 0;
            this.LicenseDescription = "";
            this.LicenseClassName = "";
            _Mode = enMode.AddNew;


        }

        private clsLicenseClass(int licenseClassID,string LicenseClassName,string LicenseDescription,byte MinimumAge,byte ValidityLength,float Fees)
        {

            this.LicenseClassID = licenseClassID;
            this.LicenseClassName = LicenseClassName;
            this.LicenseDescription = LicenseDescription;
            this.MinimumAge=MinimumAge;
            this.Fees=Fees;
            this.ValidatyLength=ValidityLength;
            _Mode= enMode.Update;
        }
        public static DataTable GetAllLicenseClassData()
        {

            return LicenseClassesData.GetAllLicenseClassData();
        }

        public static clsLicenseClass Find(string LicenseClassName)
        {

            string  LicenseDescription = "";
            int ID = -1; byte MinimumAge = 0, ValidatyLength = 0;
            float Fees = 0;

            if (LicenseClassesData.FindLicenseClassInfoByName(  LicenseClassName,ref ID, ref LicenseDescription, ref MinimumAge, ref ValidatyLength, ref Fees))
            {
                return new clsLicenseClass(ID, LicenseClassName, LicenseDescription, MinimumAge, ValidatyLength, Fees);
            }
            return null;

        }
        public static clsLicenseClass Find(int ID)
        {
            string LicenseClassName = "", LicenseDescription = "";
            byte MinimumAge = 0, ValidatyLength = 0;
            float Fees = 0;

            if (LicenseClassesData.FindLicenseClassInfoByID(ID, ref LicenseClassName, ref LicenseDescription, ref MinimumAge, ref ValidatyLength, ref Fees))
            {
                return new clsLicenseClass(ID, LicenseClassName, LicenseDescription, MinimumAge,ValidatyLength, Fees);
            }
            return null;

        }
        //public static string FindLicenseClassNameByLicenseClassID(int LicenseClassID)
        //{

        //    return LicenseClassesData.FindLicenseClassNameByLicenseClassID(LicenseClassID);
        //}

        //public static int GetMinimumAllowedAgeByLicenseClassID(int LicenseClassID)
        //{
        //    return LicenseClassesData.GetMinimumAllowedAgeOfLicenseClassByLicenseClassID(LicenseClassID);
        //}
        //public static int GetDefaultValidityLengthByLicenseClassID(int LicenseClassID)
        //{
        //    return LicenseClassesData.GetDefaultValidityLengthOfLicenseByLicenseClassID(LicenseClassID);
        //}
 }

}
