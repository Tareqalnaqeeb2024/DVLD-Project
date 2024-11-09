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
using MyDVLD;
using Microsoft.Win32;

namespace MyDVLD.Login
{
    public partial class frmLogin : Form
    {
        public ClsUser _User;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\MyDVLD";

            //string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\YourSoftware";

            string UserName = "UserName";
            string ValueOfUserName = txtUserName.Text;
            string Password = "Password";
            string ValueOfPassword = txtPassword.Text;


            _User = ClsUser.FindByUsernameAndPassword( txtUserName.Text,  txtPassword.Text);

            if (_User != null)
            {

                if (chkRememberMe.Checked)
                {
                    // Store UserName ANd Password
                    ClsGlobal.RememberUserNameAndPassWord(txtUserName.Text, txtPassword.Text.Trim());
                    try
                    {
                        Registry.SetValue(KeyPath, UserName, ValueOfUserName, RegistryValueKind.String);
                        Registry.SetValue(KeyPath, Password, ValueOfPassword, RegistryValueKind.String);


                        MessageBox.Show($"your creditional Saved Successsfluy");
                      }
                    catch
                    {
                        MessageBox.Show("Erro In Save Data in Registry");
                    }

                }else
                {
                    // Store Empty UserName ANd PassWord
                    ClsGlobal.RememberUserNameAndPassWord("", "");
                }
                if (!_User.IsActive)
                {
                    MessageBox.Show("Sorry , This User In Not Active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUserName.Focus();

                    return;
                }else
                {
                    ClsGlobal.CurrentUser = _User;
                    this.Hide();
                    MainForm frm = new MainForm(this);
                    frm.ShowDialog();
                }

            }else
            {
                MessageBox.Show("Sorry , Invalid UserName/password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
            }
            

            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // string UserName = "", Password = "";

            //string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\MyDVLD";

            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\MyDVLD";

            //string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\YourSoftware";

            string UserName = "UserName";
          //  string ValueOfUserName = txtUserName.Text;
            string Password = "Password";


            try
            {
              string ValueOfUserName=   Registry.GetValue(KeyPath, UserName, null) as string;
                 string ValueOfPassword = Registry.GetValue(KeyPath, Password, null) as string;

                if (ValueOfUserName != null)
                {
                    txtUserName.Text = ValueOfUserName;
                    txtPassword.Text = ValueOfPassword;
                    chkRememberMe.Checked = true;

                }


            }catch
            {

            }



            ////if (ClsGlobal.GetStoredCredential(ref UserName, ref Password))
            ////{
            ////    txtUserName.Text = UserName;
            ////    txtPassword.Text = Password;
            ////    chkRememberMe.Checked = true;
            ////}
            //else

                chkRememberMe.Checked = false;
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
