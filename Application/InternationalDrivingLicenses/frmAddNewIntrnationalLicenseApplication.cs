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
using MyDVLD.Global_Classes;

namespace MyDVLD.Application.InternationalDrivingLicenses
{
    public partial class frmAddNewIntrnationalLicenseApplication : Form
    {
        private int _IntrnationalLicenseID ;
        public frmAddNewIntrnationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            ClsInternationalDrivingLicense InternationalDrivingLicense = new ClsInternationalDrivingLicense();

            //these for Application Becasue it subclass of tham
            InternationalDrivingLicense.ApplicationPersonID = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalDrivingLicense.ApplicationDate = DateTime.Now;
           // InternationalDrivingLicense.ApplicationTypeID = ClsApplicationTypes.Find((int)ClsApplications.enApplicationType.NewInternationalLicense).ID;
            InternationalDrivingLicense.ApplicationStatus = ClsApplications.enApplicationStatus.Completed;
            InternationalDrivingLicense.PaidFees = ClsApplicationTypes.Find((int)ClsApplications.enApplicationType.NewInternationalLicense).Fees;
            InternationalDrivingLicense.CreatedByUserID = ClsGlobal.CurrentUser.UserID;
            InternationalDrivingLicense.LastStatusDate = DateTime.Now;

            // these fot  international License

            InternationalDrivingLicense.DriverID = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalDrivingLicense.IssuedUsingLocalLicenseID = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.LicenseID;
            InternationalDrivingLicense.IssueDate = DateTime.Now;
            InternationalDrivingLicense.ExpirationDate = DateTime.Now.AddYears(1);
           // InternationalDrivingLicense.IsActive = true;
            InternationalDrivingLicense.CreatedByUserID = ClsGlobal.CurrentUser.UserID;

            if (!InternationalDrivingLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

           // InternationalDrivingLicense.ApplicationID = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.ApplicationID;
            lblApplicationID.Text = InternationalDrivingLicense.ApplicationID.ToString();
            _IntrnationalLicenseID = InternationalDrivingLicense.InternationalLicenseID;
            lblInternationalLicenseID.Text =  InternationalDrivingLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalDrivingLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueLicense.Enabled = false;
            ctrlDriverLicenseWithFilter1.FilterEnabled = false;




        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblLocalLicenseID.Text = SelectedLicenseID.ToString();


            if(ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ActiveInterntioalLicenseID = ClsInternationalDrivingLicense.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DriverID);

            if(ActiveInterntioalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInterntioalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueLicense.Enabled = false;
                _IntrnationalLicenseID = ActiveInterntioalLicenseID;
                return;

            }

            btnIssueLicense.Enabled = true;
        }

        private void frmAddNewIntrnationalLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseWithFilter1.txtLicenseIDFoucs();
        }
    }
}
