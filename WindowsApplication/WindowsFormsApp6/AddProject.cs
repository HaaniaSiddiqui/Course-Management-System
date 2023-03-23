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
    public partial class AddProject : Form
    {
        public AddProject()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            int x = 0;
            Int32.TryParse(InstructorCourses.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            DataTable ds = c.Select("Select * from Project where CourseID=@id");

            int count = ds.Rows.Count;
            if (count > 1)
            {
                MessageBox.Show("You can only add one Project. If you want to update or delete the already added project click on Project Details");
            }
            else
            {
                c.cmd.Parameters.AddWithValue("@description", richTextBox1.Text);
                string time = dateTimePicker2.Value.ToString("hh:mm:ss.fff");
                string date = dateTimePicker1.Value.ToString("yyyy - MM - dd");
                c.Inserts("set identity_insert Project Off insert into Project (CourseID,P_Description,P_DueDate) values (@id,@description,'" + date + " " + time + "')");
            }
        }
    }
}
