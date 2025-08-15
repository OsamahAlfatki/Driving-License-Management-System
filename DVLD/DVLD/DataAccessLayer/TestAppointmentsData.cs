using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TestAppointmentsData
    {

        public static DataTable GetTestAppointmentsDataPerTestType(int LDLApp,int TestTypeID) { 
        
        DataTable dataTable = new DataTable();

            SqlConnection Connection=new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select TestAppointmentID,AppointmentDate,PaidFees,IsLocked from TestAppointments Where LocalDrivingLicenseApplicationID=@LDLApp and TestTypeID=@TestTypeID order by TestAppointmentID desc";
            SqlCommand Command=new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("LDLApp",LDLApp);
            Command.Parameters.AddWithValue("TestTypeID",TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dataTable.Load(Reader);
                }
                else
                {
                    dataTable = null;
                }
                Reader.Close();
            }

            catch (Exception ex)
            {
                dataTable = null;
            }


            finally
            {
                Connection.Close();
                
            }
            return dataTable;   
        
        
        }

        public static bool GetLastTestAppointment(int LDLAppID, int TestType, ref int TestAppointmentID, ref int UserID, ref DateTime AppointmentDate,
            ref float PaidFees, ref bool IsLocked, ref int RetakeTestApplicationID)
        {

            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"select top 1 from TestAppointments where LocalDrivingLicenseApplicationID=@ID and TestTypeID=@TestTypeID order by TestAppointmentID desc";



            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@ID", LDLAppID);
            Command.Parameters.AddWithValue("@TestTypeID", TestType);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    TestAppointmentID = (int)Reader["TestAppointmentID"];
                    IsLocked = Convert.ToBoolean(Reader["IsLocked"]);
                    UserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    AppointmentDate = Convert.ToDateTime(Reader["AppointmentDate"]);
                    if (Reader["RetakeTestApplicationID"] != DBNull.Value)
                    {
                        RetakeTestApplicationID = Convert.ToInt32(Reader["RetakeTestApplicationID"]);

                    }
                    else
                    {
                        RetakeTestApplicationID = -1;

                    }

                    TestType = Convert.ToInt32(Reader["TestTypeID"]);


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

        public static DataTable GetAllTestAppointmentData()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Select * from TestAppointments_View Order by TestAppointmentDate Desc";
            SqlCommand Command = new SqlCommand(Query, Connection);
       

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
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
        public static bool GetTestAppointmentByID(int ID,
            
            ref int LDLAppID,ref int UserID,ref DateTime AppointmentDate,
            ref float PaidFees,ref bool IsLocked,ref int RetakeTestApplicationID,ref int TestType)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from TestAppointments where TestAppointmentID=@ID";



            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("ID", ID);


            try
            {
                Connection.Open();
                SqlDataReader Reader= Command.ExecuteReader();
                if (Reader.Read())
                {
                    LDLAppID = Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]);
                    IsLocked = Convert.ToBoolean(Reader["IsLocked"]);
                    UserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    AppointmentDate = Convert.ToDateTime(Reader["AppointmentDate"]);
                    if (Reader["RetakeTestApplicationID"] != DBNull.Value)
                    {
                        RetakeTestApplicationID = Convert.ToInt32(Reader["RetakeTestApplicationID"]);

                    }
                    else {
                        RetakeTestApplicationID = -1;

                    }

                    TestType = Convert.ToInt32(Reader["TestTypeID"]);


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
            
            return IsFound;
        }
        

        
        public static int AddNewTestAppointment(int LDLAppID,int TestTypeID,int UserID,DateTime AppointmentDate,float PaidFees,bool IsLocked,int RetakeTestApplicationID )
        {
            int TestAppointmentID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Insert into TestAppointments" +
                " values " +
                "(@TestTypeID,@LDLApp,@AppointmentDate,@PaidFees,@UserID,@IsLocked,@RetakeTestApplicationID)" +
                "" +
                "select scope_identity()";
            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("LDLApp", LDLAppID);
            Command.Parameters.AddWithValue("AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("PaidFees", PaidFees);
            Command.Parameters.AddWithValue("UserID", UserID);
            Command.Parameters.AddWithValue("IsLocked", IsLocked);
            if (RetakeTestApplicationID != -1)
            {
                Command.Parameters.AddWithValue("RetakeTestApplicationID", RetakeTestApplicationID);

            }
            else
            {
                Command.Parameters.AddWithValue("RetakeTestApplicationID", DBNull.Value);

            }



            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null)
                {

                    TestAppointmentID = Convert.ToInt32(Result);
                }

            }
            catch (Exception ex)
            {
                TestAppointmentID = -1;

            }

            finally
            {
                Connection.Close();
            }

            return TestAppointmentID;
        }

        public static bool UpdateTestAppointmentByTestAppointmentID(int TestAppointmentID,DateTime Date,bool IsLocked)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Update TestAppointments" +
              " set AppointmentDate=@Date, IsLocked=@IsLocked " +
              "where TestAppointments.TestAppointmentID=@TestAppointmentID";
             
            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("Date", Date);
            Command.Parameters.AddWithValue("IsLocked", IsLocked);
           


            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();
              
            }
            catch (Exception ex)
            {
                RowsAffected =0;

            }

            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;
        }


        public static int GetTestID(int TestAppointmentID)
        {

            int TestTID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select  TestAppointments.TestID where TestAppointmentID=@TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);


            try
            {
                Connection.Open();
                object Result= Command.ExecuteScalar();
                if (Result!=null&&int.TryParse(Result.ToString(),out int ID)){
                    TestTID = ID;
                }
                else
                {
                    TestTID = -1;
                }


            }

            catch (Exception ex)
            {
                TestTID = -1;
            }

            finally
            {
                Connection.Close();
            }

            return TestTID;
        }




        public static int RetakeTestAppointment(int LDLAppID, int TestTypeID, int UserID, 
            DateTime AppointmentDate, int PaidFees, bool IsLocked,int RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Insert into TestAppointments" +
              " values " +
              "(@TestTypeID,@LDLApp,@AppointmentDate,@PaidFees,@UserID,@,@IsLocked,@RetakeTestApplicationID)" +
              "" +
              "select scope_identity()";
            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("LDLApp", LDLAppID);
            Command.Parameters.AddWithValue("AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("PaidFees", PaidFees);
            Command.Parameters.AddWithValue("UserID", UserID);
            Command.Parameters.AddWithValue("IsLocked", IsLocked);
            Command.Parameters.AddWithValue("RetakeTestApplicationID", RetakeTestApplicationID);



            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null)
                {

                    TestAppointmentID = Convert.ToInt32(Result);
                }

            }
            catch (Exception ex)
            {
                TestAppointmentID = -1;

            }

            finally
            {
                Connection.Close();
            }

            return TestAppointmentID;
        }
        
        public static bool IsPersonHaveTestAppointmentByLDLAppIDAndTestType(int LDLAppID,int TestTypeID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = 
                
                "Select IsFound=1 from TestAppointments " +
                " where LocalDrivingLicenseApplicationID=@LDLAppID and IsLocked='false' and TestTypeID=@TestTypeID";

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

            catch(Exception ex) 
            {
                IsFound = false;
            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }
        public static bool IsPersonHasLockedAppointmentByTestAppointmentID(int ID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = " select IsFound=1 from TestAppointments where IsLocked='True' and TestAppointments.TestAppointmentID=@ID";
            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("ID", ID);


            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    IsFound = true;
                }
                else
                {
                    IsFound = false;
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

        public static bool MakeTestAppointmentLockedByID(int ID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Update TestAppointments" +
              " set  IsLocked='true' " +
              "where TestAppointments.TestAppointmentID=@TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("TestAppointmentID", ID);
         


            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();

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
    }
}
