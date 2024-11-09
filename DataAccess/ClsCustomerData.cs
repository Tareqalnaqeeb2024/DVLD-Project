using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DataAccess
{
    class ClsCustomerData
    {
        public static bool GetCustomer(int CustomerID, ref string Name, ref int NationalID, ref string Address, ref string Email, ref int Phone, ref int DriverLicense)
        {
            SqlConnection Connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Select * from Customers where CustomerID = @CustomerID;";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@CustomerID", CustomerID);

            bool IsFound = false;
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    IsFound = true;
                    if (Reader["Name"] != DBNull.Value)
                        Name = (string)Reader["Name"];
                    NationalID = (int)Reader["NationalID"];
                    if (Reader["Address"] != DBNull.Value)
                        Address = (string)Reader["Address"];
                    if (Reader["Email"] != DBNull.Value)
                        Email = (string)Reader["Email"];
                    if (Reader["Phone"] != DBNull.Value)
                        Phone = (int)Reader["Phone"];
                    if (Reader["DriverLicense"] != DBNull.Value)
                        DriverLicense = (int)Reader["DriverLicense"];

                }
                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static int AddNewCustomer(string Name, int NationalID, string Address, string Email, int Phone, int DriverLicense)
        {
            SqlConnection Connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Insert into Customers (Name,NationalID,Address,Email,Phone,DriverLicense) 
Values (@Name,@NationalID,@Address,@Email,@Phone,@DriverLicense); 
SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);

            if (string.IsNullOrWhiteSpace(Name))
            {
                Command.Parameters.AddWithValue("@Name", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@Name", Name);
            }
            Command.Parameters.AddWithValue("@NationalID", NationalID);
            if (string.IsNullOrWhiteSpace(Address))
            {
                Command.Parameters.AddWithValue("@Address", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@Address", Address);
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@Email", Email);
            }
            if (Phone == 0)
            {
                Command.Parameters.AddWithValue("@Phone", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@Phone", Phone);
            }
            if (DriverLicense == 0)
            {
                Command.Parameters.AddWithValue("@DriverLicense", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@DriverLicense", DriverLicense);
            }


            int CustomerID = -1;
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    CustomerID = ID;
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                Connection.Close();
            }

            return CustomerID;
        }

        public static bool UpdateCustomer(int CustomerID, string Name, int NationalID, string Address, string Email, int Phone, int DriverLicense)
        {
            SqlConnection Connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Update Customers Set 
Name = @Name,
NationalID = @NationalID,
Address = @Address,
Email = @Email,
Phone = @Phone,
DriverLicense = @DriverLicense
where CustomerID = @CustomerID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@CustomerID", CustomerID);
            if (string.IsNullOrWhiteSpace(Name))
            {
                Command.Parameters.AddWithValue("@Name", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@Name", Name);
            }
            Command.Parameters.AddWithValue("@NationalID", NationalID);
            if (string.IsNullOrWhiteSpace(Address))
            {
                Command.Parameters.AddWithValue("@Address", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@Address", Address);
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                Command.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@Email", Email);
            }
            if (Phone == 0)
            {
                Command.Parameters.AddWithValue("@Phone", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@Phone", Phone);
            }
            if (DriverLicense == 0)
            {
                Command.Parameters.AddWithValue("@DriverLicense", DBNull.Value);
            }
            else
            {
                Command.Parameters.AddWithValue("@DriverLicense", DriverLicense);
            }


            int RowAffected = 0;
            try
            {
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return RowAffected > 0;
        }

        public static bool DeleteCustomer(int CustomerID)
        {
            SqlConnection Connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"DELETE FROM Customers
                                      WHERE CustomerID = @CustomerID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@CustomerID", CustomerID);

            int RowAffected = 0;
            try
            {
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return RowAffected > 0;
        }

        public static DataTable GetCustomers()
        {
            SqlConnection Connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Select * FROM Customers";

            SqlCommand Command = new SqlCommand(query, Connection);

            DataTable dataTable = new DataTable();
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dataTable.Load(Reader);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }


            return dataTable;
        }

        public static DataTable GetCustomersByCustomerID(int CustomerID)
        {
            SqlConnection Connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Select * FROM Customers Where CustomerID = @CustomerID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@CustomerID", CustomerID);

            DataTable dataTable = new DataTable();
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    dataTable.Load(Reader);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }


            return dataTable;
        }

        public static bool IsCustomerExistByCustomerID(int CustomerID)
        {
            SqlConnection Connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Select IsFound = 1 from Customers where CustomerID = @CustomerID;";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@CustomerID", CustomerID);

            bool IsFound = false;
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    IsFound = true;
                }

            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

    }
}
