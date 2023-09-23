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
    public partial class Section : Form

    {
        SqlCommand cnn;
        SqlConnection con;
        SqlDataAdapter de;

        public Section()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into my_info Values(  @Id,@Name,@Section)", con);
            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Name", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Section",(comboBox1.Text));
            
            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("select * from my_info", con);

            SqlDataAdapter de = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            de.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");
            con.Open();

            SqlCommand cnn = new SqlCommand("Update my_info Set Name=@Name,Section=@Section where Id=@Id", con);

            cnn.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Name", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Section", (comboBox1.Text));

            cnn.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Data Updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Main MainInfo = new Main(); ;
            MainInfo.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void getsectionID()
        {
            string sectionID;
            string query = "select ID from my_info order by ID desc";
            SqlConnection con = new SqlConnection(@"Data Source = HP\PRANALI;Initial Catalog=studentdb; Integrated Security=True");

            con.Open();
            SqlCommand cnn = new SqlCommand(query, con);

            SqlDataReader dr = cnn.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                sectionID = id.ToString("00000");
            }
            else if (Convert.IsDBNull(dr))
            {
                sectionID = ("00001");
            }
            else
            {
                sectionID = ("00001");
            }
            con.Close();

            textBox1.Text = sectionID.ToString();
        }

        private void Section_Load(object sender, EventArgs e)
        {
            getsectionID();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.Text = " ";
            getsectionID();
        }
    }
}
