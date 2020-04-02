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
    public partial class ogr_girisyap : MetroForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public ogr_girisyap()
        {
            InitializeComponent();
            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");

        }

        private void Ogr_girisyap_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ogr_uyeol ogruyeol = new ogr_uyeol();//açılacak form
                                                 //bu formu parent olarak veriyoruz.
            ogruyeol.Show(); //form 2 açılıyor.
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string user = txt_ogrkullaniciadi.Text;
            string pass = txt_ogrsifre.Text;


            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM ogretmen where ogrkullaniciadi='" + txt_ogrkullaniciadi.Text + "' AND ogrsifre='" + txt_ogrsifre.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ogr_panel_secim ogr_panel_secim = new ogr_panel_secim();

                ogr_panel_secim.kullaniciAdi = txt_ogrkullaniciadi.Text;
                ogr_panel_secim.Show();
                this.Hide();



            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");
            }
            con.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            girisyap girisyap = new girisyap();

          
            girisyap.Show();
            this.Hide();
        }
    }
}
