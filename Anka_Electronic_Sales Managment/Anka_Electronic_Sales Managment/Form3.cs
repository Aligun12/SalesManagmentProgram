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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string username;
        
        private void kapat_buton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
         
        private void giris_buton_Click(object sender, EventArgs e)
        {
            
            if (txtpsw.Text=="" || txtusr.Text=="")
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifrenizi giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sorgu = "SELECT * FROM kullanicilar where usr=@user AND pwd=@pass";
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AnkaElectronics_Data;Integrated Security=True");
                SqlCommand cmd = new SqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@user", txtusr.Text);
                cmd.Parameters.AddWithValue("@pass", txtpsw.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Form1 frm1 = new Form1();
                    frm1.username= txtusr.Text;
                    MessageBox.Show("Başarılı bir şekilde giriş yaptınız.","",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    frm1.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                con.Close();
            }
            
        }

        private void add_usr_buton_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();

            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.AcceptButton = giris_buton;
        }
    }
}
