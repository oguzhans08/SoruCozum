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
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SoruProjesiYon
{
    public partial class konusecimi : MetroForm
    {
        MySqlConnection con;
        MySqlDataReader dr2;
      
        MySqlCommand cmd;
      
        public int kullaniciId { get; set; }

        public konusecimi()
        {
            InitializeComponent();
            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");
            this.Load += new EventHandler(this.konusecimi_Load);
        }
        public string Konusecimi { get; set; }
        public  string derssecim
        {
            get;
            set;
        }
        public void konusecimi_Load(object sender, EventArgs e)
        {

            var cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = $"SELECT DISTINCT dersadi, konuadi FROM `testler` WHERE dersadi='{derssecim}'";
            using (var dr = cmd.ExecuteReader())
            {
                comboBox1.Items.Clear();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["konuadi"].ToString());
                }
                Konusecimi = "asd";
            }
            con.Close();
            con.Open();
            lbl_dersD.Text = "";
            lbl_dersY.Text = "";
            lbl_dersD.Text = dersAdi.ders + " doğru sayısı:";
            lbl_dersY.Text = dersAdi.ders + " yanlış sayısı:";
            cmd.CommandText= "Select " + dersAdi.ders + "d," + dersAdi.ders + "y from uyeler WHERE id='" + kullaniciId + "'";
            dr2 = cmd.ExecuteReader();
            int dersdogrucevap = 0;
            int dersyanliscevap = 0;
            if (dr2.Read())
            {
          
                dersdogrucevap = dr2.GetInt32(0);
                dersyanliscevap = dr2.GetInt32(1);

            }
            lbl_dogru.Text = dersdogrucevap.ToString();
            lbl_yanlis.Text = dersyanliscevap.ToString();
            con.Close();
            
        }
        public string kullaniciAdi { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {

            Konusecimi = "Ses Bilgisi";

            ders_secim_form ders_secim_form = new ders_secim_form();
            ders_secim_form.kullaniciId = kullaniciId;
            ders_secim_form.derssecim = derssecim;
            ders_secim_form.Konusecimi = Konusecimi;
            ders_secim_form.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Konusecimi = "Dil Anlatım";
            ders_secim_form ders_secim_form = new ders_secim_form();
            ders_secim_form.kullaniciId = kullaniciId;
            ders_secim_form.derssecim = derssecim;
            ders_secim_form.Konusecimi = Konusecimi;
            ders_secim_form.Show();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = con;
            
            var konuAdi = comboBox1.SelectedItem.ToString();
            dersAdi.konuAdi = comboBox1.SelectedItem.ToString();
            cmd.CommandText = $"SELECT testadi,id FROM `testler` WHERE dersadi='{derssecim}' AND konuadi='{konuAdi}'";
            using (var dr = cmd.ExecuteReader())
            {
                comboBox2.Items.Clear();
                while (dr.Read())
                {
                    comboBox2.Items.Add(new ListItem(dr["testadi"].ToString(), dr["id"].ToString()));
                }
            }
            con.Close();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var konuAdi = comboBox1.SelectedItem.ToString();
                var testAdi = ((ListItem)comboBox2.SelectedItem).Value.ToString();
                ders_secim_form ders_secim_form = new ders_secim_form();
                ders_secim_form.kullaniciId = kullaniciId;
                ders_secim_form.derssecim = derssecim;
                ders_secim_form.Konusecimi = konuAdi;
                ders_secim_form.TestId = testAdi;
                ders_secim_form.Show();


            }
            catch (Exception) 
            {

                MessageBox.Show("Fasikül seçiminde hata yaptınız");
            }
           
            

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int testdogrucevap = 0;
            int testyanliscevap = 0;
            dersAdi.testAdi = comboBox2.SelectedItem.ToString();
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select Testd,Testy from testler where dersadi='" + dersAdi.ders + "' and konuadi='" + dersAdi.konuAdi + "' and testadi='" + dersAdi.testAdi + "' ";
            dr2 = cmd.ExecuteReader();
            if (dr2.Read())
            {
                testdogrucevap = dr2.GetInt32(0);
                testyanliscevap = dr2.GetInt32(1);


            }

            con.Close();
            lbl_Testd.Text = testdogrucevap.ToString();
            lbl_Testy.Text = testyanliscevap.ToString();
        
           
          
          
            con.Open();
            lbl_dersD.Text = "";
            lbl_dersY.Text = "";
            lbl_dersD.Text = dersAdi.ders + " doğru sayısı:";
            lbl_dersY.Text = dersAdi.ders + " yanlış sayısı:";
            cmd.CommandText = "Select " + dersAdi.ders + "d," + dersAdi.ders + "y from uyeler WHERE id='" + kullaniciId + "'";
            dr2 = cmd.ExecuteReader();
            int dersdogrucevap = 0;
            int dersyanliscevap = 0;
            if (dr2.Read())
            {

                dersdogrucevap = dr2.GetInt32(0);
                dersyanliscevap = dr2.GetInt32(1);

            }
            lbl_dogru.Text = (dersdogrucevap+dersAdi.dogruSayisi).ToString();
            lbl_yanlis.Text = (dersyanliscevap+dersAdi.yanlisSayisi).ToString();
            con.Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
