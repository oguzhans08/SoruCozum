using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.WebControls;

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
        string bransSecimi;
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
               label19.Text = dr.GetValue(4).ToString();
                

                bransSecimi = dr.GetValue(4).ToString();



            }
            con.Close();

            List<int> lstTestId = new List<int>();


            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select id from testler where dersadi='"+bransSecimi+"'";
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                lstTestId.Add(dr.GetInt32(0));
            }
            con.Close();

            foreach (var testid in lstTestId)
            {
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select soru_icerik, id from sorular where testid='" + testid + "'";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(new ListItem(dr["soru_icerik"].ToString(), dr["id"].ToString()));
                }
                con.Close();
            }
            




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



            if (bransSecimi == "turkce")
            {
                bransSecimi = "turkce";
                MessageBox.Show("Sistemde Türkçe Öğretmeni olarak gözükmektesiniz.");
                comboBox4.Items.Add("Dil Anlatım");
                comboBox4.Items.Add("Ses Bilgisi");
                 
            }
            else if (bransSecimi == "matematik")
            {
                bransSecimi = "matematik";
                MessageBox.Show("Sistemde Matematik Öğretmeni olarak gözükmektesiniz.");
                comboBox4.Items.Add("Temel Kavramlar");
                comboBox4.Items.Add("Problemler");

            }
            else if (bransSecimi == "cografya")
            {
                bransSecimi = "cografya";
                MessageBox.Show("Sistemde Coğrafya Öğretmeni olarak gözükmektesiniz.");
                comboBox4.Items.Add("Atmosfer Ve Sıcaklık");
                comboBox4.Items.Add("İklimler");

            }
            else if (bransSecimi == "fizik")
            {
                bransSecimi = "fizik";
                MessageBox.Show("Sistemde Fizik Öğretmeni olarak gözükmektesiniz.");
                comboBox4.Items.Add("Fizik Giriş");
                comboBox4.Items.Add("Modern Fizik");

            }
            else if (bransSecimi == "kimya")
            {
                bransSecimi = "kimya";
                MessageBox.Show("Sistemde Kimya Öğretmeni olarak gözükmektesiniz.");
                comboBox4.Items.Add("Kimya Bilimi");
                comboBox4.Items.Add("Maddenin Halleri");

            }

            searchData("");
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
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT id FROM testler WHERE dersadi='"+bransSecimi+"' and testadi='"+txt_ismi.Text+"' and konuadi='"+comboBox4.SelectedItem+"' ";
                dr = cmd.ExecuteReader();

                if(dr.Read())
                {
                    //bu dersadi, testadi ve konuadi var onun üzerine soru ekle
                    int testid = dr.GetInt32(0);
                    con.Close();

                    //id, soru_icerik, dogru_cevap, cevap1 cevap2 cevap3 cevap4
                    MessageBox.Show("Fasiküle yeni bir soru eklediniz!");
                    cmd = new MySqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into sorular ( testid,soru_icerik, konu, dogru_cevap, cevap1, cevap2, cevap3, cevap4) values('" + testid + "', '" + txt_soru.Text + "', '" + comboBox4.SelectedItem + "', '" + dogrucevapcmb + "', '" + txt_cevap_a.Text + "', '" + txt_cevap_b.Text + "', '" + txt_cevap_c.Text + "', '" + txt_cevap_d.Text + "')";
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        MessageBox.Show("Soru eklediniz!");
                    }
                    con.Close();
                }
                else
                {
                    //test daha önce yok , oluşturuluyor.
                    con.Close();
                    cmd = new MySqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into testler (dersadi,testadi,konuadi) values ('" + bransSecimi + "' , '" + txt_ismi.Text + "' , '" + comboBox4.SelectedItem + "')";
                    dr = cmd.ExecuteReader();
                    con.Close();

                    //oluşturduğumuz testin idsini alıyoruz.
                    cmd = new MySqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT id FROM testler WHERE dersadi='" + bransSecimi + "' and testadi='" + txt_ismi.Text + "' and konuadi='" + comboBox4.SelectedItem + "' ";
                    MySqlDataReader drTestId = cmd.ExecuteReader();
                    int testid = 0;
                    if (drTestId.Read())
                    {
                        testid = drTestId.GetInt32(0);
                    }
                    con.Close();

                    //id, soru_icerik, dogru_cevap, cevap1 cevap2 cevap3 cevap4
                    // MessageBox.Show("000");
                    cmd = new MySqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into sorular ( testid,soru_icerik, konu, dogru_cevap, cevap1, cevap2, cevap3, cevap4) values('" + testid + "', '" + txt_soru.Text + "', '" + comboBox4.SelectedItem + "', '" + dogrucevapcmb + "', '" + txt_cevap_a.Text + "', '" + txt_cevap_b.Text + "', '" + txt_cevap_c.Text + "', '" + txt_cevap_d.Text + "')";
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                       MessageBox.Show("Soru eklediniz!");

                    }
                    con.Close();

                }
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

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
           // var dogrucevapcmb = cmb_dogrucevap.SelectedItem;
            // var dersadi = cmb_dogrucevap.SelectedItem;


            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from sorular where id='"+Convert.ToInt32(((ListItem)comboBox3.SelectedItem).Value.ToString())+"'";
            dr = cmd.ExecuteReader();
            MessageBox.Show("Soruyu Sildiniz.!");
            con.Close();

            comboBox3.Items.Clear();
            List<int> lstTestId = new List<int>();

            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select id from testler where dersadi='" + bransSecimi + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lstTestId.Add(dr.GetInt32(0));
            }
            con.Close();

            foreach (var testid in lstTestId)
            {
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select soru_icerik, id from sorular where testid='" + testid + "'";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(new ListItem(dr["soru_icerik"].ToString(), dr["id"].ToString()));
                }
                con.Close();
            }


            /*if (txt_soru.TextLength == 0 || txt_cevap_a.TextLength == 0 || txt_cevap_b.TextLength == 0 || txt_cevap_c.TextLength == 0 || txt_cevap_d.TextLength == 0)
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
                cmd.CommandText = "insert into " + label19.Text + "( soru_icerik, dogru_cevap, cevap1, cevap2, cevap3, cevap4) values('" + txt_soru.Text + "', '" + dogrucevapcmb + "', '" + txt_cevap_a.Text + "', '" + txt_cevap_b.Text + "', '" + txt_cevap_c.Text + "', '" + txt_cevap_d.Text + "')";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(" Soru eklediniz!");

                }
                con.Close();


            }*/



















        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var dogrucevapcmb = cmb_dogrucevap.SelectedItem;
            var dersadi = cmb_dogrucevap.SelectedItem;

            if (txt_soru.TextLength == 0 || txt_cevap_a.TextLength == 0 || txt_cevap_b.TextLength == 0 || txt_cevap_c.TextLength == 0 || txt_cevap_d.TextLength == 0)
            {
                MessageBox.Show("Lütfen eksikleri tamamlayınız.");


            }
            else
            {

              

                 
            }

            //SqlCommand com2 = new SqlCommand();
            //com2.Connection = connection;
            //com2.CommandText = "SELECT testadi,konuadi FROM testler ";
            //using (SqlDataReader dr2 = com2.ExecuteReader())
            //{
            //    while (dr2.Read())
            //    {

            //    }
            //}





        }
        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        private void tabPage1_Click(object sender, EventArgs e)
        {

            

       
        }

        public void searchData(string valueToSearch)
        {
            string query = "SELECT * FROM turkce";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Txt_ismi_TextChanged(object sender, EventArgs e)
        {
            


        }
    }
}

