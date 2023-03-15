using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Project
{
    public partial class Admin_dashboard : Form
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

        

        public Admin_dashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            Pnl_child.Controls.Add(childForm);
            Pnl_child.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SD_home());
        }

        private void btn_gradeBook_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddUserPage());
        }

        private void btn_closeApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_your_grade_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Admin_member());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Admin_lec());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Admin_kls());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginPage frm = new LoginPage();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new report_grade());
        }

        private void Admin_dashboard_Load(object sender, EventArgs e)
        {
            lb_username.Text = Get_username.uname;
        }
    }
}
