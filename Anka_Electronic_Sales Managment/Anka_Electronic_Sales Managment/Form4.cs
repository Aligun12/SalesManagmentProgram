using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anka_Electronic_Sales_Managment
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private string key = "NP3O72y1zvEEJ78L1NEJBbfDoYoGwaaB";
        private void Form4_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == key)
            {
                MessageBox.Show("Key doğrulandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form5 form5 = new Form5();
                this.Hide();
                form5.Show();
            }
            else
            {
                MessageBox.Show("Key yanlış girildi.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
