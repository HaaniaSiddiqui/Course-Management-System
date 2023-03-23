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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();

            int x = 0;
            Int32.TryParse(InstructorCourses.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            string query = "select * from Courses where CourseID=@id";
            DataTable ds = c.Select(query);
            // c.cmd.Parameters.AddWithValue("@course", );
            string course = ds.Rows[0]["CourseName"].ToString();
            textBox2.Text = ds.Rows[0]["CourseName"].ToString();
            textBox3.Text = ds.Rows[0]["CourseStarts"].ToString();
            textBox4.Text = ds.Rows[0]["CourseEnds"].ToString();
            richTextBox1.Text = ds.Rows[0]["C_Description"].ToString();
            textBox6.Text = ds.Rows[0]["C_Disabled"].ToString();
            textBox5.Text = ds.Rows[0]["Level"].ToString();
            textBox24.Text = ds.Rows[0]["NumberOfStudentsEnrolled"].ToString();
            textBox25.Text = ds.Rows[0]["Language"].ToString();
            string query1 = "select * from InstructorAccount where InstructorID=(select InstructorID from Courses where CourseName='" + course + "')";

            DataTable dss = c.Select(query1);

           // dataGridView1.DataSource = dss;
            //DataView custDV = dss.DefaultView;
            textBox1.Text = dss.Rows[0]["I_FirstName"].ToString() + " " + dss.Rows[0]["I_LastName"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            int x = 0;
            Int32.TryParse(InstructorCourses.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            c.cmd.Parameters.AddWithValue("@coursename", textBox2.Text);
            c.cmd.Parameters.AddWithValue("@coursestarts", textBox3.Text);
            c.cmd.Parameters.AddWithValue("@courseends", textBox4.Text);
            c.cmd.Parameters.AddWithValue("@c_description", richTextBox1.Text);
            c.cmd.Parameters.AddWithValue("@c_disabled", textBox6.Text);
            c.cmd.Parameters.AddWithValue("@Level", textBox5.Text);
            c.cmd.Parameters.AddWithValue("@numberofstudents", textBox24.Text);
            c.cmd.Parameters.AddWithValue("@language", textBox25.Text);
            c.cmd.Parameters.AddWithValue("@fee", textBox21.Text);

            // c.Inserts("Update StudentAccount Set S_InstructorID  = @instructorid  Where StudentID = @id");
            c.Inserts("Update Courses Set CourseName = @coursename Where CourseID = @id");
            c.Inserts("Update Courses Set CourseStarts = @coursestarts Where CourseID = @id");
            c.Inserts("Update Courses Set CourseEnds = @courseends Where CourseID = @id");
            c.Inserts("Update Courses Set FeesInDollars= @fee Where CourseID = @id");
            c.Inserts("Update Courses Set Level  = @level Where CourseID = @id");
            c.Inserts("Update Courses Set Language  = @language Where CourseID = @id");
            c.Inserts("Update Courses Set C_Description   = @c_description Where CourseID = @id");
            c.Inserts("Update Courses Set C_Disabled  = @c_disabled Where CourseID = @id");
            c.Inserts("Update Courses Set NumberOfStudentsEnrolled  = @numberofstudents Where CourseID = @id");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentDetails fm = new StudentDetails();
            fm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form18 fm = new Form18();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            int z = 0;
            Int32.TryParse(InstructorCourses.ID, out z);
            c.cmd.Parameters.AddWithValue("@id", z);
            c.Inserts("Delete From Courses where CourseID =@id");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 fm = new Form9();
            fm.Show();
        }
    }
}