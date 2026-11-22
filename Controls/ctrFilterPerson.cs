using DVLD_Buisness;
using DVLD_Project.PeopleCtr;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Controls
{
    public partial class ctrFilterPerson : UserControl
    {
        public ctrFilterPerson()
        {
            InitializeComponent();
        }

        clsUsers _User;
        private int _PersonID = -1;
        private bool _ShowAddPerson = true;

        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAdd.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get
            {
                return _FilterEnable;
            }
            set
            {
                _FilterEnable = value;
                gbFilter.Visible = _FilterEnable;
            }
        }
        public int PersonID
        {
            get { return ctrPersonInfo1.PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return ctrPersonInfo1.SelectedPersonInfo; }
        }


        private void FindNow()
        {
            switch (cbFilter.Text)
            {
                case "Person ID":
                    ctrPersonInfo1.LoadPersonInfo(int.Parse(txtFilter.Text));

                    break;

                case "National No.":
                    ctrPersonInfo1.LoadPersonInfo(txtFilter.Text);
                    break;

                default:
                    break;
            }


            if (OnPersonSelected != null && FilterEnable)
                // Raise the event with a parameter
                OnPersonSelected(ctrPersonInfo1.PersonID);
        }

        public void LoadPersonInfo(int PersonID)
        {

            cbFilter.SelectedIndex = 1;
            txtFilter.Text = PersonID.ToString();
            FindNow();

        }

        private void AddUpdatePerson_PersonIDBack(object sender, int PersonID)
        {
            ctrPersonInfo1.lblName.Text = PersonID.ToString();
            txtFilter.Text = PersonID.ToString();
            ctrPersonInfo1.LoadPersonInfo(PersonID);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson addUpdatePerson = new frmAddUpdatePerson();

            addUpdatePerson.DataBack += AddUpdatePerson_PersonIDBack;

            addUpdatePerson.ShowDialog();
        }

        private void ctrFilterPerson_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 1;
            ctrPersonInfo1.llEditPersonInfo.Visible = false;
            txtFilter.Focus();

        }

        public void FilterFocus()
        {
            txtFilter.Focus();
        }
        private void txtFilter_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilter.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilter, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(txtFilter, null);
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnSearch.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
