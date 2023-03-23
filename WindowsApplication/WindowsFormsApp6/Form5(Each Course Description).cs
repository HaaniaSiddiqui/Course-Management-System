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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();

            int x = 0;
            Int32.TryParse(Form3.CourseID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            string query = "select * from Courses where CourseID=@id";
            DataTable ds = c.Select(query);
            // c.cmd.Parameters.AddWithValue("@course", );
            string course = ds.Rows[0]["CourseName"].ToString();

            textBox9.Text = ds.Rows[0]["CourseName"].ToString();


            textBox2.Text = ds.Rows[0]["FeesInDollars"].ToString() + "$";


            textBox5.Text = ds.Rows[0]["CourseStarts"].ToString();


            textBox6.Text = ds.Rows[0]["Language"].ToString();

            textBox7.Text = ds.Rows[0]["Level"].ToString();

            textBox8.Text = ds.Rows[0]["NumberOfStudentsEnrolled"].ToString();

            richTextBox1.Text = ds.Rows[0]["C_Description"].ToString();

            if ( ds.Rows[0]["C_Disabled"].ToString() == "0")
            {
                button4.Enabled = false;
            }
            int yo = 0;
            Int32.TryParse(Form1.ID, out yo);
            c.cmd.Parameters.AddWithValue("@s_id", yo);
            string queryv = "select * From Student_Enrolls_in_Courses Where CourseID=@id and StudentID = @s_id";
            DataTable dolo = c.Select(queryv);
            
            if (dolo.Rows.Count != 0)
            {
                button4.Enabled = false;
            }
                //if (ds.Rows[0]["EndsOn"] > DateTime.Now("yyyy-MM-dd hh:mm:ss.fff"))
                //{
                //    button4.Enabled = false;
                //}
                //DateTime.Now("yyyy-MM-dd hh:mm:ss.fff"))

            string query1 = "select * from InstructorAccount where InstructorID=(select InstructorID from Courses where CourseName='" + course + "')";
            DataTable dss = c.Select(query1);
            textBox3.Text = dss.Rows[0]["I_FirstName"].ToString() + " " + dss.Rows[0]["I_LastName"].ToString(); //InstructorName
            
            textBox4.Text = dss.Rows[0]["Qualification"].ToString();

            string query2 = "Select UniversityName From University Where UniversityID = " + dss.Rows[0]["UniversityID"];
            DataTable dss2 = c.Select(query2);
            textBox1.Text = dss2.Rows[0]["UniversityName"].ToString();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm = new Form3();
            fm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = 0;
            DBconnectioncs c = new DBconnectioncs();
            Int32.TryParse(Form3.CourseID, out x);
            c.cmd.Parameters.AddWithValue("@c_id", x);
            //Console.WriteLine(x);

            int d = 0;
            Int32.TryParse(Form1.ID, out d);
            c.cmd.Parameters.AddWithValue("@s_id", d);


            //string query3 = "select * from Project where CourseID= @c_id";
            //DataTable ds3 = c.Select(query3);
            //string q = ds3.Rows[0]["ProjectID"].ToString();
            //Int32.TryParse(q, out x);
            //c.cmd.Parameters.AddWithValue("@p_id", x);

            Console.WriteLine("@c_id");
            string query1 = "select * from Courses where CourseID= " + x;
            DataTable dss = c.Select(query1);
            dataGridView1.DataSource = dss;
            int f = 0;
            Int32.TryParse(dss.Rows[0]["Free"].ToString(), out f);
            //c.cmd.Parameters.AddWithValue("@free", d);
            Console.WriteLine(f);

            if (dss.Rows.Count != 0)
            {
                if ( f == 1)
                {
                    MessageBox.Show("You have been enrolled");
                    c.Inserts("SET IDENTITY_INSERT Student_Enrolls_In_Courses OFF Insert Into [Student_Enrolls_In_Courses] ( ProjectID, CourseID, StudentID, CertificateID, RatingsByStudent,DateOfEnrollment, ProjectCompleted, VerifiedByInstructor, PaymentID) Values (NULL, @c_id, @s_id, NULL, NULL, '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', '" + 0 + "' , '" + 0 + "', NULL) SET IDENTITY_INSERT [Student_Enrolls_In_Courses] OFF");
                    button4.Enabled = false;
                    string query = "Select NumberOfStudentsEnrolled From Courses Where CourseID = @c_id";
                    string a = c.Check(query);
                    int result;
                    Int32.TryParse(a, out result);
                    int final = result + 1;
                    c.cmd.Parameters.AddWithValue("@final", final); //new value of studentsenrolled
                    c.Inserts("Update Courses SET NumberOfStudentsEnrolled = @final Where CourseID = @c_id ");


                }
                else
                {
                    this.Hide();
                    Form7 fm = new Form7();
                    fm.Show();

                }
            }




        }

        
    }
}



//dataGridView1.DataSource = dss;
//DataView custDV = dss.DefaultView;