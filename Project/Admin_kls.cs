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
    public partial class Admin_kls : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query, query2;

        public Admin_kls()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void Admin_lec_Load(object sender, EventArgs e)
        {

            koneksi.Open();
            query = string.Format("select * from classroom");
            perintah = new MySqlCommand(query, koneksi);
            adapter = new MySqlDataAdapter(perintah);
            perintah.ExecuteNonQuery();
            ds.Clear();
            adapter.Fill(ds);
            koneksi.Close();
            Userview.DataSource = ds.Tables[0];
            Userview.Columns[0].Width = 100;
            Userview.Columns[0].HeaderText = "Day";
            Userview.Columns[1].Width = 100;
            Userview.Columns[1].HeaderText = "Hour";
            Userview.Columns[2].Width = 100;
            Userview.Columns[2].HeaderText = "ID Lecture";

            BtnSave.Enabled = true;
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_day.Text != "" && txt_jam.Text != "" && txt_idLec.Text != "")
                {
                    query = string.Format("insert into classroom values ('{0}','{1}','{2}');", txt_day.Text, txt_jam.Text, txt_idLec.Text);

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
                if (txt_day.Text != "" && txt_jam.Text != "" && txt_idLec.Text != "" && txt_src.Text != "")
                {
                    query = string.Format("update classroom set day = '{0}', hour = '{1}', ID_lec = '{2}' where ID_lec = '{3}';", txt_day.Text, txt_jam.Text, txt_idLec.Text, txt_src.Text);

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
                if (txt_src.Text != "")
                {
                    query = string.Format("delete from classroom where ID_lec = '{0}'", txt_src.Text);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
