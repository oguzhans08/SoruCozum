﻿using System;
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
using MetroFramework.Forms;

namespace SoruProjesiYon
{
    public partial class uyeol : MetroForm
    {


        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;



        public uyeol()
        {
            InitializeComponent();
            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");
        }
       
        private void Btn_uyeol_Click(object sender, EventArgs e)
        {
            
           if(txt_sifre.Text == txt_resifre.Text)
            {
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "insert into uyeler( kullaniciadi, sifre, mailadresi) values('" + txt_kullaniciadi.Text + "', '" + txt_sifre.Text + "', '" + txt_mail.Text + "')";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(txt_kullaniciadi+" Hoşgeldin! üye oldunuz!");
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

        private void Uyeol_Load(object sender, EventArgs e)
        {

        }
    }
}
