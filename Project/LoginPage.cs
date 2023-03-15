using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace Project
{
    public partial class LoginPage : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
          (
          int nLeftRect,
          int nTopRect,
          int nRightRect,
          int nBottomRect,
          int nWidthEllipse,
          int nHeightEllipse

          );

        private MySqlConnection koneksi;
        private MySqlDataAdapter adapter;
        private MySqlCommand perintah;
        private DataSet ds = new DataSet();
        private string alamat, query;

       

        public LoginPage()
        {
            alamat = "server=localhost; database=project_vispro; username=root; password=;";
            koneksi = new MySqlConnection(alamat);
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtUser.Text != "" && TxtPass.Text != "")
                {
                    query = string.Format("select * from user where username = '{0}'", TxtUser.Text);
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
                            LblPass.Text = kolom["password"].ToString();
                            LblUser.Text = kolom["level"].ToString();
                            if (LblPass.Text == TxtPass.Text)
                            {
                                Get_username.uname = TxtUser.Text;
                                this.Hide();
                                
                                if(LblUser.Text == "1")
                                {
                                    Admin_dashboard frm = new Admin_dashboard();
                                    frm.Show();
                                }
                                else if (LblUser.Text == "2")
                                {
                                    Dosen_dashboard frm = new Dosen_dashboard();
                                    frm.Show();
                                }
                                else if (LblUser.Text == "3")
                                {
                                    Student_dashboard frm = new Student_dashboard();
                                    frm.Show();
                                }
                                
                                



                            }
                            else
                            {
                                MessageBox.Show("Password salah");
                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ada !!");

                    }

                }
                else
                {
                    MessageBox.Show("Anda belum memasukkan username dan password !!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_closeApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            koneksi.Open();
            query = string.Format("select * from user ");
            perintah = new MySqlCommand(query, koneksi);
            adapter = new MySqlDataAdapter(perintah);
            perintah.ExecuteNonQuery();
            ds.Clear();
            adapter.Fill(ds);
            koneksi.Close();
        }
    }
}
