﻿using MetroFramework.Forms;
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
        public string kullaniciAdi { get; set; }
        public int dogrusayi { get; set; }
        public int yanlissayi { get; set; }
        private void Ogr_secim_dersler_Load(object sender, EventArgs e)
        {
            MessageBox.Show(kullaniciAdi);
            label9.Text = kullaniciAdi;

            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select * from ogretmen where ogrkullaniciadi='" + kullaniciAdi + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                // 0 id
                // 1 ogrkullaniciadi
                // 2 ogrsifre
                // 3 ogrmailadresi
                // 4 ogr ders
                label10.Text = dr.GetValue(4).ToString();
             
           
        

            }
            con.Close();


            //cmd = new MySqlCommand();
            //con.Open();
            //cmd.Connection = con;
            //cmd.CommandText = "SELECT * FROM ogretmen where kullaniciadi='" + textBox1.Text + "' AND sifre='" + textBox2.Text + "'";
            //dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    anasayfa anasayfa = new anasayfa();

            //    ogr_panel_secim. = textBox1.Text;
            //    anasayfa.Show();
            //    this.Hide();



            //}
            //else
            //{
            //    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");
            //}
            //con.Close();






        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            ogr_panel_secim ogr_panel_secim = new ogr_panel_secim();
            ogr_panel_secim.Show();
            this.Hide();
        }

        private void Btn_soruekle_Click(object sender, EventArgs e)
        {
            var dogrucevapcmb = cmb_dogrucevap.SelectedItem;
            var dersadi = cmb_dogrucevap.SelectedItem;

            if (txt_soru.TextLength == 0 || txt_cevap_a.TextLength == 0 || txt_cevap_b.TextLength == 0 || txt_cevap_c.TextLength == 0 || txt_cevap_d.TextLength == 0)
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
                cmd.CommandText = "insert into "+label10.Text+"( soru_icerik, dogru_cevap, cevap1, cevap2, cevap3, cevap4) values('" + txt_soru.Text + "', '" + dogrucevapcmb + "', '" + txt_cevap_a.Text + "', '" + txt_cevap_b.Text + "', '" + txt_cevap_c.Text + "', '" + txt_cevap_d.Text + "')";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(" Soru eklediniz!");

                }
                con.Close();


            }





        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void cmb_derssecimi_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            var dersSecimi = label10.Text + " dersine soru eklemektesiniz.";
            label7.Text = dersSecimi;

        }
    }
}

