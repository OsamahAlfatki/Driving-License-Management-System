using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class CountriesData
    {
        public static DataTable GetAllCountriesData()
        {
            DataTable table = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Countries";
            SqlCommand command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.HasRows)
                {
                    table.Load(reader);

                }

                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Connection.Close();
            }
            return table;


        }



        public static bool GetCountryNameByCountryID(int countryID,ref string CountryName)
        {
            bool IsFound = false;
            //string CountryName = "";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select  CountryName from Countries where CountryID=@CountryID";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("CountryID", countryID);
            try
            {
                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != DBNull.Value)
                {
                    CountryName = Result.ToString();
                }
                IsFound = true;

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

        public static bool GetCountryIDByCountryName(string CountryName,ref int CountryID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select  CountryID from Countries where CountryName=@CountryName";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("CountryName",    CountryName);
            try
            {
                Connection.Open();
                object Result = command.ExecuteScalar();
                if (Result != DBNull.Value)
                {
                    CountryID =Convert.ToInt32(Result);
                }
                IsFound = true;

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
