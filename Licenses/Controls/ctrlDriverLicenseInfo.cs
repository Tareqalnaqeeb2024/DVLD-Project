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
using System.IO;
using MyDVLD.Properties;
using MyDVLD.Global_Classes;

namespace MyDVLD.Licenses.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID = -1;
        private ClsLicense _License;

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public ClsLicense SelectedLicenseInfo
        {
            get { return _License; }
        }
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public  void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;

            _License = ClsLicense.Find(LicenseID);

            if(_License == null)
            {
                MessageBox.Show("Error: No LicenseID with [" + LicenseID.ToString() + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLicenseData();
        }

        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        public void _FillLicenseData()
        {
            _LoadPersonImage();
             _LicenseID = _License.LicenseID ;
            lblDriverID.Text = _License.DriverID.ToString();
            lblClass.Text = _License.LicenseClass.ToString();
            lblExpirationDate.Text = ClsFormat.DateToShort(_License.ExpirationDate);
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIssueDate.Text = ClsFormat.DateToShort(_License.IssueDate);
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblDateOfBirth.Text = ClsFormat.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);
            lblNotes.Text = _License.Notes == "" ? "No Notes":_License.Notes;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIssueReason.Text = _License.IssueReason.ToString();
        }
        private void ctrlDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
