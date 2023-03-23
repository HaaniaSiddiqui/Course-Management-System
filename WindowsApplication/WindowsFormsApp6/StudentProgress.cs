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
    public partial class StudentProgress : Form
    {
        public StudentProgress()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();

            int x = 0;
            Int32.TryParse(StudentDetails.EnrollmentID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            string query = "select * from Student_has_Assignments where EnrollmentID=(select EnrollmentID from Student_Enrolls_In_Courses where StudentID=@id)";
            DataTable ds = c.Select(query);
            dataGridView1.DataSource = ds;
        }

        private void StudentProgress_Load(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            int x = 0;
            Int32.TryParse(StudentDetails.StudentID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            MessageBox.Show(StudentDetails.StudentID);
            string query = "select * from StudentAccount where StudentID=@id";
            DataTable ds = c.Select(query);
            textBox2.Text = ds.Rows[0]["S_FirstName"].ToString();
            textBox3.Text = ds.Rows[0]["S_LastName"].ToString();
            string query1= "select * from Student_Enrolls_In_Courses where StudentID=@id";
            string Text = "";
            DataTable dss = c.Select(query1);
            
            string query2 = "select * from Student_has_Assignments where EnrollmentID in (select EnrollmentID from Student_Enrolls_In_Courses where StudentID=@id)";
            DataTable dsss = c.Select(query2);
            dataGridView1.DataSource = dsss;

            if (dss.Rows[0]["ProjectCompleted"].ToString() == "1")
            {
                Text = "Project is Completed";

            }
            else
            {
                Text = "Project is Not Completed";
            }
            textBox1.Text = Text;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                DBconnectioncs c = new DBconnectioncs();
                int x = 0;
                Int32.TryParse(StudentDetails.StudentID, out x);
                c.cmd.Parameters.AddWithValue("@id", x);
                string query = "Update Student_Enrolls_In_Courses set  VerifiedByInstructor=1 where StudentID=@id";
                c.Inserts(query);


            }
            else
            {
                DBconnectioncs c = new DBconnectioncs();
                int x = 0;
                Int32.TryParse(StudentDetails.StudentID, out x);
                c.cmd.Parameters.AddWithValue("@id", x);
                string query = "Update Student_Enrolls_In_Courses set  VerifiedByInstructor=0 where StudentID=@id";
                c.Inserts(query);
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                DBconnectioncs c = new DBconnectioncs();
                int x = 0;
                Int32.TryParse(StudentDetails.StudentID, out x);
                c.cmd.Parameters.AddWithValue("@id", x);
                string query = "Update Student_Enrolls_In_Courses set  ProjectCompleted=1 where StudentID=@id";
                c.Inserts(query);


            }
            else
            {
                DBconnectioncs c = new DBconnectioncs();
                int x = 0;
                Int32.TryParse(StudentDetails.StudentID, out x);
                c.cmd.Parameters.AddWithValue("@id", x);
                string query = "Update Student_Enrolls_In_Courses set  ProjectCompleted=0 where StudentID=@id";
                c.Inserts(query);
            }
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                button1.Enabled = true;
            }
        }
    }
}
