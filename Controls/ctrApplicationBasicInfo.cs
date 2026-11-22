using DVLD_Buisness;
using DVLD_Project.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Project.Controls
{
    public partial class ctrApplicationBasicInfo : UserControl
    {
        
        public ctrApplicationBasicInfo()
        {
            InitializeComponent();
        }

        private int _ApplicationID = -1;
        private clsApplications _Application;

        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplications.FindBaseApplication(ApplicationID);

            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ID = " + ApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillApplicationInfo();
        }

        public void FillApplicationInfo()
        {
            _ApplicationID = _Application.ApplicationID;
            lblApplicationID.Text = _Application.ApplicationID.ToString();
            lblStatusDate.Text = _Application.ApplicationStatus.ToString();
            lblFees.Text = _Application.PaidFees.ToString();
            lblTypes.Text = clsApplicationTypes.Find(_Application.ApplicationTypeID).Title;
            lblApplicant.Text = _Application.PersonInfo.FullName;
            lblDate.Text = _Application.ApplicationDate.ToShortDateString();
            lblStatusDate.Text = _Application.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = clsUsers.Find(_Application.CreatedByUserID).UserName;
        }

        public void ResetApplicationInfo()
        {
            _ApplicationID = -1;
            lblApplicationID.Text = "[?????]";
            lblStatusDate.Text = "[?????]";
            lblFees.Text = "[?????]";
            lblTypes.Text = "[?????]";
            lblApplicant.Text = "[?????]";
            lblDate.Text = "[?????]";
            lblStatusDate.Text = "[?????]";
            lblCreatedBy.Text = "[?????]";
        }


        private void ctrApplicationBasicInfo_Load(object sender, EventArgs e)
        {

        }

        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frmShowPersonInfo = new frmShowPersonInfo(_Application.ApplicantPersonID);
            frmShowPersonInfo.ShowDialog();
            LoadApplicationInfo(_ApplicationID);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
