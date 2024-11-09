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
using MyDVLD.People.Control;
using System.Runtime.Remoting.Messaging;
using MyDVLD.Global_Classes;

namespace MyDVLD.Users
{
    public partial class frmAddUpdateUser : Form
    {


        public enum EnMode { AddNew = 0, Update = 1 };
        private EnMode Mode = EnMode.AddNew;
        ClsUser _User;
        private int _UserID = -1;

        public frmAddUpdateUser()
        {
            InitializeComponent();

            Mode = EnMode.AddNew;

        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            Mode = EnMode.Update;
        }


        private void _LoadData()
        {
            _User = ClsUser.FindByUserID(_UserID);
           //ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {

                MessageBox.Show("No User with ID [" + _UserID + "]", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();


                return;

            }
            ctrlPersonCardWithFilter1.FilterEnabled = true;

            lbUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text =  _User.Password;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
            rdIsActive.Checked = _User.IsActive;

            //if (_User.IsActive)
            //    rdIsActive.Checked = true;
            //else
            //    rdIsActive.Checked = false;

        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefultValues();
            if (Mode == EnMode.Update)

                _LoadData();

        }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void _ResetDefultValues()
        {
            if (Mode == EnMode.AddNew)
            {
                _User = new ClsUser();
                tpLoginInfo.Enabled = false; ;
                lbTitle.Text = "Add New User";
                
            }

            else

            {
                lbTitle.Text = "Update User";
            }

            txtPassword.Text = "";
            txtUserName.Text = "";
            txtConfirmPassword.Text = "";
            rdIsActive.Checked = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password =ClsGlobal.ComputeHash( txtPassword.Text.Trim());

            _User.IsActive = rdIsActive.Checked;

            if (_User.Save())
            {
                MessageBox.Show("Data Saved Successfuly", "Success", MessageBoxButtons.OK);
                lbUserID.Text = _User.UserID.ToString();
                Mode = EnMode.Update;

            }
            else

                MessageBox.Show(" Fialed In Saved", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (Mode == EnMode.Update)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;

                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                return;
            }
            if(ctrlPersonCardWithFilter1.PersonID !=-1)
            {
                if(ClsUser.isUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person Is Selected already, Choose Anthor One .", "Select antoher", MessageBoxButtons.OK);
                }
                else
                {
                    ctrlPersonCardWithFilter1.FilterEnabled = false;

                    tpLoginInfo.Enabled = true;
                    btnSave.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];


                }
            }else
            {
                MessageBox.Show("Select Person", "Select");
            }
        }

        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            
            
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;

                errorProvider1.SetError(txtUserName, " User Name Is rquired");

                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, null);

            };

            if(Mode == EnMode.AddNew)
            {
                if(ClsUser.isUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;

                errorProvider1.SetError(txtUserName, " User Name is already Exsit");
                    
                }
                else
                {
                errorProvider1.SetError(txtUserName, null);

                };

                
            }
            else
                if (_User.UserName != txtUserName.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, " User Name is should be the same");
                return;

            }
            else
            {
                errorProvider1.SetError(txtUserName, null);

            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "the filed is required !");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);

            }

            if( txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Is Not Matched with Password");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void ctrlPersonCardWithFilter1_Load_1(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            int selectPErsonID = obj;

            if (selectPErsonID != -1)
            {
                if (ClsUser.isUserExistForPersonID(selectPErsonID))
                {
                    MessageBox.Show("Selected Person Is Selected already, Choose Anthor One .", "Select antoher", MessageBoxButtons.OK);
                }
                else
                {
                    ctrlPersonCardWithFilter1.FilterEnabled = false;

                    tpLoginInfo.Enabled = true;
                  


                }
            }
            else
            {
                MessageBox.Show("Select Person", "Select");
            }

        }
    }
}
