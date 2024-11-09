using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace DataBusiness
{
  public  class ClsLicense
    {
        public enum enMode { AddNew =0 , Update =1};
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };


        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }


        public ClsDriver DriverInfo;
        public ClsApplications ApplicationInfo;
        public clsLinceseClass LicenseClassInfo;
        public ClsDetainedLicense DetainedLicenseInfo;
        public bool IsDetained
        {
            get
            {
                return ClsDetainedLicense.IsLicenseDetained(this.LicenseID);
            }
        }

        public ClsLicense()
        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }

        private ClsLicense( int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
             DateTime IssueDate, DateTime ExpirationDate, string Notes,
             float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)

        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason =  IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.DriverInfo = ClsDriver.FindDriverByDriverID(this.DriverID);
            this.LicenseClassInfo = clsLinceseClass.Find(this.LicenseClass);
            this.ApplicationInfo = ClsApplications.FindBaseApplication(this.ApplicationID);
            this.DetainedLicenseInfo = ClsDetainedLicense.FindByLicenseID(this.LicenseID);
            
          
        }

        private bool _AddNewLicense()
        {
            //call DataAccess Layer 

            this.LicenseID = ClsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);


            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            //call DataAccess Layer 

            return ClsLicenseData.UpdateLicense(this.ApplicationID, this.LicenseID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public static ClsLicense Find(int LicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0; bool IsActive = true; int CreatedByUserID = 1;
            byte IssueReason = 1;
            if (ClsLicenseData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
            ref IssueDate, ref ExpirationDate, ref Notes,
            ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new ClsLicense(LicenseID, ApplicationID, DriverID, LicenseClass,
                                     IssueDate, ExpirationDate, Notes,
                                     PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;

        }

        public static DataTable GetAllLicenses()
        {
            return ClsLicenseData.GetAllLicenses();

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicense();

            }

            return false;
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {

            return ClsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);

        }

        public static bool IsLicenseExsitByPersonID(int PersonID , int LicenseClassID)
        {
            return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
        }

        public static DataTable GetDriverLicenses(int DriverID)
        {
            return ClsLicenseData.GetDriverLicenses(DriverID);
        }

        public bool IsLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }

        public bool DeactivateCurrentLicense()
        {
            return ClsLicenseData.DeactivateLicense(this.LicenseID);
        }

        public int Detain(float FineFees , int CreatedByUserID)
        {
            ClsDetainedLicense detainedLicense = new ClsDetainedLicense();

            detainedLicense.CreatedByUserID = CreatedByUserID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = Convert.ToSingle( FineFees);
            detainedLicense.LicenseID = this.LicenseID;

            if(!detainedLicense.Save())
            {
                return -1;
            }

            return detainedLicense.DetainID;

        }

        public ClsLicense RenewLicense( string Notes , int CreatedByUserID)
        {

            ClsApplications Application = new ClsApplications();

            Application.ApplicationID = this.ApplicationID;

            Application.ApplicationStatus = ClsApplications.enApplicationStatus.Completed;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationTypeID =(int) ClsApplications.enApplicationType.RenewDrivingLicense;
            Application.PaidFees = ClsApplicationTypes.Find(Application.ApplicationTypeID).Fees;

            Application.CreatedByUserID = CreatedByUserID;


            if(!Application.Save())
            {
                return null;
            }

            ClsLicense License = new ClsLicense();


            License.ApplicationID = Application.ApplicationID;
            License.DriverID = this.DriverID;
            License.IssueDate = DateTime.Now;
            int DefaultValidityLength = this.LicenseClassInfo.DefaultValidityLength;

            License.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            License.LicenseClass = this.LicenseClass;
            License.IsActive = true;
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IssueReason = ClsLicense.enIssueReason.Renew;
            License.CreatedByUserID = CreatedByUserID;

            if(!License.Save())
            {
                return null;
            }

            DeactivateCurrentLicense();

            return License;

            
        }

        public bool ReleasedDetainedLicense(int ReleasedByUserID , ref int ApplicationID)
        {
            ClsApplications Application = new ClsApplications();

            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)ClsApplications.enApplicationType.ReleaseDetainedDrivingLicsense;
            Application.ApplicationStatus = ClsApplications.enApplicationStatus.Completed;
            Application.CreatedByUserID = ReleasedByUserID;
            Application.PaidFees = ClsApplicationTypes.Find((int)ClsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
            Application.LastStatusDate = DateTime.Now;

            if(!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }
              ApplicationID = Application.ApplicationID;

            return this.DetainedLicenseInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);

        }

        public ClsLicense Replace(enIssueReason IssueReason, int CreatedByUserID)
        {
            ClsApplications Application = new ClsApplications();

            Application.ApplicationID = this.ApplicationID;

            Application.ApplicationStatus = ClsApplications.enApplicationStatus.Completed;
            Application.ApplicationDate = DateTime.Now;
            Application.LastStatusDate = DateTime.Now;
            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationTypeID = (IssueReason == enIssueReason.DamagedReplacement) ?
                (int)ClsApplications.enApplicationType.ReplaceDamagedDrivingLicense :
                (int)ClsApplications.enApplicationType.ReplaceLostDrivingLicense; ;
            Application.PaidFees = ClsApplicationTypes.Find(Application.ApplicationTypeID).Fees;

            Application.CreatedByUserID = CreatedByUserID;


            if (!Application.Save())
            {
                return null;
            }

            ClsLicense NewLicense = new ClsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = this.Notes;
            NewLicense.PaidFees = 0;// no fees for the license because it's a replacement.
            NewLicense.IsActive = true;
            NewLicense.IssueReason = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save())
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;


        }


    }
}
