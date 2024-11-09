using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDVLD.Global_Classes
{
  public   class ClsFormat
    {
        public static string DateToShort(DateTime dt)
        {
            return dt.ToString("d/MM/yyyy");
        }
    }
}
