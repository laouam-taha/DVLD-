using DVLD_Project.Applications;
using DVLD_Project.Applications.Driving_Licences_Service;
using DVLD_Project.Applications.International_License;
using DVLD_Project.Applications.Manage_Applications;
using DVLD_Project.Applications.Release_Detain_License;
using DVLD_Project.Applications.Renew_License;
using DVLD_Project.Applications.Replace_Lost_Or_Damaged_License;
using DVLD_Project.Applications.TestType;
using DVLD_Project.Drivers;
using DVLD_Project.Global_Classe;
using DVLD_Project.Local_Licenses.Detain_License;
using DVLD_Project.Login;
using DVLD_Project.People;
using DVLD_Project.Users;
using System;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmMain : Form
    {

        frmLogin _frmLogin;


        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;

        }








        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople people = new frmListPeople();
            people.ShowDialog();
            //form that show people

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers manageUsers = new frmManageUsers();

            manageUsers.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmUserInfo personInfo = new frmUserInfo(clsGlobal.CurrentUser.UserID);

            //_User = clsUsers.Find(_UserID);

            //personInfo.LoadPersonInfo(_Person.PersonID);
            //personInfo.LoadUserInfo(_User);


            personInfo.ShowDialog();




        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID);

            changePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void accountSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDriver listDriver = new frmListDriver();
            listDriver.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationsTypes ApplicationsTypes = new frmApplicationsTypes();
            ApplicationsTypes.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestTypes TestTypes = new frmTestTypes();
            TestTypes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddLocalDrivingLicense localDrivingLicense = new frmAddLocalDrivingLicense();
            localDrivingLicense.ShowDialog();
        }

        private void localLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplication ShowLocalDrivingLicenseApplication = new frmListLocalDrivingLicenseApplication();
            ShowLocalDrivingLicenseApplication.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplication frmListLocalDrivingLicenseApplication = new frmListLocalDrivingLicenseApplication();
            frmListLocalDrivingLicenseApplication.ShowDialog();
        }

        private void renewLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicense renewLicense = new frmRenewLicense();
            renewLicense.ShowDialog();
        }

        private void replacementForLostOrDamgedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicense frmReplaceLostOrDamagedLicense = new frmReplaceLostOrDamagedLicense();
            frmReplaceLostOrDamagedLicense.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication detainLicenseApplication = new frmDetainLicenseApplication();
            detainLicenseApplication.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicense listDetainedLicense = new frmListDetainedLicense();
            listDetainedLicense.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicense listInternationalLicense = new frmListInternationalLicense();
            listInternationalLicense.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense frm = new frmNewInternationalLicense();
            frm.ShowDialog();

        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }
    }
}
