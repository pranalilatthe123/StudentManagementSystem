using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementNew
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student Form1Info = new Student();
            Form1Info.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Course CourseInfo = new Course();
            CourseInfo.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tuition TuitionfeeInfo = new Tuition();
            TuitionfeeInfo.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.Show();
            this.Hide();

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Section SectionInfo = new Section();
            SectionInfo.Show();
            this.Hide();
        }
    }
}
