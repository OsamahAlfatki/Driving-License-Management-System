using DVLDSettings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public static class LocalDrivingLicenseApplicationData
    {
        public static bool GetLocalDrivingLicenseApplicationByLDLAppID(int LDLAppID, ref int ApplicationID, ref int LicenseClassID)
        {

            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string Query = "Select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LDLAppID ";

                
            

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@LDLAppID", LDLAppID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    LicenseClassID = Convert.ToInt32(Reader["LicenseClassID"]);
                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                    IsFound = true;
                }
                else
                {
                    IsFound = false;
                }

                Reader.Close();


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

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int LDLApplicationID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Insert into LocalDrivingLicenseApplications Values(@ApplicationID,@LicenseClassID)" +

                "select scope_Identity()";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    LDLApplicationID = Convert.ToInt32(Result);

                }
            }


            catch (Exception ex)
            {

                LDLApplicationID = -1;
            }

            finally
            {
                Connection.Close();

            }

        return LDLApplicationID;
        }

        public static DataTable GetAllLocalDrivingLicenseApplicationData()
        {

            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString); ;
            string Query = "Select * from LocalDrivingLicenseApplications_view ";


            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
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

        public static bool GetLocalDrivingLicenseApplicationInfoByAppID(int ApplicationID,ref int LDLAppID  , ref int LicenseClassID)
        {

            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string Query = "Select * from LocalDrivingLicenseApplications where ApplicationID=@AppID ";




            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@AppID", ApplicationID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    LicenseClassID = Convert.ToInt32(Reader["LicenseClassID"]);
                    ApplicationID = Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]);
                    IsFound = true;
                }
                else
                {
                    IsFound = false;
                }

                Reader.Close();


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

        public static bool UpdateLocalDrivingLicenseApplicationByID(int ID, int ApplicationID, int LicenseClassID)
        {

            bool IsUpdated = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"  Update LocalDrivingLicenseApplications set LicenseClassID=@LicenseClassID ,ApplicationID=@ApplicationID where" +
                " LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@ID";




            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@ID", ID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


            try
            {
                Connection.Open();

                int RowsAffected = Command.ExecuteNonQuery(); ;
                if (RowsAffected > 0)
                {

                    IsUpdated = true;
                }

            }
            catch (Exception ex)
            {
                IsUpdated = false;

            }

            finally
            {
                Connection.Close();
            }

            return IsUpdated;
        }
        public static bool DeleteLocalDrivingApplicationByLocalDrivingAppID(int ID)
        {
            bool IsUpdated = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "\r\n\t\t\t\t  delete LocalDrivingLicenseApplications from LocalDrivingLicenseApplications inner " +
                "" +
                "join Applications on LocalDrivingLicenseApplications.ApplicationID=Applications.ApplicationID\r\n\t\t\t\t  where Applications.ApplicationStatus=1 and" +
                " LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@ID";


            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("ID", ID);


            try
            {
                Connection.Open();

                int RowsAffected = Command.ExecuteNonQuery(); ;
                if (RowsAffected > 0)
                {

                    IsUpdated = true;
                }

            }
            catch (Exception ex)
            {
                IsUpdated = false;
                clsSettings.LogExceptions(ex);

            }

            finally
            {
                Connection.Close();
            }

            return IsUpdated;

        }

        public static bool DoesAttendTest(int LocalDrivingLicenseAppID, int TestTypeID)
        {

            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = " select top 1 Found=1 from LocalDrivingLicenseApplications inner join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID"+
              " inner join Tests on Tests.TestAppointmentID=TestAppointments.TestAppointmentID where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@ID and TestAppointments.TestTypeID=@TestTypeID"
                      +"  Order by TestAppointments.TestAppointmentID desc";




            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@ID", LocalDrivingLicenseAppID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar(); ;
                if (Result!=null)
                {

                    Found = true;
                }

            }
            catch (Exception ex)
            {
                Found = false;
                clsSettings.LogExceptions(ex);

            }

            finally
            {
                Connection.Close();
            }

            return Found;
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseAppID, int TestTypeID)
        {

            byte TotalTrialsPerTest = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "\r\n\r\nselect TotalTrialsPerTest=count(Tests.TestID) from LocalDrivingLicenseApplications inner join TestAppointments on " +
                "TestAppointments.LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID\r\ninner join Tests on Tests.TestAppointmentID=TestAppointments.TestAppointmentID where" +
                " LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@ID and TestAppointments.TestTypeID=TestTypeID and Tests.TestResult=0;\r\n";



            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@ID", LocalDrivingLicenseAppID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar(); ;
                if (Result != null &&byte.TryParse(Result.ToString(),out byte Total))
                {

                    TotalTrialsPerTest = Total;
                }

            }
            catch (Exception ex)
            {
                TotalTrialsPerTest = 0;
                clsSettings.LogExceptions(ex);

            }

            finally
            {
                Connection.Close();
            }

            return TotalTrialsPerTest;
        }


        public static bool DoesPassedTest(int LocalDrivingLicenseAppID, int TestTypeID)
        {

            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select top 1 TestResult from LocalDrivingLicenseApplications inner join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                                 inner join Tests on Tests.TestAppointmentID=TestAppointments.TestAppointmentID where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@ID and TestAppointments.TestTypeID=@TestTypeID
                                                                             Order by TestAppointments.TestAppointmentID desc";


            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@ID", LocalDrivingLicenseAppID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar(); ;
                if (Result != null)
                {

                    Found = true;
                }
                else
                {
                    Found = false;
                }

            }
            catch (Exception ex)
            {
                Found = false;
                clsSettings.LogExceptions(ex);

            }

            finally
            {
                Connection.Close();
            }

            return Found;
        }

        public static bool IsThereActiveTestAppointment(int LocalDrivingLicenseAppID, int TestTypeID)
        {

            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @" select top 1 Found=1 from LocalDrivingLicenseApplications inner join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                                 where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@ID and TestAppointments.TestTypeID=@TestTypeID and TestAppointments.IsLocked=0
                                 Order by TestAppointments.TestAppointmentID desc";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@ID", LocalDrivingLicenseAppID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar(); ;
                if (Result != null)
                {

                    Found = true;
                }

            }
            catch (Exception ex)
            {
                Found = false;

            }

            finally
            {
                Connection.Close();
            }

            return Found;
        }
    }

    
}
