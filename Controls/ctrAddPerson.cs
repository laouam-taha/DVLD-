using DVLD_Buisness;
using DVLD_Project.Properties;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DVLD_Project.Controls
{
    public partial class ctrAddEditPerson : UserControl
    {
        bool IsValid = true;
        string Destination = "";

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _PersonID;
        clsPerson _Person;

        public delegate void PersonIDBackEventHandler(object sender, int PersonID);
        public event PersonIDBackEventHandler PersonIDBack;

        public ctrAddEditPerson()
        {
            InitializeComponent();


        }

        public void LoadPerson(int PersonID)
        {
            _PersonID = PersonID;

            if (PersonID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LoadData();
        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }

        }

        private void _LoadData()
        {
            _FillCountriesInComoboBox();
            dtpDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);


            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();//user will enter info
                return;
            }

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID);
                return;
            }

            lblMode.Text = "Edit Person ID = " + _Person.PersonID;

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No Person with ID = " + _PersonID);
                return;
            }

            lblPersonID.Text = _Person.PersonID.ToString();
            tbFirstName.Text = _Person.FirstName;
            tbSecond.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLast.Text = _Person.LastName;
            tbNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            tbAdress.Text = _Person.Address;



            if (!string.IsNullOrEmpty(_Person.ImagePath) && System.IO.File.Exists(_Person.ImagePath))
            {
                pbPersonImage.Load(_Person.ImagePath);
            }
            else
            {
                if (rdMale.Checked)
                    pbPersonImage.Image = Properties.Resources.ManPic;
                else
                    pbPersonImage.Image = Properties.Resources.WoPic;
            }



            if (_Person.Gendor == 0)
                rdMale.Checked = true;
            else
                rdFemale.Checked = true;
            tbPhone.Text = _Person.Phone;
            tbEmail.Text = _Person.Email;




            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Person.NationalityCountryID).CountryName);

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ctrAddPerson_Load(object sender, EventArgs e)
        {
            _LoadData();
            pbPersonImage.Image = Resources.ManPic;
        }


        private bool ValidatePerson()
        {
            bool IsValid = true;

            // First Name
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                errorProvider1.SetError(tbFirstName, "First Name is required.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(tbFirstName, "");
            }

            // Second Name
            if (string.IsNullOrWhiteSpace(tbSecond.Text))
            {
                errorProvider1.SetError(tbSecond, "Second Name is required.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(tbSecond, "");
            }

            // Third Name
            if (string.IsNullOrWhiteSpace(tbThirdName.Text))
            {
                errorProvider1.SetError(tbThirdName, "Third Name is required.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(tbThirdName, "");
            }

            // Last Name
            if (string.IsNullOrWhiteSpace(tbLast.Text))
            {
                errorProvider1.SetError(tbLast, "Last Name is required.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(tbLast, "");
            }

            // National No
            if (string.IsNullOrWhiteSpace(tbNationalNo.Text))
            {
                errorProvider1.SetError(tbNationalNo, "National No is required.");
                IsValid = false;
            }
            else if (clsPerson.IsNationalNoExist(tbNationalNo.Text, _PersonID))
            {
                errorProvider1.SetError(tbNationalNo, "National No already exists.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(tbNationalNo, "");
            }

            // Phone
            if (string.IsNullOrWhiteSpace(tbPhone.Text))
            {
                errorProvider1.SetError(tbPhone, "Phone Number is required.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(tbPhone, "");
            }

            // Address
            if (string.IsNullOrWhiteSpace(tbAdress.Text))
            {
                errorProvider1.SetError(tbAdress, "Address is required.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(tbAdress, "");
            }

            // Email
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                errorProvider1.SetError(tbEmail, "");
                IsValid = true;
            }
            else if (!tbEmail.Text.Contains("@") || !tbEmail.Text.Contains("."))
            {
                errorProvider1.SetError(tbEmail, "Invalid email format.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(tbEmail, "");
            }

            // Country
            if (cbCountry.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbCountry, "Please select a country.");
                IsValid = false;
            }
            else
            {
                errorProvider1.SetError(cbCountry, "");
            }

            return IsValid;
        }

        public void SetPersonImage()
        {

        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                //MessageBox.Show("Selected Image is:" + selectedFilePath);

                pbPersonImage.Load(selectedFilePath);//path to picture
                llRemove.Visible = true;
                // ...


                if (!string.IsNullOrEmpty(_Person.ImagePath))
                {
                    if (File.Exists(_Person.ImagePath))
                    {
                        // Release old image from PictureBox
                        if (pbPersonImage.Image != null)
                        {
                            pbPersonImage.Image.Dispose();
                            pbPersonImage.Image = null;
                        }

                        // Delete old file
                        File.Delete(_Person.ImagePath);
                    }
                }

                // 2. Generate new GUID
                string ImageName = Guid.NewGuid().ToString();
                string ImageFolder = @"C:\Users\hp\Downloads\DVLD-People-Image";
                string Extension = Path.GetExtension(selectedFilePath);

                Destination = Path.Combine(
                    ImageFolder,
                    ImageName + Extension
                );

                // 3. Copy new image
                File.Copy(selectedFilePath, Destination);

                // 4. Save new path
                _Person.ImagePath = Destination;

                // 5. Show new image
                pbPersonImage.Load(Destination);

                llRemove.Visible = true;
            }


        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (pbPersonImage.Image != null)
            {
                pbPersonImage.Image.Dispose();
                pbPersonImage.Image = null;
            }

            _Person.ImagePath = "";
            llRemove.Visible = false;

            //explain this part


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int PersonID = _Person.PersonID;
            PersonIDBack?.Invoke(this,PersonID);
            this.FindForm().Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidatePerson())
            {
                MessageBox.Show("Same Fields Are Empty");
                return;
            }
            int CountryID = clsCountry.Find(cbCountry.Text).CountryID;

            _Person.FirstName = tbFirstName.Text;
            _Person.SecondName = tbSecond.Text;
            _Person.ThirdName = tbThirdName.Text;
            _Person.LastName = tbLast.Text;
            _Person.NationalNo = tbNationalNo.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Phone = tbPhone.Text;

            _Person.ImagePath = Destination;

            // _Person.ImagePath = pbPersonImage;
            if (rdMale.Checked)
                _Person.Gendor = 0;
            else
                _Person.Gendor = 1;
            _Person.Address = tbAdress.Text;
            _Person.Email = tbEmail.Text;
            _Person.NationalityCountryID = CountryID;

            if (_Person.Save())
                MessageBox.Show("Data Saved Successfully.");

            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            _Mode = enMode.Update;
            lblMode.Text = "Edit Person ID = " + _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();

        }

        private void tbFirstName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                errorProvider1.SetError(tbFirstName, "First Name is required.");
            }
            else
            {
                errorProvider1.SetError(tbFirstName, "");

            }
        }

        private void tbSecond_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSecond.Text))
            {
                errorProvider1.SetError(tbSecond, "Second Name is required.");
            }
            else
            {
                errorProvider1.SetError(tbSecond, "");

            }

        }

        private void tbThirdName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbThirdName.Text))
            {
                errorProvider1.SetError(tbThirdName, "Third Name is required.");
            }
            else
            {
                errorProvider1.SetError(tbThirdName, "");

            }
        }

        private void tbLast_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLast.Text))
            {
                errorProvider1.SetError(tbLast, "Last Name is required.");
            }
            else
            {
                errorProvider1.SetError(tbLast, "");

            }
        }

        private void tbNationalNo_TextChanged(object sender, EventArgs e)
        {
            if (clsPerson.IsNationalNoExist(tbNationalNo.Text, _PersonID))
            {
                errorProvider1.SetError(tbNationalNo, "National No Already Exist.");
            }
            else if (string.IsNullOrWhiteSpace(tbNationalNo.Text))
            {
                errorProvider1.SetError(tbNationalNo, "National No is required.");
            }
            else
            {
                errorProvider1.SetError(tbNationalNo, "");
            }


        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            if (!long.TryParse(tbPhone.Text, out _))
            {
                errorProvider1.SetError(tbPhone, "Invalid phone number.");
                IsValid = false;
            }

            else
            {
                errorProvider1.SetError(tbPhone, "");

            }
        }

        private void tbAdress_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAdress.Text))
            {
                errorProvider1.SetError(tbAdress, "Phone Number is required.");
            }
            else
            {
                errorProvider1.SetError(tbAdress, "");

            }
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                IsValid = true;
                errorProvider1.SetError(tbEmail, "");
            }
            else if (!tbEmail.Text.Contains("@") ||
               !tbEmail.Text.Contains(".") ||
                tbEmail.Text.StartsWith("@") ||
                 tbEmail.Text.EndsWith("@"))
            {
                errorProvider1.SetError(tbEmail, "Invalid email format.");
                IsValid = false;
            }

            else
            {
                errorProvider1.SetError(tbEmail, "");

            }
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            pbPersonImage.Image = Resources.ManPic;
            llRemove.Visible = true;
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            pbPersonImage.Image = Resources.WoPic;
            llRemove.Visible = true;

        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbCountry, "");

        }

        private void tbFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
