using DVLD_Buisness;
using DVLD_Project.Global_Classe;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Applications.TestType.Vision_Test
{
    public partial class frmTakeTest : Form
    {
        int _TestAppointementID = -1;
        private clsTestTypes.enTestType _TestTypeID;

        private int _TestID = -1;
        private clsTest _Test;



        public frmTakeTest(int TestAppointementID, clsTestTypes.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestAppointementID = TestAppointementID;
            _TestTypeID = TestTypeID;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrScheduledTest1.TestTypeID = _TestTypeID;

            ctrScheduledTest1.LoadInfo(_TestAppointementID);

            if (ctrScheduledTest1.TestAppointmentID == -1)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            int _TestID = ctrScheduledTest1.TestID;
            if (_TestID != -1)
            {
                _Test = clsTest.Find(_TestID);

                if (_Test.TestResult)
                    rdPass.Checked = true;
                else
                    rdFail.Checked = true;
                txtNotes.Text = _Test.Notes;

                lblUserMessage.Visible = true;
                rdFail.Enabled = false;
                rdPass.Enabled = false;
            }

            else
                _Test = new clsTest();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to save? After that you cannot change the Pass/Fail results after you save?.",
                      "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No
             )
            {
                return;
            }

            _Test.TestAppointmentID = _TestAppointementID;
            _Test.TestResult = rdPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_Test.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void ctrScheduledTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
