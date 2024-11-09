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

namespace MyDVLD.Users
{
    public partial class frmListUsers : Form
    {
        public static DataTable _dtUsers;
        public frmListUsers()
        {
            InitializeComponent();
        }


        private void frmListUsers_Load(object sender, EventArgs e)
        {

            _dtUsers = ClsUser.GetAllUsers();
            dgvUsers.DataSource = _dtUsers;
            cbFilterBy.SelectedIndex = 0;
            lbRecord.Text = dgvUsers.Rows.Count.ToString();

            if (dgvUsers.Rows.Count > 0)
            {
                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 100;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 100;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 200;

                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 120;

                dgvUsers.Columns[4].HeaderText = "IsActive";
                dgvUsers.Columns[4].Width = 110;

            }
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterTextValue.Visible = false;

                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
                
            }
            else
            {
                txtFilterTextValue.Visible = (cbFilterBy.Text != "None");
                cbIsActive.Visible = false;

                if(cbFilterBy.Text == "None")
                {
                    txtFilterTextValue.Enabled = false;
                }
                else
                {
                    txtFilterTextValue.Enabled = true;
                    txtFilterTextValue.Focus();
                    txtFilterTextValue.Text = "";
                }


            }

           
        }

        private void txtFilterTextValue_TextChanged(object sender, EventArgs e)
        {
            string FilterCloumn = "";

            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterCloumn = "UserID";
                    break;
                case "Person ID":
                    FilterCloumn = "PersonID";
                    break;
                case "Full Name":
                    FilterCloumn = "FullName";
                    break;
                case "User Name":
                    FilterCloumn = "UserName";
                    break;
                case "Is Active":
                    FilterCloumn = "IsActive";
                    break;
                default:
                    FilterCloumn = "None";

                    break;
            }

          

            if (txtFilterTextValue.Text.Trim() == "" || FilterCloumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = "";
                lbRecord.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            if (FilterCloumn == "UserID" || FilterCloumn == "PersonID")
            
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterCloumn, txtFilterTextValue.Text.Trim());
            
            else
               _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterCloumn, txtFilterTextValue.Text.Trim());
            
            lbRecord.Text = dgvUsers.Rows.Count.ToString();
        }

        private void lToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListUsers_Load(null,null);
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

            frmListUsers_Load(null, null);

        }

        private void txtFilterTextValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Person ID" || cbFilterBy.Text=="User ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) ;
            }

            
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";

            string FilterText = cbIsActive.Text;

            switch (FilterText)

            {
                case "All":
                    break;
                case "Active":
                    FilterText = "1";
                    break;
                case "Not Active":
                   FilterText = "0";
                    break;
                default:
                    break;
            }

            if (FilterText == "All")
                _dtUsers.DefaultView.RowFilter = "";
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}",  FilterColumn, FilterText);
            lbRecord.Text = dgvUsers.Rows.Count.ToString();




        }

        private void chamgePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Active Now","See You Letter" ,MessageBoxButtons.OK);

        }

        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Active Now", "See You Letter", MessageBoxButtons.OK);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are You Sure To Delete This User " + UserID.ToString(), "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                if (ClsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User Deleted Successfuly", "Success", MessageBoxButtons.OK);
                    frmListUsers_Load(null, null);
                    return;
                }

            }
            else
                MessageBox.Show(" Falied To Delete User with UserID " + UserID.ToString(), "Falied ", MessageBoxButtons.OK);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
