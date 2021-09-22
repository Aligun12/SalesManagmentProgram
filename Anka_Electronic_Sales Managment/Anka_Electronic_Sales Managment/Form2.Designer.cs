
namespace Anka_Electronic_Sales_Managment
{
    partial class Form2
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
            this.u_modeli_ekle_2 = new System.Windows.Forms.TextBox();
            this.u_model_ekle_1 = new System.Windows.Forms.Label();
            this.u_modeli_ekle = new System.Windows.Forms.Button();
            this.u_modeli_kapat = new System.Windows.Forms.Button();
            this.urunlist = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // u_modeli_ekle_2
            // 
            this.u_modeli_ekle_2.Location = new System.Drawing.Point(88, 6);
            this.u_modeli_ekle_2.Name = "u_modeli_ekle_2";
            this.u_modeli_ekle_2.Size = new System.Drawing.Size(100, 20);
            this.u_modeli_ekle_2.TabIndex = 0;
            // 
            // u_model_ekle_1
            // 
            this.u_model_ekle_1.AutoSize = true;
            this.u_model_ekle_1.Location = new System.Drawing.Point(12, 9);
            this.u_model_ekle_1.Name = "u_model_ekle_1";
            this.u_model_ekle_1.Size = new System.Drawing.Size(70, 13);
            this.u_model_ekle_1.TabIndex = 1;
            this.u_model_ekle_1.Text = "Ürün Modeli :";
            // 
            // u_modeli_ekle
            // 
            this.u_modeli_ekle.Location = new System.Drawing.Point(12, 32);
            this.u_modeli_ekle.Name = "u_modeli_ekle";
            this.u_modeli_ekle.Size = new System.Drawing.Size(176, 23);
            this.u_modeli_ekle.TabIndex = 2;
            this.u_modeli_ekle.Text = "EKLE";
            this.u_modeli_ekle.UseVisualStyleBackColor = true;
            this.u_modeli_ekle.Click += new System.EventHandler(this.u_modeli_ekle_Click);
            // 
            // u_modeli_kapat
            // 
            this.u_modeli_kapat.Location = new System.Drawing.Point(88, 61);
            this.u_modeli_kapat.Name = "u_modeli_kapat";
            this.u_modeli_kapat.Size = new System.Drawing.Size(176, 23);
            this.u_modeli_kapat.TabIndex = 3;
            this.u_modeli_kapat.Text = "KAPAT";
            this.u_modeli_kapat.UseVisualStyleBackColor = true;
            this.u_modeli_kapat.Click += new System.EventHandler(this.u_modeli_kapat_Click);
            // 
            // urunlist
            // 
            this.urunlist.FormattingEnabled = true;
            this.urunlist.Location = new System.Drawing.Point(210, 5);
            this.urunlist.Name = "urunlist";
            this.urunlist.Size = new System.Drawing.Size(121, 21);
            this.urunlist.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "SİL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 98);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.urunlist);
            this.Controls.Add(this.u_modeli_kapat);
            this.Controls.Add(this.u_modeli_ekle);
            this.Controls.Add(this.u_model_ekle_1);
            this.Controls.Add(this.u_modeli_ekle_2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Ürün Ekle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox u_modeli_ekle_2;
        private System.Windows.Forms.Label u_model_ekle_1;
        private System.Windows.Forms.Button u_modeli_ekle;
        private System.Windows.Forms.Button u_modeli_kapat;
        private System.Windows.Forms.ComboBox urunlist;
        private System.Windows.Forms.Button button1;
    }
}