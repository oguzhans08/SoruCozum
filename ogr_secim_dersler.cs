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
    public partial class ogr_secim_dersler : MetroForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;



        public ogr_secim_dersler()
        {
            InitializeComponent();
            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");
        }

        private void Ogr_secim_dersler_Load(object sender, EventArgs e)
        {
            








        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ogr_panel_secim ogr_panel_secim = new ogr_panel_secim();
            ogr_panel_secim.Show();
            this.Hide();
        }

        private void Btn_soruekle_Click(object sender, EventArgs e)
        {
           if( txt_soru.TextLength == 0 || txt_cevap_a.TextLength == 0 || txt_cevap_b.TextLength==0 || txt_cevap_c.TextLength==0 || txt_cevap_d.TextLength==0 || txt_dogrucevap.TextLength==0)
            {
                MessageBox.Show("Lütfen eksikleri tamamlayınız.");

          
        }
            else
            {

                //id, soru_icerik, dogru_cevap, cevap1 cevap2 cevap3 cevap4
                MessageBox.Show("000");
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into turkce( soru_icerik, dogru_cevap, cevap1, cevap2, cevap3, cevap4) values('" + txt_soru.Text + "', '" + txt_dogrucevap.Text + "', '" + txt_cevap_a.Text + "', '" + txt_cevap_b.Text + "', '" + txt_cevap_c.Text + "', '" + txt_cevap_d.Text + "')";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(" Soru eklediniz!");
                   
                }
                con.Close();


            }
               
            
              

            
        }
        }
}

