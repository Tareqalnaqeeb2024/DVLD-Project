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
using MyDVLD.Test.User_Control;
using MyDVLD.Application;
using static DataBusiness.ClsTestTypes.enTestTypes;
using MyDVLD.Properties;


namespace MyDVLD.Test
{
    public partial class frmListTestAppointment : Form
    {
        private int _LocalLicenseApplicationID;
        private ClsLocalDrivingLincese _LocalDrivingLincese;
        private ClsTestTypes.enTestTypes _TestType = ClsTestTypes.enTestTypes.visionTest;
        private DataTable _dtListTestAppointment;

        public frmListTestAppointment(int LocalLicenseApplication , ClsTestTypes.enTestTypes TestTypeID )
        {
            InitializeComponent();

            _LocalLicenseApplicationID = LocalLicenseApplication;
            _TestType = TestTypeID;
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case ClsTestTypes.enTestTypes.visionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;
                    }

                case ClsTestTypes.enTestTypes.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;
                    }
                case ClsTestTypes.enTestTypes.streetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;
                    }
            }
        }
        private void frmListTestAppointment_Load(object sender, EventArgs e)
        {

            _LoadTestTypeImageAndTitle();
            _dtListTestAppointment = ClsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalLicenseApplicationID , _TestType);
            ctrlLocalDrivingLincenseCard1.LoadLocalLicenseApplicationInfo(_LocalLicenseApplicationID);
            dgvLicenseTestAppointments.DataSource = _dtListTestAppointment;

            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[0].Width = 150;

                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[1].Width = 200;

                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[2].Width = 150;

                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvLicenseTestAppointments.Columns[3].Width = 100;
            }
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            _LocalDrivingLincese = ClsLocalDrivingLincese.FindByLocalDrivingLicenseApplicationID(_LocalLicenseApplicationID); 

            if(_LocalDrivingLincese.IsThereAnActiveSheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //frmScheduleTest frm = new frmScheduleTest(_LocalLicenseApplicationID, _TestType);
            //frm.ShowDialog();

            frmListTestAppointment_Load(null, null);

            ClsTest LastTest = _LocalDrivingLincese.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_LocalLicenseApplicationID, _TestType);
                frm1.ShowDialog();
                frmListTestAppointment_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm2 = new frmScheduleTest
                (LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            frmListTestAppointment_Load(null, null);


        }

        private void ctrlLocalDrivingLincenseCard1_Load(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointment = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;
            frmScheduleTest frm = new frmScheduleTest(_LocalLicenseApplicationID, _TestType, TestAppointment);
            frm.ShowDialog();
            frmListTestAppointment_Load(null, null);
        }


        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointment = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;

            frmTakeTest frm = new frmTakeTest(TestAppointment,_TestType);
            frm.ShowDialog();

            frmListTestAppointment_Load(null, null);
        }

        
    }
}
