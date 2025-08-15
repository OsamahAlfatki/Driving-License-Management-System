using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class TestsData
    {

        public static bool GetTestInfo(int TestID, ref int TestAppointmentID, ref bool TestResult,ref string Notes, ref int UserID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "select * from Tests where TestID=@TestID";
             
            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@TestID", TestID);
            


            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {

                    TestAppointmentID =(int) Reader["TestAppoinmentID"];
                    TestResult =(bool) Reader["TestResult"];
                    UserID =(int) Reader["CreatedByUserID"];
                    if (Reader["Notes"] == DBNull.Value)
                    {
                        Notes = "No Notes";
                    }
                    else
                    {
                        Notes= Reader["Notes"].ToString();

                    }
                    IsFound = true;
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
               IsFound = true;

            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static bool GetLastTestByPersonIDAndLicenseClassAndTestType(int PersonID,int TestTypeID,int LicenseClassID ,ref int TestID,
            ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int UserID)
        {

            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select top 1 Tests.TestResult,Tests.TestID,Tests.TestAppointmentID,Tests.Notes from Tests inner join TestAppointments on TestAppointments.TestAppointmentID=Tests.TestAppointmentID\r" +
                "\ninner join LocalDrivingLicenseApplications on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=TestAppointments.LocalDrivingLicenseApplicationID inner join" +
                " Applications\r\non Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID where Applications.ApplicationPersonID=@PersonID and LocalDrivingLicenseApplications.LicenseClassID=@LicenseClassID and " +
                "TestAppointments.TestTypeID=@TestTypeID  order by TestAppointments.TestAppointmentID desc;";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);



            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {

                    TestAppointmentID = (int)Reader["TestAppoinmentID"];
                    TestResult = (bool)Reader["TestResult"];
                    TestID = (int)Reader["TestID"];
                    UserID = (int)Reader["CreatedByUserID"];
                    if (Reader["Notes"] == DBNull.Value)
                    {
                        Notes = "No Notes";
                    }
                    else
                    {
                        Notes = Reader["Notes"].ToString();

                    }
                    IsFound = true;
                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = true;

            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }
        public static int AddNewTest(int TestAppointmentID,bool TestResult,string Notes,int UserID)
        {
            int TestID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Insert into Tests" +
                " values " +
                "(@TestAppointmentID,@TestResult,@Notes,@UserID); " +
                "Update TestAppointments set IsLocked=1 where TestAppointments.TestAppointmentID=@TestAppointmentID;" +
                "" +
                "select scope_identity()";
            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes == "")
            {
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@Notes", Notes);
            }

            Command.Parameters.AddWithValue("@UserID", UserID);



            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null&&int.TryParse(Result.ToString(),out int ID))
                {

                    TestID = ID;
                }
                else
                {
                    TestID = -1;
                }

            }
            catch (Exception ex)
            {
                TestID = -1;

            }

            finally
            {
                Connection.Close();
            }

            return TestID;
        }

       public static bool UpdateTest(int TestID,int TestAppointmentID, bool TestResult, string Notes, int UserID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Update Tests" +
                " set TestAppointmentID=@TestAppointmentID,TestResult=@TestResult,Notes=@Notes,CreatedByUserID=@UserID  where TestID=@TestID";
              
            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@TestID", TestID);
            if (Notes == "")
            {
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@Notes", Notes);
            }

            Command.Parameters.AddWithValue("@UserID", UserID);



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
        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Tests; ";
                
             
            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    dt.Load(Reader);
                }

                Reader.Close();
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
        public static int GetNumberOfFailedTestsByTestTypeIDAndLDLAppID(int LDLAppID,int TestTypeID)
        {
            int NumberOfFailedTests = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select Count(Tests.TestID) from Tests inner join TestAppointments on " +
                "TestAppointments.TestAppointmentID=Tests.TestAppointmentID \r\n\t\t\t\twhere " +
                "(TestAppointments.LocalDrivingLicenseApplicationID=@LDLAppID and TestAppointments.TestTypeID=@TestTypeID)and\r\n\t\t\t\tTests.TestResult='false'\r\n\t ";



            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("LDLAppID", LDLAppID);
            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    NumberOfFailedTests=Convert.ToInt32(Result.ToString());
                }



            }

            catch(Exception ex) 
            {
                NumberOfFailedTests = 0;
            }

            finally
            {
                Connection.Close();
            }

            return NumberOfFailedTests;
        }
        public static bool IsPersonPassedTestByTestTypeIdAndLDLAppID(int LDLAppID,int TestTypeID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select IsFound=1 from Tests inner join" +
                " TestAppointments on TestAppointments.TestAppointmentID=Tests.TestAppointmentID \r\n\t\t\t\twhere" +
                " (TestAppointments.LocalDrivingLicenseApplicationID=@LDLAppID and TestAppointments.TestTypeID=@TestTypeID)and\r\n\t\t\t\tTests.TestResult='true'\r\n\t \r\n";


            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("LDLAppID", LDLAppID);
            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);


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
      public static byte GetPassedTestCount(int LDLAppID)
        {
            byte NumberOfPassedTests = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "select Count(Tests.TestResult) from Tests  full join TestAppointments on Tests.TestAppointmentID=TestAppointments.TestAppointmentID  " +
             " where TestAppointments.LocalDrivingLicenseApplicationID=@LDLAppID and Tests.TestResult='True'   ";


            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("LDLAppID", LDLAppID);
         

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null&&byte.TryParse(Result.ToString(),out byte N))
                {

                    NumberOfPassedTests = N;
                }

            }
            catch (Exception ex)
            {
                NumberOfPassedTests = 0;

            }

            finally
            {
                Connection.Close();
            }

            return NumberOfPassedTests;
        }
    }
}
