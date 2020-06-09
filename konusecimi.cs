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
        public int kullaniciId { get; set; }

        public konusecimi()
        {
            InitializeComponent();
            con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=sorucozum;");
        }
        public string Konusecimi { get; set; }
        public string derssecim
        {
            get;
            set;
        }
        private void konusecimi_Load(object sender, EventArgs e)
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
            var cmd = new MySqlCommand();
            cmd.Connection = con;
            var konuAdi = comboBox1.SelectedItem.ToString();
            cmd.CommandText = $"SELECT testadi,id FROM `testler` WHERE dersadi='{derssecim}' AND konuadi='{konuAdi}'";
            using (var dr = cmd.ExecuteReader())
            {
                comboBox2.Items.Clear();
                while (dr.Read())
                {
                    comboBox2.Items.Add(new ListItem(dr["testadi"].ToString(), dr["id"].ToString()));
                }
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
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
        
    }
}
