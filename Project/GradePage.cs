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
    public partial class GradePage : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query, assignment, quiz, project, Mid, Final, attendance, total;

        private void btn_src_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_src.Text != "")
                {
                    query = string.Format("select * from grade where stu_ID = '{0}'", txt_src.Text);
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
                            txt_src.Text = kolom["stu_ID"].ToString();
                        }
                        txt_src.Enabled = true;
                        Grade.DataSource = ds.Tables[0];
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

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuMahasiswa frm = new MenuMahasiswa();
            frm.Show();
        }

        public GradePage()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            assignment = "((assg1+assg2+assg3)/3)*0.10";
            quiz = "((quiz1+quiz2+quiz3)/3)*0.10";
            project = "((project1+project2)/2)*0.20";
            Mid = "Mid*0.25";
            Final = "Final*0.25";
            attendance = "attendace*0.10";
            total = "(((assg1+assg2+assg3)/3)*0.10)+(((quiz1+quiz2+quiz3)/3)*0.10)+(((project1+project2)/2)*0.20)+(Mid*0.25)+(Final*0.25)+(attendace*0.10)";


            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }

        private void GradePage_Load(object sender, EventArgs e)
        {
            koneksi.Open();
            query = string.Format("select * from grade");
            perintah = new MySqlCommand(query, koneksi);
            adapter = new MySqlDataAdapter(perintah);
            perintah.ExecuteNonQuery();
            ds.Clear();
            adapter.Fill(ds);
            koneksi.Close();
            Grade.DataSource = ds.Tables[0];
            Grade.Columns[0].Width = 100;
            Grade.Columns[0].HeaderText = "ID Mahasiswa";
            Grade.Columns[1].Width = 100;
            Grade.Columns[1].HeaderText = "Nama";
            Grade.Columns[2].Width = 100;
            Grade.Columns[2].HeaderText = "ID Lecture";
            Grade.Columns[3].Width = 50;
            Grade.Columns[3].HeaderText = "Assignment 10%";
            Grade.Columns[4].Width = 50;
            Grade.Columns[4].HeaderText = "Quiz 10%";
            Grade.Columns[5].Width = 50;
            Grade.Columns[5].HeaderText = "Project 20%";
            Grade.Columns[6].Width = 50;
            Grade.Columns[6].HeaderText = "Mid 25%";
            Grade.Columns[7].Width = 50;
            Grade.Columns[7].HeaderText = "Final 25%";
            Grade.Columns[8].Width = 50;
            Grade.Columns[8].HeaderText = "Attendance 10%";
            Grade.Columns[9].Width = 50;
            Grade.Columns[9].HeaderText = "Total";
            /*Grade.Columns[9].Width = 50;
            Grade.Columns[9].HeaderText = "Project 2";
            Grade.Columns[10].Width = 50;
            Grade.Columns[10].HeaderText = "Mid test";
            Grade.Columns[11].Width = 50;
            Grade.Columns[11].HeaderText = "Final test";
            Grade.Columns[12].Width = 50;
            Grade.Columns[12].HeaderText = "Attendance";
            Grade.Columns[13].Width = 50;
            Grade.Columns[13].HeaderText = "Total";*/
        }
    }
}
