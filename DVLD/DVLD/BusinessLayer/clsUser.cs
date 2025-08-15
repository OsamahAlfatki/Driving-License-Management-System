using DataAccessLayer;
using DVLDSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class clsUser 
    {
        public string FullName { get; set; }

        public string UserName { get; set; }
        public string Password
        {
            get;



            set;
            

        }
        public int UserId { get; set; }
        public bool IsActive {  get; set; }
       public int? PersonID {  get; set; }
        enum enMode
        {
            AddNew=0,Update=1
        }
        enMode _Mode=enMode.AddNew;
        public clsPerson _Person;
       public clsUser()
        {
            this.UserId = 0;
            this.UserName = "";
            this.Password = "";
            this.IsActive = true;
            this.PersonID = 0;  
            _Mode = enMode.AddNew;

        }

        private clsUser(int UserID,int PersonId,string UserName,string Password,bool IsActive)
        {
            this.UserId = UserID;   
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonID = PersonId;
            _Mode = enMode.Update;
            _Person=clsPerson.Find(PersonID);


        }

        private bool _AddNewUser()
        {
            this.UserId=UsersData.AddNewUser(this.PersonID,this.UserName, clsSettings.EncryptPasswordByHashing(this.Password),this.IsActive);
            return this.UserId != -1;
        }

        private bool _UpdateUserInfo()
        {
            return UsersData.UpdateUserData(this.UserId, this.PersonID, this.UserName, clsSettings.EncryptPasswordByHashing(this.Password), this.IsActive);
        }
        public static bool DeleteUserById(int UserID)
        {
            return UsersData.DeleteUserData(UserID);
        }

        public static clsUser Find(string UserName,string Password)
        {

            int PersonID = -1, UserID = -1;
            bool IsActive = false;
            if (UsersData.GetUserInfoByUserNameAndPassword(UserName,clsSettings.EncryptPasswordByHashing( Password), ref UserID, ref PersonID, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;
        }
        public static clsUser Find(int UserID)
        {
            int PersonID = 0;
            string UserName = "", Password = "";
            bool IsActive = false;
            if (UsersData.FindUserByID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserID,PersonID,UserName,Password,IsActive);
            }
            return null;
        }

        public static clsUser Find(string UserName)
        {
            int PersonID = 0, UserID = 0;
            string Password = "";
            bool IsActive = false;
            if (UsersData.FindUserByUserName(UserName,ref UserID, ref PersonID, ref Password, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            return null;
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }

              case enMode.Update:
                    return _UpdateUserInfo();

                default:
                    return false;
            }

        }
        public static DataTable GetAllUsersList()
        {
            return UsersData.GetAllUsersData();
        }
        public static bool IsUserExist(int UserID)
        {
            return clsUser.IsUserExist(UserID);
        }
        public static bool IsUserExist(string UserName)
        {
            return UsersData.IsUserExist(UserName);
        }

        public static bool IsUserExistByPersonID(int? PersonID)
        {
            return UsersData.IsUserExistByPersonID(PersonID);
        }
    }
}
