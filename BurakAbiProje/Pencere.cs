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
    public partial class Pencere : Form
    {
        public int id { get; set; }     
        public String gonderen { get; set; }
        public String tarih { get; set; }
        public String bitis_tarihi { get; set; }
        public String konu { get; set; }
        public String mesaj { get; set; }

        MySqlConnection baglanti = new MySqlConnection("server=localhost; port=3306; Database=burakabiproje; user Id=root; password=");
        public Pencere(int secilenId,string secilenGonderen, string secilenTarih, string secilenBitis_tarihi, string secilenKonu, string secilenMesaj)
        {
            InitializeComponent();
            id = secilenId;
            gonderen = secilenGonderen;
            tarih = secilenTarih;
            bitis_tarihi = secilenBitis_tarihi;
            konu = secilenKonu;
            mesaj = secilenMesaj;
        }

        private void Pencere_Load(object sender, EventArgs e)
        {
            textBox1.Text = gonderen.ToString();
            textBox2.Text = tarih.ToString();
            textBox5.Text = bitis_tarihi.ToString();
            textBox3.Text = konu.ToString();
            textBox4.Text = mesaj.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DateTime simdi = DateTime.Now;
            DateTime basla = DateTime.Parse(tarih.ToString());
            try
            {
                MySqlCommand komut = new MySqlCommand("insert into pasifis(gonderen,tarih,k_adi,konu,bitis_tarihi,mesaj) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", basla);
                komut.Parameters.AddWithValue("@p3", KullanıcıGiris.loggerk.ToString());
                komut.Parameters.AddWithValue("@p4", textBox3.Text);
                komut.Parameters.AddWithValue("@p5", simdi);
                komut.Parameters.AddWithValue("@p6", textBox4.Text);
                komut.ExecuteNonQuery();
                MySqlCommand komut2 = new MySqlCommand("DELETE FROM aktifis WHERE id="+id+"",baglanti);
                komut2.ExecuteNonQuery();
                MessageBox.Show("İş Başarılı Bir Şekilde Bitirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("İş Bitirilemedi.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }
    }
}
