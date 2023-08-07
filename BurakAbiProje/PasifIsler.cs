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
    public partial class PasifIsler : Form
    {
        MySqlConnection baglanti = new MySqlConnection("server=localhost; port=3306; Database=burakabiproje; user Id=root; password=");
        public PasifIsler()
        {
            InitializeComponent();
        }

        private void geriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            KullanıcıArayüz frmKullanıcıArayüz = new KullanıcıArayüz();
            frmKullanıcıArayüz.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PasifIs secilenIs = listBox1.SelectedItem as PasifIs;

            PasifPencere uu = new PasifPencere(secilenIs.Id, secilenIs.gonderen, secilenIs.tarih, secilenIs.bitis_tarihi, secilenIs.konu, secilenIs.mesaj);
            uu.ShowDialog();
        }

        private void PasifIsler_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from pasifis where k_adi='" + KullanıcıGiris.loggerk.ToString() + "'", baglanti);
            da.Fill(dt);
            listBox1.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                PasifIs aktif = new PasifIs();
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
        public class PasifIs
        {
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
