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
    public partial class Teacher : Form
    {
        SqlCommand cnn;
        SqlConnection con;
        SqlDataAdapter de;
        
        public Teacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into Teacher_table Values(  @Id,@Name,@Age,@Qualification,@Experience,@Department)", con);
            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Name", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Qualification", (textBox4.Text));
            cnn.Parameters.AddWithValue("@Experience", (comboBox1.Text));
            cnn.Parameters.AddWithValue("@Department", (comboBox2.Text));


            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Teacher_table", con);

            SqlDataAdapter de = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            de.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("Update Teacher_table Set Name=@Name,Age=@Age,Qualification=@Qualification,Experience=@Experience,Department=@Department where Id=@Id", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Name", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Qualification",(textBox4.Text));
            cnn.Parameters.AddWithValue("@Experience", (comboBox1.Text));
            cnn.Parameters.AddWithValue("@Department", (comboBox2.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Updated");

        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            getteacherID();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Main MainInfo = new Main(); ;
            MainInfo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        public void getteacherID()
        {
            string teacherID;
            string query = "select ID from Teacher_Table order by ID desc";
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");

            con.Open();
            SqlCommand cnn = new SqlCommand(query, con);

            SqlDataReader dr = cnn.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                teacherID = id.ToString("00000");
            }
            else if (Convert.IsDBNull(dr))
            {
                teacherID = ("00001");
            }
            else
            {
                teacherID = ("00001");
            }
            con.Close();

            textBox1.Text = teacherID.ToString();
        }

        private void BTN_SEARCH_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();
            DataTable dt = new DataTable();
            if (textBox7.Text.Length > 0)
            {
                SqlDataAdapter de = new SqlDataAdapter("Select * from Teacher_table where Id like'" + textBox7.Text + "%'", con);
                
                de.Fill(dt);    

            }
            else if (textBox8.Text.Length > 0)
            {
                SqlDataAdapter de = new SqlDataAdapter("Select * from Teacher_table where [Name] like '" + textBox8.Text + "%'", con);

                de.Fill(dt);
            }
            else if (textBox9.Text.Length > 0)
            {
                SqlDataAdapter de = new SqlDataAdapter("Select * from Teacher_table where Department like '" + textBox9.Text + "%'", con);

                de.Fill(dt);
            }
            dataGridView1.DataSource = dt;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox9.Text = "";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            comboBox1.Text = " ";
            comboBox2.Text = " ";
            getteacherID();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}




