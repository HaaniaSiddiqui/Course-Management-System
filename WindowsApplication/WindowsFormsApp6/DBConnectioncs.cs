using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WindowsFormsApp6
{

    class DBconnectioncs
    {
        //data members

        // connection string
        public SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2TLMARM\SQLSPARTA;Initial Catalog=CourseManagement4;Integrated Security=SSPI");
        public SqlCommand cmd = new SqlCommand();


        //consructor
        public DBconnectioncs()
        {
            //public SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2TLMARM\SQLSPARTA;Initial Catalog=Northwind;Integrated Security=SSPI");
            //public SqlCommand cmd = new SqlCommand();
        }

        //function members

        public void Inserts(string query) // insert / update / delete
        {
            //DBconnectioncs();
            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();


        }
        //c.Inserts("SET IDENTITY_INSERT Student_Enrolls_In_Courses OFF Insert Into [Student_Enrolls_In_Courses] ( ProjectID, CourseID, StudentID, CertificateID, RatingsByStudent,DateOfEnrollment, ProjectCompleted, VerifiedByInstructor, PaymentID) Values (@p_id, @c_id, @s_id, NULL, NULL, '" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff") + "', '" + 0 + "' , '" + 0 + "',  @pay_id ") SET IDENTITY_INSERT[Student_Enrolls_In_Courses] OFF");
        public DataTable Select(string query) // select query
        {
            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
       
       
        public string Check(string query)
        {
            string var;
            conn.Open();
            cmd.CommandText = query;
            cmd.Connection = conn;
            //cmd = new MySqlCommand(query, mysqlCon);
            //string x = cmd.ExecuteScalar();
            //string y = cmd.ExecuteScalar().ToString();
            
            if (cmd.ExecuteScalar() == null)
            {
                var = "" ;
            }
            else
            {
                var =  cmd.ExecuteScalar().ToString();
            }
            conn.Close();
            return var;


        }
        //public int ReturnNo(string query)
        //{
        //    int x;
        //    conn.Open();
        //    cmd.CommandText = query;
        //    cmd.Connection = conn;
        //    //cmd = new MySqlCommand(query, mysqlCon);
        //    x = cmd.ExecuteScalar().ToString();
        //    conn.Close();
        //    return x;
        //}
    }
}