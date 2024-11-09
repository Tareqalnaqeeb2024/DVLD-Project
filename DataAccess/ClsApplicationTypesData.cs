using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
   public class ClsApplicationTypesData
    { 
        public enum  EnMode { AddNew = 0 , Update=1};
        EnMode Mode;

        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID,
           ref string ApplicationTypeTitle, ref float ApplicationFees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToSingle(reader["ApplicationFees"]);





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


        public static DataTable GetAllApplicationsTypes()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string Query = "select * from ApplicationTypes order by ApplicationFees";


            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader() ;

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

        public static bool UpdateApplicationTypes(int AppID, string AppTitle, float AppFees)

        {
            int rowAffected = -1;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);


            string query = @"Update ApplicationTypes 

                 set ApplicationTypeTitle = @AppTitle,
                          ApplicationFees = @AppFees
	           where ApplicationTypeID = @AppID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppID", AppID);

            command.Parameters.AddWithValue("@AppTitle", AppTitle);
            command.Parameters.AddWithValue("@AppFees", AppFees);

            try
            {
                connection.Open();

                rowAffected = command.ExecuteNonQuery();

                
            }catch
            {
                rowAffected = -1;
            }
            finally
            {
                connection.Close();
            }

            return (rowAffected > 0);
        }

        public static int AddNewApplicationTypes( string AppTitle, float AppFees)

        {
            int AppID = -1;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);


            string query = @"Insert into ApplicationTypes (  ApplicationTypeTitle, ApplicationFees) 
                         Values(@Title,@Fees)
                        select Scope IDENtity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", AppTitle);
            command.Parameters.AddWithValue("@ApplicationFees", AppFees);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    AppID = insertedID;
                }


            }
            catch
            {
                AppID= -1;
            }
            finally
            {
                connection.Close();
            }

            return AppID ;
        }
        //public static DataTable GetAllApplactionTypes()
        //{
        //    DataTable dataTable = new DataTable();

        //    SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //    string Query = "Select * from ApplactionTypes";

        //    SqlCommand command = new SqlCommand(Query, connection);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if(reader.HasRows)
        //        {
        //            dataTable.Load(reader);
        //        }

        //        reader.Close();
        //    }catch
        //    {

        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return dataTable;
        //}

        //public static bool UpdateApplicationTypes(int ApplicationTypeID , string ApplicationTypeTitle ,decimal ApplicationFees)
        //{
        //    int RowAffected = -1;

        //    SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //    string Query = @"Update ApplicationTypes 
        //                    set = ApplicationTypeTitle = @ApplicationTypeTitle,
        //                           ApplicationFees = @ApplicationFees
        //                            where ApplicationTypeID = @ApplicationTypeID";

        //    SqlCommand command = new SqlCommand(Query, connection);

        //    command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
        //    command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);


        //    try
        //    {
        //        connection.Open();

        //        RowAffected = command.ExecuteNonQuery();






        //    }catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return (RowAffected > -1);
        //}
    }
}
