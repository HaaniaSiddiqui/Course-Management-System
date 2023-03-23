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
    
    public partial class Form3 : Form
    {
        public static string CourseID = "";

        public Form3()
        {
            InitializeComponent();

            DBconnectioncs c = new DBconnectioncs();
            DataTable ds = c.Select("Select * From Categories");
            comboBox1.DataSource = ds;
            comboBox1.ValueMember = "CategoryID";
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.Text = "";

        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 fm = new Form4();
            fm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e) //clicked enrolled courses
        {
            this.Hide();
            Form6 fm = new Form6();
            fm.Show();

        }





        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBconnectioncs c = new DBconnectioncs();
            string query = ("Select * from Courses where CategoryID =" + comboBox1.SelectedValue);
            DataTable ds = c.Select(query);
            listBox1.DataSource = ds;
            listBox1.DisplayMember = "CourseName";
            listBox1.ValueMember = "CourseID";
            if (ds.Rows.Count == 0)
            {
                MessageBox.Show("No courses offered under this category");
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 1)
            {
                MessageBox.Show("Select only one course at a time");

            }
            else if (listBox1.SelectedItems.Count == 1)
            {
                //string x = listBox1.SelectedItems.Text;
                //int curItem = listBox1.ValueMember;
                //string selected = listBox1.GetItemText(listBox1.SelectedValue);
                CourseID = listBox1.SelectedValue.ToString();
                Console.WriteLine(CourseID);
                //int x = Int16.Parse(selected); // returns 100

                this.Hide();
                Form5 fm = new Form5();
                fm.Show();


            }
            else
            {
                MessageBox.Show("Select a course");
            }
        }
    }
}


 