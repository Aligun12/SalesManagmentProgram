
namespace Anka_Electronic_Sales_Managment
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtusr = new System.Windows.Forms.TextBox();
            this.txtpsw = new System.Windows.Forms.TextBox();
            this.giris_buton = new System.Windows.Forms.Button();
            this.kapat_buton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.add_usr_buton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "KULLANICI ADI : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ŞİFRE : ";
            // 
            // txtusr
            // 
            this.txtusr.Location = new System.Drawing.Point(392, 51);
            this.txtusr.Name = "txtusr";
            this.txtusr.Size = new System.Drawing.Size(138, 20);
            this.txtusr.TabIndex = 3;
            // 
            // txtpsw
            // 
            this.txtpsw.Location = new System.Drawing.Point(392, 77);
            this.txtpsw.Name = "txtpsw";
            this.txtpsw.PasswordChar = '*';
            this.txtpsw.Size = new System.Drawing.Size(138, 20);
            this.txtpsw.TabIndex = 4;
            // 
            // giris_buton
            // 
            this.giris_buton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(22)))));
            this.giris_buton.Location = new System.Drawing.Point(297, 112);
            this.giris_buton.Name = "giris_buton";
            this.giris_buton.Size = new System.Drawing.Size(114, 28);
            this.giris_buton.TabIndex = 5;
            this.giris_buton.Text = "GİRİŞ";
            this.giris_buton.UseVisualStyleBackColor = true;
            this.giris_buton.Click += new System.EventHandler(this.giris_buton_Click);
            // 
            // kapat_buton
            // 
            this.kapat_buton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(22)))));
            this.kapat_buton.Location = new System.Drawing.Point(297, 146);
            this.kapat_buton.Name = "kapat_buton";
            this.kapat_buton.Size = new System.Drawing.Size(233, 28);
            this.kapat_buton.TabIndex = 6;
            this.kapat_buton.Text = "KAPAT";
            this.kapat_buton.UseVisualStyleBackColor = true;
            this.kapat_buton.Click += new System.EventHandler(this.kapat_buton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Anka_Electronic_Sales_Managment.Properties.Resources.isimli_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(251, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // add_usr_buton
            // 
            this.add_usr_buton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(22)))));
            this.add_usr_buton.Location = new System.Drawing.Point(417, 112);
            this.add_usr_buton.Name = "add_usr_buton";
            this.add_usr_buton.Size = new System.Drawing.Size(114, 28);
            this.add_usr_buton.TabIndex = 8;
            this.add_usr_buton.Text = "KULLANICI EKLE";
            this.add_usr_buton.UseVisualStyleBackColor = true;
            this.add_usr_buton.Click += new System.EventHandler(this.add_usr_buton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(22)))));
            this.ClientSize = new System.Drawing.Size(553, 193);
            this.Controls.Add(this.add_usr_buton);
            this.Controls.Add(this.kapat_buton);
            this.Controls.Add(this.giris_buton);
            this.Controls.Add(this.txtpsw);
            this.Controls.Add(this.txtusr);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtusr;
        private System.Windows.Forms.TextBox txtpsw;
        private System.Windows.Forms.Button giris_buton;
        private System.Windows.Forms.Button kapat_buton;
        private System.Windows.Forms.Button add_usr_buton;
    }
}