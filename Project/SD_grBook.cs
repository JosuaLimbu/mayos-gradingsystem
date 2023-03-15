using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Project
{
    public partial class SD_grBook : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlDataReader mdr;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query, query2;

        public SD_grBook()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_grSrcId_Click(object sender, EventArgs e)
        {
            koneksi.Open();

            string selectQuerry = "SELECT * FROM detail_grade WHERE ID_stu=" + int.Parse(src_grID.Text);
            perintah = new MySqlCommand(selectQuerry, koneksi);

            mdr = perintah.ExecuteReader();

            if (mdr.Read())
            {
                textBox1.Text = mdr.GetInt32("assg1").ToString();
                textBox2.Text = mdr.GetInt32("assg1").ToString();
                textBox3.Text = mdr.GetInt32("assg1").ToString();

                textBox6.Text = mdr.GetInt32("quiz1").ToString();
                textBox5.Text = mdr.GetInt32("quiz2").ToString();
                textBox4.Text = mdr.GetInt32("quiz3").ToString();

                textBox7.Text = mdr.GetInt32("project1").ToString();
                textBox8.Text = mdr.GetInt32("project2").ToString();
                

                textBox10.Text = mdr.GetInt32("Mid").ToString();
                textBox9.Text = mdr.GetInt32("Final").ToString();

                textBox12.Text = mdr.GetInt32("attendace").ToString();

            }

            else
            {
                MessageBox.Show("No Data For This ID");
            }

            koneksi.Close();
        }

        private void btn_closeApp_Click(object sender, EventArgs e)
        {
            double assg1 = Convert.ToDouble(textBox1.Text);
            double assg2 = Convert.ToDouble(textBox2.Text);
            double assg3 = Convert.ToDouble(textBox3.Text);

            double quiz1 = Convert.ToDouble(textBox6.Text);
            double quiz2 = Convert.ToDouble(textBox5.Text);
            double quiz3 = Convert.ToDouble(textBox4.Text);

            double pro1 = Convert.ToDouble(textBox7.Text);
            double pro2 = Convert.ToDouble(textBox8.Text);

            double mid = Convert.ToDouble(textBox10.Text);
            double final = Convert.ToDouble(textBox9.Text);

            double attd = Convert.ToDouble(textBox12.Text);

            double assignment = ((assg1 + assg2 + assg3) / 3) * 0.10;
            double quiz = ((quiz1 + quiz2 + quiz3) / 3) * 0.10;
            double project = ((pro1 + pro2) / 2) * 0.20;
            double midterm = mid * 0.25;
            double finalterm = final * 0.25;
            double attendace = attd * 0.10;

            double total = assignment + quiz + project + midterm + finalterm + attendace;

            lb_total.Text = Convert.ToString(total);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void SD_grBook_Load(object sender, EventArgs e)
        {

        }
    }
}
