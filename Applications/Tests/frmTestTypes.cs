using DVLD_Buisness;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Applications.TestType
{
    public partial class frmTestTypes : Form
    {

        public frmTestTypes()
        {
            InitializeComponent();
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTestTypes_Load(object sender, EventArgs e)
        {
            dgvAllTestTypes.DataSource = clsTestTypes.GetAllTestTypes();
            dgvAllTestTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lblRecords.Text = dgvAllTestTypes.RowCount.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestID = (int)dgvAllTestTypes.CurrentRow.Cells["TestTypeID"].Value;

            frmUpdateTestType testTypes = new frmUpdateTestType((clsTestTypes.enTestType)TestID);
            testTypes.ShowDialog();
            dgvAllTestTypes.DataSource = clsTestTypes.GetAllTestTypes();

        }
    }
}
