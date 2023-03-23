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
    public partial class StudentDetails : Form
    {
        public static string EnrollmentID="";
        public static string StudentID="";

        public StudentDetails()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
               // if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                //{
                 //   MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //}
           





        }

        private void StudentDetails_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            DBconnectioncs c = new DBconnectioncs();
            int x = 0;
            Int32.TryParse(InstructorCourses.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            string query = "select StudentID,S_FirstName + ' ' + S_LastName as StudentName from StudentAccount where StudentID = (select StudentID from Student_Enrolls_In_Courses where CourseID=@id)";
            
            DataTable ds = c.Select(query);
            int count = ds.Rows.Count;
            //dataGridView1.DataSource = ds;


            listBox1.DataSource = ds;
            listBox1.DisplayMember = "StudentName";
            listBox1.ValueMember = "StudentID";
           


        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            
            StudentID =listBox1.SelectedValue.ToString();
            MessageBox.Show(StudentID);
            StudentProgress fm = new StudentProgress();
            fm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            StudentID = listBox1.SelectedValue.ToString();
            MessageBox.Show(StudentID);
            StudentProgress fm = new StudentProgress();
            fm.Show();

        }
    }
}
