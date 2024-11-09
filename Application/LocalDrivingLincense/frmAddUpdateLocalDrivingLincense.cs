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
using MyDVLD.Application;
using MyDVLD.Global_Classes;
namespace MyDVLD.Application.LocalDrivingLincense
{
    public partial class frmAddUpdateLocalDrivingLincense : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode Mode;

        public ClsLocalDrivingLincese _localDrivingLincese;
        public int _LocalDrivingLiceseID = -1;
        public int _SelectedPersonID = -1;



        public frmAddUpdateLocalDrivingLincense()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }

        public frmAddUpdateLocalDrivingLincense(int LocalDrivingLincese)
        {
            InitializeComponent();
            _LocalDrivingLiceseID = LocalDrivingLincese;
            Mode = enMode.Update;
        }

        private void frmAddUpdateLocalDrivingLincense_Load(object sender, EventArgs e)
        {
            _ResetDefultValues();

            if(Mode == enMode.Update)
            {
                _LoadDate();
            }
        }

        private void _FillcbLinceseClasses()
        {
            DataTable dtLinceseClass = clsLinceseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLinceseClass.Rows)
            {
                cbLinceseClass.Items.Add(row["ClassName"]);
            }
        }

        private void _ResetDefultValues()
        {
            _FillcbLinceseClasses();

            if (Mode == enMode.AddNew)
            {
                lbTitle.Text = "Add New Local Driving Lincese";
                _localDrivingLincese = new ClsLocalDrivingLincese();
                tpApplicationInfo.Enabled = false;
                ctrlPersonCardWithFilter1.FilterFocus();

                lbApplicationFees.Text = ClsApplicationTypes.Find((int)ClsApplications.enApplicationType.NewDrivingLicense).Fees.ToString();
                lbApplicationDate.Text = DateTime.Now.ToShortDateString();
                lbCreatedByUser.Text = ClsGlobal.CurrentUser.UserName;

                cbLinceseClass.SelectedIndex = 2;


            }

            else
            {
                lbTitle.Text = "Update Local Driving Lincese";


                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void _LoadDate()
        {
            ctrlPersonCardWithFilter1.FilterEnabled = false;
      
            _localDrivingLincese = ClsLocalDrivingLincese.FindByLocalDrivingLicenseApplicationID(_LocalDrivingLiceseID);

            if(_localDrivingLincese == null)
            {
                MessageBox.Show("No Local Driving Lincese with [" + _LocalDrivingLiceseID + "]", "No Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_localDrivingLincese.ApplicationPersonID);
            
            lbApplicationDate.Text = _localDrivingLincese.ApplicationDate.ToString();
            lbApplicationFees.Text = _localDrivingLincese.PaidFees.ToString();
            lbApplicationID.Text = _localDrivingLincese.LocalDrivingLicenseApplicationID.ToString();
            cbLinceseClass.Text = clsLinceseClass.Find(_localDrivingLincese.LicenseClassID).ClassName;
            lbCreatedByUser.Text = ClsGlobal.CurrentUser.UserName;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {




            int LicensesClassID = clsLinceseClass.Find(cbLinceseClass.Text).LicenseClassID ;

            int ActiveApplicationID = ClsApplications.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, ClsApplications.enApplicationType.NewDrivingLicense, LicensesClassID);

            if(ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLinceseClass.Focus();
                return;
            }


            if(ClsLicense.IsLicenseExsitByPersonID(_SelectedPersonID,LicensesClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(ClsLicense.IsLicenseExsitByPersonID(ctrlPersonCardWithFilter1.PersonID, LicensesClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _localDrivingLincese.ApplicationPersonID =ctrlPersonCardWithFilter1.PersonID;

            _localDrivingLincese.ApplicationDate = DateTime.Now;
            _localDrivingLincese.ApplicationTypeID = 1;
            _localDrivingLincese.ApplicationStatus = ClsApplications.enApplicationStatus.New;
            _localDrivingLincese.CreatedByUserID = ClsUser.FindByUserID(1).UserID;
            _localDrivingLincese.LicenseClassID = LicensesClassID;
            _localDrivingLincese.LastStatusDate = DateTime.Now;
            _localDrivingLincese.PaidFees = Convert.ToSByte(lbApplicationFees.Text);


            if(_localDrivingLincese.Save())
            {

                lbApplicationID.Text = _localDrivingLincese.LocalDrivingLicenseApplicationID.ToString();
                MessageBox.Show("Date Saved Succseefuly ", "Date Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                lbTitle.Text = "Update Local Driving License ";
                Mode = enMode.Update;
                
                
               

                
            }

            else
            {
                MessageBox.Show("Error: Date Is Not Saved Successfuly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //في حاله  التعديل 
            if (Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLocalDrivingLicense.SelectedTab = tcLocalDrivingLicense.TabPages["tcApplicationInfo"];
                return;
            }

          //  في حاله الاضافة و الشخص محدد عليه 
            if(ctrlPersonCardWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcLocalDrivingLicense.SelectedTab = tcLocalDrivingLicense.TabPages["tpApplicationInfo"];
            }

            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }

        }

        private void frmAddUpdateLocalDrivingLincense_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;

          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
             }

        private void tpApplicationInfo_Click(object sender, EventArgs e)
        {

        }

        //private void DataBackEvent(object sender, int PersonID)
        //{
        //    // Handle the data received
        //    _SelectedPersonID = PersonID;
        //    ctrlPersonCardWithFilter1.LoadPersonInfo(PersonID);


        //}
        //private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        //{
        //    _SelectedPersonID = obj;

        //}
    }
}
