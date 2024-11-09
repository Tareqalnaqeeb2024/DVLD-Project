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
using MyDVLD.Global_Classes;

namespace MyDVLD.Test.TestTypes
{
    public partial class frmUpdateTestType : Form
    {
        public ClsTestTypes _TestType;
        public ClsTestTypes.enTestTypes _TestTypeID = ClsTestTypes.enTestTypes.visionTest;
        public frmUpdateTestType(ClsTestTypes.enTestTypes TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadData(_TestTypeID);

        }

        private void _LoadData(ClsTestTypes.enTestTypes TestID)
        {
            _TestType = ClsTestTypes.Find(TestID);

            if(_TestType == null)
            {
                MessageBox.Show("No TestType with ID [" + TestID + "");
                return;
            }
            txtTestTypeTitle.Text = _TestType.TestTitle;
            txtDescription.Text = _TestType.TestDes;
            txtTestTypeFees.Text = _TestType.TestFees.ToString();
            lbTestTypeID.Text = _TestType.ID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _TestType.TestTitle = txtTestTypeTitle.Text.Trim();
            _TestType.TestDes = txtDescription.Text.Trim();
            _TestType.TestFees = Convert.ToSingle(txtTestTypeFees.Text.Trim());


            if (_TestType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtTestTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeTitle, null);
            };
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "Description cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            };
        }

        private void txtTestTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTestTypeFees, null);

            };


            if (!ClsValidating.IsNumber(txtTestTypeFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtTestTypeFees, null);
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
