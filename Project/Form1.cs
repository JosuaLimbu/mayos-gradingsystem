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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class TblDetailGrade : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbIDStudent.Text != "" && CmbIDLec.Text != "")
                {
                    query = string.Format("insert into detail_grade values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}');", CmbIDStudent.SelectedItem, CmbIDLec.SelectedItem, InptAssgn1.Text, InptAssgn2.Text, InptAssgn3.Text, InptQuiz1.Text, InptQuiz2.Text, InptQuiz3.Text, InptPrjt1.Text, InptPrjt2.Text, InptMid.Text, InptFinal.Text, InptAttend.Text, NilaiTotal.Text);

                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Insert Data Suksess ...");
                        TblDetailGrade_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal inser Data . . . ");
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

        private void TblDetailGrade_Load(object sender, EventArgs e)
        {
            try
            {
                Cmbdisp();
                CmbDisp();
                koneksi.Open();
                query = string.Format("select * from detail_grade");
                perintah = new MySqlCommand(query, koneksi);
                adapter = new MySqlDataAdapter(perintah);
                perintah.ExecuteNonQuery();
                ds.Clear();
                adapter.Fill(ds);
                koneksi.Close();
                detail_grade.DataSource = ds.Tables[0];
                detail_grade.Columns[0].Width = 100;
                detail_grade.Columns[0].HeaderText = "ID Mahasiswa";
                detail_grade.Columns[1].Width = 100;
                detail_grade.Columns[1].HeaderText = "ID Lecture";
                detail_grade.Columns[2].Width = 50;
                detail_grade.Columns[2].HeaderText = "Assignment 1";
                detail_grade.Columns[3].Width = 50;
                detail_grade.Columns[3].HeaderText = "Assignment 2";
                detail_grade.Columns[4].Width = 50;
                detail_grade.Columns[4].HeaderText = "Assignment 3";
                detail_grade.Columns[5].Width = 50;
                detail_grade.Columns[5].HeaderText = "Quiz 1";
                detail_grade.Columns[6].Width = 50;
                detail_grade.Columns[6].HeaderText = "Quiz 2";
                detail_grade.Columns[7].Width = 50;
                detail_grade.Columns[7].HeaderText = "Quiz 3";
                detail_grade.Columns[8].Width = 50;
                detail_grade.Columns[8].HeaderText = "Project 1";
                detail_grade.Columns[9].Width = 50;
                detail_grade.Columns[9].HeaderText = "Project 2";
                detail_grade.Columns[10].Width = 50;
                detail_grade.Columns[10].HeaderText = "Mid test";
                detail_grade.Columns[11].Width = 50;
                detail_grade.Columns[11].HeaderText = "Final test";
                detail_grade.Columns[12].Width = 50;
                detail_grade.Columns[12].HeaderText = "Attendance";
                detail_grade.Columns[13].Width = 50;
                detail_grade.Columns[13].HeaderText = "Total";

                /*CmbIDStudent.Clear();
                CmbIDLec.Clear();*/
                CmbIDStudent.Enabled = true;
                CmbIDStudent.Focus();
                BtnSubmit.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CmbIDStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            koneksi.Open();

            koneksi.Close();
        }

        public void Cmbdisp()
        {
            koneksi.Open();
            string q = "SELECT ID, name FROM student";
            MySqlCommand cmd = new MySqlCommand(q, koneksi);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbIDStudent.Items.Add(dr["ID"].ToString());
                CmbIDStudent.DisplayMember = (dr["ID"].ToString());
                CmbIDStudent.ValueMember = (dr["ID"].ToString());
            }
            koneksi.Close();
        }

        private void CmbIDLec_SelectedIndexChanged(object sender, EventArgs e)
        {
            koneksi.Open();

            koneksi.Close();
        }

        public void CmbDisp()
        {
            koneksi.Open();
            string q = "SELECT ID FROM lec";
            MySqlCommand cmd = new MySqlCommand(q, koneksi);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbIDLec.Items.Add(dr["ID"].ToString());
                CmbIDLec.DisplayMember = (dr["ID"].ToString());
                CmbIDLec.ValueMember = (dr["ID"].ToString());
            }
            koneksi.Close();    
        }

        public TblDetailGrade()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }
    }
}
