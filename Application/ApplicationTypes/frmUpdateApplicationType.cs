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

namespace MyDVLD.Application.ApplicationTypes
{
    public partial class frmUpdateApplicationType : Form
    {
        public enum EnMode { AddNew = 0, Update = 1 };
        EnMode Mode;
        public ClsApplicationTypes _ApplicationTypes;
        public int _AppID;
        public frmUpdateApplicationType( int AppID)
        {
            InitializeComponent();
            _AppID = AppID;
             Mode = EnMode.Update;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           // _ApplicationTypes = new ClsApplicationTypes();

            _ApplicationTypes.Title = txtAppTypeTitle.Text;
            _ApplicationTypes.Fees = Convert.ToSingle( txtAppTypeFees.Text);

            if(_ApplicationTypes.Save())
            {
                MessageBox.Show("Updated Data Successfuly");
                lbAppTypeID.Text = _ApplicationTypes.ID.ToString();

            }else
            {
                MessageBox.Show("Failed In Update Data");
            }
        }

        private void _LoadData( int ID)

        {
            _ApplicationTypes = ClsApplicationTypes.Find(ID);

            if(_ApplicationTypes == null)
            {
                MessageBox.Show("No AppType with [" + ID + "]", "Error", MessageBoxButtons.OK);
                _ApplicationTypes = new ClsApplicationTypes();
                return;
            }

            lbAppTypeID.Text = _AppID.ToString();
            txtAppTypeTitle.Text = _ApplicationTypes.Title;
            txtAppTypeFees.Text = _ApplicationTypes.Fees.ToString();
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData(_AppID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
