using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace DataAccessLayer
{
    public static class DriversData
    {
      

        public static int AddNewDriver(int? PersonID,int UserID)
        {
            int DriverID = -1; 
            SqlConnection Connection=new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Insert into Drivers " +
                "Values (@PersonID,@UserID,@CreatedDate) Select Scope_Identity()";
            SqlCommand Command=new SqlCommand(Query,Connection);

            Command.Parameters.AddWithValue("PersonID",PersonID);
            Command.Parameters.AddWithValue("UserID",UserID);
            Command.Parameters.AddWithValue("CreatedDate",DateTime.Now);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    DriverID = Convert.ToInt32(Result);
                }

            }

            catch (Exception ex)
            {
                DriverID = -1;
            }

            finally
            {
                Connection.Close();
            }
            return DriverID;

        }

        public static DataTable GetAllDriversData()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString); ;
            string Query = "Select * from Drivers_View Order by FullName desc";
              
            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                else
                {
                    dt = null;
                }


            }
            catch (Exception ex)
            {
                dt = null;
            }

            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public static bool GetDriverDataByPersonID(int? PersonID,ref int DriverID,ref int UserID,ref DateTime CreatedDate)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string Query = "select * from Drivers where Drivers.PersonID=@PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    DriverID = Convert.ToInt32(Reader["DriverID"]);
                    UserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(Reader["CreatedDate"]);
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
        public static bool FindPersonIDByDriverID(int DriverID,ref int PersonID) {

            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string Query = "select Drivers.PersonID from Drivers where Drivers.DriverID=@DriverID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result!=null)
                {
                    PersonID = Convert.ToInt32(Result);
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

        public static bool UpdateDriver(int DriverID,int? PersonID,int UserID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string Query = "Update Drivers set PersonID=@PersonID,CreatedByUserID=@UserID where DriverID=@DriverID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {
                Connection.Open();
                RowsAffected=Command.ExecuteNonQuery();
               



            }

            catch (Exception ex)
            {
               RowsAffected = 0;
            }

            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;


        }
        public static bool FindDriverDataByDriverID(int DriverID,ref int PersonID,ref DateTime CreatedDate,ref int UserID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string Query = "select * from Drivers where Drivers.DriverID=@DriverID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    UserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    CreatedDate = Convert.ToDateTime(Reader["CreatedDate"]);
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

      
    }
}
