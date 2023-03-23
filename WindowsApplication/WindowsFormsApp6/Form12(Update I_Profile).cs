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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            c.cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
            c.cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
            c.cmd.Parameters.AddWithValue("@email", textBox3.Text);
            c.cmd.Parameters.AddWithValue("@password", textBox4.Text);
            c.cmd.Parameters.AddWithValue("@country", textBox6.Text);
           // c.cmd.Parameters.AddWithValue("@gender", textBox5.Text);
            c.cmd.Parameters.AddWithValue("@qualification", textBox8.Text);
            //c.cmd.Parameters.AddWithValue("@country", textBox5.Text);
            //c.cmd.Parameters.AddWithValue("@university", textBox7.Text);

            int x = 0;
            Int32.TryParse(Form1.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);

            if (!(string.IsNullOrWhiteSpace(textBox1.Text)))
            {

                c.Inserts("Update InstructorAccount Set I_FirstName = @firstname Where InstructorID = @id");
                //c.Inserts("Update StudentAccount Set S_FirstName = @firstname" + textBox1.Text + "', UnitPrice = '" + textBox2.Text + "', UnitPrice = '" + textBox4.Text "', UnitPrice = '" + textBox5.Text  "', UnitPrice = '" + textBox7.Text "' Where StudentID = " + textBox4.Text);

            }
            if (!(string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                c.Inserts("Update InstructorAccount Set I_LastName = @lastname Where InstructorID = @id");
            }
            if (!(string.IsNullOrWhiteSpace(textBox3.Text)))
            {
                c.Inserts("Update InstructorAccount Set I_Email = @email Where InstructorID = @id");
            }
            if (!(string.IsNullOrWhiteSpace(textBox4.Text)))
            {
                c.Inserts("Update InstructorAccount Set I_Password = @password Where InstructorID = @id");
            }
            if (!(string.IsNullOrWhiteSpace(textBox6.Text)))
            {
                c.Inserts("Update InstructorAccount Set I_Country = @country Where InstructorID = @id");
            }
            if (!(string.IsNullOrWhiteSpace(textBox8.Text)))
            {
                c.Inserts("Update InstructorAccount Set Qualification = @qualification Where InstructorID = @id");
            }
           

            MessageBox.Show("Updated");

        }

    }
}

