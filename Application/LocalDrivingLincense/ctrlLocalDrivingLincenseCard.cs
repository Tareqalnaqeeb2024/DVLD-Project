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

namespace MyDVLD.Application.LocalDrivingLincense
{
    public partial class ctrlLocalDrivingLincenseCard : UserControl
    {

        public ClsLocalDrivingLincese _localDrivingLincese;
        private int _LocalDrivingLinceseID  =-1;
        public int LocalDrivingLicenseID
        {
            get { return _LocalDrivingLinceseID; }
        }



        public ctrlLocalDrivingLincenseCard()
        {
            InitializeComponent();
            
        }


        public void  LoadLocalLicenseApplicationInfo(int LocalLicenseAppllicationID)
        {
            _localDrivingLincese = ClsLocalDrivingLincese.FindByLocalDrivingLicenseApplicationID(LocalLicenseAppllicationID);

            if(_localDrivingLincese == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show("No LocalLicenseAppWithID [" + LocalLicenseAppllicationID + "]", "Error", MessageBoxButtons.OK);
                return;
            }

            _FillLocalDrivingLicenseApplication();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void _FillLocalDrivingLicenseApplication( )
        {

            
             _LocalDrivingLinceseID = _localDrivingLincese.LocalDrivingLicenseApplicationID;
            lbDLAppID.Text = _localDrivingLincese.LocalDrivingLicenseApplicationID.ToString();
            lbAppliedForLicense.Text = _localDrivingLincese.LicenseClassInfo.ClassName;
            ctrlApplicationBasicInfo2.LoadApplicationData(_localDrivingLincese.ApplicationID);
            lbPassedTest.Text = _localDrivingLincese.GetPassedTestCount().ToString() + "/3";
        }


        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLinceseID = -1;
           
          lbAppliedForLicense.Text = "[????]";
            lbDLAppID.Text = "[????]";


        }


        private void ctrlLocalDrivingLincenseCard_Load(object sender, EventArgs e)
        {

        }

        private void ctrlApplicationBasicInfo2_Load(object sender, EventArgs e)
        {

        }

        private void gbDrivingLicenseInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}
