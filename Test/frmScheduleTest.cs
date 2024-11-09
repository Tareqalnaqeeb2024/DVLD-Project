using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBusiness;
namespace MyDVLD.Test
{
    public partial class frmScheduleTest : Form
    {
        public int _TestAppointmentID = -1;
        public ClsTestTypes.enTestTypes _TestTypesID = ClsTestTypes.enTestTypes.visionTest;
        public int _LocalLicenseApplicationID = -1;
        public frmScheduleTest(int LocalLicenseAplicationID, ClsTestTypes.enTestTypes TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();
            _TestTypesID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;
            _LocalLicenseApplicationID = LocalLicenseAplicationID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypesID;
            ctrlScheduleTest1.LoadInfo(_LocalLicenseApplicationID, _TestAppointmentID);
            
            
        }

        private void ctrlScheduleTest1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
