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
using MySql.Data;
using System.Data.SqlClient;

namespace SoruProjesiYon
{
    public partial class ders_secim_form : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public string kullaniciAdi { get; set; }
        public string derssecim { get; set; }

        public ders_secim_form()
        {
            InitializeComponent();
        }

        int sayi = 1;
        public string cevap;
        private void Ders_secim_form_Load(object sender, EventArgs e)
        {
            label3.Text = sayi.ToString();


            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");


            lbl_derssecim.Text = derssecim;

            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select * from " + derssecim + " where id='" + sayi + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //0 id
                // 1 soru
                //dogrucevap
                label1.Text += dr.GetValue(1).ToString();


            }
            con.Close();


        }

        private void Button1_Click(object sender, EventArgs e)
        {



            if (radioButton1.Checked)
            {
                string cevap = radioButton1.Text;
                label2.Text = cevap;

                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + " and dogru_cevap='" + cevap + "'"; //syntax doğru
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    if (cevap == dr.GetValue(2).ToString())
                    {

                        MessageBox.Show("Cevap Doğru!");

                    }
                    else
                    {

                        MessageBox.Show("Cevap Yanlış");
                    }

                }
                con.Close();

            }

            if (radioButton2.Checked)
            {

                string cevap = radioButton2.Text;
                label2.Text = cevap;

                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + " and dogru_cevap='" + cevap + "'"; //syntax doğru
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    if (cevap == dr.GetValue(2).ToString())
                    {
                        label2.Text = cevap;
                        MessageBox.Show("Cevap Doğru!");

                    }
                    else
                    {

                        MessageBox.Show("Cevap Yanlış");
                    }

                }
                con.Close();
            }

             if (radioButton3.Checked)
            {

                string cevap = radioButton3.Text;
                label2.Text = cevap;

                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + " and dogru_cevap='" + cevap + "'"; //syntax doğru
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    if (cevap == dr.GetValue(2).ToString())
                    {

                        MessageBox.Show("Cevap Doğru!");

                    }
                    else
                    {

                        MessageBox.Show("Cevap Yanlış");
                    }

                }
                con.Close();

            }
             if (radioButton4.Checked)
            {

                string cevap = radioButton4.Text;
                label2.Text = cevap;

                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + " and dogru_cevap='" + cevap + "'"; //syntax doğru
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    if (cevap == dr.GetValue(2).ToString())
                    {

                        MessageBox.Show("Cevap Doğru!");

                    }
                    else
                    {

                        MessageBox.Show("Cevap Yanlış");
                    }

                }
                con.Close();

            }


            //veritabanından dogru_cevap sütunundan cevabı al
        }



        private void Button2_Click(object sender, EventArgs e)
        {
            sayi = sayi + 1;
            label3.Text = sayi.ToString();


            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + ""; //syntax doğru
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label1.Text = dr.GetValue(1).ToString();

                MessageBox.Show("Soru Getilirdi");

            }
            con.Close();


        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string cevap = "a";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string cevap = "b";
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string cevap = "c";
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {

            string cevap = "d";
        }
    }
}
