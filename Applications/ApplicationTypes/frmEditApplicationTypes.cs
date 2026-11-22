using DVLD_Buisness;
using DVLD_Project.Global_Classe;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Applications.ApplicationTypes
{
    public partial class frmEditApplicationTypes : Form
    {
        int _ApplicationTypeID = -1;
        clsApplicationTypes _ApplicationType;
        public frmEditApplicationTypes()
        {
            InitializeComponent();
        }
        public frmEditApplicationTypes(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            lblID.Text = _ApplicationTypeID.ToString();

            _ApplicationType = clsApplicationTypes.Find(_ApplicationTypeID);
            if (_ApplicationType != null)
            {
                txtTitle.Text = _ApplicationType.Title.ToString();
                txtFees.Text = _ApplicationType.Fees.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Please check the fields in red, some data is invalid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // حبس وماكملش عملية الحفظ!
            }

            _ApplicationType.Title = txtTitle.Text;
            _ApplicationType.Fees = Convert.ToDecimal(txtFees.Text);


            if (_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Data Is Not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtFees_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // السماح بنقطة عشرية واحدة فقط (.)
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtTitle_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
            ;

        }

        private void txtFees_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
            ;

            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
            ;
        }
    }
}
