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
    public partial class CourseDetails : Form
    {
        public CourseDetails()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Form9 fm = new Form9();
            fm.Show();

        }

        private void CourseDetails_Load(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();

            int x = 0;
            Int32.TryParse(Form9.CourseID, out x);
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

           


            string query1 = "select * from InstructorAccount where InstructorID=(select InstructorID from Courses where CourseName='" + course + "')";
            DataTable dss = c.Select(query1);
            textBox3.Text = dss.Rows[0]["I_FirstName"].ToString() + " " + dss.Rows[0]["I_LastName"].ToString(); //InstructorName

            textBox4.Text = dss.Rows[0]["Qualification"].ToString();

            string query2 = "Select UniversityName From University Where UniversityID = " + dss.Rows[0]["UniversityID"];
            DataTable dss2 = c.Select(query2);
            textBox1.Text = dss2.Rows[0]["UniversityName"].ToString();




        }

    }
}

