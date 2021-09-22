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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using SelectPdf;
using HandlebarsDotNet;
using System.Web;

namespace Anka_Electronic_Sales_Managment
{
    public partial class Form1 : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AnkaElectronics_Data;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
        string  musteritablo, uruntablo;
        string[] garantisure = {"1 Ay","3 Ay","6 Ay","1 Yıl","2 Yıl","3 Yıl","4 Yıl","5 Yıl"};
        public string username;
        private bool Kapatsorgu;
        DialogResult dr = System.Windows.Forms.DialogResult.No;
        bool kontrol__2 = true;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            usr_label.Text = username;
            musteritablo = "Musteri_Kaydi";
            uruntablo = "Ürün_Tablosu"; 
            griddoldur(uruntablo,u_table);
            griddoldur(musteritablo,m_tablo);
            urunler();
            u_garanti.Items.AddRange(garantisure);
            string saat = DateTime.Now.ToString("HH_mm_ss");
            string tarih = DateTime.Now.ToString("dd_MM_yyyy");
            excelaktarma(saat + " " + tarih, uruntablo);
            excelaktarma(saat +" "+tarih,musteritablo);
            kontrol();

        }
        public void kontrol()
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Select * From Ürün_Tablosu where [Ürün Modeli] like '%" + "Sprint Booster" + "%'", con);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
            }
            else
            {
                dr.Close();
                con.Close();
                MessageBox.Show("Stokta Sprint Booster bulunamadı.", "Arama Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Open();
             komut = new SqlCommand("Select * From Ürün_Tablosu where [Ürün Modeli] like '%" + "Hava Filtresi" + "%'", con);
             dr = komut.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
            }
            else
            {
                dr.Close();
                con.Close();
                MessageBox.Show("Stokta Hava Filtresi bulunamadı.", "Arama Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void kontrol_2(string serino)
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Select * From Ürün_Tablosu where [Ürün Seri Numarası] like '%" + serino + "%'", con);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                MessageBox.Show("Aynı seri numarası.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kontrol__2 = false;
            }
            else
            {
                kontrol__2 = true;
                dr.Close();
                con.Close();
                
            }
        }
        public void excelaktarma(string tarih,string tablo) 
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            Int16 i, j;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            for (i = 0; i <= u_table.RowCount - 2; i++)
            {
                for (j = 0; j <= u_table.ColumnCount - 1; j++)
                {
                    xlWorkSheet.Cells[i + 1, j + 1] = u_table[j, i].Value.ToString();
                }
            }
            
            string pathh = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!(System.IO.Directory.Exists(pathh+@"\AnkaElectronic\Backups\")))
            {
                System.IO.Directory.CreateDirectory(pathh + @"\AnkaElectronic\Backups\");
            }
            xlWorkBook.SaveAs(pathh+@"\AnkaElectronic\Backups\"+tarih+"_"+tablo+".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        public void urunler()
        {
            try
            {
                u_modeli.Items.Clear();
                m_userino.Items.Clear();
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT *FROM Veriler";
                komut.Connection = con;
                komut.CommandType = CommandType.Text;
                SqlDataReader dr;
                con.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    u_modeli.Items.Add(dr["Ürün Modeli"]);
                }
                con.Close();
                komut.CommandText = "SELECT *FROM Ürün_Tablosu";
                komut.Connection = con;
                komut.CommandType = CommandType.Text;
                con.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                     m_userino.Items.Add(dr["Ürün Seri Numarası"]);
                }
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("HATA\n"+e);
                throw;
            }
            


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      

        private void m_ekle_Click(object sender, EventArgs e)
        {
            veriekle();
        }

        void veriekle()
        {
            try
            {
                if (m_ad.Text=="" || m_soyad.Text=="" || m_plaka.Text=="" || m_sasino.Text=="" || m_telno.Text=="" || m_userino.Text=="" || m_satisfiyat.Text == "" || m_email.Text=="")
                {
                    
                    MessageBox.Show("Lütfen değer giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand kaydet = new SqlCommand(@"INSERT INTO  Musteri_Kaydi 
                    (Ad,Soyad,Plaka,[Şasi Numarası],[Telefon numarası],[E Posta],[Satış Tarihi],[Ürün Seri Numarası],[Satış Fiyatı],[Ekstra Notlar])
                    VALUES
                    (@ad, @soyad, @plaka, @sasino, @telno,@email, @satistarihi, @serino, @usatis,@ekstranot)", con);
                    kaydet.Parameters.AddWithValue("@ad", m_ad.Text);
                    kaydet.Parameters.AddWithValue("@soyad", m_soyad.Text);
                    kaydet.Parameters.AddWithValue("@plaka", m_plaka.Text);
                    kaydet.Parameters.AddWithValue("@sasino", m_sasino.Text);
                    kaydet.Parameters.AddWithValue("@telno", m_telno.Text);
                    kaydet.Parameters.AddWithValue("@email", m_email.Text);
                    kaydet.Parameters.AddWithValue("@ekstranot", m_ekstranot.Text);
                    kaydet.Parameters.AddWithValue("@satistarihi", m_satistarih.Value);
                    kaydet.Parameters.AddWithValue("@serino", m_userino.Text);
                    kaydet.Parameters.Add("@usatis", SqlDbType.Money).Value = Decimal.Parse(m_satisfiyat.Text);
                    con.Open();
                    kaydet.ExecuteNonQuery();
                    con.Close();
                    griddoldur(uruntablo, u_table);
                    griddoldur(musteritablo, m_tablo);
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Lütfen değer giriniz." + e, "HATA");
                throw;
            }
            
        }
        void veriekle_2()
        {
            try
            {
                if (u_modeli.Text == "" || u_serino.Text == "" || u_garanti.Text == "" || u_extranot.Text == "" || u_miktar.Text == "" || u_bfiyat.Text == "")
                {
                    
                    MessageBox.Show("Lütfen değer giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    kontrol_2(u_serino.Text);
                    if (kontrol__2)
                    {
                        SqlCommand kaydet = new SqlCommand(@"INSERT INTO  Ürün_Tablosu 
                        ([Ürün Modeli],[Ürün Seri Numarası],[Giriş Tarihi],[Garanti Süresi],[Ekstra Notlar],Miktar,[Ürün Birim Alış Fiyatı])
                        VALUES
                        (@u_model, @u_serino, @u_giris, @u_garanti, @u_extranot, @u_miktar,@u_birimfiyat)", con);
                        kaydet.Parameters.AddWithValue("@u_model", u_modeli.Text);
                        kaydet.Parameters.AddWithValue("@u_serino", u_serino.Text);
                        kaydet.Parameters.AddWithValue("@u_giris", u_girist.Value);
                        kaydet.Parameters.AddWithValue("@u_garanti", u_garanti.Text);
                        kaydet.Parameters.AddWithValue("@u_extranot", u_extranot.Text);
                        kaydet.Parameters.AddWithValue("@u_miktar", u_miktar.Text);
                        kaydet.Parameters.Add("@u_birimfiyat", SqlDbType.Money).Value = Decimal.Parse(u_bfiyat.Text);
                        con.Open();
                        kaydet.ExecuteNonQuery();
                        con.Close();
                        griddoldur(uruntablo, u_table);
                        griddoldur(musteritablo, m_tablo);
                    }
                    

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lütfen değer giriniz."+e, "HATA");
                throw;
            }
            
            
            
        }

        private void u_ekle_Click(object sender, EventArgs e)
        {
            veriekle_2();
        }

        void griddoldur(string table, DataGridView grid)
        {
            
            da = new SqlDataAdapter("Select *From " + table, con);
            ds = new DataSet(); ;
            con.Open();
            da.Fill(ds, table);
            grid.DataSource = ds.Tables[table];
            con.Close();
            urunler();
        }

        private void u_sil_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Kayıt silinsin mi?","UYARI",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialog==DialogResult.Yes)
            {
                con.Open();
                SqlCommand komut = new SqlCommand("Select * From Musteri_Kaydi where [Ürün Seri Numarası] like '%" + u_serino.Text + "%'", con);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    /*con.Close();
                    verisil(musteritablo, "[Ürün Seri Numarası]", u_serino.Text, m_tablo);*/
                    MessageBox.Show("Bu seri numaralı ürün müsteri tablosunda mevcut. Lütfen önce müşteri kaydını siliniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                else
                {
                    con.Close();
                    verisil(uruntablo, "[Ürün Modeli]", u_modeli.Text, u_table);
                }
            }
            u_modeli.SelectedItem = "";
            u_serino.Text = "";
            u_girist.Value = DateTime.Now;
            u_garanti.SelectedItem = "";
            u_extranot.Text = "";
            u_miktar.Text = "";
            u_bfiyat.Text = "";
        }

        private void m_sil_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Kayıt silinsin mi?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                verisil(musteritablo, "Ad", m_ad.Text, m_tablo);
            }
            m_ad.Text = "";
            m_soyad.Text = "";
            m_plaka.Text = "";
            m_sasino.Text = "";
            m_telno.Text = "";
            m_satistarih.Value = DateTime.Now;
            m_userino.Text = "";
            m_satisfiyat.Text = "";
        }

        private void u_table_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (u_table.CurrentRow.Cells[0].Value.ToString() != "")
                {
                    u_modeli.SelectedItem = u_table.CurrentRow.Cells[0].Value.ToString();
                    u_serino.Text = u_table.CurrentRow.Cells[1].Value.ToString();
                    u_girist.Value = Convert.ToDateTime(u_table.CurrentRow.Cells[2].Value);
                    u_garanti.SelectedItem = u_table.CurrentRow.Cells[3].Value.ToString();
                    u_extranot.Text = u_table.CurrentRow.Cells[4].Value.ToString();
                    u_miktar.Text = u_table.CurrentRow.Cells[5].Value.ToString();
                    u_bfiyat.Text = u_table.CurrentRow.Cells[6].Value.ToString();
                }
                else 
                {
                    
                    MessageBox.Show("Boş satırı seçmeyiniz. ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("HATA : BOŞ SATIRINI SEÇMEYİNİZ\n{0}",ex.Message),"HATA:");
                throw;
            } 
        }

        private void m_tablo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (m_tablo.CurrentRow.Cells[0].Value.ToString() != "")
                {
                    m_ad.Text = m_tablo.CurrentRow.Cells[0].Value.ToString();
                    m_soyad.Text = m_tablo.CurrentRow.Cells[1].Value.ToString();
                    m_plaka.Text = m_tablo.CurrentRow.Cells[2].Value.ToString();
                    m_sasino.Text = m_tablo.CurrentRow.Cells[3].Value.ToString();
                    m_telno.Text = m_tablo.CurrentRow.Cells[4].Value.ToString();
                    m_email.Text = m_tablo.CurrentRow.Cells[5].Value.ToString();
                    m_satistarih.Value = Convert.ToDateTime(m_tablo.CurrentRow.Cells[6].Value);
                    m_userino.Text= m_tablo.CurrentRow.Cells[7].Value.ToString();
                    m_satisfiyat.Text= m_tablo.CurrentRow.Cells[8].Value.ToString();
                    m_ekstranot.Text = m_tablo.CurrentRow.Cells[9].Value.ToString();
                    
                }
                else
                {

                    MessageBox.Show("Boş satırı seçmeyiniz. ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("HATA : BOŞ SATIRINI SEÇMEYİNİZ\n{0}", ex.Message), "HATA");
                throw;
            }
        }

        private void urunmodeliekle_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            urunler();
        }

        private void u_miktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void u_bfiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m_telno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m_alisfiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void m_ad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void m_soyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void u_duzenle_Click(object sender, EventArgs e)
        {
            update();
            
        }
        public void update()
        {
            try
            {
                
                if (u_modeli.Text == "" || u_serino.Text == "" || u_garanti.Text == "" || u_extranot.Text == "" || u_miktar.Text == "" || u_bfiyat.Text == "")
                {

                    MessageBox.Show("Lütfen değer giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    SqlCommand kaydet = new SqlCommand(@"UPDATE Ürün_Tablosu SET [Ürün Modeli]=@u_model,[Ürün Seri Numarası]=@u_serino,[Giriş Tarihi]=@u_giris,[Garanti Süresi]=@u_garanti,[Ekstra Notlar]=@u_extranot,Miktar=@u_miktar,[Ürün Birim Alış Fiyatı]=@u_birimfiyat", con);
                    kaydet.Parameters.AddWithValue("@u_model", u_modeli.Text);
                    kaydet.Parameters.AddWithValue("@u_serino", u_serino.Text);
                    kaydet.Parameters.AddWithValue("@u_giris", u_girist.Value);
                    kaydet.Parameters.AddWithValue("@u_garanti", u_garanti.Text);
                    kaydet.Parameters.AddWithValue("@u_extranot", u_extranot.Text);
                    kaydet.Parameters.AddWithValue("@u_miktar", u_miktar.Text);
                    kaydet.Parameters.Add("@u_birimfiyat", SqlDbType.Money).Value = Decimal.Parse(u_bfiyat.Text);
                    kaydet.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Ürün Kaydı düzenlendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    griddoldur(uruntablo, u_table);
                    griddoldur(musteritablo, m_tablo);

                }
            }
            catch (Exception)
            {

                throw;
            }
            


        }
        public void update2()
        {
            try
            {
                if (m_ad.Text == "" || m_soyad.Text == "" || m_plaka.Text == "" || m_sasino.Text == "" || m_telno.Text == "" || m_userino.Text == "" || m_satisfiyat.Text == "")
                {

                    MessageBox.Show("Lütfen değer giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand kaydet = new SqlCommand(@"UPDATE Musteri_Kaydi SET Ad=@ad,Soyad=@soyad,Plaka=@plaka,[Şasi Numarası]=@sasino,[Telefon numarası]=@telno,[Satış Tarihi]=@satistarihi,[Ürün Seri Numarası]=@serino,[Satış Fiyatı]=@usatis",con);
                    kaydet.Parameters.AddWithValue("@ad", m_ad.Text);
                    kaydet.Parameters.AddWithValue("@soyad", m_soyad.Text);
                    kaydet.Parameters.AddWithValue("@plaka", m_plaka.Text);
                    kaydet.Parameters.AddWithValue("@sasino", m_sasino.Text);
                    kaydet.Parameters.AddWithValue("@telno", m_telno.Text);
                    kaydet.Parameters.AddWithValue("@satistarihi", m_satistarih.Value);
                    kaydet.Parameters.AddWithValue("@serino", m_userino.Text);
                    kaydet.Parameters.Add("@usatis", SqlDbType.Money).Value = Decimal.Parse(m_satisfiyat.Text);
                    con.Open();
                    kaydet.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Müşteri kaydı düzenlendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    griddoldur(uruntablo, u_table);
                    griddoldur(musteritablo, m_tablo);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Lütfen değer giriniz." + e, "HATA");
                throw;
            }



        }

        private void m_edit_Click(object sender, EventArgs e)
        {
            update2();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void arama_but_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label22.Text = DateTime.Now.ToString("HH:mm:ss");
            label23.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void arama_but_Click_1(object sender, EventArgs e)
        {
            if (a_sasino.Text == "" && a_serino.Text == "")
            {
                MessageBox.Show("Lütfen aramak istediğiniz değeri giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (a_sasino.Text != "" && a_serino.Text != "")
                {
                    MessageBox.Show("İki değerden sadece birine göre arama yapınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (a_serino.Text != "")
                    {
                        con.Open();
                        SqlCommand komut = new SqlCommand("Select * From Ürün_Tablosu where [Ürün Seri Numarası] like '%" + a_serino.Text + "%'", con);

                        SqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            dr.Close();
                            da = new SqlDataAdapter(komut);
                            ds = new DataSet();
                            da.Fill(ds);
                            arama_tablo.DataSource = ds.Tables[0];
                            con.Close();

                            MessageBox.Show("Seri numarasına ait " + (arama_tablo.RowCount - 1).ToString() + " adet kayıt bulundu.", "Arama Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dr.Close();
                            con.Close();
                            MessageBox.Show("Kayıt bulunamadı.", "Arama Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (a_sasino.Text != "")
                    {
                        con.Open();
                        SqlCommand komut = new SqlCommand("Select * From Musteri_Kaydi where [Şasi Numarası] like '%" + a_sasino.Text + "%'", con);
                        SqlDataReader dr = komut.ExecuteReader();
                        if (dr.Read())
                        {
                            dr.Close();
                            da = new SqlDataAdapter(komut);
                            ds = new DataSet();
                            da.Fill(ds);
                            arama_tablo.DataSource = ds.Tables[0];
                            con.Close();
                            MessageBox.Show("Şasi numrasına ait " + (arama_tablo.RowCount - 1).ToString() + " adet kayıt bulundu.", "Arama Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dr.Close();
                            con.Close();
                            MessageBox.Show("Kayıt bulunamadı.", "Arama Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                }


            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Kapatsorgu)
            {
                if (!Kapatsorgu)
                {
                    dr = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    Kapatsorgu = dr == System.Windows.Forms.DialogResult.Yes;
                }
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    if (Kapatsorgu)
                    {
                        Application.Exit();
                        string saat = DateTime.Now.ToString("HH_mm_ss");
                        string tarih = DateTime.Now.ToString("dd_MM_yyyy");
                        excelaktarma(saat + " " + tarih, uruntablo);
                        excelaktarma(saat + " " + tarih, musteritablo);
                    }
                    Kapatsorgu = false;
                }
                else
                {
                    e.Cancel = true;
                }

            }

        }

        private void m_excel_Click(object sender, EventArgs e)
        {
            string saat = DateTime.Now.ToString("HH_mm_ss");
            string tarih = DateTime.Now.ToString("dd_MM_yyyy");
            excelaktarma(saat + " " + tarih, musteritablo);
            MessageBox.Show("Excel dosyası başarıyla alındı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }   

        private void u_excel_Click(object sender, EventArgs e)
        {
            
            string saat = DateTime.Now.ToString("HH_mm_ss");
            string tarih = DateTime.Now.ToString("dd_MM_yyyy");
            excelaktarma(saat + " " + tarih, uruntablo);
            MessageBox.Show("Excel dosyası başarıyla alındı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        void verisil(string table, string columnName,string text,DataGridView dgv)
        {
            try
            {

                
                con.Open();
                SqlCommand command = new SqlCommand("DELETE FROM " + table + " WHERE " + columnName + " = '" + text + "'", con);
                command.ExecuteNonQuery();
                con.Close();
                griddoldur(table, dgv);
                
            }
            catch (SystemException ex)
            {
                MessageBox.Show(string.Format("HATA : {0}", ex.Message),"HATA");
                throw;
            }
        }
        public void pdfolustur()
        {
            umodelicekme();
            string pathh = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string source = System.IO.File.ReadAllText(pathh + @"\AnkaElectronic\data\fatura.html");
            var template = Handlebars.Compile(source);
            var data = new
            {
                tarih = DateTime.Now.ToString("dd/MM/yyyy"),
                n_surname = m_ad.Text + " " + m_soyad.Text,
                tel_no = m_telno.Text,
                plaka= m_plaka.Text,
                sasino = m_sasino.Text,
                email = m_email.Text,
                fligran = pathh+ @"\AnkaElectronic\data\img\fligran.png",
                cizgi = pathh + @"\AnkaElectronic\data\img\cizgi.png",
                cizgi2 = pathh + @"\AnkaElectronic\data\img\cizgi2.png",
                cizgi3 = pathh + @"\AnkaElectronic\data\img\cizgi3.png",
                logo = pathh + @"\AnkaElectronic\data\img\f_logo.png",
                userinu=m_userino.Text,
                umodel= arama_tablo.Rows[0].Cells[0].Value.ToString(),
                garantis = arama_tablo.Rows[0].Cells[3].Value.ToString(),
                urunadeti = "1",
                not = m_ekstranot.Text,
                gonderenk = usr_label.Text,
                toplamtutar =m_satisfiyat.Text+" ₺",
            };
            arama_tablo.Columns.Clear();
            arama_tablo.Refresh();
            var result = template(data);
            Html2Pdf(result, m_ad.Text + "_" + m_soyad.Text+"_");
            MessageBox.Show("Fatura PDF olarak hazırlandı.\n "+pathh+ @"\AnkaElectronic\data\pdf\" + m_ad.Text + "_" + m_soyad.Text + "_" + ".pdf", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void Html2Pdf(string temp,string madi)
        {
            string pathh = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(temp);
            doc.Save(pathh+@"\AnkaElectronic\data\pdf\"+madi+".pdf");
        }
        public void umodelicekme()
        {
            if (m_userino.Text != "")
            {
                con.Open();
                SqlCommand komut = new SqlCommand("Select * From Ürün_Tablosu where [Ürün Seri Numarası] like '%" + m_userino.Text + "%'", con);

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    da = new SqlDataAdapter(komut);
                    ds = new DataSet();
                    da.Fill(ds);
                    arama_tablo.DataSource = ds.Tables[0];
                    con.Close();
                }

            }
            
        }
        private void m_formcikart_Click(object sender, EventArgs e)
        {
            if (m_ad.Text == "" || m_soyad.Text == "" || m_plaka.Text == "" || m_sasino.Text == "" || m_telno.Text == "" || m_userino.Text == "" || m_satisfiyat.Text == "")
            {

                MessageBox.Show("Lütfen müşteri seçiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pdfolustur();
            }
            
        }

        
        
    }
    
}
