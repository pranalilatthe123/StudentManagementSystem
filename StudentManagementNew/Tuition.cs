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
    public partial class Tuition : Form
    {
        SqlCommand cnn;
        SqlConnection con;
        SqlDataAdapter de;
        public Tuition()
        {
            InitializeComponent();
 
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into Fee_Table Values(  @Id,@Name,@Year_of_study,@Fees)", con);
            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Name", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Year_of_study",(comboBox1.Text));
            cnn.Parameters.AddWithValue("@Fees", int.Parse(textBox4.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Added");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from Fee_Table", con);

            SqlDataAdapter de = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            de.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("Update Fee_Table Set Name=@Name,Year_of_study=@Year_of_study,Fees=@Fees where Id=@Id", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Name", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Year_of_study",(comboBox1.Text));
            cnn.Parameters.AddWithValue("@Fees", int.Parse(textBox4.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Updated");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Main MainInfo = new Main(); ;
            MainInfo.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        public void getfeesID()
        {
            string feesID;
            string query = "select ID from Fee_Table order by ID desc";
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");

            con.Open();
            SqlCommand cnn = new SqlCommand(query, con);

            SqlDataReader dr = cnn.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                feesID = id.ToString("00000");
            }
            else if (Convert.IsDBNull(dr))
            {
                feesID = ("00001");
            }
            else
            {
                feesID = ("00001");
            }
            con.Close();

            textBox1.Text = feesID.ToString();
        }

        private void Tuition_Load(object sender, EventArgs e)
        {
            getfeesID();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox4.Text = " ";
            comboBox1.Text = " ";
            getfeesID();


        }

        private void BTN_SEARCH_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();
            DataTable dt = new DataTable();
            if (textBox7.Text.Length > 0)
            {
                SqlDataAdapter de = new SqlDataAdapter("Select * from Fee_Table where Year_of_study like'" + textBox7.Text + "%'", con);

                de.Fill(dt);

            }
            dataGridView1.DataSource = dt;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
