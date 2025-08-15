using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public static class LicensesData
    {
        public static int AddNewDrivingLicense(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, byte IssueReason, int UserID)
        {
            int LicenseID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
                "insert into Licenses " +
                "Values (@ApplicationID,@DriverID,@LicenseClassID,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@UserID) " +
                "select Scope_Identity()";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("DriverID", DriverID);
            Command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("IssueDate", IssueDate);
            Command.Parameters.AddWithValue("ExpirationDate", ExpirationDate);
            if (Notes == "")
            {
                Command.Parameters.AddWithValue("Notes", DBNull.Value);

            }
            else
            {
                Command.Parameters.AddWithValue("Notes", Notes);
            }
            Command.Parameters.AddWithValue("PaidFees", PaidFees);
            Command.Parameters.AddWithValue("IsActive", IsActive);
            Command.Parameters.AddWithValue("IssueReason", IssueReason);
            Command.Parameters.AddWithValue("UserID", UserID);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null&&int.TryParse(Result.ToString(),out LicenseID))
                {

                }
                else
                {
                    LicenseID = -1;
                }

                       
                 

                
                  
            }

            
            catch (Exception ex)
            {
                LicenseID = -1;
            }

            finally
            {
                Connection.Close();
            }
            return LicenseID;
        }

        public static DataTable GetAllLicenses()
        {

            DataTable dt= new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT * FROM Licenses";
               
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader= Command.ExecuteReader();

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
               dt= null;    
            }

            finally
            {
                Connection.Close();
            }
            return dt;
        }
        public static bool GetLicenseInfoByID(int LicenseID,ref int ApplicationID, ref int DriverID, ref int LicenseClass,ref int UserID,ref float PaidFees,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref bool IsActive, ref byte IssueReason)
        {


            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string Query = @"Select * from Licenses where LicenseID=@LicenseID";
                
               

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    UserID = (int)Reader["CreatedByUserID"];
                    DriverID = Convert.ToInt32(Reader["DriverID"]);
                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                    LicenseClass = (int)Reader["LicenseClass"];
                    IsActive = (bool)Reader["IsActive"];
                    PaidFees= Convert.ToSingle(Reader["PaidFees"]);
                    IssueReason = (byte)Reader["IssueReason"];
                    if (Reader["Notes"] == DBNull.Value)
                    {
                        Notes = "No Notes";
                    }
                    else
                    {
                        Notes = Reader["Notes"].ToString();
                    }
                    IssueDate = Convert.ToDateTime(Reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(Reader["ExpirationDate"]);


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

        public static DataTable GetDriverLicenses(int DriverID)
        {

            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query =
                @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";



            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
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


        public static int GetActiveLicenseByPersonID(int? PersonID,int LicenseClassID)
        {
                int LicenseID = -1;
                SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"Select Licenses.LicenseID  from Licenses inner join Drivers on Drivers.DriverID=Licenses.DriverID where
                     LicenseClass=@LicenseClassID And Drivers.PersonID=@PersonID and Licenses.IsActive=1 ";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@PersonID",PersonID);
                Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
               
                try
                {
                    Connection.Open();
                    object Result = Command.ExecuteScalar();
                    if (Result != null&& int.TryParse(Result.ToString(),out int ID))
                    {
                        LicenseID = ID;
                    }

                }

                catch (Exception ex)
                {
                    LicenseID = -1;
                }

                finally
                {
                    Connection.Close();
                }
                return LicenseID;
            }

        //public static bool FindLicenseInfoByLicenseID(int LicenseID, ref int DriverID, ref string Name, ref string Class, ref DateTime BirthOfDate, ref string NationalNo,
        //    ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref string IsActive, ref string IsDetained, ref string IssueReason, ref string Gender, ref string ImagePath)
        //{


        //    bool IsFound = false;
        //    SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


        //    string Query = "      select LicenseClasses.ClassName,NationalNo,FirstName + ' ' + SecondName + ' ' + ThirdName + ' ' +LastName as\r\n                     " +
        //        "FullName,People.NationalNo, People.DateOfBirth,Licenses.LicenseID,Licenses.DriverID,Licenses.IssueDate,Licenses.ExpirationDate,Licenses.Notes,\r\n                    " +
        //        "               Case               When Licenses.IsActive = 'True'                 then 'Yes'            \r\n " +
        //        "when Licenses.IsActive = 'false'              then 'No'                   End as IsActive, \r\n   Case         " +
        //        "   When People.Gender = 0               then 'Male'                 when People.Gender = 1\r\n    then 'Female' End as Gender,           " +
        //        "  Case               When Licenses.LicenseID in(DetainedLicenses.LicenseID) and DetainedLicenses.IsReleased=0\r\n       then 'Yes'    " +
        //        "  else               'No' End as IsDetained,  case  When Licenses.IssueReason = 1 \r\n       then 'First time'           " +
        //        "    when Licenses.IssueReason = 2             \r\n                       then 'Renew License' when Licenses.IssueReason = 3       " +
        //        "          then 'Replacement For Damaged'   when Licenses.IssueReason = 4    \r\n                              then'Replacement for Lost'       " +
        //        "             End as IssueReason ,People.ImagePath    from Drivers inner join People on Drivers.PersonID=People.PersonID inner join\r\n           " +
        //        "          \r\n                     Licenses on Licenses.DriverID=Drivers.DriverID   inner join LicenseClasses on LicenseClasses.LicenseClassID=Licenses.LicenseClass  Full join  DetainedLicenses on\r\n             " +
        //        "           Licenses.LicenseID=DetainedLicenses.LicenseID where Licenses.LicenseID=@LicenseID " +
        //        "" +
        //        "order by DetainedLicenses.DetainID desc";

        //    SqlCommand Command = new SqlCommand(Query, Connection);


        //    Command.Parameters.AddWithValue("@LicenseID", LicenseID);


        //    try
        //    {
        //        Connection.Open();
        //        SqlDataReader Reader = Command.ExecuteReader();
        //        if (Reader.Read())
        //        {
        //            DriverID = Convert.ToInt32(Reader["DriverID"]);
        //            LicenseID = Convert.ToInt32(Reader["LicenseID"]);
        //            Name = Reader["FullName"].ToString();
        //            Class = Reader["ClassName"].ToString();
        //            IsActive = Reader["IsActive"].ToString();
        //            IsDetained = Reader["IsDetained"].ToString();
        //            Gender = Reader["Gender"].ToString();
        //            IssueReason = Reader["IssueReason"].ToString();
        //            NationalNo = Reader["NationalNo"].ToString();
        //            if (Reader["Notes"] == DBNull.Value)
        //            {
        //                Notes = "No Notes";
        //            }
        //            else
        //            {
        //                Notes = Reader["Notes"].ToString();
        //            }
        //            IssueDate = Convert.ToDateTime(Reader["IssueDate"]);
        //            ExpirationDate = Convert.ToDateTime(Reader["ExpirationDate"]);
        //            BirthOfDate = Convert.ToDateTime(Reader["DateOfBirth"]);
        //            if (Reader["ImagePath"] == null)
        //            {
        //                ImagePath = "";
        //            }
        //            else
        //            {
        //                ImagePath = Reader["ImagePath"].ToString();

        //            }
        //            IsFound = true;
        //        }

        //        Reader.Close();

        //    }

        //    catch (Exception ex)
        //    {

        //        IsFound = false;
        //    }

        //    finally
        //    {
        //        Connection.Close();
        //    }

        //    return IsFound;
        //}



        public static bool UpdateLicense(int LicenseID,int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
            DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, byte IssueReason, int UserID)
        {

            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Update Licenses set ApplicationID=@ApplicationID,DriverID=@DriverID," +
                "LicenseClass=@LicenseClass,IssueDate=@IssueDate,ExpirationDate=@ExpirationDate,Notes=@Notes,PaidFees=@PaidFees,IsActive=@IsActive,IssueReason=@IssueReason,CreatedByUserID=@UserID where LicenseID=@LicenseID";


            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("DriverID", DriverID);
            Command.Parameters.AddWithValue("LicenseClass", LicenseClassID);
            Command.Parameters.AddWithValue("IssueDate", IssueDate);
            Command.Parameters.AddWithValue("ExpirationDate", ExpirationDate);
            if (Notes == "")
            {
                Command.Parameters.AddWithValue("Notes", DBNull.Value);

            }
            else
            {
                Command.Parameters.AddWithValue("Notes", Notes);
            }
            Command.Parameters.AddWithValue("PaidFees", PaidFees);
            Command.Parameters.AddWithValue("IsActive", IsActive);
            Command.Parameters.AddWithValue("IssueReason", IssueReason);
            Command.Parameters.AddWithValue("UserID", UserID);
            try
            {
                Connection.Open();
                RowsAffected= Command.ExecuteNonQuery();

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

        public static bool DeActivatedLicenseByLicenseID(int LicenseID)
        {

            bool IsUpdated = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "\r\n update Licenses \r\n set IsActive=0 where LicenseID=@LicenseID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@LicenseID", LicenseID);


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



        // public static int GetLicenseFeeByLicenseClassID(int LicenseClassID)
        // {
        //     int Fees = 0;
        //     SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //     string Query = "  select LicenseClasses.ClassFees  from LicenseClasses where LicenseClasses.LicenseClassID=@LicenseClassID";




        //     SqlCommand Command = new SqlCommand(Query, Connection);

        //     Command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);
        //     try
        //     {
        //         Connection.Open();
        //         object Result = Command.ExecuteScalar();
        //         if (Result != null)
        //         {
        //             Fees = Convert.ToInt32(Result);
        //         }

        //     }

        //     catch(Exception ex) 
        //     {
        //         Fees = -1;
        //     }

        //     finally
        //     {
        //         Connection.Close();
        //     }
        //     return Fees;
        // }
        // public static bool IsPersonHasLicenseByPersonIDAndLicenseClassID(int PersonID, int LicenseClassID)
        // {

        //     bool IsFound = false;
        //     SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //     string Query = "\r\n\t\t\t\t   select IsFound=1 from Licenses inner join Drivers on Drivers.DriverID=Licenses.DriverID \r\n\t\t\t\t" +
        //         "   where Drivers.PersonID=@PersonID and Licenses.LicenseClass=@LicenseClassID and Licenses.IsActive=1";

        //     SqlCommand Command = new SqlCommand(Query, Connection);
        //     Command.Parameters.AddWithValue("PersonID", PersonID);
        //     Command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);



        //     try
        //     {
        //         Connection.Open();
        //         object Result = Command.ExecuteScalar();

        //         if (Result != null)
        //         {
        //             IsFound = true;

        //         }
        //     }


        //     catch (Exception ex)
        //     {

        //         IsFound = false;
        //     }

        //     finally
        //     {
        //         Connection.Close();

        //     }
        //     return IsFound;
        // }


        // public static bool IsLicenseExpiredByID(int LicenseID)
        // {

        //     bool IsLicenseExpired = false;
        //     SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //     string Query = "\tselect IsFound=1 from Licenses where Licenses.ExpirationDate<GetDate() and Licenses.LicenseID=@LicenseID";



        //     SqlCommand Command = new SqlCommand(Query, Connection);
        //     Command.Parameters.AddWithValue("@LicenseID", LicenseID);



        //     try
        //     {
        //         Connection.Open();
        //         object Result = Command.ExecuteScalar();

        //         if (Result != null)
        //         {

        //             IsLicenseExpired = true;

        //         }
        //     }


        //     catch (Exception ex)
        //     {
        //         IsLicenseExpired = false;
        //     }

        //     finally
        //     {
        //         Connection.Close();

        //     }
        //     return IsLicenseExpired;
        // }
        // public static bool IsLicenseExistByID(int LicenseID)
        // {


        //     bool IsLicenseExist = false;
        //     SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //     string Query = "\tselect IsFound=1 from Licenses where Licenses.LicenseID=@LicenseID";



        //     SqlCommand Command = new SqlCommand(Query, Connection);
        //     Command.Parameters.AddWithValue("@LicenseID", LicenseID);



        //     try
        //     {
        //         Connection.Open();
        //         object Result = Command.ExecuteScalar();

        //         if (Result != null)
        //         {

        //             IsLicenseExist = true;

        //         }
        //     }


        //     catch (Exception ex)
        //     {
        //         IsLicenseExist = false;
        //     }

        //     finally
        //     {
        //         Connection.Close();

        //     }
        //     return IsLicenseExist;
        // }

        // public static bool FindLicenseClassIDByLicenseID(int LicenseID, ref int LicenseClassID)
        // {


        //     bool IsFound = false;

        //     SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //     string Query = "select Licenses.LicenseClass from Licenses where Licenses.LicenseID=@LicenseID";


        //     SqlCommand Command = new SqlCommand(Query, Connection);
        //     Command.Parameters.AddWithValue("LicenseID", LicenseID);

        //     try
        //     {
        //         Connection.Open();
        //         object Result = Command.ExecuteScalar();
        //         if (Result != null)
        //         {
        //             LicenseClassID = Convert.ToInt32(Result);
        //             IsFound = true;
        //         }
        //         else
        //         {
        //             Result = false;
        //         }

        //     }

        //     catch (Exception ex)
        //     {
        //         IsFound = false;
        //     }

        //     finally
        //     {
        //         Connection.Close();
        //     }
        //     return IsFound;

        // }



        // public static bool IsDetainedNotReleasedByDetainID(int DetainID)
        // {
        //     bool IsDetainedNotReleased = false;
        //     SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //     string Query = " select IsDetained=1 from  DetainedLicenses  where DetainedLicenses.DetainID=@DetainID   and DetainedLicenses.IsReleased=0";


        //     SqlCommand Command = new SqlCommand(Query, Connection);
        //     Command.Parameters.AddWithValue("@DetainID", DetainID);



        //     try
        //     {
        //         Connection.Open();
        //         object Result = Command.ExecuteScalar();

        //         if (Result != null)
        //         {

        //             IsDetainedNotReleased = true;

        //         }
        //     }


        //     catch (Exception ex)
        //     {
        //         IsDetainedNotReleased = false;
        //     }

        //     finally
        //     {
        //         Connection.Close();

        //     }
        //     return IsDetainedNotReleased;
        // }

        //public static bool IsLicenseDetainedByID(int LicenseID)
        // {
        //     bool IsLicenseDetained = false;
        //     SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //     string Query = " select IsDetained=1 from  DetainedLicenses  where DetainedLicenses.LicenseID=@LicenseID   and DetainedLicenses.IsReleased=0";


        //     SqlCommand Command = new SqlCommand(Query, Connection);
        //     Command.Parameters.AddWithValue("@LicenseID", LicenseID);



        //     try
        //     {
        //         Connection.Open();
        //         object Result = Command.ExecuteScalar();

        //         if (Result != null)
        //         {

        //             IsLicenseDetained = true;

        //         }
        //     }


        //     catch (Exception ex)
        //     {
        //         IsLicenseDetained = false;
        //     }

        //     finally
        //     {
        //         Connection.Close();

        //     }
        //     return IsLicenseDetained;
        // }
      

      
        // public static DataTable GetAllDetainedLicensesList()
        // {
        //     
        // }
    }
}
