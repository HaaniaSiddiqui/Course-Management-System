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
    public partial class InstructorCourses : Form
    {
        public static string ID = "";
        public InstructorCourses()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            int x = 0;
            Int32.TryParse(Form1.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            string query = "Select * from Courses where InstructorID=@id";
            DataTable ds = c.Select(query);
            listBox1.DataSource = ds;
            listBox1.DisplayMember = "CourseName";
            listBox1.ValueMember = "CourseID";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            ID = listBox1.SelectedValue.ToString();
            MessageBox.Show(ID);
            Console.WriteLine(ID);
            Form13 fm = new Form13();
            this.Close();
            fm.Show();

        }
    }
}
