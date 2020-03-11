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
    public partial class istatistik : MetroForm
    {
        public int dogrusayi { get; set; }
        public int yanlissayi { get; set; }
        public istatistik()
        {
            InitializeComponent();
        }

        private void İstatistik_Load(object sender, EventArgs e)
        {
            chart1.Titles.Add("Doğru/Yanlış İstatistiğiniz");
            chart1.Series["s1"].Points.AddXY("Yanlış", yanlissayi);
            chart1.Series["s1"].Points.AddXY("Doğru", dogrusayi);
            lbl_dogrusayisi.Text = dogrusayi.ToString(); 
            lbl_yanlissayisi.Text = yanlissayi.ToString();


        }
    }
}
