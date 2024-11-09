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
using static DataBusiness.ClsLicense;

namespace MyDVLD.Application.ReplaceLostOrDamgedLicense
{
    public partial class frmReplaceLostOrDemagedLicense : Form
    {
        private int _NewLicenseID=-1;
        public frmReplaceLostOrDemagedLicense()
        {
            InitializeComponent();
        }

        private void frmReplaceLostOrDemagedLicense_Load(object sender, EventArgs e)
        {
            lblCreatedByUser.Text = ClsGlobal.CurrentUser.UserName;
            lblApplicationDate.Text = ClsFormat.DateToShort(DateTime.Now);
        }


        private int _GetApplicationTyoeID()
        {
            if (rbDamagedLicense.Checked)
                return (int)ClsApplications.enApplicationType.ReplaceDamagedDrivingLicense;
            else
                return (int)ClsApplications.enApplicationType.ReplaceLostDrivingLicense;
        }
        private enIssueReason _GetIssueReason()
        {
            if (rbDamagedLicense.Checked)
                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replace For Damaged Licese";
            lblApplicationFees.Text = ClsApplicationTypes.Find(_GetApplicationTyoeID()).Fees.ToString();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replace For Lost Licese";
            lblApplicationFees.Text = ClsApplicationTypes.Find(_GetApplicationTyoeID()).Fees.ToString();
        }

        private void ctrlDriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();


            if(SelectedLicenseID == -1)
            {
                return;
            }


            if(!ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                 , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }

            btnIssueReplacement.Enabled = true;

        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you Sure To Replace Lost Or Damaged License","Confirm",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }


            ClsLicense NewLicense = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(), 1);

            if(NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;

            lblRreplacedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnIssueReplacement.Enabled = false;
            gbReplacementFor.Enabled = false;
            ctrlDriverLicenseWithFilter1.FilterEnabled = false;
            //llShowLicenseInfo.Enabled = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
