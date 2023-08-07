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
    public partial class PasifPencere : Form
    {
        public int id { get; set; }
        public String gonderen { get; set; }
        public String tarih { get; set; }
        public String bitis_tarihi { get; set; }
        public String konu { get; set; }
        public String mesaj { get; set; }

        MySqlConnection baglanti = new MySqlConnection("server=localhost; port=3306; Database=burakabiproje; user Id=root; password=");
        public PasifPencere(int secilenId, string secilenGonderen, string secilenTarih, string secilenBitis_tarihi, string secilenKonu, string secilenMesaj)
        {
            InitializeComponent();
            id = secilenId;
            gonderen = secilenGonderen;
            tarih = secilenTarih;
            bitis_tarihi = secilenBitis_tarihi;
            konu = secilenKonu;
            mesaj = secilenMesaj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PasifPencere_Load(object sender, EventArgs e)
        {
            textBox1.Text = gonderen.ToString();
            textBox2.Text = tarih.ToString();
            textBox5.Text = bitis_tarihi.ToString();
            textBox3.Text = konu.ToString();
            textBox4.Text = mesaj.ToString();
        }
    }
}
