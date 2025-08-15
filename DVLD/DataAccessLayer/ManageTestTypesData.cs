using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Policy;
using System.Runtime.Remoting.Messaging;

namespace DataAccessLayer
{
    public static class ManageTestTypesData
    {
        public static DataTable GetAllTestTypesList()
        {

            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString); ;
            string Query = "select * from TestTypes order by TestTypeID";
            ;
            SqlCommand command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();

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

        public static bool FindTestTypeDataByID(int TestTypeID, ref string TestTypeTitle,ref string TestTypeDescription, ref float TestTypeFees)
        {
            bool IsFounde = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString); ;
            string Query = "select TestTypeID as ID,TestTypeTitle as Title ,TestTypeDescription as Description ,TestTypeFees as Fees from TestTypes where TestTypeID=@TestTypeID";

            ;
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if (Reader.Read())
                {
                   TestTypeTitle = Convert.ToString(Reader["Title"]);
                    TestTypeDescription = Convert.ToString(Reader["Description"]);
                    TestTypeFees = Convert.ToSingle(Reader["Fees"]);



                    IsFounde = true;
                }

                Reader.Close();




            }
            catch (Exception ex)
            {
                IsFounde = false;
            }

            finally
            {
                Connection.Close();
            }
            return IsFounde;

        }
        public static bool UpdateTestTypeDataByTestID(int TestTypeID, string TestTypeTitle,string TestTypeDescription, float TestTypeFees)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString); ;
            string Query = "Update TestTypes set TestTypeTitle=@TestTypeTitle,TestTypeDescription=@TestTypeDescription,TestTypeFees=@TestTypeFees where TestTypeID=@TestTypeID";
            ;
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("TestTypeDescription",TestTypeDescription);
            command.Parameters.AddWithValue("TestTypeFees", TestTypeFees);
            try
            {
                Connection.Open();
                RowsAffected = command.ExecuteNonQuery();

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
        public static  int AddNewTestType(  string TestTypeTitle, string TestTypeDescription,  float TestTypeFees)
        {

            int TestTypeID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString); ;
            string Query = "Insert into TestTypes(TestTypeTitle,TestTypeDescription,TestTypeFees)   values TestTypes(@TestTypeTitle,@TestTypeDescription,@TestTypeFees) " +
                " Select scope_Identity()";
            ;
            SqlCommand command = new SqlCommand(Query, Connection);
            command.Parameters.AddWithValue("TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("TestTypeFees", TestTypeFees);
            try
            {
                Connection.Open();

                object Result = command.ExecuteScalar();
                if (Result != null)
                {
                    TestTypeID = (int)Result;

                }
                else
                {
                    TestTypeID = -1;
                }

            }
            catch (Exception ex)
            {
                TestTypeID = -1;
            }

            finally
            {
                Connection.Close();
            }
            return TestTypeID;
        }
       
}
}
