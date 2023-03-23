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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            int x = 0;
            Int32.TryParse(InstructorCourses.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            c.cmd.Parameters.AddWithValue("@description", richTextBox1.Text);
            c.cmd.Parameters.AddWithValue("@name", textBox2.Text);
            c.cmd.Parameters.AddWithValue("@link", textBox1.Text);


            string time = dateTimePicker2.Value.ToString("hh:mm:ss.fff");
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            c.Inserts("set identity_insert Assignments Off insert into Assignments (CourseID,AssignmentName,A_Description,PdfLink,A_DueDate) values (@id,@name,@description,@link,'" + date + " " + time + "')");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form18 fm = new Form18();
            fm.Show();
        }
    }
}
