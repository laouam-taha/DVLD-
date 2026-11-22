using System;
using System.Windows.Forms;

namespace DVLD_Project.Local_Licenses
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        int _PersonID;
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            ctrFilterPerson1.gbFilter.Enabled = false;
            ctrFilterPerson1.LoadPersonInfo(_PersonID);
            ctrDriverLicenses1.LoadInfoByPersonID(_PersonID);
        }
    }
}
