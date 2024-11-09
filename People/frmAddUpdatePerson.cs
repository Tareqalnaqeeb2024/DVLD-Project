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

namespace MyDVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {
        public  delegate void DataBackEventHandler(object sender, int PersonID);

        public DataBackEventHandler DataBack;


        public enum EnMode { AddNew =0 , Update=1};
        public enum EnGendor { Male =0 ,Female =1};
       
        EnMode Mode = EnMode.AddNew;
        public int _PersonID =-1;
        public ClsPerson _Person;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
           
            Mode = EnMode.AddNew;

        }

        public frmAddUpdatePerson(int PersonID )
        {
            InitializeComponent();
            Mode = EnMode.Update;
            _PersonID = PersonID;
        

        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            
               
              _ResetDefultValues(); 
            if(Mode == EnMode.Update)
            _LoadDataInfo();

        }


        private void _ResetDefultValues()
        {

            _FillAllCountriesToComboBox();


            if(Mode == EnMode.AddNew)
            {
                lbTitle.Text = "Add New Person";

                _Person = new ClsPerson();
            }else
            {
                lbTitle.Text = "Update Person";
            }

            if (rbMale.Checked)
                pbPersonImage.Image = Properties.Resources.Male_512;
            else
                pbPersonImage.Image = Properties.Resources.Female_512;

            // Issue Max Date for dtpDataOfBirth
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            // Issue Min Date for dtpDateOfBirth

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            cbCountry.SelectedIndex = cbCountry.FindString("Yemen");



            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void _FillAllCountriesToComboBox()
        {
            DataTable dtCountries = ClsCountry.GetAllCountries();

            foreach(DataRow row in dtCountries.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }
        private void _LoadDataInfo()
        {

            _Person = ClsPerson.Find(_PersonID);

            if (_Person == null)
            {

                MessageBox.Show("No Person ");
                this.Close();
                return;

            }
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;  
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtPhone.Text = _Person.Phone;
            txtNationalNo.Text = _Person.NationalNo;
            txtEmail.Text = _Person.Phone;
            txtAddress.Text = _Person.Address.Trim();
            lbPersonID.Text = _Person.PersonID.ToString();

            if (_Person.DateOfBirth != null)

                dtpDateOfBirth.Value = _Person.DateOfBirth;
            else
                dtpDateOfBirth.Value = DateTime.Now;


            pbPersonImage.ImageLocation = _Person.ImagePath;

            if (_Person.Gendor == 0)

                rbMale.Checked =true;

            else
                rbFemale.Checked = true;

            cbCountry.Text = ClsCountry.Find(_Person.NationalityCountryID).CountryName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int NationalityCountryID = ClsCountry.Find(cbCountry.Text).ID;
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.NationalityCountryID = NationalityCountryID;
            _Person.DateOfBirth = dtpDateOfBirth.Value;



            if (rbMale.Checked)
                _Person.Gendor = (short)EnGendor.Male;
            else
                _Person.Gendor = (short)  EnGendor.Female ;


            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                MessageBox.Show("Saved Data Successfuly");
                lbTitle.Text = "Update Person";
                lbPersonID.Text = _Person.PersonID.ToString();
                Mode = EnMode.Update;

                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show("Error In Saved");
            }
        }


        
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            TextBox Temp = (TextBox)sender;

             if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(Temp, "this field is required!");


            }
             else
            {
                e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;
            
                if(!ClsValidating.ValidateEmail(txtEmail.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEmail, "Format is Incorrect");
                }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Images Files |*jpg;*.jpeg;*.png";

            openFileDialog1.RestoreDirectory = true;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonImage.Load(openFileDialog1.FileName);
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "this field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);

            }

            if( txtNationalNo.Text.Trim() != _Person.NationalNo && ClsPerson.isPersonExist(txtNationalNo.Text.Trim()) )
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "this NationalNo is Used!");
            }else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if(pbPersonImage.ImageLocation == null)
            {
                pbPersonImage.Image = Properties.Resources.Male_512;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
            {
                pbPersonImage.Image = Properties.Resources.Female_512;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
