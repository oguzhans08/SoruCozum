using MetroFramework.Forms;
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
    public partial class konusecimi : MetroForm
    {
      
        public konusecimi()
        {
            InitializeComponent();
        }
        public string Konusecimi { get; set; }
        public string derssecim
        {
            get;
            set;
        }
        private void konusecimi_Load(object sender, EventArgs e)
        {
            Konusecimi = "asd";
        }
        public string kullaniciAdi { get; set; }
        
        private void button1_Click(object sender, EventArgs e)
        {

            Konusecimi = "Ses Bilgisi";
         
            ders_secim_form ders_secim_form = new ders_secim_form();
            ders_secim_form.derssecim = derssecim;
            ders_secim_form.Konusecimi = Konusecimi;
            ders_secim_form.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Konusecimi = "Dil Anlatım";
            ders_secim_form ders_secim_form = new ders_secim_form();
            ders_secim_form.derssecim = derssecim;
            ders_secim_form.Konusecimi = Konusecimi;
            ders_secim_form.Show();
        }
    }
}
