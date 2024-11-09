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
using System.IO;

namespace MyDVLD.Application.ApplicationTypes
{
    public partial class frmListApplicationTypes : Form
    {
        public DataTable _AllApplicationsTypes;
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void _RefershAllApplicationTypes()
        {
           
            

            lbRecord.Text = dgvAppTypes.Rows.Count.ToString();
        }
        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
           // _RefershAllApplicationTypes();

            _AllApplicationsTypes = ClsApplicationTypes.GetAllApplicationTypes();
            dgvAppTypes.DataSource = _AllApplicationsTypes;
            lbRecord.Text = dgvAppTypes.Rows.Count.ToString();

            dgvAppTypes.Columns[0].HeaderText = "ID";
            dgvAppTypes.Columns[0].Width = 110;

            dgvAppTypes.Columns[1].HeaderText = "Title";
            dgvAppTypes.Columns[1].Width = 400;

            dgvAppTypes.Columns[2].HeaderText = "Fees";
            dgvAppTypes.Columns[2].Width = 100;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType frm = new frmUpdateApplicationType((int)dgvAppTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefershAllApplicationTypes();
        }
    }
}
