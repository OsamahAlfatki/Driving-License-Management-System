using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using DVLDSettings;

namespace DataAccessLayer
{
    public static class ApplicationsTypesData
    {
        public static DataTable GetAllApplicationTypesList()
        {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = $"select ApplicationTypeID as ID,ApplicationTypeTitle as Title ,ApplicationFees as Fees from ApplicationTypes";
                        Connection.Open();
                    ;

                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {

                        using (SqlDataReader Reader = command.ExecuteReader())
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

        public static bool FindApplicationTypeByApplicationTypeID(int ApplicationTypeID,ref string ApplicationTypeTitle,ref int ApplicationTypeFees)
        {
            bool IsFounde=false;

            try {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = $"select ApplicationTypeTitle ,ApplicationFees from ApplicationTypes where ApplicationTypeID=@ApplicationTypeID";
                    ;
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);

                        Connection.Open();
                        using (SqlDataReader Reader = command.ExecuteReader())
                        {
                            while (Reader.Read())
                            {
                                ApplicationTypeTitle = Convert.ToString(Reader["ApplicationTypeTitle"]);
                                ApplicationTypeFees = Convert.ToInt32(Reader["ApplicationFees"]);

                                IsFounde = true;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

                IsFounde = false;
            }

            return IsFounde;

        }
        public static int AddNewApplicationType(string ApplicationTypeTitle,float ApplicationTypeFees)
        {
            int ApplicationTypeID = -1;
            try {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = $"Insert into ApplicationTypes Values( @ApplicationTitle,@ApplicationFees) select scope_Idetity()";
                    ;
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("ApplicationTitle", ApplicationTypeTitle);
                        command.Parameters.AddWithValue("ApplicationFees", ApplicationTypeFees);


                        Connection.Open();
                        object Result = command.ExecuteScalar();

                        if (Result != null)
                        {
                            ApplicationTypeID = Convert.ToInt32(Result);
                        }
                        else
                        {
                            ApplicationTypeID = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                    ApplicationTypeID = -1;
                clsSettings.LogExceptions(ex);

            }


            return ApplicationTypeID;

        }
        public static bool UpdateApplicationTypeDataByAppID(int ApplicationID, string ApplicationTitle, float ApplicationFees)
        {
            int RowsAffected = 0;

            try {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = $"Update ApplicationTypes set ApplicationTypeTitle=@ApplicationTitle,ApplicationFees=@ApplicationFees where ApplicationTypeID=@ApplicationID";
                    ;
                    using (SqlCommand command = new SqlCommand(Query, Connection))
                    {
                        command.Parameters.AddWithValue("ApplicationID", ApplicationID);
                        command.Parameters.AddWithValue("ApplicationTitle", ApplicationTitle);
                        command.Parameters.AddWithValue("ApplicationFees", ApplicationFees);

                        Connection.Open();
                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
                clsSettings.LogExceptions(ex);

            }


            return RowsAffected > 0;

        }

        }
    }
    
    

