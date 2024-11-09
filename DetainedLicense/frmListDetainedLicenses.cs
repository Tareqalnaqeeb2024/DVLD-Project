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



namespace MyDVLD.DetainedLicense
{
    public partial class frmListDetainedLicenses : Form
    {
        public DataTable _allDetainedLicense;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _allDetainedLicense = ClsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicenses.DataSource = _allDetainedLicense;
            lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

            if(dgvDetainedLicenses.Rows.Count>0)
            {
                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 90;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 90;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 160;

                dgvDetainedLicenses.Columns[3].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[3].Width = 110;

                dgvDetainedLicenses.Columns[4].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[4].Width = 110;

                dgvDetainedLicenses.Columns[5].HeaderText = "Rlease App.ID";
                dgvDetainedLicenses.Columns[5].Width = 160;

                dgvDetainedLicenses.Columns[6].Width = 90;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 330;

                dgvDetainedLicenses.Columns[8].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[8].Width = 150;

            }

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
  
            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    FilterColumn = "Is Released";
                    break;
                case "National No.":
                    FilterColumn ="NationalNo";
                    break;
                case "Full Name":
                    FilterColumn ="FullName";
                    break;
                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;
                default:
                    FilterColumn = "None";
                    break;

                        

            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                dgvDetainedLicenses.DataSource = _allDetainedLicense;

                _allDetainedLicense.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }

            if(FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
            
                _allDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
                

            
            else
            
                _allDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
                
            
            lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();




        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Enabled = (cbFilterBy.Text != "None");
            cbIsReleased.Visible = false;

            if(cbFilterBy.Text == "Is Released")
            {
                txtFilterValue.Enabled = false;
                cbIsReleased.Visible = true;
                cbIsReleased.SelectedIndex = 0;
                cbIsReleased.Focus();
            }

            else
            {

                if (cbFilterBy.Text == "None")
                {
                    
                    txtFilterValue.Enabled = false;
                   
                }else
                {
                    txtFilterValue.Enabled = true;
                    txtFilterValue.Focus();
                    txtFilterValue.Text = "";
                }
               
            }
                  

        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")

                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));

        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                _allDetainedLicense.DefaultView.RowFilter = "";
            else
                _allDetainedLicense.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
