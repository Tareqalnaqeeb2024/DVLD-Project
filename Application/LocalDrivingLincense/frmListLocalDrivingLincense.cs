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
using MyDVLD.Application;
using MyDVLD.Test;
using MyDVLD.Licenses;
using MyDVLD.Licenses.Local_License;



namespace MyDVLD.Application.LocalDrivingLincense
{
    public partial class frmListLocalDrivingLincense : Form
    {
        public static DataTable _dtAllApplication;
        public frmListLocalDrivingLincense()
        {
            InitializeComponent();
        }


        private void frmListLocalDrivingLincense_Load(object sender, EventArgs e)
        {
            _dtAllApplication = ClsLocalDrivingLincese.GetAllLocalDrivingLicenseApplication();
            dgvApplications.DataSource = _dtAllApplication;
            lbRecord.Text = dgvApplications.Rows.Count.ToString();

            if (_dtAllApplication.Rows.Count > 0)
            {


                dgvApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvApplications.Columns[0].Width = 120;

                dgvApplications.Columns[1].HeaderText = "Driving Classes";
                dgvApplications.Columns[1].Width = 220;

                dgvApplications.Columns[2].HeaderText = "National No";
                dgvApplications.Columns[2].Width = 80;

                dgvApplications.Columns[3].HeaderText = "Full Name";
                dgvApplications.Columns[3].Width = 220;

                dgvApplications.Columns[4].HeaderText = "Application Date";
                dgvApplications.Columns[4].Width = 150;

                dgvApplications.Columns[5].HeaderText = "Passed Test";
                dgvApplications.Columns[5].Width = 130;

                dgvApplications.Columns[6].HeaderText = "Status";
                dgvApplications.Columns[6].Width = 130;
            }
            cbFilterBy.SelectedIndex = 0;


        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)

        {

            frmAddUpdateLocalDrivingLincense frm = new frmAddUpdateLocalDrivingLincense((int)dgvApplications.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            frmListLocalDrivingLincense_Load(null, null);

        }

        private void addNewLocalDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLincense frm = new frmAddUpdateLocalDrivingLincense();

            frm.ShowDialog();
            frmListLocalDrivingLincense_Load(null, null);
        }

        private void localDrivingLicenseCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseInfo frm = new frmLocalDrivingLicenseInfo((int)dgvApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListLocalDrivingLincense_Load(null, null);
        }

        private void txtFilterTextValue_TextChanged(object sender, EventArgs e)
        {
            string FilterBy = "";

            switch (cbFilterBy.Text)

            {
                case "L.D.L.AppID":
                    FilterBy = "LocalDrivingLicenseApplicationID";
                    break;
                case "FullName":
                    FilterBy = "FullName";
                    break;

                case "National No":
                    FilterBy = "NationalNo";
                    break;
                case "Status":
                    FilterBy = "Status";
                    break;
                default:
                    FilterBy = "None";
                    break;
            }

            if (txtFilterTextValue.Text.Trim() == "" || FilterBy == "None")
            {

                _dtAllApplication.DefaultView.RowFilter = "";
                lbRecord.Text = dgvApplications.Rows.Count.ToString();
                return;
            }

            if (FilterBy == "LocalDrivingLicenseApplicationID")
            {
                _dtAllApplication.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterBy, txtFilterTextValue.Text.Trim());
                lbRecord.Text = dgvApplications.Rows.Count.ToString();


            }
            else

            {
                _dtAllApplication.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterBy, txtFilterTextValue.Text.Trim());
                // lbRecord.Text = dgvApplications.Rows.Count.ToString();
                lbRecord.Text = _dtAllApplication.Rows.Count.ToString();

            }




        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterTextValue.Enabled = (cbFilterBy.Text != "None");

            txtFilterTextValue.Text = "";
            txtFilterTextValue.Focus();
        }
        private void _ScheduleTest(ClsTestTypes.enTestTypes TestTypes)
        {
            int LocalLicenseApplication = (int)dgvApplications.CurrentRow.Cells[0].Value;

            frmListTestAppointment frm = new frmListTestAppointment(LocalLicenseApplication, TestTypes);
            frm.ShowDialog();
            frmListLocalDrivingLincense_Load(null, null);
        }

        private void visoinTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(ClsTestTypes.enTestTypes.visionTest);
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(ClsTestTypes.enTestTypes.WrittenTest);
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(ClsTestTypes.enTestTypes.streetTest);
        }

        private void issueLicenseFroeFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseApplication = (int)dgvApplications.CurrentRow.Cells[0].Value;


            frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime(LocalLicenseApplication);
            frm.ShowDialog();
            frmListLocalDrivingLincense_Load(null, null);
        }

        private void showDrivingLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseApplication = (int)dgvApplications.CurrentRow.Cells[0].Value;

            int LicenseID = ClsLocalDrivingLincese.FindByLocalDrivingLicenseApplicationID(LocalLicenseApplication).GetActiveLicenseID();

            if (LicenseID == -1)
            {
                MessageBox.Show("Error : No License ID with " + LicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
        }

        private void txtFilterTextValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLincense frm = new frmAddUpdateLocalDrivingLincense();
            frm.ShowDialog();

            frmListLocalDrivingLincense_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int LocalLicenseApplicationID = (int)dgvApplications.CurrentRow.Cells[0].Value;


            ClsLocalDrivingLincese localDrivingLincese = ClsLocalDrivingLincese.FindByLocalDrivingLicenseApplicationID(LocalLicenseApplicationID);

            if (localDrivingLincese != null)
            {
                if (MessageBox.Show("Are you Sure To Delete this LocalApplication with ID[" + LocalLicenseApplicationID + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {


                    if (localDrivingLincese.Delete())
                    {
                        MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmListLocalDrivingLincense_Load(null, null);

                    }
                    else
                    {
                        MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int LocalLicenseApplicationID = (int)dgvApplications.CurrentRow.Cells[0].Value;

            ClsLocalDrivingLincese localDrivingLincese = ClsLocalDrivingLincese.FindByLocalDrivingLicenseApplicationID(LocalLicenseApplicationID);

            int TotalPassedTest = (int)dgvApplications.CurrentRow.Cells[5].Value;
            bool LicenseExists = localDrivingLincese.IsLicenseIssued();


            issueLicenseFroeFirstTimeToolStripMenuItem.Enabled = TotalPassedTest == 3 && !LicenseExists;
            showDrivingLicenseInfoToolStripMenuItem.Enabled = LicenseExists;
            editToolStripMenuItem.Enabled = !LicenseExists && localDrivingLincese.ApplicationStatus == ClsApplications.enApplicationStatus.New;
            scheduleTestToolStripMenuItem.Enabled = !LicenseExists;
            cancelApplicationtoolStripMenuItem.Enabled = localDrivingLincese.ApplicationStatus == ClsApplications.enApplicationStatus.New;
            deletetoolStripMenuItem1.Enabled = localDrivingLincese.ApplicationStatus == ClsApplications.enApplicationStatus.New;

            bool PassedVisionTest = localDrivingLincese.DoesPassedTestType(ClsTestTypes.enTestTypes.visionTest);
            bool PassedWrittenTest = localDrivingLincese.DoesPassedTestType(ClsTestTypes.enTestTypes.WrittenTest);
            bool PassedStreetTest = localDrivingLincese.DoesPassedTestType(ClsTestTypes.enTestTypes.streetTest);

            scheduleTestToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (localDrivingLincese.ApplicationStatus == ClsApplications.enApplicationStatus.New);

            if (scheduleTestToolStripMenuItem.Enabled)
            {
                visoinTestToolStripMenuItem.Enabled = !PassedVisionTest;
                writtenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;
                streetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
            }




        }

        private void cancelApplicationtoolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgvApplications.CurrentRow.Cells[0].Value;

            ClsLocalDrivingLincese LocalDrivingLicenseApplication =
                ClsLocalDrivingLincese.FindByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmListLocalDrivingLincense_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
