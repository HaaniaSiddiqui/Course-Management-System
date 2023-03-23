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
    public partial class Form6 : Form
    {
        static string courseIDclicked = "";
        static string AssIDclicked = "";

        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            DBconnectioncs c = new DBconnectioncs();
            //studentid
            int x = 0;
            Int32.TryParse(Form1.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            Console.WriteLine(x);

            string query = "select * from student_enrolls_in_courses S Inner join courses C On S.CourseID = C.CourseID Where S.StudentID = @id";
            DataTable dt = c.Select(query);

            listBox1.DataSource = dt;
            listBox1.DisplayMember = "CourseName";
            listBox1.ValueMember = "CourseID";
            //if (dt.Rows.Count == 0)
            //{
            //    MessageBox.Show("You aren't enrolled in any of the courses");
            //}
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            courseIDclicked = listBox1.SelectedValue.ToString();
            //Console.WriteLine(courseIDclicked);
        }
        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxASSIGNMENTSxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        //stores selectedassignment from listbox2
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            if (listBox2.SelectedValue != null)
            {
                AssIDclicked = listBox2.SelectedValue.ToString();
                Console.WriteLine(AssIDclicked);
            }
            else
            {
                AssIDclicked = "";
            }


        }

        //displays assignment description in listbox2
        private void button2_Click(object sender, EventArgs e) //assignment clicked
        {
            button5.Enabled = true;
            listBox2.DataSource = null;
            listBox2.Items.Clear();
            listView1.Items.Clear();
            checkBox1.Visible = true; //asign ka
            listView1.Visible = true;
            checkBox2.Visible = false; //project ka

            int b = 0;
            DBconnectioncs c = new DBconnectioncs();
            Int32.TryParse(courseIDclicked, out b);
            c.cmd.Parameters.AddWithValue("@c_id", b);



            //displays assignment description in listbox2
            string query3 = "Select * From Assignments Where CourseID = @c_id";
            DataTable ds3 = c.Select(query3);
            listBox2.DataSource = ds3;
            listBox2.DisplayMember = "PdfLink";
            listBox2.ValueMember = "AssignmentID";
            //can be no assignment, in that case nothing displayed

        }
        //private void ListBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.C)
        //    {
        //        System.Text.StringBuilder copy_buffer = new System.Text.StringBuilder();
        //        foreach (object item in listBox2.SelectedItems)
        //            copy_buffer.AppendLine(item.ToString());
        //        if (copy_buffer.Length > 0)
        //            Clipboard.SetText(copy_buffer.ToString());
        //    }
        //}

        private void button5_Click(object sender, EventArgs e)  //more button
        {
            listView1.Items.Clear();
            DBconnectioncs c = new DBconnectioncs();

            int b = 0;
            Int32.TryParse(courseIDclicked, out b);
            c.cmd.Parameters.AddWithValue("@c_id", b);


            int x = 0;
            Int32.TryParse(Form1.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            if (AssIDclicked != "")
            {

                int z = 0;
                Int32.TryParse(AssIDclicked, out z);
                c.cmd.Parameters.AddWithValue("@a_id", z);
                string queryb = "Select * From Assignments Where AssignmentID = @a_id";
                DataTable dsb = c.Select(queryb);
                //Console.WriteLine(z);
                if (!(dsb.Rows.Count == 0))
                {
                    string str = "Assignment Name: " + dsb.Rows[0]["AssignmentName"].ToString() + "Assignment Description: " + dsb.Rows[0]["A_Description"].ToString() + "  DueDate:" + dsb.Rows[0]["A_DueDate"].ToString() + " PdfLink: " + dsb.Rows[0]["PdfLink"].ToString(); //add pdf link later
                    listView1.Items.Add(str);
                }


                string queryy = "Select * From Student_Enrolls_In_Courses Where StudentID = @id and CourseID = @c_id";
                DataTable dbb = c.Select(queryy);
                string querym = "Select AssignmentCompleted  From [Student_has_Assignments] Where EnrollmentID ='" + dbb.Rows[0]["EnrollmentID"] + "' and St_Ass_Id = @a_id";

                DataTable db = c.Select(querym);
                if (db.Rows.Count != 0)
                {
                    string s4 = db.Rows[0]["AssignmentCompleted"].ToString();
                    if (s4 == "1")
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                }

            }
            else
            {
                MessageBox.Show("Select an assignment first if any.");
            }
            
        }




        //private void ListBox2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.Control && e.KeyCode == Keys.C)
        //    {
        //        System.Text.StringBuilder copy_buffer = new System.Text.StringBuilder();
        //        foreach (object item in listBox2.SelectedItems)
        //            copy_buffer.AppendLine(item.ToString());
        //        if (copy_buffer.Length > 0)
        //            Clipboard.SetDataObject(copy_buffer.ToString());
        //    }
        //}
        


        private void checkBox1_CheckedChanged(object sender, EventArgs e) //to check if assignment completed
        {
            string query4;
            int b = 0;

            DBconnectioncs c = new DBconnectioncs();
            Int32.TryParse(AssIDclicked, out b);
            c.cmd.Parameters.AddWithValue("@a_id", b);
            Console.WriteLine(b);
            if (checkBox1.Checked)
            {
                query4 = "Update [Student_has_Assignments ] Set AssignmentCompleted = '" + 1 + "' Where St_Ass_Id = @a_id";
                c.Inserts(query4);
            }
            else
            {
                query4 = "Update [Student_has_Assignments ] Set AssignmentCompleted = '" + 0 + "' Where St_Ass_Id = @a_id";
                c.Inserts(query4);
            }
        }







        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxLECTURE VIDEOS xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

        //displays videos acc to course clicked
        private void button3_Click(object sender, EventArgs e) //lecture videos
        {
            button5.Enabled = false;
            listBox2.DataSource = null;
            listBox2.Items.Clear();
            listView1.Items.Clear();
            listView1.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            int b = 0;
            DBconnectioncs c = new DBconnectioncs();
            Int32.TryParse(courseIDclicked, out b);
            c.cmd.Parameters.AddWithValue("@c_id", b);
            Console.WriteLine(b);

            string query3 = "Select * From LectureVideos Where CourseID = @c_id";
            DataTable ds3 = c.Select(query3);
            listBox2.DataSource = ds3;
            listBox2.DisplayMember = "DownloadLink";
            listBox2.ValueMember = "LectureVideoID";

            if (ds3.Rows.Count == 0)
            {
                MessageBox.Show("No Videos of this course");
            }

        }


        //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxPROJECT xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        private void button1_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            DBconnectioncs c = new DBconnectioncs();
            listBox2.DataSource = null;
            listBox2.Items.Clear();
            listView1.Items.Clear();
            listBox2.Items.Clear();
            listView1.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = true;

            int b = 0;
            Int32.TryParse(courseIDclicked, out b);
            c.cmd.Parameters.AddWithValue("@c_id", b);

            checkBox2.Visible = true;
            string querym = "Select ProjectCompleted  From [Student_Enrolls_In_Courses ] Where CourseID = @c_id";
            DataTable db = c.Select(querym);
            if (db.Rows.Count != 0)
            {
                string s4 = db.Rows[0]["ProjectCompleted"].ToString();
                if (s4 == "1")
                {
                    checkBox2.Checked = true;
                }
            }


            listBox2.Visible = true;


            string query3 = "Select * From Project  Where CourseID = @c_id";
            DataTable ds3 = c.Select(query3);
            listBox2.DataSource = ds3;
            listBox2.DisplayMember = "P_Description";
            listBox2.ValueMember = "ProjectID";

        }



        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            string query4;

            int b = 0;
            DBconnectioncs c = new DBconnectioncs();
            Int32.TryParse(courseIDclicked, out b);
            c.cmd.Parameters.AddWithValue("@c_id", b);
            if (checkBox2.Checked)
            {
                query4 = "Update [Student_Enrolls_In_Courses ] Set ProjectCompleted  = '" + 1 + "' Where CourseID = @c_id";
                c.Inserts(query4);
            }
            else if (!(checkBox2.Checked))
            {
                query4 = "Update [Student_Enrolls_In_Courses ] Set ProjectCompleted = '" + 0 + "' Where CourseID = @c_id";
                c.Inserts(query4);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm = new Form3();
            fm.Show();
        }




        //private void button4_Click(object sender, EventArgs e) 
        //{

        //    DBconnectioncs c = new DBconnectioncs();
        //    int b = 0;
        //    Int32.TryParse(courseIDclicked, out b);
        //    c.cmd.Parameters.AddWithValue("@c_id", b);


        //    int x = 0;
        //    Int32.TryParse(Form1.ID, out x);
        //    c.cmd.Parameters.AddWithValue("@id", x);

        //    //for finding enrollment id
        //    string queryy = "Select * From Student_Enrolls_In_Courses Where StudentID = @id and CourseID = @c_id";
        //    DataTable dbb = c.Select(queryy);

        //    c.Inserts("Delete From Student_Enrolls_In_Courses Where EnrollmentID = " + dbb.Rows[0]["EnrollmentID"]);

        //    //updating number of students enrolled
        //    string query = "Select NumberOfStudentsEnrolled From Courses Where CourseID = @c_id";
        //    string a = c.Check(query);
        //    int result;
        //    Int32.TryParse(a, out result);
        //    int final = result - 1;
        //    c.cmd.Parameters.AddWithValue("@final", final); //new value of studentsenrolled

        //    c.Inserts("Update Courses SET NumberOfStudentsEnrolled = @final Where CourseID = @c_id ");

        //}
   
    }
}
