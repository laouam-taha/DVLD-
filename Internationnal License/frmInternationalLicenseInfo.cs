using System;
using System.Windows.Forms;

namespace DVLD_Project.Internationnal_License
{
    public partial class frmInternationalLicenseInfo : Form
    {
        int _InternationnalLicenseID;
        public frmInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationnalLicenseID = InternationalLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrInternationalLicense1_Load(object sender, EventArgs e)
        {

        }

        private void frmInternationalLicense_Load(object sender, EventArgs e)
        {
            ctrInternationalLicense1.LoadInfo(_InternationnalLicenseID);
        }
    }
}
