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
    public partial class Form1 : Form
    {
        public static string ID = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fm = new Form2(); //registration form
            fm.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //goes to home page for students
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                DBconnectioncs c = new DBconnectioncs();
                c.cmd.Parameters.AddWithValue("@username", textBox1.Text);
                c.cmd.Parameters.AddWithValue("@password", textBox2.Text);
                
                Console.WriteLine(ID);
                if (checkBox1.Checked)
                {
                    ID = c.Check("Select StudentID From StudentAccount Where S_Username = @username and S_Password = @password");

                    DataTable ds = c.Select("Select * from StudentAccount where S_Username=@username and S_Password=@password");

                    int count = ds.Rows.Count;
                    if (count == 1)
                    {
                        MessageBox.Show("Login Successful!");
                        this.Hide();
                        Form3 fm = new Form3(); //homepage for students
                        fm.Show();

                    }
                    else
                    {
                        MessageBox.Show("Login Failed!");
                    }
                }

                else if (checkBox2.Checked)
                {


                    ID = c.Check("Select InstructorID From InstructorAccount Where I_Username = @username and I_Password = @password");
                    Console.WriteLine(ID);
                    MessageBox.Show(ID);
                    DataTable ds = c.Select("Select * from InstructorAccount where I_Username=@username and I_Password=@password");
                    //int count = ds.Tables[0].Rows.Count;
                    int count = ds.Rows.Count;

                    if (count == 1)
                    {
                        MessageBox.Show("Login Successful!");
                        this.Hide();

                        Form9 fm = new Form9(); //home page for instructors
                        fm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Are you an Instructor or a Student? Specify");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
        
