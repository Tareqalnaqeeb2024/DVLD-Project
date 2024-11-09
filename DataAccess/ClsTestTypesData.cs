using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public  class ClsTestTypesData
    {
        public static bool GetTestTypeInfoByID(int TestTypeID,
             ref string TestTypeTitle, ref string TestDescription, ref float TestFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestDescription = (string)reader["TestTypeDescription"];
                    TestFees = Convert.ToSingle(reader["TestTypeFees"]);

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static DataTable GetAllTestTypes()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string Query = "Select * from TestTypes";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dataTable.Load(reader);
                }

                reader.Close();
            }catch
            {

            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public static int  AddNewTestTypes(string TestTitle, string TestDes , float TestFees)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string Query = @"Insert Into  TestTypes(TestTypeTitle,TestTypeDescription,TestTypeFees )
                              Values (@TestTitle , @TestDes , @TestFees)
                               select Scope Identity(); ";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", TestTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestDes);
            command.Parameters.AddWithValue("@TestTypeFees", TestFees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString() , out int Inserted))
                {
                    ID = Inserted;
                }

            }catch
            {
                ID = -1;
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }


        public static bool UpdateTestType(int TestID , string TestTitle , string TestDes , float TestFees)
        {
            int rowAffected = -1;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string Query = @"Update  TestTypes  
                            set TestTypeTitle = @TestTypeTitle,
                                TestTypeDescription=@TestTypeDescription,
                                TestTypeFees = @TestTypeFees
                                where TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestDes);
            command.Parameters.AddWithValue("@TestTypeFees", TestFees);

            try
            {
                connection.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowAffected > -1);
        }

    }
}
