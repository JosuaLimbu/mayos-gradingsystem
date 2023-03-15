namespace Project
{
    partial class JadwalPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JadwalPage));
            this.grid_kls = new System.Windows.Forms.DataGridView();
            this.txt_src = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_closeApp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_kls)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_kls
            // 
            this.grid_kls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_kls.Location = new System.Drawing.Point(23, 223);
            this.grid_kls.Name = "grid_kls";
            this.grid_kls.Size = new System.Drawing.Size(698, 227);
            this.grid_kls.TabIndex = 0;
            // 
            // txt_src
            // 
            this.txt_src.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txt_src.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_src.Font = new System.Drawing.Font("Roboto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_src.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_src.Location = new System.Drawing.Point(29, 31);
            this.txt_src.Multiline = true;
            this.txt_src.Name = "txt_src";
            this.txt_src.Size = new System.Drawing.Size(199, 20);
            this.txt_src.TabIndex = 22;
            this.txt_src.Text = "Search By ID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.txt_src);
            this.panel1.Controls.Add(this.btn_closeApp);
            this.panel1.Location = new System.Drawing.Point(420, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 78);
            this.panel1.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Mono", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label3.Location = new System.Drawing.Point(32, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 38);
            this.label3.TabIndex = 25;
            this.label3.Text = "Your Classes";
            // 
            // btn_closeApp
            // 
            this.btn_closeApp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_closeApp.BackgroundImage")));
            this.btn_closeApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_closeApp.FlatAppearance.BorderSize = 0;
            this.btn_closeApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_closeApp.ForeColor = System.Drawing.Color.White;
            this.btn_closeApp.Location = new System.Drawing.Point(234, 29);
            this.btn_closeApp.Name = "btn_closeApp";
            this.btn_closeApp.Size = new System.Drawing.Size(25, 25);
            this.btn_closeApp.TabIndex = 23;
            this.btn_closeApp.UseVisualStyleBackColor = true;
            this.btn_closeApp.Click += new System.EventHandler(this.btn_closeApp_Click);
            // 
            // JadwalPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(749, 494);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grid_kls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JadwalPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JadwalPage";
            this.Load += new System.EventHandler(this.JadwalPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_kls)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_kls;
        private System.Windows.Forms.Button btn_closeApp;
        private System.Windows.Forms.TextBox txt_src;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}