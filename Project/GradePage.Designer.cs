namespace Project
{
    partial class GradePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GradePage));
            this.Grade = new System.Windows.Forms.DataGridView();
            this.txt_src = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_src = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grade)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grade
            // 
            this.Grade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grade.Location = new System.Drawing.Point(35, 155);
            this.Grade.Name = "Grade";
            this.Grade.Size = new System.Drawing.Size(646, 304);
            this.Grade.TabIndex = 0;
            // 
            // txt_src
            // 
            this.txt_src.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_src.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.txt_src.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_src.Font = new System.Drawing.Font("Roboto Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_src.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.txt_src.Location = new System.Drawing.Point(29, 28);
            this.txt_src.Multiline = true;
            this.txt_src.Name = "txt_src";
            this.txt_src.Size = new System.Drawing.Size(197, 20);
            this.txt_src.TabIndex = 12;
            this.txt_src.Text = "Search By ID";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btn_src);
            this.panel1.Controls.Add(this.txt_src);
            this.panel1.Location = new System.Drawing.Point(385, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 72);
            this.panel1.TabIndex = 14;
            // 
            // btn_src
            // 
            this.btn_src.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_src.BackgroundImage")));
            this.btn_src.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_src.FlatAppearance.BorderSize = 0;
            this.btn_src.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_src.ForeColor = System.Drawing.Color.White;
            this.btn_src.Location = new System.Drawing.Point(232, 26);
            this.btn_src.Name = "btn_src";
            this.btn_src.Size = new System.Drawing.Size(25, 25);
            this.btn_src.TabIndex = 22;
            this.btn_src.UseVisualStyleBackColor = true;
            this.btn_src.Click += new System.EventHandler(this.btn_src_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Mono", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label3.Location = new System.Drawing.Point(32, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 38);
            this.label3.TabIndex = 17;
            this.label3.Text = "Students Grade";
            // 
            // GradePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(749, 494);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Grade);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GradePage";
            this.Text = "GradePage";
            this.Load += new System.EventHandler(this.GradePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grade)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grade;
        private System.Windows.Forms.TextBox txt_src;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_src;
        private System.Windows.Forms.Label label3;
    }
}