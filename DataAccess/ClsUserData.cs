using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
   public class ClsUserData
    {

        //public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName ,ref string Password, ref bool IsActive)
        //{
        //    bool IsFound = false;
        //    SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //    string query = "select * from Users where UserID =@UserID";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue(query, "@UserID");

        //    try
        //    {
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        if(reader.Read())
        //        {
        //            IsFound = true;

        //            PersonID = (int)reader["PersonID"];
        //            UserName = (string)reader["UserName"];
        //            Password = (string)reader["Password"];
        //            IsActive = (bool)reader["IsActive"];

        //        }

        //        reader.Close();

        //    }catch
        //    {
        //        IsFound = false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return IsFound;
        //}

        //public static bool GetUserInfoByPersonID(int PersonID , ref int UserID , ref string Password , ref string UserName, ref bool IsActive)
        //{
        //    bool IsFound =false ;

        //    SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //    string query = "select * from Users where PersonID = @PersonID ";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue("@PersonID",PersonID);

        //    try
        //    {
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        if(reader.Read())
        //        {
        //            IsFound = true;
        //            UserID = (int)reader["UserID"];
        //            UserName = (string)reader["UserName"];
        //            Password = (string)reader["Password"];
        //            IsActive = (bool)reader["IsActive"];
        //        }
        //        reader.Close();
        //    }catch
        //    {
        //        IsFound = false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return IsFound;
        //}




        //public static bool GetUserInfoByUserNameAndPassword(string UserName, string Password , ref int  UserID, ref int PersonID , ref bool IsActive)
        //{

        //    bool IsFound = false;

        //    SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //    string query = "Select * from Users where UserName =@UserName and Password= @Password";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    command.Parameters.AddWithValue(UserName, "@UserName");
        //    command.Parameters.AddWithValue(Password, "@Password");

        //    try

        //    {
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        if(reader.Read())
        //        {
        //            IsFound = true;
        //            PersonID = (int)reader["PersonID"];
        //            UserID = (int)reader["UserID"];
        //            IsActive = (bool)reader["IsActive"];

        //        }

        //        reader.Close();



        //    }catch
        //    {
        //        IsFound = false;

        //    }

        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return IsFound;
        //}

        //public static int AddNewUser( int PersonID, string UserName, string Password, bool IsActive)
        //{
        //    int userID = -1;

        //    SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //    string query = @"Insert into Users 
        //                       Set (UserID ,PersonID,UserName,Password,IsActive )
        //                             Values(@UserID , @PersonID,@UserName,@Password,@IsActive);
        //                               select Scope-IDentity";

        //    SqlCommand command = new SqlCommand(query, connection);

        //   // command.Parameters.AddWithValue("@UserID", UserID);
        //    command.Parameters.AddWithValue("@PersonID", PersonID);
        //    command.Parameters.AddWithValue("@UserName", UserName);
        //    command.Parameters.AddWithValue("@Password", Password);
        //    command.Parameters.AddWithValue("@IsActive", IsActive);


        //    try
        //    {
        //        connection.Open();

        //        object Reslut = command.ExecuteScalar();

        //        if(Reslut != null && int.TryParse(Reslut.ToString(), out int InsertedID ))
        //        {
        //            userID = InsertedID;
        //        }

        //    }catch
        //    {
        //        userID = -1;
        //    }finally
        //    {
        //        connection.Close();
        //    }
        //    return userID;

        //}

        //        public static bool UpdateUserInfo(int UserID , int PersonID , string UserName, string Password , bool IsActive)
        //        {
        //            int rowAffected = -1;

        //            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //            string query = @"Update Users 
        //                             set UserID =@UserID,
        //                                  PersonID =@PersonID,
        //                                 UserName =@UserName,
        //                                Password = @Password,
        //                                IsActive = @IsActive
        //                            where UserID =@UserID  ";


        //            SqlCommand command = new SqlCommand(query, connection);
        //            command.Parameters.AddWithValue("@UserID", UserID);
        //            command.Parameters.AddWithValue("@PersonID", PersonID);
        //            command.Parameters.AddWithValue("@UserName", UserName);
        //            command.Parameters.AddWithValue("@Password", Password);
        //            command.Parameters.AddWithValue("@IsActive", IsActive);

        //            try
        //            {
        //                connection.Open();

        //                rowAffected =command.ExecuteNonQuery();


        //            }catch

        //            {
        //                rowAffected = -1;
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //            return (rowAffected > 0);



        //        }

        //        public static DataTable GetAllUsers()
        //        {
        //            DataTable dataTable = new DataTable();

        //            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //            string query = @"
        //select Users.UserID , People.PersonID  , FullName = People.FirstName + '' + People.SecondName + '' + ISNULL(ThirdName, '') + '' + LastName ,Users.UserName,Users.Password,Users.IsActive
        //   from Users join People
        //   on Users.PersonID = People.PersonID; ";

        //            SqlCommand command = new SqlCommand(query, connection);

        //            try
        //            {
        //                connection.Open();

        //                SqlDataReader reader = command.ExecuteReader();

        //                if(reader.HasRows)
        //                {
        //                    dataTable.Load(reader);
        //                }

        //                reader.Close();
        //            }catch
        //            {

        //            }finally
        //            {
        //                connection.Close();
        //            }

        //            return dataTable;
        //        }

        //        public static bool DeleteUser(int UserID)
        //        {
        //            int rowAffected = -1;
        //            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //            string query = "Delete Users where UserID =@UserID";

        //            SqlCommand command = new SqlCommand(query, connection);

        //            command.Parameters.AddWithValue("@UserID",UserID );

        //            try
        //            {
        //                connection.Open();

        //                rowAffected = command.ExecuteNonQuery(); 
        //            }
        //            catch
        //            {
        //                rowAffected = -1;
        //            }
        //            finally
        //            {
        //                connection.Close();

        //            }
        //            return (rowAffected > 0);
        //        }


        //        public static bool IsUserExist(int UserID)

        //        {
        //            bool IsFound = false;

        //            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //            string query = "select Found = 1 from Users where UserID =@UserID";

        //            SqlCommand command = new SqlCommand(query, connection);

        //            command.Parameters.AddWithValue("@UserID", UserID);

        //            try
        //            {
        //                connection.Open();

        //                SqlDataReader reader = command.ExecuteReader();



        //                    IsFound = reader.HasRows;

        //                reader.Close();

        //            }catch
        //            {
        //                IsFound = false;
        //            }finally
        //            {
        //                connection.Close();
        //            }
        //            return IsFound;
        //        }

        //        public static bool IsUserExist(string UserName)

        //        {
        //            bool IsFound = false;

        //            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //            string query = "select Found = 1 from Users where UserName =@UserName";

        //            SqlCommand command = new SqlCommand(query, connection);

        //            command.Parameters.AddWithValue("@UserName", UserName);

        //            try
        //            {
        //                connection.Open();

        //                SqlDataReader reader = command.ExecuteReader();



        //                IsFound = reader.HasRows;

        //                reader.Close();

        //            }
        //            catch
        //            {
        //                IsFound = false;
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //            return IsFound;
        //        }


        //        public static bool IsUserExistByPersonID(int PersonID)

        //        {
        //            bool IsFound = false;

        //            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //            string query = "select Found = 1 from Users where PersonID =@PersonID";

        //            SqlCommand command = new SqlCommand(query, connection);

        //            command.Parameters.AddWithValue("@PersonID", PersonID);

        //            try
        //            {
        //                connection.Open();

        //                SqlDataReader reader = command.ExecuteReader();



        //                IsFound = reader.HasRows;

        //                reader.Close();

        //            }
        //            catch
        //            {
        //                IsFound = false;
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //            return IsFound;
        //        }

        //        public static bool ChangePassword(int UserID , string NewPassword)
        //        {
        //            int rowAffected = -1;

        //            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

        //            string query = @"Update Users 
        //                             set UserID = @UserID, 
        //                                Password= @Password
        //                          where UserID = @UserID";

        //            SqlCommand command = new SqlCommand(query, connection);

        //            command.Parameters.AddWithValue("@UserID", UserID);

        //            try
        //            {
        //                connection.Open();

        //                rowAffected = command.ExecuteNonQuery();


        //            }
        //            catch
        //            {
        //                rowAffected = -1;
        //            }
        //            finally
        //            {
        //                connection.Close();

        //            }
        //            return (rowAffected > 0);
        //        }

        public static bool GetUserInfoByUserID(int UserID, ref int PersonID, ref string UserName,
          ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "SELECT * FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];


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


        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName,
          ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];


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

        public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password,
            ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "SELECT * FROM Users WHERE Username = @Username and Password=@Password;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", UserName);
            command.Parameters.AddWithValue("@Password", Password);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];


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

        public static int AddNewUser(int PersonID, string UserName,
             string Password, bool IsActive)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int UserID = -1;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"INSERT INTO Users (PersonID,UserName,Password,IsActive)
                             VALUES (@PersonID, @UserName,@Password,@IsActive);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return UserID;
        }


        public static bool UpdateUser(int UserID, int PersonID, string UserName,
             string Password, bool IsActive)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Update  Users  
                            set PersonID = @PersonID,
                                UserName = @UserName,
                                Password = @Password,
                                IsActive = @IsActive
                                where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"SELECT  Users.UserID, Users.PersonID,
                            FullName = People.FirstName + ' ' + People.SecondName + ' ' + ISNULL( People.ThirdName,'') +' ' + People.LastName,
                             Users.UserName, Users.IsActive
                             FROM  Users INNER JOIN
                                    People ON Users.PersonID = People.PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool DeleteUser(int UserID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Delete Users 
                                where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "SELECT Found=1 FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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

        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "SELECT Found=1 FROM Users WHERE UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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

        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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

        public static bool DoesPersonHaveUser44(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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

        public static bool ChangePassword(int UserID, string NewPassword)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Update  Users  
                            set Password = @Password
                            where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
