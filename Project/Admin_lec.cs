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
    public partial class Admin_lec : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query, query2;

        public Admin_lec()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id.Text != "" && txt_nama.Text != "" && txt_sks.Text != "" && txt_lecturer.Text != "") 
                {
                    query = string.Format("insert into lec values ('{0}','{1}','{2}', '{3}');", txt_id.Text, txt_nama.Text, txt_sks.Text, txt_lecturer.Text);
                
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Suksess ...");
                        Admin_lec_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal insert Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak lengkap !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id.Text != "" && txt_nama.Text != "" && txt_sks.Text != "" && txt_lecturer.Text != "" && txt_src.Text != "")
                {
                    query = string.Format("update lec set lec_name = '{0}', SKS = '{1}', ID_lecturer = '{2}' where ID = '{3}';", txt_nama.Text, txt_sks.Text, txt_lecturer.Text, txt_src.Text);

                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Suksess ...");
                        Admin_lec_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal insert Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Data Tidak lengkap !!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_src.Text != "")
                {
                    query = string.Format("delete from lec where ID = '{0}'", txt_src.Text);
                    ds.Clear();
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    perintah.ExecuteNonQuery();
                    adapter.Fill(ds);
                    koneksi.Close();
                }

                else
                {
                    MessageBox.Show("Data Tidak Ada !!");
                    Admin_lec_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Admin_lec_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_closeApp_Click(object sender, EventArgs e)
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
                        txt_src.Enabled = true;
                        Userview.DataSource = ds.Tables[0];
                        btn_up.Enabled = true;
                        button3.Enabled = true;
                        BtnSave.Enabled = true;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Admin_lec_Load(object sender, EventArgs e)
        {
            koneksi.Open();
            query = string.Format("select * from lec");
            perintah = new MySqlCommand(query, koneksi);
            adapter = new MySqlDataAdapter(perintah);
            perintah.ExecuteNonQuery();
            ds.Clear();
            adapter.Fill(ds);
            koneksi.Close();
            Userview.DataSource = ds.Tables[0];
            Userview.Columns[0].Width = 100;
            Userview.Columns[0].HeaderText = "ID lecture";
            Userview.Columns[1].Width = 100;
            Userview.Columns[1].HeaderText = "lecture name";
            Userview.Columns[2].Width = 100;
            Userview.Columns[2].HeaderText = "SKS";
            Userview.Columns[3].Width = 100;
            Userview.Columns[3].HeaderText = "ID lecturer";

            BtnSave.Enabled = true;
            btn_up.Enabled = true;
        }
    }
}
