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
    public partial class ctrlUserCard : UserControl
    {
        public ClsUser _User;
        public int _UserID;

        public ctrlUserCard()
        {
            InitializeComponent();
        }


        public void LoadUserInfo(int UserID)
        {

            _User = ClsUser.FindByUserID(UserID);

            if(_User == null)
            {
                MessageBox.Show("No User With ID [" + UserID.ToString() + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }


        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lbUserID.Text = _User.UserID.ToString();
            lbUserName.Text = _User.UserName;

            if (_User.IsActive)
                lbIsActive.Text = "Yes";
            else
                lbIsActive.Text = "No";
        }
        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
