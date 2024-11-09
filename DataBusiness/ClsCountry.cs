using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace DataBusiness
{
   public class ClsCountry
    {
        public int ID { set; get; }
        public string CountryName { set; get; }

        public ClsCountry()

        {
            this.ID = -1;
            this.CountryName = "";

        }

        private ClsCountry(int ID, string CountryName)

        {
            this.ID = ID;
            this.CountryName = CountryName;
        }

        public static ClsCountry Find(int ID)
        {
            string CountryName = "";

            if (ClsCountryData.GetCountryInfoByID(ID, ref CountryName))

                return new ClsCountry(ID, CountryName);
            else
                return null;

        }

        public static ClsCountry Find(string CountryName)
        {

            int ID = -1;

            if (ClsCountryData.GetCountryInfoByName(CountryName, ref ID))

                return new ClsCountry(ID, CountryName);
            else
                return null;

        }

        public static DataTable GetAllCountries()
        {
            return ClsCountryData.GetAllCuntries();
        }
    }
}
