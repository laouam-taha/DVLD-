using DVLD_Buisness;
using DVLD_Project.Global_Classe;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Users
{
    public partial class frmUserInfo : Form
    {
        public frmUserInfo(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        int _UserID;
        

        private void frmShowDetails_Load(object sender, EventArgs e)
        {
            ctrUserCard1.LoadUserInfo(_UserID);
        }

        private void ctrPersonInfo1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
