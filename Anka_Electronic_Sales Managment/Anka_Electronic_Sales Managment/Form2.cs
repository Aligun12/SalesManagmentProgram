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
    public partial class Form2 : Form
    {
        public Form1 frm1;
        public Form2()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AnkaElectronics_Data;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
        private void u_modeli_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (u_modeli_ekle_2.Text != "")
                {
                    SqlCommand kaydet = new SqlCommand(@"INSERT INTO  Veriler 
                    ([Ürün Modeli])
                    VALUES
                    (@urunmodeli)", con);
                    kaydet.Parameters.AddWithValue("@urunmodeli", u_modeli_ekle_2.Text);
                    con.Open();
                    kaydet.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Ürün Eklendi","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else 
                {
                    
                    MessageBox.Show("Ürün modeli boş bırakılamaz.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                

                }
                
            }
            catch (Exception hata )
            {
                MessageBox.Show("Ürün modeli boş bırakılamaz."+hata.ToString() , "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            urunekle();
            urunlist.Text = "";
            u_modeli_ekle_2.Text = "";

        }

        private void u_modeli_kapat_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        public void urunekle()
        {
            urunlist.Items.Clear();
            try
            {
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT *FROM Veriler";
                komut.Connection = con;
                komut.CommandType = CommandType.Text;
                SqlDataReader dr;
                con.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    urunlist.Items.Add(dr["Ürün Modeli"]);
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("HATA\n" + e);
                throw;
            }



        }
        void verisill(string table, string columnName, string text)
        {
            try
            {


                con.Open();
                SqlCommand command = new SqlCommand("DELETE FROM " + table + " WHERE " + columnName + " = '" + text + "'", con);
                command.ExecuteNonQuery();
                con.Close();
                urunekle();
                MessageBox.Show("Ürün Başarıyla Silindi","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                urunlist.Text = "";

            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("HATA : {0}", ex.Message), "HATA");
                throw;
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verisill("Veriler", "[Ürün Modeli]", urunlist.Text);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            urunekle();
        }
    }
}
