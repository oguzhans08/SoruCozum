using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;//2
using System.Data.SqlClient;





using System.Windows.Forms;

namespace SoruProjesiYon
{
    public partial class anasayfa : MetroForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
      
        public anasayfa()
        {
            InitializeComponent();

           
            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");

        }
        public int kullaniciId { get; set; }
        public string kullaniciAdi { get; set; }
        public string derssecim { get; set; }
        public string cevaps;
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;

            cmd.CommandText = "Select * from uyeler where id='" + kullaniciId + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                // 0 id
                // 1 soru
                // 2dogrucevap
                // 3cevap1
                // 4cevap2
                // 5cevap3
                // 6cevap4
                label4.Text = (dr.GetInt32(6) + dr.GetInt32(7)).ToString();
                label5.Text = dr.GetInt32(6).ToString();
                label6.Text = dr.GetInt32(7).ToString();
                label10.Text = dr.GetValue(0).ToString();
                var kullaniciID = label10.Text;
            


            }
            con.Close();


            string imgUrl;
            kullansali.Text = kullaniciAdi;

           
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM uyeler WHERE kullaniciadi='"+kullaniciAdi+"'";
            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    imgUrl = dr.GetValue(5).ToString();
                    pictureBox1.ImageLocation = imgUrl;

                }
            }
        }

        private void Btn_turkce_ders_Click(object sender, EventArgs e)
        {
           string derssecim = "turkce";
            konusecimi ders_secim_form = new konusecimi();


            ders_secim_form.kullaniciId = kullaniciId;
            ders_secim_form.kullaniciAdi = kullaniciAdi;
            ders_secim_form.derssecim = derssecim;
            ders_secim_form.Show();
            this.Hide();
        }

        private void Btn_matematik_ders_Click(object sender, EventArgs e)
        {
            derssecim = "matematik";
            konusecimi ders_secim_form = new konusecimi();


            ders_secim_form.kullaniciId = kullaniciId;
            ders_secim_form.kullaniciAdi = kullaniciAdi;
            ders_secim_form.derssecim = derssecim;
            ders_secim_form.Show();
            this.Hide();
        }

        private void Btn_kimya_ders_Click(object sender, EventArgs e)
        {
            derssecim = "kimya";
            konusecimi ders_secim_form = new konusecimi();


            ders_secim_form.kullaniciId = kullaniciId;
            ders_secim_form.kullaniciAdi = kullaniciAdi;
            ders_secim_form.derssecim = derssecim;
            ders_secim_form.Show();
            this.Hide();
        }

        private void Btn_cografya_ders_Click(object sender, EventArgs e)
        {
            derssecim = "cografya";
            konusecimi ders_secim_form = new konusecimi();


            ders_secim_form.kullaniciId = kullaniciId;
            ders_secim_form.kullaniciAdi = kullaniciAdi;
            ders_secim_form.derssecim = derssecim;
            ders_secim_form.Show();
            this.Hide();
        }

        private void Btn_fizik_ders_Click(object sender, EventArgs e)
        {
            derssecim = "Fizik";
            konusecimi ders_secim_form = new konusecimi();


            ders_secim_form.kullaniciId = kullaniciId;
            ders_secim_form.kullaniciAdi = kullaniciAdi;
            ders_secim_form.derssecim = derssecim;
            ders_secim_form.Show();
            this.Hide();

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
        string imageUplGlb;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            String imageLocation = "";

            try
            {
                OpenFileDialog imageUpload = new OpenFileDialog();
                imageUpload.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (imageUpload.ShowDialog() == DialogResult.OK)
                {
                    

                    imageLocation = imageUpload.FileName;
                    pictureBox1.ImageLocation = imageLocation;
                    MessageBox.Show(imageLocation);

                    imageUplGlb = imageLocation;
                    button3.Visible = true;


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Resim eklenirken bir hata oluştu.");
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        { //SQL'de insert ederken \ bu slash işaretini görmüyor ve ne kayıt edersem edeyim slashsiz ekliyordu path'i. Path slashsız olunca da resmi çekmiyordu.
            //Aşağıda eklemiş olduğum linkten replace ile durumu hallettim.
            string imgPathSlash = imageUplGlb.Replace("\\", "\\\\"); //https://www.codeproject.com/Questions/1246134/Csharp-textbox-not-contains-backslash-while-insert
            con.Close();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE uyeler SET picImg='" + imgPathSlash + "' WHERE kullaniciadi='" + kullaniciAdi+ "'";
            dr = cmd.ExecuteReader();
   
            con.Close();

        }

        private void Button2_Click(object sender, EventArgs e)
        {


        }
    }
}
