using DVLD_Buisness;
using DVLD_Project.Global_Classe;
using DVLD_Project.Local_Licenses;
using DVLD_Project.Local_Licenses.Controls;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Renew_License
{
    public partial class frmRenewLicense : Form
    {
        clsLicense _License;
        public frmRenewLicense()
        {
            InitializeComponent();


        }

        private void ctrDriverLicenseInfo1_Load(object sender, EventArgs e)
        {

        }

        private void gpApplicationInfo_Enter(object sender, EventArgs e)
        {

        }


        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsLicense.enIssueReason.Renew).Fees.ToString();

            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationDate.Text = DateTime.Now.AddYears(10).ToShortDateString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();


        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {

            if (_License == null)
            {
                MessageBox.Show("Please select a license first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Renew this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(txtNotes.Text, clsGlobal.CurrentUser.UserID);
            _License = NewLicense;

            if (NewLicense != null)
            {
                MessageBox.Show("License Renewed Successfully with ID=" + NewLicense.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
                lblApplicationID.Text = NewLicense.ApplicationID.ToString();

                btnRenewLicense.Enabled = false;
                ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
                txtNotes.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error: Data Is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ctrDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            if (SelectedLicenseID == -1)
            {
                return;
            }

            _License = clsLicense.Find(SelectedLicenseID);

            if (_License == null)
            {
                MessageBox.Show("License not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation 1: Is license active?
            if (!_License.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                llShowLicenseHistory.Enabled = true;
                llShowNewLicenseInfo.Enabled = true;
                return;
            }

            // Validation 2: Is license expired? (Standard renewal rule: license must be expired)
            if (!_License.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expired, it will expire on: " + _License.ExpirationDate.ToShortDateString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenewLicense.Enabled = false;
                llShowLicenseHistory.Enabled = true;
                llShowNewLicenseInfo.Enabled = false;
                return;
            }

           
            lblLicenseFees.Text = _License.LicenseClassIfo.ClassFees.ToString();
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsLicense.enIssueReason.Renew).Fees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            llShowLicenseHistory.Enabled = true;
            llShowNewLicenseInfo.Enabled = true;
            txtNotes.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;

            // Expiration date calculation for the new license
            lblExpirationDate.Text = DateTime.Now.AddYears(_License.LicenseClassIfo.DefaultValidityLength).ToShortDateString();

        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo licenseInfo = new frmShowLicenseInfo(_License.LicenseID);
            licenseInfo.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frmShowPerson = new frmShowPersonLicenseHistory(_License.DriverInfo.PersonInfo.PersonID);
            frmShowPerson.ShowDialog();
        }

        private void ctrDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
