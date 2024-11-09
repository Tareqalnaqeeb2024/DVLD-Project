using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;


namespace DataBusiness
{
  public  class ClsTestAppointment
    {

        public enum enMode { AddNew = 0 , Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public ClsTestTypes.enTestTypes TestTypeID { get; set; }
     
        public ClsTestTypes TestTypesInfo;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }

        public int RetakeTestApplicationID { get; set; }
        public ClsApplications RetakeTestAppInfo;


        public ClsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = ClsTestTypes.enTestTypes.visionTest;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;
            Mode = enMode.AddNew;
        }

        private ClsTestAppointment(int TestAppointmentID, ClsTestTypes.enTestTypes TestTypeID,
           int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees,
           int CreatedByUserID, bool IsLocked , int RetakeTestApplicationID)
        {
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.RetakeTestAppInfo = ClsApplications.FindBaseApplication(RetakeTestApplicationID);
            Mode = enMode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            //call DataAccess Layer 

            this.TestAppointmentID = ClsTestAppointmentData.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);

            return (this.TestAppointmentID != -1);
        }

        private bool _UpdateTestAppointment()
        {
            //call DataAccess Layer 

            return ClsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID,
                this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked ,this.RetakeTestApplicationID);
        }
        public static ClsTestAppointment Find(int TestAppointmentID)
        {
            int TestTypeID = 1; int LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now; float PaidFees = 0;
            int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

            if (ClsTestAppointmentData.GetTestAppointmentInfoByID(TestAppointmentID, ref TestTypeID, ref LocalDrivingLicenseApplicationID,
            ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked , ref RetakeTestApplicationID))

                return new ClsTestAppointment(TestAppointmentID, (ClsTestTypes.enTestTypes)TestTypeID, LocalDrivingLicenseApplicationID,
             AppointmentDate, PaidFees, CreatedByUserID, IsLocked ,RetakeTestApplicationID);
            else
                return null;

        }

        //public static ClsTestAppointment GetLastTestAppointment(int LocalDrivingLicenseApplicationID, ClsTestTypes.enTestType TestTypeID)
        //{
        //    int TestAppointmentID = -1;
        //    DateTime AppointmentDate = DateTime.Now; float PaidFees = 0;
        //    int CreatedByUserID = -1; bool IsLocked = false; int RetakeTestApplicationID = -1;

        //    if (ClsTestAppointmentData.GetLastTestAppointment(LocalDrivingLicenseApplicationID, (int)TestTypeID,
        //        ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID))

        //        return new ClsTestAppointment(TestAppointmentID, TestTypeID, LocalDrivingLicenseApplicationID,
        //     AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
        //    else
        //        return null;

        //}

        public static DataTable GetAllTestAppointments()
        {
            return ClsTestAppointmentData.GetAllTestAppointments();

        }

        public DataTable GetApplicationTestAppointmentsPerTestType(ClsTestTypes.enTestTypes TestTypeID)
        {
            return ClsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, ClsTestTypes.enTestTypes TestTypeID)
        {
            return ClsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestAppointment())
                    {
                        Mode = enMode.Update;


                        return true;

                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestAppointment();

            }

            return false;
        }

        private int _GetTestID()
        {
            return ClsTestAppointmentData.GetTestID(TestAppointmentID);
        }


    }
}
