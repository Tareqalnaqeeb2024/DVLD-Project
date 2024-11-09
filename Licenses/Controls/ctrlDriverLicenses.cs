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
    public partial class ctrlDriverLicensec : UserControl
    {

        private int _DriverID;
        private ClsDriver _Driver;
        private DataTable _dtLocalLicense;
        private DataTable _dtInternationalLicense;


        public ctrlDriverLicensec()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenseInfo()
        {
            _dtLocalLicense = ClsDriver.GetLicenses(_DriverID);

            dgvLocalDrivingLicense.DataSource = _dtLocalLicense;

            lbLocalLicense.Text = dgvLocalDrivingLicense.Rows.Count.ToString();

            if(dgvLocalDrivingLicense.Rows.Count > 0)
            {

                dgvLocalDrivingLicense.Columns[0].HeaderText = "Lic.ID";
                dgvLocalDrivingLicense.Columns[0].Width = 110;

                dgvLocalDrivingLicense.Columns[1].HeaderText = "Application ID";
                dgvLocalDrivingLicense.Columns[1].Width = 110;

                dgvLocalDrivingLicense.Columns[2].HeaderText = " Class Name ";
                dgvLocalDrivingLicense.Columns[2].Width = 270;

                dgvLocalDrivingLicense.Columns[3].HeaderText = "Issue Date";
                dgvLocalDrivingLicense.Columns[3].Width = 170;

                dgvLocalDrivingLicense.Columns[4].HeaderText = " Expiration Date ";
                dgvLocalDrivingLicense.Columns[4].Width = 170;

                dgvLocalDrivingLicense.Columns[5].HeaderText = "Is active ";
                dgvLocalDrivingLicense.Columns[5].Width = 110;


            }
        }


        private void _LoadInternationalLicense()
        {
            _dtInternationalLicense = ClsDriver.GetInternationalLicenses(_DriverID);

            dgvInternationalLicense.DataSource = _dtInternationalLicense;

            lbInternationalRecord.Text = dgvInternationalLicense.Rows.Count.ToString();

            if(dgvInternationalLicense.Rows.Count >0)
            {

                dgvInternationalLicense.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicense.Columns[0].Width = 160;

                dgvInternationalLicense.Columns[1].HeaderText = "Application ID ";
                dgvInternationalLicense.Columns[1].Width = 130;

                dgvInternationalLicense.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicense.Columns[2].Width = 130;

                dgvInternationalLicense.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicense.Columns[3].Width = 180;

                dgvInternationalLicense.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicense.Columns[4].Width = 180;

                dgvInternationalLicense.Columns[5].HeaderText = "Is Active ";
                dgvInternationalLicense.Columns[5].Width = 120;

            }
        }


        public void LoadInfoByDriverID(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = ClsDriver.FindDriverByDriverID(DriverID);

            _LoadLocalLicenseInfo();
            _LoadInternationalLicense();


        }

        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = ClsDriver.FindDriverByPersonID(PersonID);

            if(_Driver != null)
            {
                _DriverID = ClsDriver.FindDriverByPersonID(PersonID).DriverID;
            }

            _LoadLocalLicenseInfo();
            _LoadInternationalLicense();


            
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ctrlDriverLicensec_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
