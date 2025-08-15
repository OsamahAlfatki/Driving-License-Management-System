using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataAccessLayer
{
    public static class LicenseClassesData
    {

        public static DataTable GetAllLicenseClassData()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "Select ClassName from LicenseClasses";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }

            catch(Exception ex) 
            {
                dt = null;
            }

            finally
            {
                Connection.Close();
            }
            return dt;

        }
        public static int AddLicenseClass(string LicenseClassName,  string LicenseDescription,  byte MinimumAge,  byte ValidatyLength,  float Fees)
        {


           int ClassID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Insert into LicenseClasses (@LicenseClassName,@LicenseDescription,@MinimumAge,@ValidatyLength,@Fees) " +
                "select scope_Identity()";
                
                
              

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Class", LicenseClassName);
            Command.Parameters.AddWithValue("@LicenseDescription", LicenseDescription);
            Command.Parameters.AddWithValue("@MinimumAge", MinimumAge);
            Command.Parameters.AddWithValue("@ValidatyLength", ValidatyLength);
            Command.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result!=null&&int.TryParse(Result.ToString(),out int  Class))
                {
                    ClassID = Class;
                }
                else
                {
                    ClassID = -1;
                }



            }

            catch (Exception ex)
            {
                ClassID = -1;
            }

            finally
            {
                Connection.Close();
            }
            return ClassID;
        }

        public static bool UpdateClass(int ClassID,string LicenseClassName, string LicenseDescription, byte MinimumAge, byte ValidatyLength, float Fees)
        {

            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "Update  LicenseClasses set ClassName=@Class,ClassDescription=@ClassDescription,MinimumAllowedAge=@MinimumAllowedAge,DefualtValidityLength=@DefaultValidityLength,ClassFees=@ClassFees) " +
                "select scope_Identity()";




            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Class", LicenseClassName);
            Command.Parameters.AddWithValue("@ClassDescription", LicenseDescription);
            Command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAge);
            Command.Parameters.AddWithValue("@DefualtValidityLength", ValidatyLength);
            Command.Parameters.AddWithValue("@ClassFees", Fees);

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
        public static bool FindLicenseClassInfoByName( string LicenseClassName,ref int ID, ref string LicenseDescription, ref byte MinimumAge, ref byte ValidatyLength, ref float Fees)
        {


            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select  *  from LicenseClasses where" +
                " LicenseClasses.ClassName=@Class";


            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Class", LicenseClassName);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    ID = Convert.ToInt32(Reader["LicenseClassID"]);
                    LicenseDescription = Reader["ClassDescription"].ToString();
                    MinimumAge = (byte)(Reader["MinimumAllowedAge"]);
                    ValidatyLength = (byte)(Reader["DefaultValidityLength"]);
                    Fees = Convert.ToSingle(Reader["ClassFees"]);
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
        public static bool FindLicenseClassInfoByID(int ID,ref string LicenseClassName,ref string LicenseDescription,ref byte MinimumAge,ref byte ValidatyLength,ref float Fees)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"select  *  from LicenseClasses where" +
                " LicenseClasses.LicenseClassID=@LicenseClassID";


            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseClassID", ID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if ( Reader.Read())
                {
                    LicenseClassName = Reader["ClassName"].ToString();
                    LicenseDescription = Reader["ClassDescription"].ToString();
                    MinimumAge = Convert.ToByte(Reader["MinimumAllowedAge"]);
                    ValidatyLength= Convert.ToByte(Reader["DefaultValidityLength"]);
                    Fees= Convert.ToSingle(Reader["ClassFees"]);
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
        //public static int GetMinimumAllowedAgeOfLicenseClassByLicenseClassID(int LicenseClassID)
        //{

        //    int MinimumAllowedAge = -1;

        //    SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string Query = "select LicenseClasses.MinimumAllowedAge from LicenseClasses where" +
        //        " LicenseClasses.LicenseClassID=@LicenseClassID";


        //    SqlCommand Command = new SqlCommand(Query, Connection);
        //    Command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);

        //    try
        //    {
        //        Connection.Open();
        //        object Result = Command.ExecuteScalar();
        //        if (Result != null)
        //        {
        //            MinimumAllowedAge = Convert.ToInt32(Result);
        //        }

        //    }

        //    catch( Exception ex ) 
        //    {
        //        MinimumAllowedAge = -1;
        //    }

        //    finally
        //    {
        //        Connection.Close();
        //    }
        //    return MinimumAllowedAge;

        //}
        //public static int GetDefaultValidityLengthOfLicenseByLicenseClassID(int LicensesClassID)
        //{
        //    int ValidityLength = -1;

        //    SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string Query = "select LicenseClasses.DefaultValidityLength from LicenseClasses where LicenseClasses.LicenseClassID=@LicenseClassID";           


        //    SqlCommand Command = new SqlCommand(Query, Connection);
        //    Command.Parameters.AddWithValue("LicenseClassID", LicensesClassID);

        //    try
        //    {
        //        Connection.Open();
        //        object Result = Command.ExecuteScalar();
        //        if (Result != null)
        //        {
        //            ValidityLength = Convert.ToInt32(Result);
        //        }

        //    }

        //    catch(Exception ex ) 
        //    {
        //        ValidityLength = -1;
        //    }

        //    finally
        //    {
        //        Connection.Close();
        //    }
        //    return ValidityLength;

        //}
        //public static string FindLicenseClassNameByLicenseClassID(int LicenseClassID)

        //{
        //    string LicenseClassName = "";

        //    SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        //    string Query = " select LicenseClasses.ClassName from LicenseClasses where LicenseClasses.LicenseClassID=@LicenseClassID";


        //    SqlCommand Command = new SqlCommand(Query, Connection);
        //    Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

        //    try
        //    {
        //        Connection.Open();
        //        object Result = Command.ExecuteScalar();
        //        if (Result != null)
        //        {
        //            LicenseClassName =Result.ToString();
        //        }

        //    }

        //    catch( Exception ex ) 
        //    {
        //        LicenseClassName = "";
        //    }

        //    finally
        //    {
        //        Connection.Close();
        //    }
        //    return LicenseClassName;

        //}

      
    }
    
}
