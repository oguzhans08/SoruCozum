using MetroFramework.Forms;
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

namespace SoruProjesiYon
{
    public partial class ogr_panel_secim : MetroForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public ogr_panel_secim()
        {
            InitializeComponent();
            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");

        }
        public string kullaniciAdi { get; set; }
        private void Ogr_panel_secim_Load(object sender, EventArgs e)
        {
            lbl_ogradi.Text = kullaniciAdi;

        }

        private void Btn_dersler_secim_Click(object sender, EventArgs e)
        {
            ogr_secim_dersler ogr_secim_dersler = new ogr_secim_dersler();

            ogr_secim_dersler.kullaniciAdi = kullaniciAdi;
            ogr_secim_dersler.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            org_secim_ogrenci org_secim_ogrenci = new org_secim_ogrenci();

            //org_secim_ogrenci.kullaniciAdi = textBox1.Text;
            org_secim_ogrenci.Show();
            this.Hide();
        }
    }
}
