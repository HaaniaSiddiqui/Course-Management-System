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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();

            c.cmd.Parameters.AddWithValue("@description", richTextBox1.Text);
           DateTime date1 = dateTimePicker2.Value;
            DateTime date2 = DateTime.Now;
           int result = DateTime.Compare(date1, date2);
            string relationship = "";

            if (result < 0)
            {
                MessageBox.Show("You cant add this date. This date is is older than your current date");
               // relationship = "";
            }
            else if (result == 0)
            {
                //relationship = "is the same time as";
            }
            else
            {
                //relationship = "is later than";
            }
            MessageBox.Show(relationship);
            
            int x = 0;
            Int32.TryParse(Form18.AssIDclicked, out x);
            c.cmd.Parameters.AddWithValue("@id", x);

            string time = dateTimePicker2.Value.ToString("hh:mm:ss.fff");
            string date = dateTimePicker1.Value.ToString("yyyy - MM - dd");
            c.Inserts("Update Assignments set A_Description=@description, A_DueDate='" + date + " " + time + "' where AssignmentID=@id");
            MessageBox.Show("Updated");
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            int x = 0;
            Int32.TryParse(Form18.AssIDclicked, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            string query3 = "Select * From Assignments Where AssignmentID = @id";
            DataTable ds3 = c.Select(query3);
            DateTime dt = DateTime.Parse(ds3.Rows[0]["A_DueDate"].ToString());
            
            MessageBox.Show(dt.ToString());
            richTextBox1.Text = ds3.Rows[0]["A_Description"].ToString();
            dateTimePicker1.Text= dt.ToString("dddd, dd MMMM yyyy");
            dateTimePicker2.Text = dt.ToString("hh:mm tt");




        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            
            int x = 0;
            Int32.TryParse(Form18.AssIDclicked, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            c.Inserts("Delete From Assignments where AssignmentID =@id");
            MessageBox.Show("Assignment Deleted");
        }
    }
}
