using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using DVLDSettings;

namespace DataAccessLayer
{
    public static  class clsInternationalLicenseData
    {
        public static DataTable GetAllInternationalLicenseApplication()
        {
            DataTable result = new DataTable();

            try
            {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {


                    string Query =
                        @"
            SELECT    InternationalLicenseID, ApplicationID,DriverID,
		                IssuedUsingLocalLicenseID , IssueDate, 
                        ExpirationDate, IsActive
		    from InternationalLicenses 
                order by IsActive, ExpirationDate desc";




                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {



                        Connection.Open();
                        using (SqlDataReader Reader = Command.ExecuteReader())
                        {
                            if (Reader.HasRows)
                            {
                                result.Load(Reader);
                            }

                            else
                            {
                                result = null;

                            }
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

                result = null;
            }

           
            return result;

        }
        public static int AddnternationalLicense(int ApplicationID,int DriverID,DateTime IssueDate,DateTime ExpirationDate,bool IsActive,int UserID,int LDLID)
        {
           
                int InternationalLicenseID = -1;
                try
                {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string Query = @" Update InternationalLicenses set IsActive =0 where DriverID=@DriverID" +
                    " insert into InternationalLicenses " +
                        "Values (@ApplicationID,@DriverID,@LicenseID,@IssueDate,@ExpirationDate,@IsActive,@UserID) " +
                        "select Scope_Identity()";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                        Command.Parameters.AddWithValue("@DriverID", DriverID);
                        Command.Parameters.AddWithValue("@LicenseID", LDLID);
                        Command.Parameters.AddWithValue("@IssueDate", IssueDate);
                        Command.Parameters.AddWithValue("ExpirationDate", ExpirationDate);

                        Command.Parameters.AddWithValue("@IsActive", IsActive);
                        Command.Parameters.AddWithValue("@UserID", UserID);
                        Connection.Open();




                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                        {
                            InternationalLicenseID = ID;
                        }
                        else
                        {
                            InternationalLicenseID = -1;
                        }
                    }
                }

                }

                catch(Exception ex) 
                {
                clsSettings.LogExceptions(ex);

                InternationalLicenseID = -1;
                }

                return InternationalLicenseID;
            }

        public static bool UpdateInternationalLicense(int InternationalLicenseID,int ApplicationID, int DriverID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int UserID, int LDLID)
        {

            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @" Update InternationalLicenses set IsActive =@IsActive,  DriverID=@DriverID,
                   IssuedUsingLocalLicenseID=@LicenseID,IssueDate=@IssueDate,
                  ExpirationDate=@ExpirationDate,CreatedByUserID=@UserID ,ApplicationID=@ApplicationID"+
                 "where InternationalLicenseID=@InternationalLicenseID";
           
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseID", LDLID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("ExpirationDate", ExpirationDate);

            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@UserID", UserID);
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
        public static int GetActiveInternationaLicense(int DriverID)
        {

            int InternationaLicenseID = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    string Query = "\tselect InternationalLicenses.InternationalLicenseID from InternationalLicenses where InternationalLicenses.DriverID=@DriverID and InternationalLicenses.IsActive=1" +
                        "order by ExpirationDate desc";

                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {
                        Command.Parameters.AddWithValue("@DriverID", DriverID);
                        Connection.Open();
                        object Result = Command.ExecuteScalar();

                        if (Result != null && int.TryParse(Result.ToString(), out int ID))
                        {

                            InternationaLicenseID = ID;

                        }
                        else
                        {
                            InternationaLicenseID = -1;
                        }
                    }

                }
            }


            catch (Exception ex)
            {
                clsSettings.LogExceptions(ex);

                InternationaLicenseID = -1;
            }

       
            return InternationaLicenseID;
        }
        public static bool GetInternationalLicenseInfoByLicenseID(
            int LicenseID,ref int DriverID,  ref int LDLID,ref int UserID,
            ref DateTime IssueDate, ref DateTime ExpirationDate,ref int ApplicationID , ref bool IsActive)
        {


            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string Query = @"Select * from InternationalLicenses where InternationalLicenseID=@ID";
                


            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@ID", LicenseID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    DriverID = Convert.ToInt32(Reader["DriverID"]);
                    LicenseID = Convert.ToInt32(Reader["InternationalLicenseID"]);
                    LDLID = Convert.ToInt32(Reader["IssuedUsingLocalLicenseID"]);
                    IsActive =(bool) Reader["IsActive"];
                  ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                  UserID = Convert.ToInt32(Reader["CreatedByUserID"]);

                    IssueDate = Convert.ToDateTime(Reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(Reader["ExpirationDate"]);
                   
                    IsFound = true;
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

        public static int GetInternationalLicenseValidityLength()
        {
            int DefualtValidityLength = -1;
                try
                {

                using (SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    string Query = @"Select top 1 InternationalLicenseSettings.DefaultValidityLength from InternationalLicenseSettings";


                    using (SqlCommand Command = new SqlCommand(Query, Connection))
                    {

                        Connection.Open();
                        object Result = Command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int Length))
                        {
                            DefualtValidityLength = Length;
                        }
                        else
                        {
                            DefualtValidityLength = -1;
                        }
                    }
                }
                }

                catch (Exception ex)
                {
                clsSettings.LogExceptions(ex);

                DefualtValidityLength = -1;
                }

               
                return DefualtValidityLength;

            

        }
        public static DataTable GetDriverInternationalLicense(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString); 
            string Query = " Select InternationalLicenses.InternationalLicenseID,InternationalLicenses.ApplicationID,InternationalLicenses.IssuedUsingLocalLicenseID,InternationalLicenses.IssueDate,InternationalLicenses.ExpirationDate," +
                " InternationalLicenses.IsActive   from InternationalLicenses inner join   Drivers on Drivers.DriverID = InternationalLicenses.DriverID  where Drivers.DriverID =@ID order by ExpirationDate desc";



            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ID", DriverID);
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

                Reader.Close ();
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


    }
}
