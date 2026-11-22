using DVLD_Buisness;
using DVLD_Project.People;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Controls
{
    public partial class ctrLocalDrivingLicenseApplicationInfo : UserControl
    {



        clsApplications _Application;
        clsLocalDrivingLicenseApplications _LocalDrivingLicense;
        private int _LicenseID;
        private int _LocalDrivingLicenseApplicationID = -1;


        public ctrLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }



        void _FillLocalDrivingLicenseApplicationInfo()
        {
            //_LicenseID = _LocalDrivingLicense.GetActiveLicenseID();
            _LicenseID = 2;
            llShowLicenseInfo.Visible = (_LicenseID != -1);

            lblLocalDrivingLicenseAppID.Text = _LocalDrivingLicense.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedFor.Text = clsLicenseClasses.Find(_LocalDrivingLicense.LicenseClassID).ClassName;
            //lblAppliedFor.Text = "teesst";

            lblPassTest.Text = _LocalDrivingLicense.GetPassedTestCount().ToString() + "/3";
            ctrApplicationBasicInfo1.LoadApplicationInfo(_LocalDrivingLicense.ApplicationID);

        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LocalDrivingLicenseApplicationID = -1;
            ctrApplicationBasicInfo1.ResetApplicationInfo();
            lblLocalDrivingLicenseAppID.Text = "[????]";
            lblAppliedFor.Text = "[????]";


        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public void LoadApplicationInfoByLocalDrivingAppID(int LocalDrivingLicenseApplicationID)
        {
            _LocalDrivingLicense = clsLocalDrivingLicenseApplications.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (_LocalDrivingLicense == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }

        public void LoadApplicationInfoByApplicationID(int ApplicationID)
        {
            _LocalDrivingLicense = clsLocalDrivingLicenseApplications.FindByApplicationID(ApplicationID);
            if (_LocalDrivingLicense == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();


                MessageBox.Show("No Application with ApplicationID = " + _LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillLocalDrivingLicenseApplicationInfo();
        }


        private void ctrVisionTestAppointments_Load(object sender, EventArgs e)
        {


        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo showPersonInfo = new frmShowPersonInfo(_Application.ApplicantPersonID);
            showPersonInfo.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmShowLicenseInfo frm = new frmShowLicenseInfo(_LocalDrivingLicenseApplication.GetActiveLicenseID());
            //frm.ShowDialog();

        }
    }
}
