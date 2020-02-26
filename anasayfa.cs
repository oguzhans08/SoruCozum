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
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }
        public string kullaniciAdi { get; set; }
        public string derssecim { get; set; }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

            kullansali.Text = kullaniciAdi;


        }

        private void Btn_turkce_ders_Click(object sender, EventArgs e)
        {
           string derssecim = "turkce";

            ders_secim_form ders_secm = new ders_secim_form();

            ders_secm.derssecim = derssecim;
            ders_secm.Show();
            this.Hide();


        }

        private void Btn_matematik_ders_Click(object sender, EventArgs e)
        {
            derssecim = "Matematik";
            ders_secim_form ders_secm = new ders_secim_form();

            ders_secm.derssecim = derssecim;
            ders_secm.Show();
            this.Hide();
        }

        private void Btn_kimya_ders_Click(object sender, EventArgs e)
        {
            derssecim = "Kimya";
            ders_secim_form ders_secm = new ders_secim_form();

            ders_secm.derssecim = derssecim;
            ders_secm.Show();
            this.Hide();
        }

        private void Btn_cografya_ders_Click(object sender, EventArgs e)
        {
            derssecim = "Coğrafya";
            ders_secim_form ders_secm = new ders_secim_form();

            ders_secm.derssecim = derssecim;
            ders_secm.Show();
            this.Hide();
        }

        private void Btn_fizik_ders_Click(object sender, EventArgs e)
        {
            derssecim = "Fizik";
            ders_secim_form ders_secm = new ders_secim_form();

            ders_secm.derssecim = derssecim;
            ders_secm.Show();
            this.Hide();

        }
    }
}
