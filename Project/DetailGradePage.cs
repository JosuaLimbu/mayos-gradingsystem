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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class TblDetailGrade : Form
    {
        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query, query2;

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbIDStudent.Text != "" && CmbIDLec.Text != "")
                {
                    

                    query = string.Format("insert into detail_grade values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}', '{13}');", CmbIDStudent.SelectedItem, CmbIDLec.SelectedItem, InptAssgn1.Text, InptAssgn2.Text, InptAssgn3.Text, InptQuiz1.Text, InptQuiz2.Text, InptQuiz3.Text, InptPrjt1.Text, InptPrjt2.Text, InptMid.Text, InptFinal.Text, InptAttend.Text, NilaiTotal.Text);

                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();

                    double assignment = ((Convert.ToDouble(InptAssgn1.Text) + Convert.ToDouble(InptAssgn2.Text) + Convert.ToDouble(InptAssgn3.Text)) / 3) * 0.10;
                    double quiz = ((Convert.ToDouble(InptQuiz1.Text) + Convert.ToDouble(InptQuiz2.Text) + Convert.ToDouble(InptQuiz3.Text)) / 3) * 0.10;
                    double project = ((Convert.ToDouble(InptPrjt1.Text) + Convert.ToDouble(InptPrjt2.Text)) / 2) * 0.20;
                    double test1 = Convert.ToDouble(InptMid.Text) * 0.25;
                    double test2 = Convert.ToDouble(InptFinal.Text) * 0.25;
                    double attd = (Convert.ToDouble(InptAttend.Text)) * 0.10;
                    double total = assignment + quiz + project + test1 + test2 + attd;

                    query2 = string.Format("insert into grade values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}');", CmbIDStudent.SelectedItem, CmbNameStudent.SelectedItem, CmbIDLec.SelectedItem, assignment, quiz, project, test1, test2, attd, total);


                    koneksi.Open();
                    perintah = new MySqlCommand(query2, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res2 = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        

                        MessageBox.Show("Insert Data Suksess ...");
                        TblDetailGrade_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Gagal insert Data . . . ");
                    }
                }
                else
                {
                    MessageBox.Show("Wajib mengisi ID student dan ID mata kuliah !!");
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
                CmbDisP();
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

                CmbIDStudent.Enabled = true;
                CmbIDStudent.Focus();
                CmbIDLec.Enabled= true;
                CmbIDLec.Focus();
                BtnSubmit.Enabled = true;
                BtnUpdate.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CmbIDStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*koneksi.Open();

            koneksi.Close();*/
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
            /*koneksi.Open();

            koneksi.Close();*/
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

        private void CmbNameStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*koneksi.Open();

            koneksi.Close();*/
        }

        public void CmbDisP()
        {
            koneksi.Open();
            string q = "SELECT name FROM student";
            MySqlCommand cmd = new MySqlCommand(q, koneksi);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CmbNameStudent.Items.Add(dr["name"].ToString());
                CmbNameStudent.DisplayMember = (dr["name"].ToString());
                CmbNameStudent.ValueMember = (dr["name"].ToString());
            }
            koneksi.Close();
        }

        private void BtnKalku_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            double txt1 = Convert.ToDouble(InptAssgn1.Text);
            double txt2 = Convert.ToDouble(InptAssgn2.Text);
            double txt3 = Convert.ToDouble(InptAssgn3.Text);
            double txt4 = Convert.ToDouble(InptQuiz1.Text);
            double txt5 = Convert.ToDouble(InptQuiz2.Text);
            double txt6 = Convert.ToDouble(InptQuiz3.Text);
            double txt7 = Convert.ToDouble(InptPrjt1.Text);
            double txt8 = Convert.ToDouble(InptPrjt2.Text);
            double txt9 = Convert.ToDouble(InptMid.Text);
            double txt10 = Convert.ToDouble(InptFinal.Text);
            double txt11 = Convert.ToDouble(InptAttend.Text);

            double total = (((txt1 + txt2 + txt3) / 3) * 0.10) + (((txt4 + txt5 + txt6) / 3) * 0.10) + (((txt7 + txt8) / 2) * 0.20) + (txt9 * 0.25) + (txt10 * 0.25) + (txt11 * 0.10);
            NilaiTotal.Text = total.ToString();

            koneksi.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbIDStudent.SelectedItem != null && CmbIDLec.SelectedItem != null)
                {
                    query = string.Format("update detail_grade set assg1 = '{0}', assg2 = '{1}', assg3 = '{2}', quiz1 = '{3}', quiz2 = '{4}', quiz3 = '{5}', project1 = '{6}', project2 = '{7}', Mid = '{8}', Final = '{9}', attendace = '{10}',total = '{11}' where ID_stu = '{12}' and ID_lec = '{13}';", InptAssgn1.Text, InptAssgn2.Text, InptAssgn3.Text, InptQuiz1.Text, InptQuiz2.Text, InptQuiz3.Text, InptPrjt1.Text, InptPrjt2.Text, InptMid.Text, InptFinal.Text, InptAttend.Text, NilaiTotal.Text, CmbIDStudent.SelectedItem, CmbIDLec.SelectedItem);
                    koneksi.Open();
                    perintah = new MySqlCommand(query, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res = perintah.ExecuteNonQuery();
                    koneksi.Close();

                    double assignment = ((Convert.ToDouble(InptAssgn1.Text) + Convert.ToDouble(InptAssgn2.Text) + Convert.ToDouble(InptAssgn3.Text)) / 3) * 0.10;
                    double quiz = ((Convert.ToDouble(InptQuiz1.Text) + Convert.ToDouble(InptQuiz2.Text) + Convert.ToDouble(InptQuiz3.Text)) / 3) * 0.10;
                    
                    double project = ((Convert.ToDouble(InptPrjt1.Text) + Convert.ToDouble(InptPrjt1.Text)) / 2) * 0.20;
                    double test1 = Convert.ToDouble(InptMid.Text) * 0.25;
                    double test2 = Convert.ToDouble(InptFinal.Text) * 0.25;
                    double attd = (Convert.ToDouble(InptAttend.Text)) * 0.10;
                    double total = assignment + quiz + project + test1 + test2 + attd;
                    query2 = string.Format("update grade set assignment_grade = '{0}', quiz_grade = '{1}', project = '{2}', MidTerm = '{3}', FinalTerm = '{4}', attendance = '{5}', total_grade = '{6}'  where stu_ID = '{7}' and ID_lec = '{8}';", assignment, quiz, project, test1, test2, attd, total, CmbIDStudent.SelectedItem, CmbIDLec.SelectedItem);


                    koneksi.Open();
                    perintah = new MySqlCommand(query2, koneksi);
                    adapter = new MySqlDataAdapter(perintah);
                    int res2 = perintah.ExecuteNonQuery();
                    koneksi.Close();
                    if (res == 1)
                    {
                        MessageBox.Show("Update Data Gagal...");

                    }
                    else
                    {
                        MessageBox.Show("Update Data Sukses...");
                        TblDetailGrade_Load(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Pilih ID student dan ID matakuliah!!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_src_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_src.Text != "")
                {
                    query = string.Format("select * from detail_grade where ID_stu = '{0}'", txt_src.Text);
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
                            txt_src.Text = kolom["ID_stu"].ToString();
                        }
                        txt_src.Enabled = true;
                        detail_grade.DataSource = ds.Tables[0];
                        BtnUpdate.Enabled = true;
                        BtnKalku.Enabled = true;
                        BtnSubmit.Enabled = true;
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
            LoginPage frm = new LoginPage();
            frm.Show();
        }

        public TblDetailGrade()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
        }
    }
}
