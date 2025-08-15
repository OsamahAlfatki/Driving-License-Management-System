using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  class clsDriver
    {
        enum enMode
        {
            AddNew,Update
        }
        public clsPerson PersonInfo { get; set; }
        private enMode _Mode=enMode.AddNew;
        public int? PersonID {  get; set; }
      public  int DriverID {  get; set; }
      public int UserID {  get; set; }
        public DateTime CreatedDate { get; set; }


      public  clsDriver() { 
        this.DriverID = -1;
        this.UserID = -1;
        this.CreatedDate = DateTime.Now;
            _Mode = enMode.AddNew;
        }

        private bool _AddNewDriver()
        {
            this.DriverID=DriversData.AddNewDriver(this.PersonID,UserID);
            return this.DriverID!= -1;
        
        
        }

       
        private clsDriver(int driverID,int? PersonID, int userID, DateTime createdDate
            ) 
        {
            DriverID = driverID;
            UserID = userID;
            CreatedDate = createdDate;
            this.PersonID = PersonID;   
            PersonInfo=clsPerson.Find(this.PersonID);
        }

        public static clsDriver FindDriverByPersonID(int? PersonID)
        {

            int DriverID = 0, UserID = 0;
            DateTime CreatedDateTime = DateTime.Now;
            if (DriversData.GetDriverDataByPersonID(PersonID, ref DriverID,ref UserID,ref CreatedDateTime))
            {
                return new clsDriver(DriverID, PersonID, UserID, CreatedDateTime);
            }

            return null;
        }
        public static clsDriver FindDriverInfoByDriverID(int DriverID)
        {
            int PersonID=0, UserID=0;
            DateTime CreatedDateTime=DateTime.Now;
            if (DriversData.FindDriverDataByDriverID(DriverID, ref PersonID, ref CreatedDateTime, ref UserID))
            {
                return new clsDriver(DriverID, PersonID, UserID, CreatedDateTime);
            }

            return null;
        }

        private bool _UpdateDriver()
        {
            return DriversData.UpdateDriver(DriverID,PersonID,UserID);

        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }

                    return false;

                    case enMode.Update:
                    return _UpdateDriver();
                    default:
                    return false;
            }
        }
        public static DataTable GetLicenses(int DriverID)
        {
            return clsLicense.GetDriverLicenses(DriverID);
        }
        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
          return  clsInternationalLicense.GetInternationalLicenseHistory(DriverID);
        }
        public static DataTable GetAllDriversData()
        {
            return DriversData.GetAllDriversData();
        }
       
    }
}
