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
    public partial class KullanıcıArayüz : Form
    {
        MySqlConnection baglanti = new MySqlConnection("server=localhost; port=3306; Database=burakabiproje; user Id=root; password=");
        public KullanıcıArayüz()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktifIs secilenIs = listBox1.SelectedItem as AktifIs;

            Pencere uu = new Pencere(secilenIs.Id, secilenIs.gonderen, secilenIs.tarih, secilenIs.bitis_tarihi, secilenIs.konu, secilenIs.mesaj);
            uu.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
  
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void KullanıcıArayüz_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from aktifis where k_adi='"+KullanıcıGiris.loggerk.ToString()+"'", baglanti);
            da.Fill(dt);
            listBox1.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                AktifIs aktif = new AktifIs();
                aktif.Id = (int)dr["id"];
                aktif.Title = dr["id"].ToString() + "\t" + dr["gonderen"] + "\t" + dr["konu"];
                aktif.gonderen = dr["gonderen"].ToString();
                aktif.tarih = dr["tarih"].ToString();
                aktif.bitis_tarihi = dr["bitis_tarihi"].ToString();
                aktif.konu = dr["konu"].ToString();
                aktif.mesaj = dr["mesaj"].ToString();
                listBox1.Items.Add(aktif);
            }
        }

        private void oturumuKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Giriş frmGiris = new Giriş();
            frmGiris.Show();
        }

        private void kullanıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            PasifIsler frmPasif = new PasifIsler();
            frmPasif.Show();
        }
    }

    public class AktifIs {
        public int Id { get; set; }
        public String Title { get; set; }
        public String gonderen { get; set; }
        public String tarih { get; set; }
        public String bitis_tarihi { get; set; }
        public String konu { get; set; }
        public String mesaj { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
