using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();

            int x = 0;
            Int32.TryParse(Form3.CourseID, out x);
            c.cmd.Parameters.AddWithValue("@c_id", x);

            int d = 0;
            Int32.TryParse(Form1.ID, out d);
            c.cmd.Parameters.AddWithValue("@s_id", d);


            //string query3 = "select * from Project where CourseID= @c_id";
            //DataTable ds3 = c.Select(query3);
            //string q = ds3.Rows[0]["ProjectID"].ToString();
            //Int32.TryParse(q, out x);
            //c.cmd.Parameters.AddWithValue("@p_id", x);

            c.cmd.Parameters.AddWithValue("@amount", textBox4.Text);
            c.cmd.Parameters.AddWithValue("@typeofpayment", textBox2.Text);
            c.Inserts("SET IDENTITY_INSERT Payment OFF Insert Into Payment ( Amount, TypeOfPayment) Values (@amount, @typeofpayment) SET IDENTITY_INSERT Payment OFF");

            string payid = c.Check("select max(PaymentID) From Payment");
            int inte = 0;
            if (payid != "")
            {
                
                Int32.TryParse(payid, out inte);
                c.cmd.Parameters.AddWithValue("@pay_id", inte + 1);
            }
            else
            {
                c.cmd.Parameters.AddWithValue("@pay_id", 1);
            }

            c.Inserts("SET IDENTITY_INSERT Student_Enrolls_In_Courses OFF Insert Into [Student_Enrolls_In_Courses] ( ProjectID, CourseID, StudentID, CertificateID, RatingsByStudent,DateOfEnrollment, ProjectCompleted, VerifiedByInstructor, PaymentID) Values (NULL, @c_id, @s_id, NULL, NULL, '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', '" + 0 + "' , '" + 0 + "',  @pay_id ) SET IDENTITY_INSERT[Student_Enrolls_In_Courses] OFF");



            MessageBox.Show("Paid");
            MessageBox.Show("You have been enrolled");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm = new Form3();
            fm.Show();
        }
    }
}