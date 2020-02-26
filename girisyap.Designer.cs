namespace SoruProjesiYon
{
    partial class girisyap
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_oturumbaslat = new System.Windows.Forms.Button();
            this.btn_uyeol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(435, 246);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "oguz";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(435, 274);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(243, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "oguz";
            // 
            // btn_oturumbaslat
            // 
            this.btn_oturumbaslat.Location = new System.Drawing.Point(435, 302);
            this.btn_oturumbaslat.Name = "btn_oturumbaslat";
            this.btn_oturumbaslat.Size = new System.Drawing.Size(243, 51);
            this.btn_oturumbaslat.TabIndex = 2;
            this.btn_oturumbaslat.Text = "Oturum Başlat!";
            this.btn_oturumbaslat.UseVisualStyleBackColor = true;
            this.btn_oturumbaslat.Click += new System.EventHandler(this.Btn_oturumbaslat_Click);
            // 
            // btn_uyeol
            // 
            this.btn_uyeol.Location = new System.Drawing.Point(435, 189);
            this.btn_uyeol.Name = "btn_uyeol";
            this.btn_uyeol.Size = new System.Drawing.Size(243, 51);
            this.btn_uyeol.TabIndex = 3;
            this.btn_uyeol.Text = "Üye Ol";
            this.btn_uyeol.UseVisualStyleBackColor = true;
            this.btn_uyeol.Click += new System.EventHandler(this.Btn_uyeol_Click);
            // 
            // girisyap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_uyeol);
            this.Controls.Add(this.btn_oturumbaslat);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "girisyap";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_oturumbaslat;
        private System.Windows.Forms.Button btn_uyeol;
    }
}

