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
    public partial class YoneticiPasif : Form
    {
        MySqlConnection baglanti = new MySqlConnection("server=localhost; port=3306; Database=burakabiproje; user Id=root; password=");
        public YoneticiPasif()
        {
            InitializeComponent();
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            YoneticiArayuz fr = new YoneticiArayuz();
            fr.Show();
        }

        private void YoneticiPasif_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from pasifis", baglanti);
            da.Fill(dt);
            listBox1.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                AktifIs aktif = new AktifIs();
                aktif.Id = (int)dr["id"];
                aktif.Title = dr["id"].ToString() + "\t" + dr["k_adi"] + "\t" + dr["konu"];
                aktif.gonderen = dr["gonderen"].ToString();
                aktif.tarih = dr["tarih"].ToString();
                aktif.bitis_tarihi = dr["bitis_tarihi"].ToString();
                aktif.konu = dr["konu"].ToString();
                aktif.mesaj = dr["mesaj"].ToString();
                listBox1.Items.Add(aktif);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AktifIs secilenIs = listBox1.SelectedItem as AktifIs;

            PasifPencere uu = new PasifPencere(secilenIs.Id, secilenIs.gonderen, secilenIs.tarih, secilenIs.bitis_tarihi, secilenIs.konu, secilenIs.mesaj);
            uu.ShowDialog();
        }
    }
}
