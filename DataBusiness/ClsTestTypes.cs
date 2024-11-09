using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Data;

namespace DataBusiness
{
  public  class ClsTestTypes
    {
        public enum EnMode { AddNew =0 , Update = 1};
        EnMode Mode = EnMode.AddNew;
        public enum enTestTypes { visionTest = 1 , WrittenTest = 2 , streetTest = 3};

        public ClsTestTypes.enTestTypes  ID { get; set; }
        public string TestTitle { get; set; }
        public string TestDes { get; set; }
        public float TestFees { get; set; }

        public ClsTestTypes()
        {
          this.ID =enTestTypes.visionTest;
            this.TestTitle = "";
            this.TestDes = "";
            this.TestFees = 0;
            Mode = EnMode.AddNew;


        }

        private ClsTestTypes(ClsTestTypes.enTestTypes ID , string TestTitle, string TestDes , float TestFees)
        {
            this.ID = ID;
            this.TestTitle = TestTitle;
            this.TestDes = TestDes;
            this.TestFees = TestFees;
            Mode = EnMode.Update;
         }

         
        public static ClsTestTypes Find( ClsTestTypes.enTestTypes  ID)

        {
            string TestTitle = "";
            string TestDes = "";
            float TestFees = 0;

            if(ClsTestTypesData.GetTestTypeInfoByID((int) ID, ref TestTitle, ref TestDes , ref TestFees))
            {
                return new ClsTestTypes(ID, TestTitle,TestDes,TestFees);
            }else
            {
                return null;
            }
            
        }

        public static DataTable GetAllTestTypes()
        {
            return ClsTestTypesData.GetAllTestTypes();
        }

        private bool _AddNewTestType()
        {
            this.ID =  (ClsTestTypes.enTestTypes) ClsTestTypesData.AddNewTestTypes(this.TestTitle, this.TestDes, this.TestFees);

            return (this.ID > 0);
        }

        private bool _UpdateTestType()
        {
            return ClsTestTypesData.UpdateTestType((int) this.ID, this.TestTitle, this.TestDes, this.TestFees);
        }

        public  bool Save()
        {
            switch (Mode)
            {
                case EnMode.AddNew:

                    if(_AddNewTestType())
                    {
                        return true;
                        Mode = EnMode.Update;
                    }
                    else
                    {
                        return false;
                    }
                
                case EnMode.Update:
                    return _UpdateTestType();
                   
                default:
                    break;
            }
            return false;
        }
    }
}
