using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDetainedLicense
    {

        enum enMode
        {
            AddNew,Update
        }

        enMode _Mode= enMode.AddNew;
        public int DetainID {  get; set; }
        public int LicenseID {  get; set; }
        public bool IsReleased {  get; set; }

        public DateTime ReleasedDate { get; set; }  
        public int CreatedByUserID {  get; set; }
        public clsUser CreatedUserInfo { get; set; }
        public float FineFees {  get; set; }

        public DateTime DetainDate { get; set; }    

        public int ReleasedByUserID { get; set; }
        public clsUser ReleasedUserInfo { get; set; }
        public int ReleaseApplicationID {  get; set; }

        public clsLicense DetainLicenseInfo { get; set; }

        public clsDetainedLicense() { 
        this.IsReleased = false;
            this.ReleaseApplicationID = 0;
            this.LicenseID = 0;
            this.CreatedByUserID = 0;
            this.FineFees = 0;
            this.DetainDate = DateTime.Now;
            this.ReleasedByUserID = 0;
            this.ReleasedDate = DateTime.Now;
            this.DetainID= 0;
            this._Mode = enMode.AddNew;
        
        }

        private clsDetainedLicense(int DetainID,  int LicenseID,  int ReleaseApplicationUser,  int ReleaseApplicationID,  bool IsReleased,  DateTime ReleaseDate,  int CreatedUserID,  DateTime DetainDate,  float FineFess)
        {
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.ReleasedDate= ReleaseDate;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.IsReleased = IsReleased;
            this.CreatedByUserID= CreatedUserID;
            this.CreatedUserInfo = clsUser.Find(CreatedUserID);

            this.ReleasedByUserID= ReleaseApplicationUser;

            this.ReleasedUserInfo=clsUser.Find(ReleasedByUserID);

            this.DetainDate=DetainDate; ;
            this._Mode = enMode.Update;

        this.FineFees= FineFess;
        }

        private bool _AddNewDetainedLicense()
        {
            this.DetainID= clsDetainedLicensesData.AddNewDetainLicense(this.LicenseID, this.CreatedByUserID, this.FineFees);
            return DetainID != -1;
        }

        public bool Release()
        {
            return clsDetainedLicensesData.ReleaseDetainedLicense(DetainID, ReleasedByUserID, ReleaseApplicationID);
        }

        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicensesData.UpdateDetainLicense(this.DetainID,this.LicenseID,this.CreatedByUserID,this.FineFees);    
        }

        public static clsDetainedLicense FindByLicenseID(int LicenseID)
        {
            int DetainID = -1, ReleaseApplicationUser = -1, ReleaseApplicationID = -1, CreatedUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.Now, DetainDate = DateTime.Now;
            float FineFess = 0;

            if (clsDetainedLicensesData.GetDetainedLicenseInfoByLicenseID(LicenseID, ref DetainID,
                ref ReleaseApplicationUser, ref ReleaseApplicationID, ref IsReleased, ref ReleaseDate, ref CreatedUserID, ref DetainDate, ref FineFess))
            {
                return new clsDetainedLicense(DetainID, LicenseID, ReleaseApplicationUser, ReleaseApplicationID, IsReleased, ReleaseDate, CreatedUserID, DetainDate, FineFess);

           }
            
            return null;


        }

        public static DataTable GetAllDetainedLicense()
        {
            return clsDetainedLicensesData.GetAllDetainedLicense();
        }
        public static clsDetainedLicense FindByDetainID(int DetainID)
        {
            int LicenseID = -1, ReleaseApplicationUser = -1, ReleaseApplicationID = -1, CreatedUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.Now, DetainDate = DateTime.Now;
            float FineFess = 0;

            if (clsDetainedLicensesData.GetDetainedLicenseInfoByDetainID( DetainID,ref LicenseID,
                ref ReleaseApplicationUser, ref ReleaseApplicationID, ref IsReleased, ref ReleaseDate, ref CreatedUserID, ref DetainDate, ref FineFess))
            {
                return new clsDetainedLicense(DetainID, LicenseID, ReleaseApplicationUser, ReleaseApplicationID, IsReleased, ReleaseDate, CreatedUserID, DetainDate, FineFess);

            }

            return null;


        }

       public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDetainedLicense())
                    {

                        _Mode = enMode.Update;
                        return true;    
                    }
                    return false;

                    case enMode.Update:
                    return _UpdateDetainedLicense();

                    default: return false;
            }
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
         return clsDetainedLicensesData.IsDetainedLicense(LicenseID);   
        }

    }
}
