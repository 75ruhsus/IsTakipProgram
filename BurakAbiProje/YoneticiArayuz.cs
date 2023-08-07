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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BurakAbiProje
{
    public partial class YoneticiArayuz : Form
    {
        MySqlConnection baglanti = new MySqlConnection("server=localhost; port=3306; Database=burakabiproje; user Id=root; password=");
        public YoneticiArayuz()
        {
            InitializeComponent();
        }

        private void YoneticiArayuz_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("select k_adi from kullanici", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "k_adi";
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "k_adi";
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DateTime simdi = DateTime.Now;
            string selected = comboBox1.Text;
            try
            {
                MySqlCommand komut = new MySqlCommand("insert into aktifis(gonderen,tarih,k_adi,konu,bitis_tarihi,mesaj) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
                komut.Parameters.AddWithValue("@p1", YoneticiGiris.logger.ToString());
                komut.Parameters.AddWithValue("@p2", simdi);
                komut.Parameters.AddWithValue("@p3", selected);
                komut.Parameters.AddWithValue("@p4", textBox1.Text);
                komut.Parameters.AddWithValue("@p5", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@p6", textBox2.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("İş Başarılı Bir Şekilde Gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Bütün Boşlukları Eksiksiz ve Doğru Bir Şekilde Doldurun.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                MySqlCommand komut = new MySqlCommand("insert into kullanici(k_adi,sifre) values(@p1,@p2)", baglanti);
                komut.Parameters.AddWithValue("@p1", textBox3.Text);
                komut.Parameters.AddWithValue("@p2", textBox4.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Bütün Boşlukları Eksiksiz ve Doğru Bir Şekilde Doldurun.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            try
            {
                MySqlCommand komut = new MySqlCommand("DELETE from kullanici where k_adi='"+textBox3.Text+"'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Bütün Boşlukları Eksiksiz ve Doğru Bir Şekilde Doldurun.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            baglanti.Close();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void oturumuKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Giriş frmGiris = new Giriş();
            frmGiris.Show();
        }

        private void aktifİşlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            YoneticiAktif frmAktif = new YoneticiAktif();
            frmAktif.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pasifİşlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            YoneticiPasif frm = new YoneticiPasif();
            frm.Show();
        }
    }
}
