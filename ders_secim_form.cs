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
        private void Ders_secim_form_Load(object sender, EventArgs e)
        {
          
            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");

            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
        
            cmd.CommandText = "Select * from uyeler where kullaniciadi='" + kullaniciAdi + "'";
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
                label6.Text = dr.GetValue(0).ToString();
               
               
            

            }
            con.Close();




            btn_bitir.Enabled = false;
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 3);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            label3.Text = sayi.ToString();


         

            lbl_derssecim.Text = derssecim;

            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select * from " + derssecim + " where id='" + sayi + "'";
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

                label1.Text += dr.GetValue(1).ToString();

                radioButton1.Text = dr.GetValue(3).ToString();
                radioButton2.Text = dr.GetValue(4).ToString();
                radioButton3.Text = dr.GetValue(5).ToString();
                radioButton4.Text = dr.GetValue(6).ToString();

            }
            con.Close();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            btn_bitir.Enabled = true;


            if (radioButton1.Checked)
            {

                string cevap = "a";
                label2.Text = cevap;
                con.Close();

                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + " and dogru_cevap='" + cevap + "'"; //syntax doğru
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    url = dr.GetValue(1).ToString();

                    if (cevap == dr.GetValue(2).ToString())
                    {


                        dogru++;
                        con.Close();
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

                            radioButton1.Text = dr.GetValue(3).ToString();
                            radioButton2.Text = dr.GetValue(4).ToString();
                            radioButton3.Text = dr.GetValue(5).ToString();
                            radioButton4.Text = dr.GetValue(6).ToString();


                        }
                        else
                        {

                            sayi = sayi - 1;
                            label3.Text = sayi.ToString();
                            MessageBox.Show("Soru bitti");
                        }

                        con.Close();

                    }


                }
                else
                {

                    yanlis++;

                    sayi = sayi + 1;
                    label3.Text = sayi.ToString();
                    con.Close();


                    cmd = new MySqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + ""; //syntax doğru
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        label1.Text = dr.GetValue(1).ToString();


                        radioButton1.Text = dr.GetValue(3).ToString();
                        radioButton2.Text = dr.GetValue(4).ToString();
                        radioButton3.Text = dr.GetValue(5).ToString();
                        radioButton4.Text = dr.GetValue(6).ToString();

                    }
                    else
                    {

                        sayi = sayi - 1;
                        label3.Text = sayi.ToString();
                        MessageBox.Show("Soru bitti");
                    }
                    con.Close();

                }
                con.Close();

            }
            if (radioButton2.Checked)
            {

                string cevap = "b";
                label2.Text = cevap;
                con.Close();

                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + " and dogru_cevap='" + cevap + "'"; //syntax doğru
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    url = dr.GetValue(1).ToString();
                    if (cevap == dr.GetValue(2).ToString())
                    {


                        dogru++;
                        con.Close();
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

                            radioButton1.Text = dr.GetValue(3).ToString();
                            radioButton2.Text = dr.GetValue(4).ToString();
                            radioButton3.Text = dr.GetValue(5).ToString();
                            radioButton4.Text = dr.GetValue(6).ToString();


                        }
                        else
                        {

                            sayi = sayi - 1;
                            label3.Text = sayi.ToString();
                            MessageBox.Show("Soru bitti");
                        }

                        con.Close();

                    }


                }
                else
                {

                    yanlis++;
                    con.Close();
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


                        radioButton1.Text = dr.GetValue(3).ToString();
                        radioButton2.Text = dr.GetValue(4).ToString();
                        radioButton3.Text = dr.GetValue(5).ToString();
                        radioButton4.Text = dr.GetValue(6).ToString();

                    }
                    else
                    {

                        sayi = sayi - 1;
                        label3.Text = sayi.ToString();
                        MessageBox.Show("Soru bitti");
                    }
                    con.Close();

                }
                con.Close();

            }
            if (radioButton3.Checked)
            {

                string cevap = "c";
                label2.Text = cevap;
                con.Close();

                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + " and dogru_cevap='" + cevap + "'"; //syntax doğru
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    url = dr.GetValue(1).ToString();

                    if (cevap == dr.GetValue(2).ToString())
                    {


                        dogru++;
                        con.Close();
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
                            radioButton1.Text = dr.GetValue(3).ToString();
                            radioButton2.Text = dr.GetValue(4).ToString();
                            radioButton3.Text = dr.GetValue(5).ToString();
                            radioButton4.Text = dr.GetValue(6).ToString();



                        }
                        else
                        {

                            sayi = sayi - 1;
                            label3.Text = sayi.ToString();
                            MessageBox.Show("Soru bitti");
                        }

                        con.Close();

                    }


                }
                else
                {

                    yanlis++;

                    sayi = sayi + 1;
                    label3.Text = sayi.ToString();
                    con.Close();


                    cmd = new MySqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + ""; //syntax doğru
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        label1.Text = dr.GetValue(1).ToString();
                        url = dr.GetValue(1).ToString();

                        radioButton1.Text = dr.GetValue(3).ToString();
                        radioButton2.Text = dr.GetValue(4).ToString();
                        radioButton3.Text = dr.GetValue(5).ToString();
                        radioButton4.Text = dr.GetValue(6).ToString();

                    }
                    else
                    {

                        sayi = sayi - 1;
                        label3.Text = sayi.ToString();
                        MessageBox.Show("Soru bitti");
                    }
                    con.Close();

                }
                con.Close();

            }
            if (radioButton4.Checked)
            {

                string cevap = "d";
                label2.Text = cevap;

                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + " and dogru_cevap='" + cevap + "'"; //syntax doğru
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    url = dr.GetValue(1).ToString();
                    if (cevap == dr.GetValue(2).ToString())
                    {


                        dogru++;
                        con.Close();
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
                            radioButton1.Text = dr.GetValue(3).ToString();
                            radioButton2.Text = dr.GetValue(4).ToString();
                            radioButton3.Text = dr.GetValue(5).ToString();
                            radioButton4.Text = dr.GetValue(6).ToString();



                        }
                        con.Close();

                    }


                }
                else
                {

                    yanlis++;

                    sayi = sayi + 1;
                    label3.Text = sayi.ToString();
                    con.Close();
                    cmd = new MySqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from " + derssecim + " where id=" + sayi + ""; //syntax doğru
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        label1.Text = dr.GetValue(1).ToString();

                        radioButton1.Text = dr.GetValue(3).ToString();
                        radioButton2.Text = dr.GetValue(4).ToString();
                        radioButton3.Text = dr.GetValue(5).ToString();
                        radioButton4.Text = dr.GetValue(6).ToString();

                    }
                    else
                    {

                        sayi = sayi - 1;
                        label3.Text = sayi.ToString();
                        MessageBox.Show("Soru bitti");
                    }

                    con.Close();

                }


            }

            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into cozulensorular(kullaniciID, soruID) values('" + label6.Text + "', '" + sayi + "')";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Sayi Soru ID: " + sayi);
            }
            con.Close();

            
     
           
       
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
            dogrusayi = dogru;
            yanlissayi = yanlis;
         
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
        }
    }
}