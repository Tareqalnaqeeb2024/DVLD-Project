using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDVLD.Application.LocalDrivingLincense
{
    public partial class frmLocalDrivingLicenseInfo : Form
    {
        public int _ApplicationID;
        public frmLocalDrivingLicenseInfo(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
        }

        private void ctrlLocalDrivingLincenseCard1_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLincenseCard1.LoadLocalLicenseApplicationInfo(_ApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
