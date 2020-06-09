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
using MetroFramework.Forms;

namespace SoruProjesiYon
{
    public partial class ders_secim_form : MetroForm
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public int kullaniciId { get; set; }

        public string Konusecimi
        {
            get;
            set;
        }
        public string TestId
        {
            get;
            set;
        }
        public string kullaniciAdi
        {
            get;
            set;
        }
        public string derssecim
        {
            get;
            set;
        }
        public string url
        {
            get;
            set;
        }
        public int dogrusayi
        {
            get;
            set;
        }
        public int yanlissayi
        {
            get;
            set;
        }

        public class sorular
        {
            public int id { get; set; }
            public int testid { get; set; }
            public string konu { get; set; }
            public string soru_icerik { get; set; }
            public string dogru_cevap { get; set; }
            public string cevap1 { get; set; }
            public string cevap2 { get; set; }
            public string cevap3 { get; set; }
            public string cevap4 { get; set; }
        }

        public ders_secim_form()
        {
            InitializeComponent();


        }

        int sayi = 1;
        public string cevap;
        int dogru = 0;
        int yanlis = 0;

        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        int sonraki = 0;

        List<String> columnData = new List<String>();

        int soruIndex = 0;
        List<sorular> sorularList = new List<sorular>();
        List<string> soruCevapList = new List<string>();

        private void Ders_secim_form_Load(object sender, EventArgs e)
        {
            btn_bitir.Enabled = false;
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 3);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            

            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");


            

            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select * from sorular WHERE testid='" + TestId + "'";
            dr = cmd.ExecuteReader();

            
            while (dr.Read())
            {
                // 0id
                // 1testid
                // 2konu
                // 3soruicerik
                // 4dogrucevap
                // 5cevap1
                // 6cevap2
                // 7cevap3
                // 8cevap4

                sorular model = new sorular();
                model.id = dr.GetInt32(0);
                model.testid = dr.GetInt32(1);
                model.konu = dr.GetString(2);
                model.soru_icerik = dr.GetString(3);
                model.dogru_cevap = dr.GetString(4);
                model.cevap1 = dr.GetString(5);
                model.cevap2 = dr.GetString(6);
                model.cevap3 = dr.GetString(7);
                model.cevap4 = dr.GetString(8);

                sorularList.Add(model);
                //label1.Text += dr[""].ToString();
               /* columnData.Add(dr.GetString(sonraki));

                label1.Text =
                radioButton1.Text = dr["cevap1"].ToString();
                radioButton2.Text = dr["cevap2"].ToString();
                radioButton3.Text = dr["cevap3"].ToString();
                radioButton4.Text = dr["cevap4"].ToString();*/

            }
            con.Close();

            label3.Text = (soruIndex+1).ToString();
            lbl_derssecim.Text = derssecim;
            label1.Text = sorularList[soruIndex].konu;
            label7.Text = sorularList[soruIndex].soru_icerik;
            radioButton1.Text = sorularList[soruIndex].cevap1;
            radioButton2.Text = sorularList[soruIndex].cevap2;
            radioButton3.Text = sorularList[soruIndex].cevap3;
            radioButton4.Text = sorularList[soruIndex].cevap4;
        }


        private void Button1_Click(object sender, EventArgs e)
        {


            btn_bitir.Enabled = true;
            if(radioButton1.Checked)
            {
                soruCevapList.Add("a");
            }
            else if(radioButton2.Checked)
            {
                soruCevapList.Add("b");
            }
            else if(radioButton3.Checked)
            {
                soruCevapList.Add("c");
            }
            else if(radioButton4.Checked)
            {
                soruCevapList.Add("d");
            }

            //sonraki soruya geçiyoruz.
            if(soruIndex+1 == sorularList.Count)
            {
                MessageBox.Show("Test bitti lütfen testi bitir butonuna tıklayınız.");
            }
            else
            {
                soruIndex++;
                label3.Text = (soruIndex + 1).ToString();
                lbl_derssecim.Text = derssecim;
                label1.Text = sorularList[soruIndex].konu;
                label7.Text = sorularList[soruIndex].soru_icerik;
                radioButton1.Text = sorularList[soruIndex].cevap1;
                radioButton2.Text = sorularList[soruIndex].cevap2;
                radioButton3.Text = sorularList[soruIndex].cevap3;
                radioButton4.Text = sorularList[soruIndex].cevap4;
            }

            //veritabanından dogru_cevap sütunundan cevabı al
        }



        //private void Button2_Click(object sender, EventArgs e)
        //{
        //    sayi = sayi + 1;
        //    label3.Text = sayi.ToString();


        //    cmd = new MySqlCommand();
        //    con.Open();
        //    cmd.Connection = con;
        //    cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + ""; //syntax doğru
        //    dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        label1.Text = dr.GetValue(1).ToString();

        //        MessageBox.Show("Soru Getilirdi");

        //    }
        //    con.Close();


        //}

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

        private void Btn_bitir_Click(object sender, EventArgs e)
        {
            int cevapIndex = 0;
            foreach(var soru in sorularList)
            {
                if(soruCevapList[cevapIndex]==soru.dogru_cevap)
                {
                    dogrusayi++;
                }
                else
                {
                    yanlissayi++;
                }
                cevapIndex++;
            }

            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");




            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select dogrucevap,yanliscevap from uyeler WHERE id='" + kullaniciId + "'";
            dr = cmd.ExecuteReader();

            int dtdogrucevap = 0;
            int dtyanliscevap = 0;

            if(dr.Read())
            {
                dtdogrucevap = dr.GetInt32(0);
                dtyanliscevap = dr.GetInt32(1);
            }
            con.Close();

            dtdogrucevap += dogrusayi;
            dtyanliscevap += yanlissayi;

            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Update uyeler set dogrucevap='"+ dtdogrucevap + "' , yanliscevap='"+ dtyanliscevap + "' where id='"+kullaniciId+"'";
            dr = cmd.ExecuteReader();
            con.Close();

            /*dogrusayi = dogru;
            yanlissayi = yanlis;*/

            istatistik istatistikfrm = new istatistik();

            istatistikfrm.kullaniciAdi = kullaniciAdi;
        
            istatistikfrm.dogrusayi = dogrusayi;
            istatistikfrm.yanlissayi = yanlissayi;

            istatistikfrm.Show();
            this.Hide();
        }

        private void Btn_arastir_Click(object sender, EventArgs e)
        {
            soru_arastir soruarastirfrm = new soru_arastir();

            soruarastirfrm.url = url;
            soruarastirfrm.Show();


        }
        int xx, yy;
        int yaziTahtasi = 0;
        private void MetroButton1_Click(object sender, EventArgs e)
        {
            if (yaziTahtasi == 0)
            {
                yaziTahtasi++;
                xx = 500;
                yy = 80;
                this.Width += xx;
                this.Height += yy;
                btn_yazitahtasi.Enabled = false;

            }

        }
        Graphics g;

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;



        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            panel1.Cursor = Cursors.Cross;
        }

        private void Panel1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {

                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Bitmap bitmap = DrawControllerToBitmap(panel1);
            bitmap.Save("panel.bmp");
            System.Diagnostics.Process.Start("panel.bmp");
        }


        private static Bitmap DrawControllerToBitmap(Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle rect = control.RectangleToScreen(control.ClientRectangle);
            graphics.CopyFromScreen(rect.Location, Point.Empty, rect.Size);
            return bitmap;



        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
        }
    }
}