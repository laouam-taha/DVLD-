using DVLD_Buisness;
using DVLD_Project.PeopleCtr;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Controls
{
    public partial class ctrPersonInfo : UserControl
    {
        private clsPerson _Person;
        private int _PersonID = -1;



        public bool IsValid
        {
            get { return _Person != null; }
        }

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }
        public ctrPersonInfo()
        {
            InitializeComponent();
        }


        public void LoadPersonInfo(int ID)
        {
            _Person = clsPerson.Find(ID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + ID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llEditPersonInfo.Visible = false;
                return;
            }
            llEditPersonInfo.Visible = true;

            FillPersonInfo();

        }

        public void FillPersonInfo()
        {
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
            llEditPersonInfo.Visible = true;
            lblNationalNo.Text = _Person.NationalNo.ToString();
            lblEmail.Text = _Person.Email.ToString();
            if (_Person.Gendor == 0)
                lblGendor.Text = "Male";
            else
                lblGendor.Text = "Female";
            lblAdress.Text = _Person.Address.ToString();
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblPhone.Text = _Person.Phone.ToString();
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;

            if (!string.IsNullOrEmpty(_Person.ImagePath) && System.IO.File.Exists(_Person.ImagePath))
            {
                pictureBox1.Load(_Person.ImagePath);
            }
            else
            {
                if (_Person.Gendor == 0)
                    pictureBox1.Image = Properties.Resources.ManPic;
                else
                    pictureBox1.Image = Properties.Resources.WoPic;
            }
        }



        public void ResetPersonInfo()
        {
            _Person = null;
            lblPersonID.Text = "[????]";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblEmail.Text = "[????]";
            lblGendor.Text = "[????]";
            lblAdress.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblPhone.Text = "[????]";
            lblCountry.Text = "[????]";
            llEditPersonInfo.Visible = false;
            pictureBox1.Image = null;
        }


        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with NationalNo = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                llEditPersonInfo.Visible = false;

                return;
            }

            FillPersonInfo();
            llEditPersonInfo.Visible = true;

        }

        private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);

            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }

        private void ctrPersonInfo_Load(object sender, EventArgs e)
        {
            llEditPersonInfo.Visible = false;
            if (this.DesignMode)
            {
                return; // Ḥbs ila kan f l-designer bach mat-dirch exception
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblNationalNo_Click(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblPersonID_Click(object sender, EventArgs e)
        {

        }

        private void lblGendor_Click(object sender, EventArgs e)
        {

        }

        private void lblAdress_Click(object sender, EventArgs e)
        {

        }

        private void lblDateOfBirth_Click(object sender, EventArgs e)
        {

        }

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void lblCountry_Click(object sender, EventArgs e)
        {

        }
    }
}
