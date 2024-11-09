using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataAccess;

namespace DataBusiness
{
  public   class ClsDriver
    {

       public enum enMode { Add =0 , Update = 1};
        public enMode Mode = enMode.Add;

        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public ClsPerson PersonInfo;
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get;  }

        public ClsDriver()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
            Mode = enMode.Add;
        }

        private ClsDriver(int DriverID , int PersonID, int CreatedByUserID , DateTime CreatedDate )
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = ClsPerson.Find(PersonID);
            Mode = enMode.Update;
        }

        public static ClsDriver FindDriverByDriverID(int DriverID)
        {
            int  PersonID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if(ClsDriverData.GetDriverInfoByDriverID(DriverID,ref PersonID , ref CreatedByUserID , ref CreatedDate ))
            {
                return new ClsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }

        public static ClsDriver FindDriverByPersonID(int PersonID)
        {
            int DriverID = -1, CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            if (ClsDriverData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))
            {
                return new ClsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            }
            else
            {
                return null;
            }
        }
        private bool _AddNewDriver()
        {
            this.DriverID = ClsDriverData.AddNewDriver(this.PersonID, this.CreatedByUserID);

            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return ClsDriverData.UpdateDriverData(this.DriverID, this.PersonID, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:

                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                    
                case enMode.Update:

                    return _UpdateDriver();
                    
                    
               
            }
            return false;


        }

        public  static DataTable GetAllDrivers()
        {
            return ClsDriverData.GetAllDrivers();
        }
        public static DataTable GetLicenses(int DriverID)
        {
            return ClsLicense.GetDriverLicenses(DriverID);
        }

        public static DataTable GetInternationalLicenses(int DriverID)
        {
            return ClsInternationalDrivingLicense.GetDriverInternationalLicenses(DriverID);
        }




    }
}
