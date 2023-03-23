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
    public partial class ProjectDetails : Form
    {
        public ProjectDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            c.cmd.Parameters.AddWithValue("@description", richTextBox1.Text);
            string time = dateTimePicker2.Value.ToString("hh:mm:ss.fff");
            string date = dateTimePicker1.Value.ToString("yyyy - MM - dd");
            c.Inserts("Update Project set P_Description=@description,set P_DueDate='" + date + " " + time + "'");
            MessageBox.Show("Updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            int z = 0;
            Int32.TryParse(InstructorCourses.ID, out z);
            c.cmd.Parameters.AddWithValue("@id", z);
            c.Inserts("Delete From Projects where CourseID =@id");
        }

        private void ProjectDetails_Load(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            int x = 0;
            Int32.TryParse(InstructorCourses.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            string query3 = "Select * From Project Where CourseID = @id";
            DataTable ds3 = c.Select(query3);
            DateTime dt = DateTime.Parse(ds3.Rows[0]["P_DueDate"].ToString());

            MessageBox.Show(dt.ToString());
            richTextBox1.Text = ds3.Rows[0]["P_Description"].ToString();
            dateTimePicker1.Text = dt.ToString("dddd, dd MMMM yyyy");
            dateTimePicker2.Text = dt.ToString("hh:mm tt");
        }
    }
}
