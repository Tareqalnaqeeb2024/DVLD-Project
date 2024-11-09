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
//using MyDVLD.Properties;
using System.Resources;
using System.IO;
using MyDVLD.Global_Classes;

namespace MyDVLD.Licenses.International_License.Controls
{
    public partial class ctrlIntrenationalLicense : UserControl
    {

        private int _InternationalLicenseID;
        private ClsInternationalDrivingLicense _InternationalDrivingLicense;

        public int InternationaLicenseID
        {
            get { return _InternationalLicenseID; }
        }
        public ctrlIntrenationalLicense()
        {
            InitializeComponent();
        }

        private void ctrlIntrenationalLicense_Load(object sender, EventArgs e)
        {

        }

        private void _LoadImage()
        {
            if (_InternationalDrivingLicense.DriverInfo.PersonInfo.Gendor == 0)

                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;

            string ImageFile = _InternationalDrivingLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImageFile != "")
            {
                if (File.Exists(ImageFile))
                    pbPersonImage.Load(ImageFile);
                else
                    MessageBox.Show("Could Not Find This Iamge : = " + ImageFile, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void LoadInfo(int InternationalLicenseID )
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalDrivingLicense = ClsInternationalDrivingLicense.Find(_InternationalLicenseID);

            if (_InternationalDrivingLicense == null)
            {
                MessageBox.Show("Could not find International License ID =" + _InternationalLicenseID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }

            lblInternationalLicenseID.Text = _InternationalDrivingLicense.InternationalLicenseID.ToString();
            lblApplicationID.Text = _InternationalDrivingLicense.ApplicationTypeID.ToString();
            lblDriverID.Text = _InternationalDrivingLicense.DriverID.ToString();

            lblDateOfBirth.Text = ClsFormat.DateToShort(_InternationalDrivingLicense.DriverInfo.PersonInfo.DateOfBirth);
            lblExpirationDate.Text = ClsFormat.DateToShort(_InternationalDrivingLicense.ExpirationDate);
            lblIssueDate.Text = ClsFormat.DateToShort(_InternationalDrivingLicense.IssueDate);

            lblFullName.Text = _InternationalDrivingLicense.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _InternationalDrivingLicense.DriverInfo.PersonInfo.NationalNo;
            //lblFullName.Text = _InternationalDrivingLicense.ApplicationPersonInfo.FullName;


            lblIsActive.Text = _InternationalDrivingLicense.IsActive ? "true" : "false";
            lblGendor.Text = _InternationalDrivingLicense.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";

            lblLocalLicenseID.Text = _InternationalDrivingLicense.IssuedUsingLocalLicenseID.ToString();

            _LoadImage();



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
