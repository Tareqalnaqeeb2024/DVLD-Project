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

namespace MyDVLD.Application.ReleasedDetainedLicense
{
    public partial class frmReleasedDetainedLicense : Form
    {
        public ClsDetainedLicense DetainedLicense;
        public int DetainedLicnseID = -1;
        public int LicenseID = -1;
        public frmReleasedDetainedLicense()
        {
            InitializeComponent();
        }

        private void frmReleasedDetainedLicense_Load(object sender, EventArgs e)
        {
           
            lblCreatedByUser.Text = "Tareq";
            lblApplicationFees.Text = ClsApplicationTypes.Find((int)ClsApplications.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
           

        }

        private void ctrlDriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            LicenseID = obj;
            DetainedLicense = ClsDetainedLicense.FindByLicenseID(LicenseID);
            if (DetainedLicense == null)
            {
                MessageBox.Show("Error , License Is Not Detained ", "Failed", MessageBoxButtons.OK);
                return;
            }
            lblFineFees.Text = DetainedLicense.FineFees.ToString();
            lblLicenseID.Text = LicenseID.ToString();
            lblDetainDate.Text = ClsFormat.DateToShort( DetainedLicense.DetainDate);
            lblDetainID.Text = DetainedLicense.DetainID.ToString();
            lblTotalFees.Text = (Convert.ToInt32(lblFineFees.Text) + Convert.ToInt32(lblApplicationFees.Text)).ToString();

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure To Released This License", "Confrim" ,MessageBoxButtons.YesNo ) == DialogResult.No)
            {
                btnRelease.Enabled = false;
                return;
            }

            int ApplicationID = -1;
            bool IsReleased = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.ReleasedDetainedLicense(1, ref ApplicationID);

            if (!IsReleased )
            {
            MessageBox.Show( " Sorry ,Released Detained License Failed ", "Failed", MessageBoxButtons.OK);
                return;

            }
            else

            MessageBox.Show("Released Detained License Successfuly ", "Success", MessageBoxButtons.OK);
            lblApplicationID.Text = ApplicationID.ToString();
            btnRelease.Enabled = false;
            ctrlDriverLicenseWithFilter1.FilterEnabled = false;
            

        }
    }
}
