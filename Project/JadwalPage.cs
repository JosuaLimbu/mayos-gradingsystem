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
    public partial class JadwalPage : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;

        public JadwalPage()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuMahasiswa frm= new MenuMahasiswa();
            frm.Show();
        }

        private void btn_closeApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_src.Text != "")
                {
                    query = string.Format("select * from classroom where ID_lec = '{0}'", txt_src.Text);
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow kolom in ds.Tables[0].Rows)
                        {
                            txt_src.Text = kolom["ID_lec"].ToString();
                        }
                        txt_src.Enabled = false;
                        grid_kls.DataSource = ds.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void JadwalPage_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                query = string.Format("select * from classroom");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                grid_kls.DataSource = ds.Tables[0];
                grid_kls.Columns[0].Width = 200;
                grid_kls.Columns[0].HeaderText = "Hari";
                grid_kls.Columns[1].Width = 200;
                grid_kls.Columns[1].HeaderText = "Jam";
                grid_kls.Columns[2].Width = 340;
                grid_kls.Columns[2].HeaderText = "Mata Kuliah";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
