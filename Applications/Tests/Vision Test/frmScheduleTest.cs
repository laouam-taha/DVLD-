using DVLD_Buisness;
using System;
using System.Windows.Forms;

namespace DVLD_Project.Applications.TestType.Vision_Test
{
    public partial class frmScheduleTest : Form
    {

        int _LocalDrivingLicenseApplicationID = -1;
        clsTestTypes.enTestType _TestTypeID = clsTestTypes.enTestType.VisionTest;
        int _Appointment=-1;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType TestTypeID,int Appointment=-1)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
            _LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            _Appointment=Appointment;
        }

        
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrScheduleTest1.TestTypeID = _TestTypeID;
            ctrScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID,_Appointment);

           

        }
     
        private void ctrScheduleTest1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();


        }

        private void frmScheduleTest_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrScheduleTest1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
