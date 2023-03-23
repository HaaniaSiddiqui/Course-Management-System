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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            c.cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
            c.cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
            c.cmd.Parameters.AddWithValue("@email", textBox3.Text);
            c.cmd.Parameters.AddWithValue("@password", textBox4.Text);
            c.cmd.Parameters.AddWithValue("@country", textBox5.Text);
            int x = 0;
            Int32.TryParse(Form1.ID, out x);
            c.cmd.Parameters.AddWithValue("@id", x);
            if (!(string.IsNullOrWhiteSpace(textBox1.Text)))
            {
                c.Inserts("Update StudentAccount Set S_FirstName = @firstname Where StudentID = @id" );
                //c.Inserts("Update StudentAccount Set S_FirstName = @firstname" + textBox1.Text + "', UnitPrice = '" + textBox2.Text + "', UnitPrice = '" + textBox4.Text "', UnitPrice = '" + textBox5.Text  "', UnitPrice = '" + textBox7.Text "' Where StudentID = " + textBox4.Text);

            }
            if (!(string.IsNullOrWhiteSpace(textBox2.Text)))
            {
                c.Inserts("Update StudentAccount Set S_LastName = @lastname Where StudentID = @id");
            }
            if (!(string.IsNullOrWhiteSpace(textBox3.Text)))
            {
                c.Inserts("Update StudentAccount Set S_Email = @email Where StudentID = @id");
            }
            if (!(string.IsNullOrWhiteSpace(textBox4.Text)))
            {
                c.Inserts("Update StudentAccount Set S_Password = @password Where StudentID = @id");
            }
            if (!(string.IsNullOrWhiteSpace(textBox5.Text)))
            {
                c.Inserts("Update StudentAccount Set S_Country = @country Where StudentID = @id");
            }
            MessageBox.Show("Updated");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm = new Form3();
            fm.Show();
        }
    }
}
