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
    public partial class Form9 : Form
    {
        public static string CourseID = "";
        public Form9()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstructorCourses fm = new InstructorCourses();
            fm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();

            DataTable ds = c.Select("Select * from Categories");
            comboBox1.DataSource = ds;
            comboBox1.ValueMember = "CategoryID";
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.Text = "";
            //string query= "SET IDENTITY_INSERT Student_Enrolls_In_Courses OFF Insert Into [Student_Enrolls_In_Courses] ( ProjectID, CourseID, StudentID, CertificateID, RatingsByStudent,DateOfEnrollment, ProjectCompleted, VerifiedByInstructor, PaymentID) Values (@p_id, @c_id, @s_id, NULL, NULL, '{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff")}', ' 0 ' , '0',  @pay_id ) SET IDENTITY_INSERT[Student_Enrolls_In_Courses] OFF"
            //c.Inserts(query);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddCourse fm = new AddCourse();
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 fm = new Form12();
            fm.Show();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //listBox1.DataSource = null;
            //listBox1.Items.Clear();
            //DBconnectioncs c = new DBconnectioncs();

            //c.cmd.Parameters.AddWithValue("@category", comboBox1.Text);
            //MessageBox.Show(comboBox1.Text);
            //string query = "Select co.CourseID,CourseName from (Courses co inner join Category_has_Courses cc on cc.CourseID=co.CourseID) inner join Categories ca on ca.CategoryID=cc.CategoryID where ca.CategoryName=@category";

            //DataTable ds = c.Select(query);
            //listBox1.DataSource = ds;
            //listBox1.DisplayMember = "CourseName";
            //listBox1.ValueMember = "CourseID";


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Form1 fm = new Form1();
            fm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            DBconnectioncs c = new DBconnectioncs();
            string query = ("Select * from Courses where CategoryID =" + comboBox1.SelectedValue);
            DataTable ds = c.Select(query);
            listBox1.DataSource = ds;
            listBox1.DisplayMember = "CourseName";
            listBox1.ValueMember = "CourseID";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 1)
            {
                MessageBox.Show("Select only one course at a time");

            }
            else if (listBox1.SelectedItems.Count == 1)
            {
                //string x = listBox1.SelectedItems.Text;
                //int curItem = listBox1.ValueMember;
                //string selected = listBox1.GetItemText(listBox1.SelectedValue);
                CourseID = listBox1.SelectedValue.ToString();
                //Console.WriteLine(selected);
                //int x = Int16.Parse(selected); // returns 100

                this.Hide();
                CourseDetails fm = new CourseDetails();
                fm.Show();
            }
        }
    }
}


