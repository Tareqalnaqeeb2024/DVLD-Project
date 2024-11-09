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
namespace MyDVLD.People
{
    public partial class frmListPeople : Form
    {
        public static DataTable _dtAllPeople = ClsPerson.GetAllPeople();
        public DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName",
             "SecondName", "ThirdName", "LastName", "DateOfBirth", "GendorCaption", "Phone", "Address", "Email");
        public frmListPeople()
        {
            InitializeComponent();
        }

        private void dgvPeople_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           
        }

       
        private void frmListPeople_Load(object sender, EventArgs e)
        {

            dgvPeople.DataSource = _dtPeople;
            lbRecord.Text = dgvPeople.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;

            if(dgvPeople.Rows.Count >0)
            {

                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 80;

                dgvPeople.Columns[1].HeaderText = "National No";
                dgvPeople.Columns[1].Width = 80;

                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 100;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 120;

                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 120;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 120;

                dgvPeople.Columns[6].HeaderText = "Date OF Birth";
                dgvPeople.Columns[6].Width = 140;

                dgvPeople.Columns[7].HeaderText = " Gendor";
                dgvPeople.Columns[7].Width = 100;

                dgvPeople.Columns[8].HeaderText = "Phone";
                dgvPeople.Columns[8].Width = 100;

                dgvPeople.Columns[9].HeaderText = "Address";
                dgvPeople.Columns[9].Width = 130;

                dgvPeople.Columns[10].HeaderText = "Email";
                dgvPeople.Columns[10].Width = 150;

            }
          
        }

        private void txtFilterTextValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch(cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No":
                    FilterColumn = "NationalNo";
                    break;
                case "First Name":
                    FilterColumn = "FirstName";
                    break;
                case "Second Name":
                    FilterColumn = "SecondName";
                    break;
                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;
                case "Last Name":
                    FilterColumn = "LastName";
                    break;
              
                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Address":
                    FilterColumn = "Address";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;
                
            }

            if(FilterColumn == "None" || txtFilterTextValue.Text.Trim() =="")
            {
                _dtPeople.DefaultView.RowFilter = "";
                
                lbRecord.Text = dgvPeople.Rows.Count.ToString();
                return;

            }
            if (FilterColumn == "PersonID")
                 _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}",FilterColumn,txtFilterTextValue.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] Like '{1}%'", FilterColumn, txtFilterTextValue.Text.Trim());
            lbRecord.Text = dgvPeople.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterTextValue.Visible = cbFilterBy.Text != "None";

            if(txtFilterTextValue.Visible)
            {
                //txtFilterTextValue.Text = "";
                txtFilterTextValue.Focus();
            }
        }

        private void showDetalisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListPeople_Load(null,null);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();


            frmListPeople_Load(null, null);

        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();

            frmListPeople_Load(null, null);
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
    
            frmListPeople_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            ClsPerson person = ClsPerson.Find(PersonID);
            if(MessageBox.Show("Are you sure to delete Person with ID["+PersonID+"]","Delete",MessageBoxButtons.OKCancel ) == DialogResult.OK)
            {
                
                if (ClsPerson.DeletePerson(PersonID))
                {
                    
                    MessageBox.Show("Person Deleted Successfuly", "Success", MessageBoxButtons.OK);
                    frmListPeople_Load(null, null);
                    return;
                }
                else
                {
                    MessageBox.Show("No Person with ID[" + PersonID + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void txtFilterTextValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
