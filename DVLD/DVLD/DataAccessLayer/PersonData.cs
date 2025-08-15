using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Data;


namespace DataAccessLayer
{
    public class PersonData
    {

        public static int? AddNewPerson(string NationalNo, string FirstName,
            string SecondName,
            string ThirdName, string LastName, short Gender, DateTime BirthOfDate,
            string Address,
            string Phone, string Email,  int NationalityCountryID, 
            string ImagePath)
        {
            int? PersonID =null;
            try {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string Query = $"Insert into People" +
                        " values " +
                        "(@NationalNo,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gender,@Address,@Phone,@Email,@NationalityCountryID,@ImagePath)" +
                        "" +
                        "select scope_identity()";
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {


                        Command.Parameters.AddWithValue("NationalNo", NationalNo);
                        Command.Parameters.AddWithValue("FirstName", FirstName);
                        Command.Parameters.AddWithValue("SecondName", SecondName);
                        Command.Parameters.AddWithValue("Address", Address);
                        Command.Parameters.AddWithValue("NationalityCountryID", NationalityCountryID);
                        Command.Parameters.AddWithValue("LastName", LastName);
                        Command.Parameters.AddWithValue("Gender", Gender);
                        Command.Parameters.AddWithValue("DateOfBirth", BirthOfDate);
                        Command.Parameters.AddWithValue("Phone", Phone);


                        if (ThirdName!=null)
                        {

                            Command.Parameters.AddWithValue("ThirdName", ThirdName);
                        }
                        else
                        {
                            Command.Parameters.AddWithValue("ThirdName", DBNull.Value);

                        }
                        if (Email != null)
                        {
                            Command.Parameters.AddWithValue("Email", Email);
                        }
                        else
                        {
                            Command.Parameters.AddWithValue("Email", DBNull.Value);

                        }

                        if (ImagePath !=null)
                        {
                            Command.Parameters.AddWithValue("ImagePath", ImagePath);


                        }
                        else
                        {
                            Command.Parameters.AddWithValue("ImagePath", DBNull.Value);


                        }



                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                        {

                            PersonID = ID;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                PersonID = null;

            }

           
            return PersonID;

        }



        public static bool UpdatePersonData(int? ID,string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, short Gender,string Address, DateTime BirthOfDate, string Phone, string Email,  int NationalityCountryID,  string ImagePath)
        {
            int RowsAffected = 0;
            try {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string Query = $"Update People  " +
                        " set  " +
                        "NationalNo=@NationalNo, FirstName=@FirstName,SecondName=@SecondName,ThirdName=@ThirdName,LastName=@LastName,DateOfBirth=@BirthOfDate,Gender=" +
                        "@Gender,Address=@Address,Phone=@Phone,Email=@Email,NationalityCountryID=@NationalityCountryID,ImagePath=@ImagePath" +
                        " where PersonID=@ID";
                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {


                        Command.Parameters.AddWithValue("NationalNo", NationalNo);
                        Command.Parameters.AddWithValue("FirstName", FirstName);
                        Command.Parameters.AddWithValue("SecondName", SecondName);
                        Command.Parameters.AddWithValue("Address", Address);
                        Command.Parameters.AddWithValue("NationalityCountryID", NationalityCountryID);
                        Command.Parameters.AddWithValue("LastName", LastName);
                        Command.Parameters.AddWithValue("Gender", Gender);
                        Command.Parameters.AddWithValue("BirthOfDate", BirthOfDate);
                        Command.Parameters.AddWithValue("Phone", Phone);
                        Command.Parameters.AddWithValue("ID", ID);

                        if (ThirdName != null)
                        {

                            Command.Parameters.AddWithValue("ThirdName", ThirdName);
                        }
                        else
                        {
                            Command.Parameters.AddWithValue("ThirdName", DBNull.Value);

                        }
                        if (Email != null)
                        {
                            Command.Parameters.AddWithValue("Email", Email);
                        }
                        else
                        {
                            Command.Parameters.AddWithValue("Email", DBNull.Value);

                        }

                        if (ImagePath == null)
                        {
                            Command.Parameters.AddWithValue("ImagePath", DBNull.Value);

                        }
                        else
                        {

                            Command.Parameters.AddWithValue("ImagePath", ImagePath);

                        }



                         RowsAffected = Command.ExecuteNonQuery(); ;
                      
                    }

                }
                }

            catch (Exception ex)
            {
                RowsAffected = 0;

            }



            return RowsAffected > 0;

        }





        public static bool GetPersonInfoByID(int? ID, ref string NationalNo, ref string FirstName, 
            ref string SecondName,
           ref string ThirdName, ref string LastName, ref short Gender,ref string Address,
           ref DateTime BirthOfDate, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

            try {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) { 

                    string Query = $"select * from People where PersonID=@ID";
               
                Connection.Open();

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Command.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                NationalNo = Convert.ToString(reader["NationalNo"]);

                                FirstName = Convert.ToString(reader["FirstName"]);
                                SecondName = Convert.ToString(reader["SecondName"]);
                                ThirdName = Convert.ToString(reader["ThirdName"]);
                                LastName = Convert.ToString(reader["LastName"]);
                                Gender = Convert.ToInt16(reader["Gender"]);
                                BirthOfDate = Convert.ToDateTime(reader["DateOfBirth"]);
                                Phone = Convert.ToString(reader["Phone"]);
                                NationalityCountryID = Convert.ToInt16(reader["NationalityCountryID"]);
                                Address = Convert.ToString(reader["Address"]);
                                if (reader["ImagePath"] == null)
                                {
                                    ImagePath = null;
                                }
                                else
                                {
                                    ImagePath = Convert.ToString(reader["ImagePath"]);
                                }

                                if (reader["Email"] != null)
                                {
                                    Email = Convert.ToString(reader["Email"]);

                                }
                                else
                                {
                                    Email = null;
                                }
                                if (ThirdName != null)
                                {

                                    ThirdName = Convert.ToString(reader["ThirdName"]);

                                }
                                else
                                {
                                    ThirdName = null;

                                }
                                IsFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsFound = false;

            }

            return IsFound;

        }

        public static bool DeletePersonByID(int ID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"Delete  from People where PersonID=@ID";


            SqlCommand Command = new SqlCommand(Query, Connection);
           
            
                Command.Parameters.AddWithValue("ID", ID);
            
            try
            {
                Connection.Open();
                 RowsAffected = Command.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                RowsAffected= 0;    

            }

            finally
            {
                Connection.Close();
            }

            return RowsAffected>0;


        }

        
        public static bool GetPersonInfoByNationalNo(ref int ID, ref string NationalNo, ref string FirstName, ref string SecondName,
         ref string ThirdName, ref string LastName, ref short Gender,ref string Address, ref DateTime BirthOfDate, 
         ref string Phone, ref string Email,ref int NationalityCountryID,ref string ImagePath)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = $"select * from People where NationalNo=@NationalNo";


            SqlCommand Command = new SqlCommand(Query, Connection);
            
            
                Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            


            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    ID = Convert.ToInt16(reader["PersonID"]);
                    //ID = reader("ID"]

                    FirstName = Convert.ToString(reader["FirstName"]);
                    SecondName = Convert.ToString(reader["SecondName"]);
                    ThirdName = Convert.ToString(reader["ThirdName"]);
                    LastName = Convert.ToString(reader["LastName"]);
                    Gender = Convert.ToInt16(reader["Gender"]);
                    BirthOfDate = Convert.ToDateTime(reader["DateOfBirth"]);
                    Phone = Convert.ToString(reader["Phone"]);
                    NationalityCountryID = Convert.ToInt16(reader["NationalityCountryID"]);
                    ImagePath = Convert.ToString(reader["ImagePath"]);
                    Address = Convert.ToString(reader["Address"]);


                  
                    if (reader["ImagePath"] == null)
                    {
                        ImagePath = null;
                    }
                    else
                    {
                        ImagePath = Convert.ToString(reader["ImagePath"]);
                    }

                    if (reader["Email"] != null)
                    {
                        Email = Convert.ToString(reader["Email"]);

                    }
                    else
                    {
                        Email = null;
                    }
                    if (ThirdName != null)
                    {

                        ThirdName = Convert.ToString(reader["ThirdName"]);

                    }
                    else
                    {
                        ThirdName = null;

                    }
                    IsFound = true;
                    reader.Close();


                }
            }
            catch (Exception ex)
            {

                IsFound = false; 
            }

            finally
            {
                Connection.Close();
                
            }

            return IsFound;



        }

    public static DataTable GetAllPersonsListData()
        {

            DataTable dt = new DataTable();
            SqlConnection Connection=new SqlConnection(clsDataAccessSettings.ConnectionString); ;
            string Query = "select PersonID,NationalNo,FirstName,SecondName,Isnull(ThirdName,' ')as ThirdName,LastName," +
                " Case " +"When People.Gender = 0 " +
                 "then 'Male' " +
                   "Else 'Female' " +
                   "End as Gender," +
                   "CountryName,DateOfBirth,"+
                 "Address,Phone,Email from People inner join Countries on Countries.CountryID = People.NationalityCountryID";
            SqlCommand command=new  SqlCommand(Query,Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex) {
                dt = null;
            }

            finally
            {
                Connection.Close();
            }
            return dt;

        }

        public static bool IsPersonExist(int PersonID)
        {
            bool IsFound = false;
         
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
                @"Select IsFound =1 from People where PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null)
                {

                    IsFound=true;
                }
                else
                    IsFound = false;

            }
            catch (Exception ex)
            {
                IsFound = false;


            }

            finally
            {
                Connection.Close();
            }

               return IsFound;

        }

        public static bool IsPersonExist(string NationalNo)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
                @"Select IsFound =1 from People where NationalNo=@NationalNo";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null)
                {

                    IsFound = true;
                }
                else
                    IsFound = false;

            }
            catch (Exception ex)
            {
                IsFound = false;


            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }
    }
}
