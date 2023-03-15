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
    public partial class Admin_member : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query, query2;

        public Admin_member()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                koneksi.Open();
                query = string.Format("select * from {0}", comboBox1.Text);
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

                Userview.DataSource = ds.Tables[0];
                Userview.Columns[0].Width = 100;
                Userview.Columns[0].HeaderText = "ID";
                Userview.Columns[1].Width = 100;
                Userview.Columns[1].HeaderText = "name";
                Userview.Columns[2].Width = 100;
                Userview.Columns[2].HeaderText = "ID user";
            }
            else
            {
                MessageBox.Show("Pilih table terlebih dahulu");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_id.Text != "" && txt_name.Text != "" && txt_idUser.Text != "" && comboBox1.Text != "")
                {
                    query = string.Format("insert into {0} values ('{1}','{2}','{3}');", comboBox1.Text, txt_id.Text, txt_name.Text, txt_idUser.Text);

                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Suksess ...");
                        Admin_member_Load(null, null);
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
                if (txt_id.Text != "" && txt_name.Text != "" && txt_idUser.Text != "" && comboBox1.Text != "")
                {
                    query = string.Format("update {0} set ID = '{1}', name = '{2}', ID_user = '{3}' where ID = '{4}';", comboBox1.Text, txt_id.Text, txt_name.Text, txt_idUser.Text, txt_id.Text);

                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Suksess ...");
                        Admin_member_Load(null, null);
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

        private void btn_closeApp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_src.Text != "" && comboBox1.Text != "")
                {
                    query = string.Format("select * from {0} where ID = '{1}'", comboBox1.Text, txt_src.Text);
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
                        button2.Enabled = true;
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_src.Text != "" && comboBox1.Text != "")
                {
                    query = string.Format("delete from {0} where ID = '{1}'", comboBox1.Text, txt_src.Text);
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
                    Admin_member_Load(null, null);
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
                Admin_member_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Admin_member_Load(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                koneksi.Open();
                query = string.Format("select * from {0}", comboBox1.Text);
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();

                Userview.DataSource = ds.Tables[0];
                Userview.Columns[0].Width = 100;
                Userview.Columns[0].HeaderText = "ID";
                Userview.Columns[1].Width = 100;
                Userview.Columns[1].HeaderText = "name";
                Userview.Columns[2].Width = 100;
                Userview.Columns[2].HeaderText = "ID user";
            }
            else
            {
                MessageBox.Show("Pilih table terlebih dahulu");
            }
            BtnSave.Enabled = true;
            button2.Enabled = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
