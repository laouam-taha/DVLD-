using DVLD_Buisness;
using DVLD_Project.Global_Classe;
using DVLD_Project.Local_Licenses;
using System;
using System.Windows.Forms;
using static DVLD_Buisness.clsLicense;

namespace DVLD_Project.Applications.Replace_Lost_Or_Damaged_License
{
    public partial class frmReplaceLostOrDamagedLicense : Form
    {
        int _LicenseID;
        clsLicense _License;
        decimal _ApplicationFees = 0;
        public frmReplaceLostOrDamagedLicense()
        {
            InitializeComponent();

        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement For Lost License";
            _ApplicationFees = clsApplicationTypes.Find((int)clsLicense.enIssueReason.LostReplacement).Fees;
            lblApplicationFees.Text = _ApplicationFees.ToString();
        }

        private enIssueReason _GetIssueReason()
        {
            //this will decide which reason to issue a replacement for

            if (rbDamageLicense.Checked)

                return enIssueReason.DamagedReplacement;
            else
                return enIssueReason.LostReplacement;
        }

        private void frmReplaceLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsLicense.enIssueReason.DamagedReplacement).Fees.ToString();
        }

        private void ctrDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;

            if (_LicenseID == -1)
            {
                return;
            }

            _License = clsLicense.Find(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show("License not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validation 1: Is license active?
            if (!_License.IsActive)
            {
                MessageBox.Show("Selected License is not Active, choose an active license.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                llShowLicenseHistory.Enabled = true;
                llShowLicenseInfo.Enabled = true;
                return;
            }

            btnIssueReplacement.Enabled = true;
            ctrDriverLicenseInfoWithFilter1.LoadLicenseInfo(_LicenseID);
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblOldLicenseID.Text = _LicenseID.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbDamageLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitle.Text = "Replacement For Damaged License";
            _ApplicationFees = clsApplicationTypes.Find((int)clsLicense.enIssueReason.DamagedReplacement).Fees;
            lblApplicationFees.Text = _ApplicationFees.ToString();
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

        private void btnIssueReplacement_Click(object sender, EventArgs e)
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

            clsLicense NewLicense = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Replace(_GetIssueReason(), _License.CreatedByUserID);
            _License = NewLicense;

            if (NewLicense != null)
            {
                MessageBox.Show("License Renewed Successfully with ID=" + NewLicense.LicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblRreplacedLicenseID.Text = NewLicense.LicenseID.ToString();
                lblApplicationID.Text = NewLicense.ApplicationID.ToString();

                btnIssueReplacement.Enabled = false;
                ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;

            }
            else
            {
                MessageBox.Show("Error: Data Is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
