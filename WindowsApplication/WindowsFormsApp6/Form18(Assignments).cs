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
    public partial class Form18 : Form
    {
        public static string AssIDclicked="";
        public Form18()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form17 fm = new Form17();
            fm.Show();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            Form13 fm = new Form13();
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AssIDclicked = listBox1.SelectedValue.ToString();
            Console.WriteLine(AssIDclicked);
            Form19 fm = new Form19();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddProject fm = new AddProject();
            fm.Show();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            DBconnectioncs c = new DBconnectioncs();
            int x = 0;
            Int32.TryParse(InstructorCourses.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            string query = ("Select * from Assignments where CourseID =@id");
            DataTable ds = c.Select(query);
            listBox1.DataSource = ds;
            listBox1.DisplayMember = "AssignmentName";
            listBox1.ValueMember = "AssignmentID";
            string queryy = ("Select * from Project where CourseID =@id");
            DataTable dss = c.Select(queryy);
            richTextBox1.Text = dss.Rows[0][2].ToString();
            textBox1.Text = dss.Rows[0][3].ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
