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
using MyDVLD.People;
using MyDVLD.Licenses.International_License;
using MyDVLD.Licenses;

namespace MyDVLD.Application.InternationalDrivingLicenses
{
    public partial class frmListInternationalDrivingLicense : Form
    {
        public  DataTable _dtAllInternationalLicense;
        
        public frmListInternationalDrivingLicense()
        {
            InitializeComponent();
        }

        private void frmListInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            _ResfersAllInternationalLicense();
        }

        private void _ResfersAllInternationalLicense()
        {
            _dtAllInternationalLicense = ClsInternationalDrivingLicense.GetAllInternationalLicenses();
            dgvInternationalLicenses.DataSource = _dtAllInternationalLicense;

            lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();

            if(dgvInternationalLicenses.Rows.Count >0)
            {
                dgvInternationalLicenses.Columns[0].HeaderText = "Int.National ID";
                dgvInternationalLicenses.Columns[0].Width = 160;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 150;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 130;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 130;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 180;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 180;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 120;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.Text == "Is Active")
            {
                cbIsActive.Enabled = true;
                txtFilterValue.Enabled = false;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtFilterValue.Enabled = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                if(cbFilterBy.Text =="None")
                {
                    txtFilterValue.Enabled = false;
                }
                else
                {
                    txtFilterValue.Enabled = true;
                    txtFilterValue.Focus();
                    txtFilterValue.Text = "";

                }
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;

                  
                case "Application ID":
                    
                        FilterColumn = "ApplicationID";
                        break;
                 

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if(FilterColumn == "None" || txtFilterValue.Text.Trim() == "")
            {
                _dtAllInternationalLicense.DefaultView.RowFilter = "";
                lblInternationalLicensesRecords.Text = _dtAllInternationalLicense.Rows.Count.ToString();
                return;
            }
           
                _dtAllInternationalLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
                lblInternationalLicensesRecords.Text = _dtAllInternationalLicense.Rows.Count.ToString();


        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string TextValue = cbIsActive.Text;

            switch (TextValue)
            {
                case "All":
                    
                    break;
                case "Yes":
                    TextValue = "1";
                    break;
                case "No":
                    TextValue = "0";
                    break;
               
            }

            if (TextValue == "All")
                _dtAllInternationalLicense.DefaultView.RowFilter = "";
            else
                _dtAllInternationalLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TextValue);

            lblInternationalLicensesRecords.Text = _dtAllInternationalLicense.Rows.Count.ToString();


        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsDriver Driver = ClsDriver.FindDriverByDriverID((int)dgvInternationalLicenses.CurrentRow.Cells[2].Value);

            int PersonID = Driver.PersonID;

            frmPersonInfo frm = new frmPersonInfo(PersonID);
            frm.ShowDialog();

            
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo((int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;

            int PersonID = ClsDriver.FindDriverByDriverID(DriverID).PersonID;
            

            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            frmAddNewIntrnationalLicenseApplication frm = new frmAddNewIntrnationalLicenseApplication();
            frm.ShowDialog();

            frmListInternationalDrivingLicense_Load(null, null);
        }
    }
}
