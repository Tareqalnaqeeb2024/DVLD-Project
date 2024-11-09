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
using System.Data;
using System.Resources;

namespace MyDVLD.Test.User_Control
{
    public partial class ctrlScheduledTest : UserControl
    {
        private ClsTestTypes.enTestTypes _TestTypesID;
        private int _TestID = -1;
        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseID = -1;
        private ClsTestAppointment _TestAppointment;
        private ClsLocalDrivingLincese _LocalDrivingLincese;

        public ClsTestTypes.enTestTypes TestTypesID
        {
            get
            {
                return _TestTypesID;
            }

            set
            {
                _TestTypesID = value;

                switch (_TestTypesID)
                {

                    case ClsTestTypes.enTestTypes.visionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image =Properties.Resources.Vision_512;
                            break;
                        }

                    case ClsTestTypes.enTestTypes.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Properties.Resources.Written_Test_512;
                            break;
                        }
                    case ClsTestTypes.enTestTypes.streetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.Image =Properties.Resources.driving_test_512;
                            break;


                        }
                }
            }
        }
        
        public int TestAppointmentID
        {
            get { return _TestAppointmentID; }
        }

        public int TestID
        {
            get { return _TestID; }
        }

       
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }


        public void LoadData(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;

            _TestAppointment = ClsTestAppointment.Find(TestAppointmentID);

            if(_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //_TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestAppointmentID;

            _LocalDrivingLicenseID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLincese = ClsLocalDrivingLincese.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLicenseID);

            if(_LocalDrivingLincese == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseID.ToString(),
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLincese.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LocalDrivingLincese.LicenseClassInfo.ClassName;
            lblFullName.Text = _LocalDrivingLincese.ApplicantFullName;
           // lblTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();



            lblDate.Text = _TestAppointment.AppointmentDate.ToString();
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = (_TestAppointment.TestAppointmentID == -1) ? "Not Taken Yet" : _TestAppointment.TestAppointmentID.ToString();


        }
        private void ctrlScheduledTest_Load(object sender, EventArgs e)
        {

        }
    }
}
