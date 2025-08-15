using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class UsersData
    {

        public static int AddNewUser(int? PersonID, string UserName, string Password,bool IsActive)
        {
            int UserID = -1;
            SqlConnection Connection=new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Insert into Users  values (@PersonID,@UserName,@Password,@IsActive)" +
                " select scope_Identity()";
            SqlCommand Command=new SqlCommand(Query,Connection);

            Command.Parameters.AddWithValue("PersonID", PersonID);
            Command.Parameters.AddWithValue("UserName", UserName);
            Command.Parameters.AddWithValue("Password", Password);
            Command.Parameters.AddWithValue("IsActive", IsActive);

            try
            {
                Connection.Open();
                object Result=Command.ExecuteScalar();
                if (Result != null)
                {
                    UserID = Convert.ToInt32(Result);
                }


            }

            catch(Exception ex) {
            UserID=-1;
            }

            finally
            {
                Connection.Close();
            }

                return UserID;

        }

        public static bool UpdateUserData(int UserID,int? PersonID,string UserName,
            string Password,bool IsActive)
        {
            int RowsAffected=0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Update Users  set PersonID=@PersonID, UserName=@UserName,Password=@Password,IsActive=@IsActive where UserID=@UserID";
                
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("PersonID", PersonID);
            Command.Parameters.AddWithValue("UserName", UserName);
            Command.Parameters.AddWithValue("Password", Password);
            Command.Parameters.AddWithValue("IsActive", IsActive);
            Command.Parameters.AddWithValue("UserID", UserID);
            

            try
            {
                Connection.Open();
               RowsAffected= Command.ExecuteNonQuery();
            


            }

            catch(Exception ex) 
            {
              RowsAffected = 0;
            }

            finally
            {
                Connection.Close();
            }

            return RowsAffected>0;

        }

        public static bool DeleteUserData(int UserID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Delete from Users  where UserID=@UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);

         
            Command.Parameters.AddWithValue("UserID", UserID);


            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();



            }

            catch( Exception ex) 
            {
                RowsAffected = 0;
            }

            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;

        }

        public static bool FindUserByID(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound= false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select UserID,PersonID,UserName,Password,IsActive " +
                "from Users where UserID=@UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("UserID", UserID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                   // FullName = Convert.ToString(Reader["FullName"]);
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    UserName = Convert.ToString(Reader["UserName"]);
                    Password = Convert.ToString(Reader["Password"]);
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);
                    IsFound = true;

                }
                Reader.Close();
           
            }

            catch(Exception ex) 
            {
                IsFound = false;
            }

            finally
            {
                Connection.Close();
            }
            
            return  IsFound;


        }
        public static bool FindUserByUserName(string UserName,ref int UserID, ref int PersonID, ref string Password, ref bool IsActive)
        {
            bool IsUpdated = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select UserID,PersonID,UserName,Password,IsActive " +
                "from Users where UserName=@UserName";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("UserName", UserName);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    // FullName = Convert.ToString(Reader["FullName"]);
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    UserID = Convert.ToInt32(Reader["UserID"]);
                    Password = Convert.ToString(Reader["Password"]);
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);
                    
                    IsUpdated = true;

                }


            }

            catch( Exception ex ) 
            {
                IsUpdated = false;
            }

            finally
            {
                Connection.Close();
            }

            return IsUpdated;


        }
    
      public static bool IsUserExistByID (int UserID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select IsFound=1 from Users  where UserID=@UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("UserID", UserID);


            try
            {
                Connection.Open();
              object Result= Command.ExecuteScalar();
                if (Result != DBNull.Value)
                {
                    IsFound = true;
                }



            }

            catch(Exception ex) 
            {
                IsFound= false;
            }

            finally
            {
                Connection.Close();
            }

            return  IsFound ;
        }

        public static bool GetUserInfoByUserNameAndPassword(string UserName, string Password ,ref int UserID, ref int PersonID, ref bool IsActive)
        {

            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select UserID,PersonID,UserName,Password,IsActive " +
                "from Users where UserName=@UserName and Password=@Password";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    // FullName = Convert.ToString(Reader["FullName"]);
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    UserID = Convert.ToInt32(Reader["UserID"]);
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);

                    IsFound = true;

                }

                else
                {
                    IsFound = false;  
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
        public static bool IsUserExist(string UserName)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select isfound=1 from Users  where UserName=@UserName";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@UserName", UserName);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    IsFound = true;
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
        public static bool IsUserExistByPersonID(int? PersonID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select isfound=1 from Users  where PersonID=@PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("PersonID", PersonID);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    IsFound = true;
                }



            }

            catch( Exception ex) 
            {
                IsFound = false;
            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }
        public static DataTable GetAllUsersData()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = 
                
                "select UserID,People.PersonID,UserName,People.FirstName+'" +
                " '+People.SecondName+' '+People.ThirdName+' '+People.LastName as FullName,IsActive " +
                    "from Users inner join People on Users.PersonID=People.PersonID";


            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader= Command.ExecuteReader();
                
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                else
                {
                    dt = null;
                }
                reader.Close();

            }

            catch(Exception ex) 
            {
                dt = null;
            }

            finally
            {
                Connection.Close();
            }
            return dt ;

        }


    }
}
