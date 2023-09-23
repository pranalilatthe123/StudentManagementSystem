using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace StudentManagementNew
{
    public partial class Course : Form
    {
        SqlCommand cnn;
        SqlConnection con;
        SqlDataAdapter de;
        public Course()
        {
            InitializeComponent();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
            Main MainInfo = new Main(); ;
            MainInfo.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into CourseTab Values(  @Id,@Course,@Credit)", con);
            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox4.Text));
            cnn.Parameters.AddWithValue("@Course", (textBox6.Text));
            cnn.Parameters.AddWithValue("@Credit", int.Parse(textBox5.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Added");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from CourseTab", con);

            SqlDataAdapter de = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            de.Fill(table);
            dataGridView2.DataSource = table;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("Update CourseTab Set Course=@Course,Credit=@Credit where Id=@Id", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox4.Text));
            cnn.Parameters.AddWithValue("@Course", (textBox6.Text));
            cnn.Parameters.AddWithValue("@Credit", int.Parse(textBox5.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Updated");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox4.Text = " ";
            textBox6.Text = " ";
            textBox5.Text = " ";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

       

       

       

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
