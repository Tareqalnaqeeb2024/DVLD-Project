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
using MyDVLD.People;
using MyDVLD.Properties;
using MyDVLD.Global_Classes;


namespace MyDVLD.Application.ApplicationTypes
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {

        public ClsApplications _Application;

        private int _ApplicationID = -1;

        public int ApplicationID
        {
            get { return _ApplicationID; }
        }



        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }


        public  void LoadApplicationData(int ApplicationID)

        {
            _Application = ClsApplications.FindBaseApplication(ApplicationID);

            if(_Application == null)
            {
                _ResetDefultValue();
                MessageBox.Show("Sorry! : No Application with ID [" + ApplicationID + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            _FillApplicationInfo();
        }

        public void _ResetDefultValue()
        {
            _ApplicationID = -1;
            lbApplicationID.Text = "??";
            lbStatus.Text = "???";
            lbStatusDate.Text = "???";
            lbFees.Text = "???";
            lbType.Text = "???";
            lbUserID.Text = "???";
            lbDate.Text = "???";
            lbApplicant.Text = "???";
           
        }

        private void _FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lbApplicationID.Text = _Application.ApplicationID.ToString();

            lbApplicant.Text = _Application.ApplicantFullName;
            lbDate.Text = ClsFormat.DateToShort(_Application.ApplicationDate);
            lbStatus.Text = _Application.ApplicationStatus.ToString();
            lbStatusDate.Text = ClsFormat.DateToShort(_Application.LastStatusDate);
            lbFees.Text = _Application.PaidFees.ToString();
            lbType.Text = _Application.ApplicationTypesInfo.Title;
            lbUserID.Text = "Tareq";
        }
        private void ctrlApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }

        private void gbApplicationInfo_Enter(object sender, EventArgs e)
        {

        }

        private void ctrlUserCard1_Load(object sender, EventArgs e)
        {

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_Application.ApplicationPersonID);
            frm.ShowDialog();
            LoadApplicationData(_ApplicationID);
        }
    }
}
