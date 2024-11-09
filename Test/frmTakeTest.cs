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
    public partial class frmTakeTest : Form
    {
        private ClsTestTypes.enTestTypes _TestType;
        private int _TestAppoinmentID ;
        private ClsTest _Test;
       
        //private ClsTestAppointment _TestAppointment;
        private int _LocalLicenseDrivingID = -1;
        //private ClsLocalDrivingLincese _LocalLicenseDriving;


        public frmTakeTest(int TestAppointmentID , ClsTestTypes.enTestTypes TestType)
        {
            InitializeComponent();
            _TestAppoinmentID = TestAppointmentID;
            _TestType = TestType;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest1.TestTypesID = _TestType;
            ctrlScheduledTest1.LoadData(_TestAppoinmentID);

            //int TestID = ctrlScheduledTest1.TestID;
            //int TestID = 73;

            //if (TestID != -1)
            //{
            //    _Test = ClsTest.Find(TestID);

            //    //if (_Test.TestResult)

            //    //    rbPass.Checked = true;
            //    //else
            //    //    rbFail.Checked = true;

            //    txtNotes.Text = _Test.Notes;
            //    lblUserMessage.Enabled = true;

            //    rbFail.Enabled = false;
            //    rbPass.Enabled = false;

                
            //}
            //else
            //{
                _Test = new ClsTest();
            //}

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to save the Reslut , you can not Edit after" ,"Confrim",MessageBoxButtons.YesNo)==
                DialogResult.No)
            {
                return;
            }

            _Test.TestAppointmentID = _TestAppoinmentID;
            
            _Test.Notes = txtNotes.Text;
            _Test.TestResult = rbPass.Checked;
            _Test.CreatedByUserID = 1;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfuly", "Saved ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                MessageBox.Show(_Test.TestID.ToString());
                return;
            }
            else
                MessageBox.Show("Data Not Saved Successfuly", "Error", MessageBoxButtons.OK);
        }
    }
}
