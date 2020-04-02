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
    public partial class ogr_uyeol : MetroForm
    {

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;



        public ogr_uyeol()
        {
            InitializeComponent();
            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");
        }

        private void Ogr_uyeol_Load(object sender, EventArgs e)
        {
         
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txt_password.Text == txt_cPassword.Text)
            {
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into ogretmen( ogrkullaniciadi, ogrsifre, ogrmailadresi) values('" + txt_kullaniciadi.Text + "', '" + txt_password.Text + "', '" + txt_mailadresi.Text + "')";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(txt_kullaniciadi + " Hoşgeldin! üye oldunuz!");
                    girisyap form1 = new girisyap();//açılacak form
                                                    //bu formu parent olarak veriyoruz.
                    form1.Show(); //form 2 açılıyor.
                }
                con.Close();


            }
            else
            {
                MessageBox.Show("Şifreler birbirini tutmamaktadır.");

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ogr_girisyap girisyap = new ogr_girisyap();


            girisyap.Show();
            this.Hide();
        }
    }
}
