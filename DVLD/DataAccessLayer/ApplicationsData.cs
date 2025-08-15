using System;
using System.CodeDom;
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
    public static class ApplicationsData
    {
        public static int AddNewApplication(int ApplicationType, int? ApplicationPersonID, int ApplicationUserID, DateTime
            ApplicationDate, int ApplicationStatus,
            float Fees, DateTime ApplicationLastStatusDate)
        {
            int ApplicationID = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();
                    string Query = "Insert into Applications Values(@ApplicationPersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus" +
                        ",@ApplicationLastStatusDate,@Fees,@ApplicationUserID)" +
                        "select scope_Identity()";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("ApplicationDate", ApplicationDate);
                        Command.Parameters.AddWithValue("ApplicationPersonID", ApplicationPersonID);
                        Command.Parameters.AddWithValue("ApplicationTypeID", ApplicationType);
                        Command.Parameters.AddWithValue("ApplicationUserID", ApplicationUserID);
                        Command.Parameters.AddWithValue("ApplicationStatus", ApplicationStatus);
                        Command.Parameters.AddWithValue("ApplicationLastStatusDate", ApplicationLastStatusDate);
                        Command.Parameters.AddWithValue("Fees", Fees);

                        object Result = Command.ExecuteScalar();

                        if (Result != null)
                        {
                            ApplicationID = Convert.ToInt32(Result);
                        }
                    }
                }
            }
            

            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

                ApplicationID = -1;
            }

            return ApplicationID;
         
        }

        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string query = @"select * from ApplicationsList_View order by ApplicationDate desc";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }


                }
            }

            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

              
            }


            return dt;
        }
        public static bool DeleteApplication(int ApplicationID)
        {

            int RowsAffected = 0;
            try {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string Query = @"Delete from Applications where ApplicationID=@ApplicationID";
                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);



                        RowsAffected = Command.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {
                RowsAffected = -1;
                clsSettings.LogExceptions(ex);

            }


            return RowsAffected > 0;
        }
        public static bool IsPersonHaveActiveApplication(int? PersonID,int ApplicationTypeID)
        {
            return GetActiveApplication(PersonID, ApplicationTypeID) != -1;
        }
        public static bool IsApplicationExist(int ApplicationID)
      {

            bool IsFound = false;

            try {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = "Select IsFound = 1 from Applications where ApplicationID=@ApplicationID";
                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);



                        object Result = Command.ExecuteScalar();

                        if (Result != null)
                        {
                            IsFound = true;

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
        public static bool IsPersonHasApplicationByLicenseClassID(int PersonID,int LicenseClassID,int ApplicationTypeID)
        {
            bool IsFound = false;
            try {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = $"Select IsFound = 1 from Applications inner join LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID" +
                      " where ApplicationPersonID =@ApplicationPersonID and LicenseClassID =@LicenseClassID  and (ApplicationStatus = 1 or   ApplicationStatus=  3) and Applications.ApplicationTypeID=@ApplicationTypeID ";
                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ApplicationPersonID", PersonID);
                        Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                        Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);


                        object Result = Command.ExecuteScalar();

                        if (Result != null)
                        {
                            IsFound = true;

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

      
        public static bool FindApplicationInfoByID(int ID,ref int ApplicationTypeID,ref int ApplicationPersonID,ref int UserID,ref int Status,ref DateTime ApplicationDate,ref DateTime LastStatusDate,ref float Fees)
        {
            bool IsFound = false;
            try {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    Connection.Open();


                    string Query = $"select * from Applications where Applications.ApplicationID=@ID";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Command.Parameters.AddWithValue("@ID", ID);

                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.Read())
                            {
                                ApplicationDate = Convert.ToDateTime(Reader["ApplicationDate"]);
                                LastStatusDate = Convert.ToDateTime(Reader["LastStatusDate"]);
                                Fees = Convert.ToSingle(Reader["PaidFees"]);
                                ApplicationPersonID = Convert.ToInt32(Reader["ApplicationPersonID"]);
                                UserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                                Status = Convert.ToInt32(Reader["ApplicationStatus"]);
                                ApplicationTypeID = Convert.ToInt32(Reader["ApplicationTypeID"]);

                                IsFound = true;
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
        public static bool UpdateApplicationByApplicationID(int ID, DateTime ApplicationLastStatusDate,int ApplicationStatus)
        {
            int RowsAffected=0;
            try {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string Query = $"Update Applications set Applications.ApplicationStatus=@ApplicationStatus ," +
                        "Applications.LastStatusDate=@LastStatusDate where Applications.ApplicationID=@ID";


                    Connection.Open();
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Command.Parameters.AddWithValue("ID", ID);
                        Command.Parameters.AddWithValue("ApplicationStatus", ApplicationStatus);
                        Command.Parameters.AddWithValue("LastStatusDate", ApplicationStatus);

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

        public static int GetActiveApplication(int? PersonID,int ApplicationTypeID)
        {
            int ApplicationID = -1;
            try {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = $"Select Applications.ApplicationID from Applications where ApplicationPersonID=@ApplicationPersonID and ApplicationTypeID=@ApplicationTypeID and Status=1";
                        Connection.Open();
                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ApplicationPersonID", PersonID);
                        Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int AppID))
                        {
                            ApplicationID = AppID;

                        }
                        else
                        {
                            ApplicationID = -1;
                        }

                    }
                }
            }


            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

                ApplicationID = -1;
            }

           
            return ApplicationID;

        }

        public static int GetActiveApplicationForLicenseClass(int? PersonID, int LicenseClassID, int ApplicationTypeID)
        {


            int ApplicationID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString)) { 
                    string Query = $"Select Applications.ApplicationID from Applications inner join LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID" +
                      " where ApplicationPersonID =@ApplicationPersonID and LicenseClassID =@LicenseClassID  and (ApplicationStatus = 1 or   ApplicationStatus=  3) and Applications.ApplicationTypeID=@ApplicationTypeID ";

                    Connection.Open();

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@ApplicationPersonID", PersonID);
                        Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                        Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int AppID))
                        {
                            ApplicationID = AppID;

                        }
                        else
                        {
                            ApplicationID = -1;
                        }
                    }
            }
            }


            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

                ApplicationID = -1;
            }

           
            return ApplicationID;
        }

    }

}
