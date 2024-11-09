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
using System.IO;
using MyDVLD.People;
using MyDVLD.Properties;



namespace MyDVLD.People.Control
{
    public partial class ctrlPersonCard : UserControl
    {
       private ClsPerson _Person;
        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public ClsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = ClsPerson.Find(PersonID);

            if(_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("Sorry No Person With ID [" + PersonID.ToString() + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
                   
            }


            _FillPersonInfo();


           
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = ClsPerson.Find(NationalNo);

            if(_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("Sorry No Person With NationalNo [" + NationalNo + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillPersonInfo();

        }


        



        private void _FillPersonInfo()
        {
            _PersonID = _Person.PersonID;
            lbPersonID.Text = _Person.PersonID.ToString();
            lbPersonName.Text = _Person.FullName;
            lbNatinonalNo.Text = _Person.NationalNo;
            lbPhone.Text = _Person.Phone;
            lbDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lbEmail.Text = _Person.Email;
            lbAddress.Text = _Person.Address;
            lbGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lbCountry.Text = ClsCountry.Find(_Person.NationalityCountryID).CountryName;
            _LoadPersonImage();

        }
        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
                pbPersonImage.Image = Properties.Resources.Female_512;
            else
                pbPersonImage.Image = Properties.Resources.Male_512;

            string ImagePath = _Person.ImagePath;
            if ( ImagePath!= "")
            {
                if (File.Exists(ImagePath))
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Sorry We Couldnot Find ImagePath (" + ImagePath + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lbPersonID.Text = "[????]";
            lbNatinonalNo.Text = "[????]";
            lbPersonName.Text = "[????]";
            lbGendor.Image = Resources.Man_32;
            lbGendor.Text = "[????]";
            lbEmail.Text = "[????]";
            lbPhone.Text = "[????]";
            lbDateOfBirth.Text = "[????]";
            lbCountry.Text = "[????]";
            lbAddress.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;

        }
        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void lblinkEditPeron_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }

        private void lbAddress_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
