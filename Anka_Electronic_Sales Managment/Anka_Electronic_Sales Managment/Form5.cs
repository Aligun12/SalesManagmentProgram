using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Anka_Electronic_Sales_Managment
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sifre_text.Text==""||sifretekrar_text.Text==""||usr_name.Text=="")
            {
                MessageBox.Show("Lütfen değer giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (sifretekrar_text.Text == sifre_text.Text)
                {
                    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AnkaElectronics_Data;Integrated Security=True");
                    SqlCommand kaydet = new SqlCommand(@"INSERT INTO  kullanicilar 
                    (usr,pwd)
                    VALUES
                    (@username,@password)", con);
                    kaydet.Parameters.AddWithValue("@username", usr_name.Text);
                    kaydet.Parameters.AddWithValue("@password", sifre_text.Text);
                    con.Open();
                    kaydet.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kayıt tamamlandı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Şifreler aynı değil.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }
    }
}
