using System;
using System.Windows.Forms;

namespace DVLD_Project.People
{
    public partial class frmShowPersonInfo : Form
    {
       
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            ctrPersonInfo1.LoadPersonInfo(PersonID);

        }

        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();
            ctrPersonInfo1.LoadPersonInfo(NationalNo);

        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrPersonInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
