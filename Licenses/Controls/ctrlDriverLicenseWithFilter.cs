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

namespace MyDVLD.Licenses.Controls
{
    public partial class ctrlDriverLicenseWithFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID); // Raise the event with the parameter
            }
        }

        public ctrlDriverLicenseWithFilter()
        {
            InitializeComponent();
        }

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get {
                return _FilterEnabled;
            }

            set {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
        private int _LicenseID = -1;

        public int LicenseID
        {
            get { return ctrlDriverLicenseInfo1.LicenseID; }
        }

        public ClsLicense SelectedLicenseInfo
        {
            get { return ctrlDriverLicenseInfo1.SelectedLicenseInfo; }
        }


        public void LoadLicenseInfo(int LicenseID)
        {
            ctrlDriverLicenseInfo1.LoadInfo(LicenseID);
            txtLicenseID.Text = LicenseID.ToString();

            _LicenseID = ctrlDriverLicenseInfo1.LicenseID;

            if (OnLicenseSelected != null && _FilterEnabled)

                OnLicenseSelected(ctrlDriverLicenseInfo1.LicenseID);
        }
        private void ctrlDriverLicenseWithFilter_Load(object sender, EventArgs e)
        {

        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtLicenseID.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtLicenseID, "This Filed Is Requird!");


            }
            else
            {
                errorProvider1.SetError(txtLicenseID, null);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseID.Focus();
                return;

            }

            _LicenseID = int.Parse(txtLicenseID.Text);

            LoadLicenseInfo(_LicenseID);
        }

        public void txtLicenseIDFoucs()
        {
            txtLicenseID.Focus();
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if(e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }
        }

        private void ctrlDriverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
