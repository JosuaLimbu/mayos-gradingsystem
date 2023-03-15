namespace Project
{
    partial class MenuMahasiswa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnJadwal = new System.Windows.Forms.Button();
            this.BtnNilai = new System.Windows.Forms.Button();
            this.BtnKeluar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnJadwal
            // 
            this.BtnJadwal.Location = new System.Drawing.Point(276, 158);
            this.BtnJadwal.Name = "BtnJadwal";
            this.BtnJadwal.Size = new System.Drawing.Size(211, 52);
            this.BtnJadwal.TabIndex = 0;
            this.BtnJadwal.Text = "Schedule";
            this.BtnJadwal.UseVisualStyleBackColor = true;
            this.BtnJadwal.Click += new System.EventHandler(this.BtnJadwal_Click);
            // 
            // BtnNilai
            // 
            this.BtnNilai.Location = new System.Drawing.Point(276, 244);
            this.BtnNilai.Name = "BtnNilai";
            this.BtnNilai.Size = new System.Drawing.Size(211, 52);
            this.BtnNilai.TabIndex = 1;
            this.BtnNilai.Text = "Grade";
            this.BtnNilai.UseVisualStyleBackColor = true;
            this.BtnNilai.Click += new System.EventHandler(this.BtnNilai_Click);
            // 
            // BtnKeluar
            // 
            this.BtnKeluar.Location = new System.Drawing.Point(624, 67);
            this.BtnKeluar.Name = "BtnKeluar";
            this.BtnKeluar.Size = new System.Drawing.Size(75, 23);
            this.BtnKeluar.TabIndex = 2;
            this.BtnKeluar.Text = "Log Out";
            this.BtnKeluar.UseVisualStyleBackColor = true;
            this.BtnKeluar.Click += new System.EventHandler(this.BtnKeluar_Click);
            // 
            // MenuMahasiswa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnKeluar);
            this.Controls.Add(this.BtnNilai);
            this.Controls.Add(this.BtnJadwal);
            this.Name = "MenuMahasiswa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuMahasiswa";
            this.Load += new System.EventHandler(this.MenuMahasiswa_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnJadwal;
        private System.Windows.Forms.Button BtnNilai;
        private System.Windows.Forms.Button BtnKeluar;
    }
}