using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Project
{
    public partial class SD_grade : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlDataReader mdr;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query, query2;

        public SD_grade()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_grSrcId_Click(object sender, EventArgs e)
        {
            koneksi.Open();

            string selectQuerry = "SELECT * FROM grade WHERE stu_ID=" + int.Parse(src_grID.Text);
            perintah = new MySqlCommand(selectQuerry, koneksi);
            mdr = perintah.ExecuteReader();

            if (mdr.Read())
            {
                label10.Text = mdr.GetInt32("assignment_grade").ToString();
                label11.Text = mdr.GetInt32("quiz_grade").ToString();
                label12.Text = mdr.GetInt32("project").ToString();

                label13.Text = mdr.GetInt32("MidTerm").ToString();
                label16.Text = mdr.GetInt32("FinalTerm").ToString();
                label14.Text = mdr.GetInt32("attendance").ToString();
                label5.Text = mdr.GetInt32("total_grade").ToString();
                

            }

            else
            {
                MessageBox.Show("No Data For This ID");
            }

            koneksi.Close();
        }
    }
}
