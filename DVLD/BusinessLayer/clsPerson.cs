using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace BusinessLayer
{
    public class clsPerson
    {
      public enum enMode
        {
            AddNew = 0, Update = 1
        }

     
        public string NationalNo { get; set; }
        public int? PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

    
        public DateTime BirthOfDate { get; set; }
        public string Address {  get; set; }
        public int NationalityCountryID {  get; set; }
        public string ImagePath {  get; set; }
        public short Gender {  get; set; }
    
        private enMode _Mode = enMode.AddNew;

        public clsCountry _Countryinfo;
        public string FullName()
        {
            if(ThirdName!= null)
            return FirstName+ " " + SecondName+ " " +  ThirdName+ " " + LastName;

            return FirstName+ " " + SecondName+  " " + LastName;

        }

        public clsPerson()
        {
            _Mode = enMode.AddNew;
            NationalNo = null;
            PersonID = -1;
            FirstName = null;
            SecondName = null;
            ThirdName = null;
            LastName = null;
            Email = null;
            Phone = null;
            ImagePath = null;
            BirthOfDate = new DateTime();
            _Mode = enMode.AddNew;
        }
      
        private clsPerson(
            
            int? ID, string nationalNo, string firstName, string secondName, string thirdName, string lastName,
            string email, string phone, DateTime birthOfDate, short gender,string Address,int NationalityCountryID,string ImagePath)
        {
            this.NationalNo = nationalNo;
            this.PersonID = ID;
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.ThirdName = thirdName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.BirthOfDate = birthOfDate;
            this._Mode = enMode.Update;
            this.Gender = gender;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.Address = Address;
            _Countryinfo=clsCountry.Find(NationalityCountryID);
        }


        private async Task<bool> _AddNewPerson()
        {
           this.PersonID = await PersonData.AddNewPerson(NationalNo, FirstName, SecondName, 
                ThirdName, LastName, Gender, BirthOfDate,Address, Phone, Email,NationalityCountryID,ImagePath);
            if (this.PersonID.HasValue)
            {
                return true;

            }
            return false;
        }

        public static bool DeletePersonByID(int PersonID)
        {
            return PersonData.DeletePersonByID(PersonID);
        }
   
        public static DataTable GetAllPersonsData()
        {
            return PersonData.GetAllPersonsListData();
        }

        public static clsPerson Find(int? ID)
        {
            string NationalNo="", FirstName="", SecondName="",
             ThirdName="", LastName="";
            int NationalityCountryID = -1;
            short Gender = 0;
            DateTime BirthOfDate= DateTime.Now;
            string Phone = "", Email = "", ImagePath = "", Address = "";


            if (PersonData.GetPersonInfoByID(ID,ref NationalNo,ref FirstName,ref SecondName,ref ThirdName,ref LastName,ref
                 Gender,ref Address,ref BirthOfDate,ref Phone,ref Email,ref NationalityCountryID,ref ImagePath))
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, Email, Phone, BirthOfDate,
                    Gender,Address,NationalityCountryID,ImagePath);
            }
            return null;
        }

        public static clsPerson Find(string NationalNo)
        {

            string  FirstName = "", SecondName = "",
             ThirdName = "", LastName = "";
            int ID = -1, NationalityCountryID = -1;
            short Gender = 0;
            DateTime BirthOfDate = DateTime.Now;
            string Phone = "", Email = "", ImagePath = "", Address = "";

            if (PersonData.GetPersonInfoByNationalNo(ref ID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref
                 Gender,ref Address, ref BirthOfDate, ref Phone, ref Email,ref NationalityCountryID,ref ImagePath))
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, Email, Phone, BirthOfDate,
                    Gender,Address,NationalityCountryID,ImagePath);
            }
            return null;

        }

        private  async Task<bool> _UpdatePerson()
        {

            return await PersonData.UpdatePersonData(this.PersonID,this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.Gender,this.Address, this.BirthOfDate, this.Phone, this.Email,this.NationalityCountryID,this.ImagePath);
        }

        public  async Task<bool> Save()
        {
            switch (_Mode)
            {

                case enMode.AddNew:
                    if ( await  _AddNewPerson())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                   return await _UpdatePerson();
                default: return false;
            }
            
            }
        public static DataTable GetAllCountriesList()
        {
            return CountriesData.GetAllCountriesData();
        }
        public static bool IsPersonExist(int PersonID)
        {
            return PersonData.IsPersonExist(PersonID);
        }
        public static bool IsPersonExist(string NationalNo)
        {
            return PersonData.IsPersonExist(NationalNo);
        }
    }
}
