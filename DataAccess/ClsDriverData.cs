using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataAccess
{
  public  class ClsDriverData
    {
        public static bool GetDriverInfoByDriverID(int DriverID , ref int PersonID , ref int CreatedByUserID , ref DateTime CreatedDate )
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            //string query = "select * from Drivers where DriverID = @DriverID";
            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];

                    
                }
                else
                {
                    IsFound = false;
                }
                reader.Close();
            }catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static bool GetDriverInfoByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "select * from Drivers where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];


                }
                else
                {
                    IsFound = false;
                }
                reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }


        public static int AddNewDriver( int PersonID, int CreatedByUserID)
        {
            int DriverID = -1;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Insert Into Drivers (PersonID, CreatedByUserID, CreatedDate)
                                        values (@PersonID, @CreatedByUserID, @CreatedDate);
                                          select scope_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);

            try
            {
                connection.Open();

                object Reslut = command.ExecuteScalar();

                if(Reslut != null && int.TryParse(Reslut.ToString(), out int InsreatedID ) )
                {
                    DriverID = InsreatedID;
                }


            }catch
            {
                DriverID = -1;
            }
            finally
            {
                connection.Close();
            }

            return DriverID;

        }

        public static bool UpdateDriverData(int DriverID ,int PersonID, int CreatedByUserID)
        {
            int rowAffted = 0;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Update Drivers 
                           set  
                                PersonID = @PersonID,
                                CreatedByUserID = @CreatedByUserID,
                                where DriverID = @DriverID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();

                 rowAffted = command.ExecuteNonQuery();

               

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowAffted > 0);
        }

        public static DataTable GetAllDrivers()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "SELECT * FROM Drivers_View order by FullName";

            SqlCommand command = new SqlCommand(query, connection);

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

            }finally
            {
                connection.Close();
            }

            return dataTable;
        }
    }
}
