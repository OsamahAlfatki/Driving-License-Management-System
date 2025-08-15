using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DVLDSettings;

namespace DataAccessLayer
{
    public static class clsDetainedLicensesData
    {

        public static bool GetDetainedLicenseInfoByDetainID(int DetainID, ref int LicenseID, ref int ReleaseApplicationUser, ref int ReleaseApplicationID, ref bool IsReleased, ref DateTime ReleaseDate, ref int CreatedUserID, ref DateTime DetainDate, ref float FineFess)
        {

            bool IsFound = true;
                    try
                    {


            using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                      {

            
                string Query = "Select * from DetainedLicenses where DetainedLicenses.LicenseID=@LicenseID order by DetainedLicenses.DetainID desc";

                using (SqlCommand Command = new SqlCommand(Query, Connection))

                     {

                
                    Command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        Connection.Open();


                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                DetainID = Convert.ToInt32(Reader["DetainID"]);
                                CreatedUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                                FineFess = Convert.ToSingle(Reader["FineFees"]);
                                DetainDate = Convert.ToDateTime(Reader["DetainDate"]);
                                IsReleased = (bool)Reader["IsReleased"];
                                if (Reader["ReleaseDate"] != DBNull.Value)
                                {
                                    ReleaseDate = (DateTime)Reader["ReleaseDate"];

                                }
                                else
                                {
                                    ReleaseDate = DateTime.MaxValue;

                                }

                                if (Reader["ReleasedByUserID"] != DBNull.Value)
                                {
                                    ReleaseApplicationUser = (int)Reader["RelaesedByUserID"];
                                }
                                else
                                {
                                    ReleaseApplicationUser = -1;
                                }

                                if (Reader["ReleaseApplicationID"] == DBNull.Value)
                                {
                                    ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];
                                }
                                else
                                {
                                    ReleaseApplicationID = -1;
                                }

                                IsFound = true;
                            }
                            else
                            {
                                IsFound = false;
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

                IsFound = false;
            }
         
            return IsFound;
        }
        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID, ref int DetainID, ref int ReleaseApplicationUser, ref int ReleaseApplicationID, ref bool IsReleased, ref DateTime ReleaseDate, ref int CreatedUserID, ref DateTime DetainDate, ref float FineFess)
        {
            bool IsFound = true;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query =@"Select * from DetainedLicenses where DetainedLicenses.LicenseID=@LicenseID order by DetainedLicenses.DetainID desc";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        Connection.Open();

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                DetainID = Convert.ToInt32(Reader["DetainID"]);
                                CreatedUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                                FineFess = Convert.ToSingle(Reader["FineFees"]);
                                DetainDate = Convert.ToDateTime(Reader["DetainDate"]);
                                IsReleased = (bool)Reader["IsReleased"];
                                if (Reader["ReleaseDate"] != DBNull.Value)
                                {
                                    ReleaseDate = (DateTime)Reader["ReleaseDate"];

                                }
                                else
                                {
                                    ReleaseDate = DateTime.MaxValue;
                                }


                                if (Reader["ReleasedByUserID"] != DBNull.Value)
                                {
                                    ReleaseApplicationUser = (int)Reader["RelaesedByUserID"];
                                }
                                else
                                {
                                    ReleaseApplicationUser = -1;
                                }

                                if (Reader["ReleaseApplicationID"] != DBNull.Value)
                                {
                                    ReleaseApplicationID = (int)Reader["ReleaseApplicationID"];
                                }
                                else
                                {
                                    ReleaseApplicationID = -1;
                                }

                                IsFound = true;
                            }
                            else
                            {
                                IsFound = false;
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                IsFound = false;
                clsSettings.LogExceptions(ex);

            }

            return IsFound;
        }


        public static DataTable GetAllDetainedLicense()
        {
            DataTable dt = new DataTable();

            try { 
            using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) { 

                string Query = @"SELECT * FROM DetainedLicenses_View Order by DetainID desc ,IsReleased desc";


                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {


                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                dt.Load(Reader);
                            }
                            else
                            {
                                dt = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

                dt = null;
            }
          
            return dt;
        }
        public static bool UpdateDetainLicense(int DetainID, int LicenseID, int CreatedByUserID, float FineFees)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update DetainedLicenses " +
                "set CreatedByUserID=@CreatedByUserID,FineFees=@FineFees,LicenseID=@LicenseID where DetainID=@DetainID";


            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@DetainID", DetainID);


            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                RowsAffected = 0; ;

            }

            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;
        }
        public static int AddNewDetainLicense( int LicenseID, int CreatedByUserID, Double FineFees)
        {
            int DetainID = -1;

            try {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {


                    string Query = @"\r\n\tinsert into DetainedLicenses values (@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,0,null,null,null)" +
                        "select scope_Identity();";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {


                        Command.Parameters.AddWithValue("@LicenseID", LicenseID);
                        Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                        Command.Parameters.AddWithValue("@FineFees", FineFees);
                        Command.Parameters.AddWithValue("@DetainDate", DateTime.Now);




                        Connection.Open();

                        object Result = Command.ExecuteScalar(); ;
                        if (Result != null)
                        {

                            DetainID = Convert.ToInt32(Result);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

                DetainID = -1;

            }

            return DetainID;
        }
        public static bool ReleaseDetainedLicense(int DetainId, int ReleasedByUserID, int ReleaseApplicationID)
        {


            int RowsAffected = 0;
            try {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {


                    string Query = @"Update DetainedLicenses " +
                        " set IsReleased=1,ReleaseApplicationID=@ReleaseApplicationID,ReleasedByUserID=@ReleasedByUserID,ReleaseDate=@ReleaseDate " +
                        "where DetainedLicenses.DetainID=@DetainID ";


                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {


                        Command.Parameters.AddWithValue("@DetainID", DetainId);
                        Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                        Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                        Command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
                        Command.Parameters.AddWithValue("@IsReleased", 1); ;


                        Connection.Open();

                        RowsAffected = Command.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

                RowsAffected = -1;

            }

         
            return RowsAffected > 0;
        }
        public static bool IsDetainedLicense(int LicenseID)
        {

            bool IsDetainedOrDeActivated = false;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string Query = @" select top 1 IsDetained=1 from Licenses inner join DetainedLicenses on Licenses.LicenseID=DetainedLicenses.LicenseID where Licenses.LicenseID=@LicenseID and DetainedLicenses.IsReleased='False'" +
                        " ";


                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@LicenseID", LicenseID);

                        Connection.Open();
                        object Result = Command.ExecuteScalar();
                        

                            if (Result != null)
                            {

                                IsDetainedOrDeActivated = true;

                            }
                        
                    }
                }
            
            }
            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

                IsDetainedOrDeActivated = false;
            }

          
            return IsDetainedOrDeActivated;
        }
    }
}
