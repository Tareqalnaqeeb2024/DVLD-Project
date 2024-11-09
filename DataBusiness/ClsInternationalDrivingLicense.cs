using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;


namespace DataBusiness
{
  public  class ClsInternationalDrivingLicense:ClsApplications
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public ClsDriver DriverInfo;
        public int InternationalLicenseID { set; get; }
        public int DriverID { set; get; }
        public int IssuedUsingLocalLicenseID { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public bool IsActive { set; get; }


        public ClsInternationalDrivingLicense()
        {
            
                //here we set the applicaiton type to New International License.
                this.ApplicationTypeID = (int)ClsApplications.enApplicationType.NewInternationalLicense;

                this.InternationalLicenseID = -1;
                this.DriverID = -1;
                this.IssuedUsingLocalLicenseID = -1;
                this.IssueDate = DateTime.Now;
                this.ExpirationDate = DateTime.Now;

                this.IsActive = true;


                Mode = enMode.AddNew;

           

        }


        public ClsInternationalDrivingLicense(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID,
             int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            base.ApplicationID = ApplicationID;
            base.ApplicationPersonID = ApplicantPersonID;
            base.ApplicationTypeID =(int) enApplicationType.NewInternationalLicense;
            base.ApplicationDate = ApplicationDate;
            base.PaidFees = PaidFees;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.CreatedByUserID = CreatedByUserID;

            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;

            this.DriverInfo = ClsDriver.FindDriverByDriverID(this.DriverID);

            Mode = enMode.Update;

        }

        private bool _AddNewInternationalLicense()
        {
            //call DataAccess Layer 

            this.InternationalLicenseID =
                ClsInternationalDrivingLicenseData.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
               this.IssueDate, this.ExpirationDate,
               this.IsActive, this.CreatedByUserID);


            return (this.InternationalLicenseID != -1);
        }

        private bool _UpdateInternationalLicense()
        {
            //call DataAccess Layer 

            return ClsInternationalDrivingLicenseData.UpdateInternationalLicense(
                this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
               this.IssueDate, this.ExpirationDate,
               this.IsActive, this.CreatedByUserID);
        }

        public static ClsInternationalDrivingLicense Find(int InternationalDrivingLicenseID)
        {
            int ApplicationID = -1, DriverID = -1, CreatedByUserID = 1, IssuedUsingLocalLicensID = -1;

            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool IsActive = true;


            if (ClsInternationalDrivingLicenseData.GetInternationalLicenseInfoByID(InternationalDrivingLicenseID, ref ApplicationID,
                ref DriverID, ref IssuedUsingLocalLicensID, ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {

                ClsApplications Application = ClsApplications.FindBaseApplication(ApplicationID);


                return new ClsInternationalDrivingLicense(InternationalDrivingLicenseID, Application.ApplicationPersonID, Application.ApplicationDate,
                   (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID, InternationalDrivingLicenseID,
                    DriverID, IssuedUsingLocalLicensID, IssueDate, ExpirationDate, IsActive);
            }
            else
                return null;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            return ClsInternationalDrivingLicenseData.GetAllInternationalLicenses();

        }

        public bool Save()
        {

            base.Mode = (ClsApplications.enMode)Mode;

            if (!base.Save())
                return false;


            switch (Mode)
            {

               
                case enMode.AddNew:
                    if(_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }else
                    {
                        return false;
                    }

              
                case enMode.Update:
                    return _UpdateInternationalLicense();
                   
            }
            return false;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {

            return ClsInternationalDrivingLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);

        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return ClsInternationalDrivingLicenseData.GetDriverInternationalLicenses(DriverID);
        }
    }

    
}
