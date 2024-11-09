using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyDVLD.People;
using MyDVLD.Users;
using MyDVLD.People.Control;
using MyDVLD.Application.LocalDrivingLincense;
using MyDVLD.Drivers;
using MyDVLD.Application.ApplicationTypes;
using MyDVLD.Test.TestTypes;
using MyDVLD.Application.InternationalDrivingLicenses;
using MyDVLD.Application.Renew_Local_License;
using MyDVLD.Application.ReplaceLostOrDamgedLicense;
using MyDVLD.Login;
using MyDVLD.DetainedLicense;
using MyDVLD.Application.ReleasedDetainedLicense;
using MyDVLD.Global_Classes;
using MyDVLD.Test;



namespace MyDVLD
{
    public partial class MainForm : Form
    {
        frmLogin _frmLogin;

        public MainForm(  frmLogin frm )
        {
            InitializeComponent();
            _frmLogin =frm;
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(ClsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void newDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriverList frm = new frmDriverList();
            frm.ShowDialog();
        }

        private void manageApplicationsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
                frm.ShowDialog();
        }

        private void mangeInternationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void renewLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicense frm = new frmRenewLocalLicense();
            frm.ShowDialog();   
        }

        private void replaceLoseOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDemagedLicense frm = new frmReplaceLostOrDemagedLicense();
            frm.ShowDialog();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLincense frm = new frmAddUpdateLocalDrivingLincense();
            frm.ShowDialog();
        }

        private void mangeApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLincense frm = new frmListLocalDrivingLincense();
            frm.ShowDialog();

        }

        private void IntrenationalLicensetoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmListInternationalDrivingLicense frm = new frmListInternationalDrivingLicense();
            frm.ShowDialog();
        }

        private void intrnationalDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewIntrnationalLicenseApplication frm = new frmAddNewIntrnationalLicenseApplication();
            frm.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();

        }

        private void detainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releasedDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleasedDetainedLicense frm = new frmReleasedDetainedLicense();
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void cahngePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(ClsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleasedDetainedLicense frm = new frmReleasedDetainedLicense();
            frm.ShowDialog();
        }

        private void ratekeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLincense frm = new frmListLocalDrivingLincense();
            frm.ShowDialog();

        }
    }
}
