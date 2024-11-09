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

namespace MyDVLD.Application.Renew_Local_License
{
    public partial class frmRenewLocalLicense : Form
    {
        private int _NewLicenseID = -1;
        public frmRenewLocalLicense()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            int SelcetedPersonID = obj;
            lblOldLicenseID.Text = SelcetedPersonID.ToString();
            if (SelcetedPersonID == -1)
            {
                return;
            }

            if (ctrlDriverLicenseWithFilter1.SelectedLicenseInfo == null)
            {
                return;
            }
            int DefaultValidityLength = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength;
            lblOldLicenseID.Text = SelcetedPersonID.ToString();
            lblExpirationDate.Text = ClsFormat.DateToShort(DateTime.Now.AddYears(DefaultValidityLength));
            lblLicenseFees.Text = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblLicenseFees.Text) + Convert.ToSingle(lblApplicationFees.Text)).ToString();
           // lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();

            txtNotes.Text = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.Notes;


            if(!ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.IsActive)
            {
                

                MessageBox.Show("Selected License is not Not Active, choose an active license."
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                return;
            }

            if(!ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + ClsFormat.DateToShort(ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.ExpirationDate)
                      , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;

                return;
            }

            btnRenewLicense.Enabled = true;


        }

        private void frmRenewLocalLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseWithFilter1.txtLicenseIDFoucs();
        }

        private void frmRenewLocalLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = ClsFormat.DateToShort(DateTime.Now);
            lblApplicationFees.Text = ClsApplicationTypes.Find((int)ClsApplications.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblIssueDate.Text = lblApplicationDate.Text;
            lblExpirationDate.Text = "???";
            lblCreatedByUser.Text = ClsGlobal.CurrentUser.UserName;
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Are you Sure To Renew this License ","Confirm",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }


            ClsLicense NewLicense = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text, ClsGlobal.CurrentUser.UserID);


            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblRenewedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRenewLicense.Enabled = false;
          
            
        }
    }
}
