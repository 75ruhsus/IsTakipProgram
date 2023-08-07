using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BurakAbiProje
{
    public partial class YoneticiGiris : Form
    {
        public static string logger;

        MySqlConnection baglanti = new MySqlConnection("server=localhost; port=3306; Database=burakabiproje; user Id=root; password=");
        public YoneticiGiris()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giriş frmGiris = new Giriş();
            frmGiris.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool blnfound = false;
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand("select * from yonetici where k_adi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'", baglanti);
            MySqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                string login = dr["k_adi"].ToString();
                logger = login;
                blnfound = true;
                YoneticiArayuz frmArayuz = new YoneticiArayuz();
                frmArayuz.Show();
                Hide();
            }
            if (blnfound == false)
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış. Lütfen tekrar deneyiniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dr.Close();
            baglanti.Close();
        }

        private void YoneticiGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
