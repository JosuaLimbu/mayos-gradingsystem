using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Project
{
    public partial class MenuMahasiswa : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;

        public MenuMahasiswa()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void BtnJadwal_Click(object sender, EventArgs e)
        {
            this.Hide();
            JadwalPage frm = new JadwalPage();
            frm.Show();
        }

        private void BtnNilai_Click(object sender, EventArgs e)
        {
            this.Hide();
            GradePage frm = new GradePage();
            frm.Show();
        }

        private void BtnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage frm = new LoginPage();
            frm.Show();
        }

        private void MenuMahasiswa_Load(object sender, EventArgs e)
        {
            
        }
    }
}
