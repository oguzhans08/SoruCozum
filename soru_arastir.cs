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
    public partial class soru_arastir : Form
    {
        public soru_arastir()
        {
            InitializeComponent();
        }
        public string url { get; set; }
        private void Soru_arastir_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/search?q=" + url);
        }
    }
}
