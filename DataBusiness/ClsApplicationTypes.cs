using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace DataBusiness
{
    public class ClsApplicationTypes
    {
        public enum EnMode { AddNew = 0, Update = 1 };
        EnMode Mode = EnMode.AddNew;


        public int ID { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; }


        public ClsApplicationTypes()
        {
            this.ID = -1;
            this.Title = "";
            this.Fees = 0;
            Mode = EnMode.AddNew;
        }


        private ClsApplicationTypes(int AppID ,string AppTitle , float Fees)
        {
            this.ID = AppID;
            this.Title = AppTitle;
            this.Fees = Fees;
            Mode = EnMode.Update;
        }
        public static ClsApplicationTypes Find(int ID)
        {
            string Title = ""; float Fees = 0;

            if (ClsApplicationTypesData.GetApplicationTypeInfoByID((int)ID, ref Title, ref Fees))

                return new ClsApplicationTypes(ID, Title, Fees);
            else
                return null;

        }

        public static DataTable GetAllApplicationTypes()
        {
           return  ClsApplicationTypesData.GetAllApplicationsTypes();
        }


        public bool _UpdateApplicationType()

        {
            return ClsApplicationTypesData.UpdateApplicationTypes(this.ID, this.Title, this.Fees);
        }

        private bool AddNewApplicationType()
        {
            this.ID = ClsApplicationTypesData.AddNewApplicationTypes(this.Title, this.Fees);

            return (this.ID != 0);
        }


        public  bool Save()

        {
            switch (Mode)
            {
                case EnMode.AddNew:
                   if( AddNewApplicationType())
                    {
                        return true;
                        Mode = EnMode.Update;
                    }else
                    {
                        return false;
                    }
                    
                   
                   
                case EnMode.Update:

                    return _UpdateApplicationType();
                    
               

            }

            return false;
        }
        //public enum EnMode { AddNew =0 ,Update =1};
        //public EnMode Mode = EnMode.AddNew;

        //public int ID { get; set; }
        //public string Title { get; set; }
        //public decimal Fees { get; set; }

        //ClsApplicationTypes()
        //{
        //    this.ID = -1;
        //    this.Title = "";
        //    this.Fees = 0;
        //}
        //ClsApplicationTypes(int ID ,string Title ,decimal Fees)
        //{
        //    this.ID = ID;
        //    this.Title = Title;
        //    this.Fees = Fees;
        //    Mode = EnMode.Update;
        //}
        //public static DataTable GetAllApplicationTypes()
        //{
        //    return ClsApplicationTypesData.GetAllApplactionTypes();
        //}
        //private bool _UpdateApplicationTypes()
        //{

        //    return ClsApplicationTypesData.UpdateApplicationTypes(this.ID, this.Title, this.Fees);



        //}


    }
}
