using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class Lectures : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;

        public Lectures()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_src.Text != "")
                {
                    query = string.Format("select * from lec where ID = '{0}'", txt_src.Text);
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
                            txt_src.Text = kolom["ID"].ToString();
                        }
                        txt_src.Enabled = false;
                        grid_lec.DataSource = ds.Tables[0];
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

        private void Lectures_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.Open();
                if (txt_src.Text != "")
                {
                    query = string.Format("select * from lec where ID='{0}'", txt_src.Text);
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    ds.Clear();
                    adapter.Fill(ds);
                    koneksi.Close();
                    grid_lec.DataSource = ds.Tables[0];
                    grid_lec.Columns[0].Width = 200;
                    grid_lec.Columns[0].HeaderText = "ID";
                    grid_lec.Columns[1].Width = 200;
                    grid_lec.Columns[1].HeaderText = "lec_name";
                    grid_lec.Columns[2].Width = 340;
                    grid_lec.Columns[2].HeaderText = "SKS";
                    grid_lec.Columns[3].Width = 200;
                    grid_lec.Columns[3].HeaderText = "ID_lecturer";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
