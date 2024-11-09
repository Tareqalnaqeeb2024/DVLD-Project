using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDVLD.Users;
using MyDVLD.Application;
using MyDVLD.Properties;
using MyDVLD.People;
using DataBusiness;
using System.Data;
using MyDVLD.Application.ApplicationTypes;
using MyDVLD.Test.TestTypes;
using MyDVLD.Application.LocalDrivingLincense;

using MyDVLD.Application;
using MyDVLD.Login;


//namespace MyDVLD
//{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        //.Run(new frmListUsers());
        // Application.Run(new frmListApplicationTypes() );
        //Application.Run(new frmListLocalDrivingLincense());
       // Application.Run( new MyDVLD.MainForm() );
       // Application.Run(new MyDVLD.frmMainForm());
        Application.Run(new frmLogin());

    }
}
//}
