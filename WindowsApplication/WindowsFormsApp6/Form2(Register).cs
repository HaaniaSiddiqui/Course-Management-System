using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        public Form2()
        {   
            InitializeComponent();
            DBconnectioncs c = new DBconnectioncs();
            //DataTable ds = c.Select("Select UniversityName From University");
            DataTable ds = c.Select("Select * From University");

            comboBox1.DataSource = ds;
            comboBox1.DisplayMember = "UniversityName";
            comboBox1.ValueMember = "UniversityID";
            comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e) //student
        {
            groupBox1.Visible = true; //student form visible
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true; //instructor form visible
        }

        

        private void button3_Click(object sender, EventArgs e) //student registered
        {
            DBconnectioncs c = new DBconnectioncs();
            //student registration form
            
            c.cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
            c.cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
            c.cmd.Parameters.AddWithValue("@username", textBox3.Text);
            c.cmd.Parameters.AddWithValue("@password", textBox8.Text);
            c.cmd.Parameters.AddWithValue("@gender", textBox5.Text);
            c.cmd.Parameters.AddWithValue("@country", textBox6.Text);
            c.cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = textBox4.Text;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox8.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Empty Fields");
            }
            //values not unique
            else if (c.Check("Select S_Username from  StudentAccount where S_Username = @userName") != "")
            {
                //c.Check();
                textBox3.Focus();
                MessageBox.Show("UserName already taken");
            }
            else if (c.Check("Select S_Password from  StudentAccount where S_Password = @password") != "")
            {
                textBox8.Focus();
                MessageBox.Show("Change Password: Integrity Issues");

            }
            else if (c.Check("Select S_Email from  StudentAccount where S_Email = @email") != "")
            {
                textBox4.Focus();
                MessageBox.Show("An account already registered on this email");

            }
            //register account
            else
            {
                c.Inserts("SET IDENTITY_INSERT StudentAccount OFF Insert Into StudentAccount ( S_FirstName, S_LastName,S_Username,S_Password, S_Gender, S_Country, S_Email,S_AccountCreationDate) Values (@firstname, @lastname, @username, @password, @gender, @country, @email ,'" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "') SET IDENTITY_INSERT StudentAccount OFF");
                this.Hide();
                Form1 fm = new Form1(); // after registration, back to login form to login
                fm.Show();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            //instructor registration form
            c.cmd.Parameters.AddWithValue("@firstname", textBox15.Text);
            c.cmd.Parameters.AddWithValue("@lastname", textBox14.Text);
            c.cmd.Parameters.AddWithValue("@username", textBox13.Text);
            c.cmd.Parameters.AddWithValue("@password", textBox12.Text);
            c.cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = textBox11.Text;
            c.cmd.Parameters.AddWithValue("@gender", textBox16.Text);
            c.cmd.Parameters.AddWithValue("@country", textBox10.Text);
            c.cmd.Parameters.AddWithValue("@qualification", textBox7.Text);
            //checks if any of them empty-- all should be filled
            if (string.IsNullOrWhiteSpace(textBox13.Text) || string.IsNullOrWhiteSpace(textBox12.Text) || string.IsNullOrWhiteSpace(textBox15.Text) || string.IsNullOrWhiteSpace(textBox14.Text) || string.IsNullOrWhiteSpace(textBox16.Text) || string.IsNullOrWhiteSpace(textBox10.Text) || string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox11.Text))
            {
                MessageBox.Show("Empty Fields");
            }
            //values not unique
            else if (c.Check("Select I_Username from  InstructorAccount where I_Username = @userName") != "")
            {
                //c.Check();
                textBox13.Focus();
                MessageBox.Show("UserName already taken");
            }
            else if (c.Check("Select I_Password from  InstructorAccount where I_Password = @password") != "")
            {
                textBox12.Focus();
                MessageBox.Show("Change Password: Integrity Issues");

            }
            else if (c.Check("Select I_Email from  InstructorAccount where I_Email = @email") != "")
            {
                textBox11.Focus();
                MessageBox.Show("An account already registered on this email");

            }
            // instructor registered 
            else
            {
                c.Inserts("SET IDENTITY_INSERT InstructorAccount OFF Insert Into InstructorAccount (UniversityID , I_Username,I_Password, I_FirstName, I_LastName, I_Gender, I_Country,I_Email, Qualification ,I_AccountCreationDate) Values ('" + (comboBox1.SelectedValue) + "' ,@username, @password, @firstname, @lastname, @gender, @country, @qualification, @email ,'" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "') SET IDENTITY_INSERT InstructorAccount OFF");
                this.Hide();
                Form1 fm = new Form1(); // after registration, back to login form to login
                fm.Show();
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
