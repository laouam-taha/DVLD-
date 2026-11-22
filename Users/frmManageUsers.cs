using DVLD_Buisness;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Project.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private static DataTable _dtAllUsers;

        private void _RefreshAllUsers()
        {
            dgvAllUsers.DataSource = clsUsers.GetManageUsers();
            lblRecords.Text = dgvAllUsers.RowCount.ToString();
            dgvAllUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        public int PersonID
        {
            get
            {
                return (int)dgvAllUsers.CurrentRow.Cells["PersonID"].Value;
            }
        }
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUsers.GetAllUsers();
            dgvAllUsers.DataSource = _dtAllUsers;
            cbFilter.SelectedIndex = 0;
            lblRecords.Text = dgvAllUsers.Rows.Count.ToString();
            if (dgvAllUsers.Rows.Count > 0)
            {
                dgvAllUsers.Columns[0].HeaderText = "User ID";
                dgvAllUsers.Columns[0].Width = 110;

                dgvAllUsers.Columns[1].HeaderText = "Person ID";
                dgvAllUsers.Columns[1].Width = 120;

                dgvAllUsers.Columns[2].HeaderText = "Full Name";
                dgvAllUsers.Columns[2].Width = 350;

                dgvAllUsers.Columns[3].HeaderText = "UserName";
                dgvAllUsers.Columns[3].Width = 120;

                dgvAllUsers.Columns[4].HeaderText = "Is Active";
                dgvAllUsers.Columns[4].Width = 120;
            }
        }





        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "Is Active")
            {
                txtFilter.Visible = false;
                cbActive.Visible = true;
                cbActive.Focus();
                cbActive.SelectedIndex = 0;
            }
            else
            {
                txtFilter.Visible = (cbFilter.Text != "None");
                cbActive.Visible = false;



                txtFilter.Text = "";
                txtFilter.Focus();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {




        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsActive";
            string FilterValue = cbActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecords.Text = _dtAllUsers.Rows.Count.ToString();

        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilter.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvAllUsers.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lblRecords.Text = _dtAllUsers.Rows.Count.ToString();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 3)
            {
                // يسمح غير بالأرقام و Backspace
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser FRM = new frmAddUpdateUser();
            FRM.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmAddUpdateUser frmAddUpdate = new frmAddUpdateUser((int)dgvAllUsers.CurrentRow.Cells[0].Value);

            frmAddUpdate.ShowDialog();
            frmManageUsers_Load(null, null);
            //_RefreshAllUsers();

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {


            frmUserInfo personInfo = new frmUserInfo((int)dgvAllUsers.CurrentRow.Cells[0].Value);

            personInfo.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvAllUsers.CurrentRow.Cells["UserID"].Value;

            int PersonID = Convert.ToInt32(
            dgvAllUsers.CurrentRow.Cells["PersonID"].Value);

            if (clsUsers.IsUserUsed(PersonID))
            {
                MessageBox.Show("Cannot Delete This User Because of Referential Integrity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUsers.DeleteUser(UserID))
                {
                    MessageBox.Show("User Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmManageUsers_Load(null, null);
                }
                else
                {
                    MessageBox.Show("User Not Deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            lblRecords.Text = dgvAllUsers.RowCount.ToString();



        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser FRM = new frmAddUpdateUser();

            FRM.ShowDialog();
            frmManageUsers_Load(null, null);
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvAllUsers.CurrentRow.Cells["PersonID"].Value;

            clsUsers User = clsUsers.FindByPersonID(ID);
            frmChangePassword frmChangePassword = new frmChangePassword(User.UserID);


            frmChangePassword.ShowDialog();
        }
    }
}
