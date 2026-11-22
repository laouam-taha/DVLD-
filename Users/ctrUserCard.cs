using DVLD_Buisness;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Users
{
    public partial class ctrUserCard : UserControl
    {
        public ctrUserCard()
        {
            InitializeComponent();
            if (this.DesignMode)
            {
                return; // Ḥbs ila kan f l-designer bach mat-dirch error
            }
        }

        clsUsers _User;
        private void _ResetPersonInfo()
        {

            ctrPersonInfo1.ResetPersonInfo();
            lblUserID.Text = "[???]";
            lblUsername.Text = "[???]";
            lblIsActive.Text = "[???]";
        }

        public void LoadUserInfo(int UserID)
        {
            _User = clsUsers.Find(UserID);
            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        private void _FillUserInfo()
        {

            ctrPersonInfo1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.UserName.ToString();

            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";

        }


        private void ctrUserCard_Load(object sender, EventArgs e)
        {


        }
    }
}
