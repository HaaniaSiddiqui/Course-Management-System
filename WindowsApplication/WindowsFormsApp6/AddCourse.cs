using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Have to delete discount and fees label and textbox
namespace WindowsFormsApp6
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            c.cmd.Parameters.AddWithValue("@coursename", textBox2.Text);
            c.cmd.Parameters.AddWithValue("@starts", textBox3.Text);
            c.cmd.Parameters.AddWithValue("@ends", textBox4.Text);
            c.cmd.Parameters.AddWithValue("@about", richTextBox1.Text);
            c.cmd.Parameters.AddWithValue("@available", textBox6.Text);
            c.cmd.Parameters.AddWithValue("@fees", textBox22.Text);
            c.cmd.Parameters.AddWithValue("@free", textBox21.Text);
            c.cmd.Parameters.AddWithValue("@level", textBox23.Text);
            c.cmd.Parameters.AddWithValue("@NumberOfStudents", textBox24.Text);
            c.cmd.Parameters.AddWithValue("@language", textBox25.Text);
            //c.cmd.Parameters.AddWithValue("@credithours", textBox19.Text);
            c.cmd.Parameters.AddWithValue("@category", textBox7.Text);
            string free = "";
            string available = "";
            if (textBox6.Text.ToString() == "true")
            {
                available = "1";
            } 
            else { available = "0"; }
            if (textBox21.Text.ToString() == "true")
            {
                free = "1";
            }
            else { free = "0"; }

            int x = 0;
            Int32.TryParse(Form1.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            DataTable ds = c.Select("Select * from Categories");
            bool check = false;
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                string category = ds.Rows[i][1].ToString();
                if (category == textBox7.Text.ToString())
                {

                    check = true;
                }
            }
            if (check == false)
            {
                c.Inserts("Set identity_insert Categories off  Insert into Categories(CategoryName) values (@category)");
                Console.WriteLine("category added");
            }


            string queryyy = "select CategoryID from Categories where CategoryName=@category";
            //string category = ;


            c.cmd.Parameters.AddWithValue("@C_ID", c.Select(queryyy).Rows[0]["CategoryID"].ToString());


            c.Inserts("SET IDENTITY_INSERT Courses OFF Insert Into Courses (CategoryID,InstructorID,CourseName,CourseStarts, CourseEnds, NumberOfStudentsEnrolled,Free,FeesInDollars,Level,Language, C_Description, C_Disabled) Values (@C_ID,@id,@coursename, @starts,@ends, @NumberOfStudents,@fees,"+free+",@level,@language,@about,"+available+" ) SET IDENTITY_INSERT Courses OFF");
            this.Hide();
            MessageBox.Show("Course Added");

            //@coursename, @starts,@ends,@about,@available,@language,@NumberOfProjects, @NumberOfStudents,@level,@credithours

            //string courseID = "";
            //string categoryID = "";
            //courseID = c.Check("Select StudentID From StudentAccount Where S_Username = @username and S_Password = @password");
            //categoryID =c.Check("Select StudentID From StudentAccount Where S_Username = @username and S_Password = @password");
            //c.Inserts("set identity_insert off Categories_has_Courses Insert into Categories_has_Courses (CourseID,CategoryID) values('"+courseID+"',"+categoryID+"'");


        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Form9 fm = new Form9();
            fm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
