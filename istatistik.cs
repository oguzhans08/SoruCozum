using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;//2
using System.Data.SqlClient;

namespace SoruProjesiYon
{
    public partial class istatistik : MetroForm
    {

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public string kullaniciAdi { get; set; }
        public int dogrusayi { get; set; }
        public int yanlissayi { get; set; }
        public istatistik()
        {
            InitializeComponent();
            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");
        }

        private void İstatistik_Load(object sender, EventArgs e)
        {
            MessageBox.Show(kullaniciAdi);
            chart1.Titles.Add("Doğru/Yanlış İstatistiğiniz");
            chart1.Series["s1"].Points.AddXY("Yanlış", yanlissayi);
            chart1.Series["s1"].Points.AddXY("Doğru", dogrusayi);
            lbl_dogrusayisi.Text = dogrusayi.ToString(); 
            lbl_yanlissayisi.Text = yanlissayi.ToString();
            //dogrucevap

        
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con; //insert
            cmd.CommandText = "UPDATE uyeler SET dogrucevap='" + lbl_dogrusayisi.Text + "', yanliscevap='" + lbl_yanlissayisi.Text + "' WHERE kullaniciadi='" + kullaniciAdi + "'";
            dr = cmd.ExecuteReader();

            con.Close();





        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
