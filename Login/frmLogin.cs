using DVLD_Buisness;
using DVLD_Project.Global_Classe;
using Microsoft.Win32;
using System;
using System.Windows.Forms;


namespace DVLD_Project.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public static clsUsers _User;


        static string UsernameValueName = "Username";
        static string PasswordValueName = "Password";

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUsername.Text = UserName;
                txtPassword.Text = Password;
                cbRemember.Checked = true;
            }
            else
                cbRemember.Checked = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {



        }

        public static void LoadUserInfoToWindowsRegistry(string Username, string Password)
        {
            string RegistrySubKey = @"Software\DVLD Project";
            try
            {
                if (string.IsNullOrEmpty(Username))
                {
                    Registry.CurrentUser.DeleteSubKey(RegistrySubKey, false);
                }


                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistrySubKey))
                {
                    key.SetValue(UsernameValueName, Username, RegistryValueKind.String);
                    key.SetValue(PasswordValueName, Password, RegistryValueKind.String);

                    // key.SetValue(PasswordValueName, Convert.ToBase64String(encrypted), RegistryValueKind.String);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            _User = clsUsers.FindByUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());

            if (_User == null)
            {
                txtUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_User.IsActive)
            {
                txtUsername.Focus();
                MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbRemember.Checked)
                clsGlobal.RememberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            else
                clsGlobal.RememberUsernameAndPassword("", "");

            clsGlobal.CurrentUser = _User;
            this.Hide();
            frmMain frm = new frmMain(this);
            frm.ShowDialog();


        }

        private void cbRemember_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
