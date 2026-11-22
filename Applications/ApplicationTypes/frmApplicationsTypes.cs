using DVLD_Buisness;
using DVLD_Project.Applications.ApplicationTypes;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Project.Applications
{
    public partial class frmApplicationsTypes : Form
    {
        DataTable _dtAllApplicationTypes;
        public frmApplicationsTypes()
        {
            InitializeComponent();
        }

        private void frmApplicationsTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();
            dgvAllApplicationTypes.DataSource = _dtAllApplicationTypes;
            lblRecords.Text = dgvAllApplicationTypes.Rows.Count.ToString();

            if (dgvAllApplicationTypes.Rows.Count > 0)
            {
                dgvAllApplicationTypes.Columns[0].HeaderText = "ID";
                dgvAllApplicationTypes.Columns[0].Width = 110;

                dgvAllApplicationTypes.Columns[1].HeaderText = "Title";
                dgvAllApplicationTypes.Columns[1].Width = 400;

                dgvAllApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvAllApplicationTypes.Columns[2].Width = 100;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmEditApplicationTypes EditApplication = new frmEditApplicationTypes((int)dgvAllApplicationTypes.CurrentRow.Cells["ApplicationTypeID"].Value);
            EditApplication.ShowDialog();
            frmApplicationsTypes_Load(null, null);  

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
