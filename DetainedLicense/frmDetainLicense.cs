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

namespace MyDVLD.DetainedLicense
{
    public partial class frmDetainLicense : Form
    {

       
    
       
        public int _DetainID = -1;
        public int _SelectLiceneID =-1;

        
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseWithFilter1_Load(object sender, EventArgs e)
        {
            
        }

        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = ClsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = "Tareq";
            

        }

        private void ctrlDriverLicenseWithFilter1_OnLicenseSelected(int obj)
        {

            _SelectLiceneID = obj;
            lblLicenseID.Text = _SelectLiceneID.ToString();


            bool IsDetainedLicense = ClsDetainedLicense.IsLicenseDetained(_SelectLiceneID);


            if (IsDetainedLicense)
            {
                MessageBox.Show("License With ID [  " + _SelectLiceneID.ToString() + "] Is Already Detained", "Not Allowed", MessageBoxButtons.OKCancel);
                txtFineFees.Enabled = false;
                btnDetain.Enabled = false;
                return;

            }
            txtFineFees.Enabled = true;
            btnDetain.Enabled = true;








        }

        private void btnDetain_Click(object sender, EventArgs e)
        {

            if(!ValidateChildren())
            {
                return;
            }
            if(MessageBox.Show("Are you sure to Detain this License" ,"Confrim" ,MessageBoxButtons.OKCancel) == DialogResult.No)
            {
                return;
            }
            _DetainID = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.Detain(Convert.ToSingle(txtFineFees.Text), 1);

            if (_DetainID == -1)
            {
                MessageBox.Show("Faild to Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            else
            lblDetainID.Text = _DetainID.ToString();

            MessageBox.Show("License Detained Successfully with ID=" + _DetainID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ctrlDriverLicenseWithFilter1.FilterEnabled = false;
            txtFineFees.Enabled = false;
            btnDetain.Enabled = false;


           


        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtFineFees.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtFineFees, "Is Not Should be Empty");
                return;

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFineFees, null);
            }

            if (!ClsValidating.IsNumber(txtFineFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFineFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFineFees, null);
            };
        }

        private void frmDetainLicense_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseWithFilter1.txtLicenseIDFoucs();
        }
    }
}
