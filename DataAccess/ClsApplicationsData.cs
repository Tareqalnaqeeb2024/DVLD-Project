using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
   public class ClsApplicationsData
    {
        public static bool GetApplicationByID(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID,
                     ref byte ApplicationStatus , ref DateTime LastStatusDate , ref float PaidFees  , ref int CreatedByUserID)

        {


          
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "select * from Applications where ApplicationID = @ApplicationID";
           // string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                  
                    IsFound = true;
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];





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


        public static int AddNewApplication(  int ApplicantPersonID,  DateTime ApplicationDate,  int ApplicationTypeID,
                      byte ApplicationStatus,  DateTime LastStatusDate,  float PaidFees,  int CreatedByUserID)

        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            //string query = @"Insert Into Applications (PersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate
            //                      ,PaidFees,UserID)
            //                  values (@PersonID,@ApplicationDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate
            //                      ,@PaidFees,@UserID);
            //                select Scope IDENitity();";

            string query = @"INSERT INTO Applications ( 
                            ApplicantPersonID,ApplicationDate,ApplicationTypeID,
                            ApplicationStatus,LastStatusDate,
                            PaidFees,CreatedByUserID)
                             VALUES (@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,
                                      @ApplicationStatus,@LastStatusDate,
                                      @PaidFees,   @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            //command.Parameters.AddWithValue("PersonID", PersonID);
            //command.Parameters.AddWithValue("ApplicationDate", ApplicationDate);
            //command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            //command.Parameters.AddWithValue("ApplicationStatus", ApplicationStatus);
            //command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);
            //command.Parameters.AddWithValue("PaidFees", PaidFees);
            //command.Parameters.AddWithValue("UserID", UserID) ;

            command.Parameters.AddWithValue("ApplicantPersonID", @ApplicantPersonID);
            command.Parameters.AddWithValue("ApplicationDate", @ApplicationDate);
            command.Parameters.AddWithValue("ApplicationTypeID", @ApplicationTypeID);
            command.Parameters.AddWithValue("ApplicationStatus", @ApplicationStatus);
            command.Parameters.AddWithValue("LastStatusDate", @LastStatusDate);
            command.Parameters.AddWithValue("PaidFees", @PaidFees);
            command.Parameters.AddWithValue("CreatedByUserID", @CreatedByUserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result !=null && int.TryParse(result.ToString() , out int InsertedID))
                {
                    ApplicationID = InsertedID;
                }


            }catch
            {
                ApplicationID = -1;
            }finally
            {
                connection.Close();
            }
            return ApplicationID;


        }


     public static bool UpdateApplication(int ApplicationID ,  int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
                      byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)

        {
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            //string Query = @"Update Applications
            //                 Set ApplicationID = @ApplicationID ,
            //                     ApplicationPersonID = @PersonID, 
            //                    ApplicationDate  = @ApplicationDate,
            //                   ApplicationTypeID = @ApplicationTypeID,
            //                    ApplicationStatus =@ApplicationStatus, 
            //                    LastStatusDate  = @LastStatusDate ,
            //                 PaidFees = @PaidFees,
            //             CreatedByUserID = @UserId
            //           where ApplicationID = @ApplicationID; ";

            string query = @"Update  Applications  
                            set ApplicantPersonID = @ApplicantPersonID,
                                ApplicationDate = @ApplicationDate,
                                ApplicationTypeID = @ApplicationTypeID,
                                ApplicationStatus = @ApplicationStatus, 
                                LastStatusDate = @LastStatusDate,
                                PaidFees = @PaidFees,
                                CreatedByUserID=@CreatedByUserID
                            where ApplicationID=@ApplicationID";


            SqlCommand command = new SqlCommand(query, connection);

            //command.Parameters.AddWithValue("ApplicationPersonID", PersonID);
            //command.Parameters.AddWithValue("ApplicationDate", ApplicationDate);
            //command.Parameters.AddWithValue("ApplicationTypeID", ApplicationTypeID);
            //command.Parameters.AddWithValue("ApplicationStatus", ApplicationStatus);
            //command.Parameters.AddWithValue("LastStatusDate", LastStatusDate);
            //command.Parameters.AddWithValue("PaidFees", PaidFees);
            //command.Parameters.AddWithValue("CreatedByUserID", UserID);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("ApplicantPersonID", @ApplicantPersonID);
            command.Parameters.AddWithValue("ApplicationDate", @ApplicationDate);
            command.Parameters.AddWithValue("ApplicationTypeID", @ApplicationTypeID);
            command.Parameters.AddWithValue("ApplicationStatus", @ApplicationStatus);
            command.Parameters.AddWithValue("LastStatusDate", @LastStatusDate);
            command.Parameters.AddWithValue("PaidFees", @PaidFees);
            command.Parameters.AddWithValue("CreatedByUserID", @CreatedByUserID);


            try
            {
                connection.Open();

                rowAffected = command.ExecuteNonQuery();

                if(rowAffected !=0)
                {
                    return true;
                }

            }catch
            {
              
            }finally
            {
                connection.Close();

            }
            return (rowAffected > 0);

        }


        public static  bool DeleteApplication(int ApplicationID)
    {
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

           // string query = @"delete Applications where ApplicationID = @ApplicationID";
            string query = @"Delete Applications 
                                where ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                rowAffected = command.ExecuteNonQuery();
            }
            catch
            {
                
            }
            finally
            {
                connection.Close();
            }
            return (rowAffected > 0);
    }

        public static bool IsApplicationExist(int ApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "select found =1 from Applications Where ApplicationID =@ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;
                   
                
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


        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString) ;

            string query = @"SELECT ActiveApplicationID=ApplicationID FROM Applications
                   WHERE ApplicantPersonID = @ApplicantPersonID 
                and ApplicationTypeID=@ApplicationTypeID 
                     and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }

        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {

            //incase the ActiveApplication ID !=-1 return true.
            return (GetActiveApplicationID(PersonID, ApplicationTypeID) != -1);
        }
        public static DataTable GetAllApplications()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = "select * from ApplicationsList_View order by ApplicationDate desc";

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

            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int ApplicationTypeID, int LicenseClassID)
        {
            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }
        public static bool UpdateStatus(int ApplicationID , short NewStatus)
        {
            int rowAffected = 0;

            SqlConnection connection = new SqlConnection(ClsDVLDSettings.ConnectionsString);

            string query = @"Update Applications
                             set ApplicationStatus = @NewStatus,
                                 LastStatusDate =@LastStatusDate

                           where  ApplicationID =@ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

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

            return (rowAffected > 0);
        }

        
    }
}
