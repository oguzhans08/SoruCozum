using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;



namespace SoruProjesiYon
{
    public partial class girisyap : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public girisyap()
        {


           

        InitializeComponent();
            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");
        }
    

        private void Btn_oturumbaslat_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox1.Text;
           
         
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM uyeler where kullaniciadi='" + textBox1.Text + "' AND sifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                anasayfa anasayfa = new anasayfa();

                anasayfa.kullaniciAdi = textBox1.Text;
                anasayfa.Show();
                this.Hide();



            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");
            }
            con.Close();
        }


















        private void Btn_uyeol_Click(object sender, EventArgs e)
        {
           
           
            uyeol form2 = new uyeol();//açılacak form
           //bu formu parent olarak veriyoruz.
            form2.Show(); //form 2 açılıyor.
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
    }

