using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace DataBusiness
{
    public class ClsApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 8
        };


        //public enum enApplicationStatus { New = 1 , Cancelled= 2 ,Completed =3 };
        public enMode Mode = enMode.AddNew;

        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public string ApplicantFullName
        {
            get { return ClsPerson.Find(ApplicationPersonID).FullName; }
        }
        public ClsPerson ApplicationPersonInfo;
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public ClsApplicationTypes ApplicationTypesInfo;

        public enApplicationStatus ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public ClsApplications()
        {
            this.ApplicationID = -1;
            this.ApplicationPersonID = -1;
            this.ApplicationPersonInfo = ClsPerson.Find(ApplicationPersonID);
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationTypesInfo = ClsApplicationTypes.Find(ApplicationTypeID);
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;

        }

        //private ClsApplications(int ApplicationID,  int ApplicationPersonID,  DateTime ApplicationDate,  int ApplicationTypeID,
        //              enApplicationStatus ApplicationStatus,  DateTime LastStatusDate,  float PaidFees,  int CreatedByUserID)
        //{
        //    this.ApplicationID = ApplicationID;
        //    this.ApplicationPersonID = ApplicationPersonID;
        //    this.ApplicationPersonInfo = ClsPerson.Find(ApplicationPersonID);
        //    this.ApplicationDate = ApplicationDate;
        //    this.ApplicationTypeID =  ApplicationTypeID;
        //    this.ApplicationTypesInfo = ClsApplicationTypes.Find(ApplicationTypeID);
        //    this.ApplicationStatus = ApplicationStatus;
        //    this.LastStatusDate =  LastStatusDate;
        //    this.PaidFees = PaidFees;
        //    this.CreatedByUserID = CreatedByUserID;
        //    Mode = enMode.Update;
        //}

        private ClsApplications(int ApplicationID, int ApplicantPersonID,
    DateTime ApplicationDate, int ApplicationTypeID,
     enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
     float PaidFees, int CreatedByUserID)

        {
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypesInfo = ClsApplicationTypes.Find(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
           // this. = clsUser.FindByUserID(CreatedByUserID);
            Mode = enMode.Update;
        }

            private bool _AddNewApplication()
        {
            this.ApplicationID = ClsApplicationsData.AddNewApplication(this.ApplicationPersonID, this.ApplicationDate, this.ApplicationTypeID,
                      (byte) this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            return ClsApplicationsData.UpdateApplication(this.ApplicationID, this.ApplicationPersonID, this.ApplicationDate, this.ApplicationTypeID,
                     (byte) this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public  bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewApplication())
                    {
                        return true;
                        Mode = enMode.Update;
                    }else
                    {
                        return false;
                    }
               
                case enMode.Update:
                    return _UpdateApplication();
                   
                default:
                    break;
            }

            return false;
        }

        public static ClsApplications FindBaseApplication(int ApplicationID)
        {

            //int ApplicantPersonID = -1;
            //DateTime ApplicationDate = DateTime.Now; int ApplicationTypeID = -1;
            //byte ApplicationStatus = 1; DateTime LastStatusDate = DateTime.Now;
            //float PaidFees = 0; int CreatedByUserID = -1;


            //bool IsFound = ClsApplicationsData.GetApplicationByID(ApplicationID, ref ApplicantPersonID, ref ApplicationDate,
            //     ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID);

            //if(IsFound)
            //{
            //    return new ClsApplications(ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID,(enApplicationStatus) ApplicationStatus,
            //         LastStatusDate, PaidFees, CreatedByUserID);
            //}else
            //{
            //    return null;
            //}

              int ApplicantPersonID=-1;
            DateTime ApplicationDate=DateTime.Now ;  int ApplicationTypeID=-1;
            byte ApplicationStatus =1; DateTime LastStatusDate= DateTime.Now;
            float PaidFees = 0  ;  int CreatedByUserID = -1;

            bool IsFound =ClsApplicationsData.GetApplicationByID
                                (
                                    ApplicationID, ref  ApplicantPersonID, 
                                    ref  ApplicationDate, ref  ApplicationTypeID,
                                    ref   ApplicationStatus, ref  LastStatusDate,
                                    ref  PaidFees, ref  CreatedByUserID
                                );

            if (IsFound)
                //we return new object of that person with the right data
                return new ClsApplications(ApplicationID,  ApplicantPersonID,
                                     ApplicationDate,  ApplicationTypeID,
                                    (enApplicationStatus) ApplicationStatus,  LastStatusDate,
                                     PaidFees,  CreatedByUserID);
            else
                return null;

        }

        public bool DeleteApplication()
        {
            return ClsApplicationsData.DeleteApplication(this.ApplicationID);
        }
        public bool IsApplicationExist(int ApplicationID)
        {
            return ClsApplicationsData.IsApplicationExist(ApplicationID);
        }
        public static DataTable GetAllApplications()
        {
            return ClsApplicationsData.GetAllApplications();
        }


        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return ClsApplicationsData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicationPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, ClsApplications.enApplicationType ApplicationTypeID)
        {
            return ClsApplicationsData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, ClsApplications.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return ClsApplicationsData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }

        public int GetActiveApplicationID(ClsApplications.enApplicationType ApplicationTypeID)
        {
            return GetActiveApplicationID(this.ApplicationPersonID, ApplicationTypeID);
        }

            public bool SetComplate()
        {
            return ClsApplicationsData.UpdateStatus(ApplicationID, 3);
        }

        public bool Cancel()
        {
            return ClsApplicationsData.UpdateStatus(this.ApplicationID, 2);
        }
    }
}
