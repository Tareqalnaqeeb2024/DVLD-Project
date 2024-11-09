using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace DataBusiness
{
  public  class ClsLocalDrivingLincese :ClsApplications
    {

        public  enum  enMode { AddNew =0 , Update =1};

        private  enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; }
        //public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLinceseClass LicenseClassInfo;
        public string FullName
        {
            get
            {
                return base.ApplicationPersonInfo.FullName;
            }
        }
        public ClsLocalDrivingLincese()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;
          //  this.ApplicationID = -1;
            Mode = enMode.AddNew;
        }

        private ClsLocalDrivingLincese(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID, int LicenseClassID)

        {
            //this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            //this.LicenseClassID =  LicenseClassID;
            //this.ApplicationID = ApplicationID;
            //this.ApplicationPersonID = ApplicationPersonID;
            //this.ApplicationStatus =( byte)ApplicationStatus;
            //this.PaidFees = PaidFees;
            //this.LastStatusDate = LastStatusDate;
            //this.CreatedByUserID = CreatedByUserID;
            //this.ApplicationDate = ApplicationDate;
            //this.ApplicationTypeID = ApplicationTypeID;

            //Mode = enMode.Update;

            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID; ;
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = (int)ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLinceseClass.Find(LicenseClassID);
            Mode = enMode.Update;
        }

        public static ClsLocalDrivingLincese FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int LicenseClassID = -1,ApplicationID = -1;

            bool IsFound = ClsLocalDrivingLinceseData.GetLocalDrivingLinceseDataByID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);
            if (IsFound)
            {

                ClsApplications Application = ClsApplications.FindBaseApplication(ApplicationID);

                if(Application == null)
                {
                 
               

                }
                //return new ClsLocalDrivingLincese(LocalDrivingLicenseApplicationID, LicenseClassID, Applications.ApplicationID , 
                //    Applications.ApplicationDate ,Applications.ApplicationTypeID , (enApplicationStatus)Applications.ApplicationStatus ,Applications.ApplicationPersonID,
                //    Applications.LastStatusDate ,Applications.PaidFees , Applications.CreatedByUserID);

                return new ClsLocalDrivingLincese(LocalDrivingLicenseApplicationID, Application.ApplicationID,
                    Application.ApplicationPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
            }
            else
            {
                return null;
            }
        }

        public static ClsLocalDrivingLincese FindByApplicationID(int ApplicationID )
        {
            int LicenseClassID = -1, LocalDrivingLicenseApplicationID = -1;

            bool IsFound = ClsLocalDrivingLinceseData.GetLocalDrivingLinceseDataByApplicationID(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);
            if (IsFound)
            {

                ClsApplications Application = ClsApplications.FindBaseApplication(ApplicationID);

                return new ClsLocalDrivingLincese(LocalDrivingLicenseApplicationID, Application.ApplicationID,
                    Application.ApplicationPersonID,
                                     Application.ApplicationDate, Application.ApplicationTypeID,
                                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                                     Application.PaidFees, Application.CreatedByUserID, LicenseClassID);

            }
            else
            {
                return null;
            }
        }


        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = ClsLocalDrivingLinceseData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);

            return (this.LocalDrivingLicenseApplicationID != -1);
        }

        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return ClsLocalDrivingLinceseData.UpdateNewLocalDrivingLicenseApplication
                (this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }

        public  bool Save()
        {


            base.Mode = (ClsApplications.enMode)Mode;

            if (!base.Save())

                return false;



            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                       
                    }
                    else
                    {
                        return false;
                    }
                    
                case enMode.Update:
                    return _UpdateLocalDrivingLicenseApplication();
                    
               
            }

            return false;
        }

        public static DataTable GetAllLocalDrivingLicenseApplication()
        {
            return ClsLocalDrivingLinceseData.GetAllLocalDrivingLincenseApplications();
        }

        public static bool DeleteLocalDrivingLicenseApplicationByID(int LocalDrivingLicenseApplicationID)
        {
            return ClsLocalDrivingLinceseData.DeleteLocalDrivingLicenseApplicationByID(LocalDrivingLicenseApplicationID);
        }
        public bool Delete()
        {

            bool IsDeleteLocalLicenseFirst = false;
            bool IsDeleteBaseApplication = false;

            IsDeleteLocalLicenseFirst = ClsLocalDrivingLinceseData.DeleteLocalDrivingLicenseApplicationByID(this.LocalDrivingLicenseApplicationID);

            if (!IsDeleteLocalLicenseFirst)

                return false;
            IsDeleteBaseApplication = base.DeleteApplication();

            return IsDeleteBaseApplication;
                
        }

       
        public  bool DoesPassedTestType(ClsTestTypes.enTestTypes TestType)
        {
            return ClsLocalDrivingLinceseData.DoesPassedTestType(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }
        public bool DoesAttendTestType( ClsTestTypes.enTestTypes testTypes)
        {
            return ClsLocalDrivingLinceseData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)testTypes);
        }

        public static bool IsThereAnActiveSheduledTest(int LocalDrivingLicenseApplicationID, ClsTestTypes.enTestTypes testTypes)
        {
            return ClsLocalDrivingLinceseData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)testTypes);
        }
        public bool IsThereAnActiveSheduledTest( ClsTestTypes.enTestTypes testTypes)
        {
            return ClsLocalDrivingLinceseData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)testTypes);
        }

        public  byte GetPassedTestCount()
        {
           return  ClsTest.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }

        public static byte GetPassedTestCount(int LocalDrivingLicense)
        {
            return ClsTest.GetPassedTestCount(LocalDrivingLicense);
        }

        public byte TotalTrialsPerTest(ClsTestTypes.enTestTypes TestTypeID)
        {
            return ClsLocalDrivingLinceseData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, ClsTestTypes.enTestTypes TestTypeID)

        {
            return ClsLocalDrivingLinceseData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        //public bool SetComplate()
        //{
        //    return ClsApplicationsData.UpdateStatus(ApplicationID, 3);
        //}

        public ClsTest GetLastTestPerTestType(ClsTestTypes.enTestTypes TestTypeID)
        {
            return ClsTest.FindLastTestPerPersonAndLicenseClass(this.ApplicationPersonID, this.LicenseClassID, TestTypeID);
        }


        public int IssuelicenseForFristTime(string Notes )
        {
            int DriverID = -1;

            ClsDriver Driver = ClsDriver.FindDriverByPersonID(this.ApplicationPersonID);

            if(Driver == null)
            {
                Driver = new ClsDriver();

                Driver.PersonID = this.ApplicationPersonID;
                Driver.CreatedByUserID = this.CreatedByUserID;

                if(Driver.Save())
                {
                    DriverID = Driver.DriverID ;
                }
                else
                {
                   
                    return -1;
                }
            }else
            {
                DriverID = Driver.DriverID;
            }

            ClsLicense License = new ClsLicense();

            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.IsActive = true;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.IssueDate = DateTime.Now;
            License.CreatedByUserID = this.CreatedByUserID  ;
            License.LicenseClass = this.LicenseClassID;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IssueReason = ClsLicense.enIssueReason.FirstTime;
            
            if(License.Save())
            {
                this.SetComplate();

                return License.LicenseID;
            }

            else
            {
                return -1;
            }
        }

        public bool PassedAllTest()
        {
            return ClsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }

        public  int GetActiveLicenseID()
        {
            return ClsLicense.GetActiveLicenseIDByPersonID(this.ApplicationPersonID, this.LicenseClassID);
        }
        public static bool IsThereActiveSchduleTest(int LocalDrivingLicenseApplicationID, ClsTestTypes.enTestTypes TestTypeID)
        {
            return ClsLocalDrivingLinceseData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool IsLicenseIssued()
        {
            return (GetActiveLicenseID() != -1);
        }


    }
}
