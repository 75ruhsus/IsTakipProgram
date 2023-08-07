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
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            YoneticiGiris frmYoneticiGiris = new YoneticiGiris();
            frmYoneticiGiris.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            KullanıcıGiris frmKullanıcıGiris = new KullanıcıGiris();
            frmKullanıcıGiris.Show();
            Hide();
        }

        private void Giriş_Load(object sender, EventArgs e)
        {

        }
    }
}
