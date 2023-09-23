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
    public partial class Student : Form
    {
        SqlCommand cnn;
        SqlConnection con;
        SqlDataAdapter de;
        public Student()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from userinfo", con);

            SqlDataAdapter de = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            de.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into userinfo Values(  @ID,@Name,@Age,@Course,@Date)", con);
            cnn.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Name", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Course", (comboBox1.Text));
            cnn.Parameters.AddWithValue("@Date", (this.dateTimePicker1.Text));
            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Added");


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            comboBox1.Text = " ";
            textBox5.Text = " ";
            getStuID();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("Update userinfo Set Name=@Name,Age=@Age,Course=@Course, Date=@Date where ID=@ID",con);

            cnn.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Name", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Course", (comboBox1.Text));
            cnn.Parameters.AddWithValue("@Date", (this.dateTimePicker1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Updated");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("Delete userinfo where ID=@ID", con);

            cnn.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Deleted");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Main MainInfo = new Main(); ;
            MainInfo.Show();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void getStuID()
        {
            string stuID;
            string query = "select ID from userinfo order by ID desc";
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");

            con.Open();
            SqlCommand cnn = new SqlCommand(query, con);

            SqlDataReader dr = cnn.ExecuteReader();

            if(dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                stuID = id.ToString("00000");
            }
            else if(Convert.IsDBNull(dr))
            {
                stuID = ("00001");
            }
            else
            {
                stuID = ("00001");
            }
            con.Close();

            textBox1.Text = stuID.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
private void Student_Load_1(object sender, EventArgs e)
        {
            getStuID();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
