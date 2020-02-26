namespace SoruProjesiYon
{
    partial class anasayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kullansali = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_turkce_ders = new System.Windows.Forms.Button();
            this.btn_matematik_ders = new System.Windows.Forms.Button();
            this.btn_kimya_ders = new System.Windows.Forms.Button();
            this.btn_cografya_ders = new System.Windows.Forms.Button();
            this.btn_fizik_ders = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kullansali
            // 
            this.kullansali.AutoSize = true;
            this.kullansali.Location = new System.Drawing.Point(51, 306);
            this.kullansali.Name = "kullansali";
            this.kullansali.Size = new System.Drawing.Size(80, 17);
            this.kullansali.TabIndex = 0;
            this.kullansali.Text = "KullanıcıAdı";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(43, 181);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 113);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_turkce_ders
            // 
            this.btn_turkce_ders.Location = new System.Drawing.Point(43, 44);
            this.btn_turkce_ders.Name = "btn_turkce_ders";
            this.btn_turkce_ders.Size = new System.Drawing.Size(152, 83);
            this.btn_turkce_ders.TabIndex = 2;
            this.btn_turkce_ders.Text = "Türkçe";
            this.btn_turkce_ders.UseVisualStyleBackColor = true;
            this.btn_turkce_ders.Click += new System.EventHandler(this.Btn_turkce_ders_Click);
            // 
            // btn_matematik_ders
            // 
            this.btn_matematik_ders.Location = new System.Drawing.Point(201, 44);
            this.btn_matematik_ders.Name = "btn_matematik_ders";
            this.btn_matematik_ders.Size = new System.Drawing.Size(152, 83);
            this.btn_matematik_ders.TabIndex = 3;
            this.btn_matematik_ders.Text = "Matematik";
            this.btn_matematik_ders.UseVisualStyleBackColor = true;
            this.btn_matematik_ders.Click += new System.EventHandler(this.Btn_matematik_ders_Click);
            // 
            // btn_kimya_ders
            // 
            this.btn_kimya_ders.Location = new System.Drawing.Point(359, 44);
            this.btn_kimya_ders.Name = "btn_kimya_ders";
            this.btn_kimya_ders.Size = new System.Drawing.Size(152, 83);
            this.btn_kimya_ders.TabIndex = 4;
            this.btn_kimya_ders.Text = "Kimya";
            this.btn_kimya_ders.UseVisualStyleBackColor = true;
            this.btn_kimya_ders.Click += new System.EventHandler(this.Btn_kimya_ders_Click);
            // 
            // btn_cografya_ders
            // 
            this.btn_cografya_ders.Location = new System.Drawing.Point(517, 44);
            this.btn_cografya_ders.Name = "btn_cografya_ders";
            this.btn_cografya_ders.Size = new System.Drawing.Size(152, 83);
            this.btn_cografya_ders.TabIndex = 5;
            this.btn_cografya_ders.Text = "Coğrafya";
            this.btn_cografya_ders.UseVisualStyleBackColor = true;
            this.btn_cografya_ders.Click += new System.EventHandler(this.Btn_cografya_ders_Click);
            // 
            // btn_fizik_ders
            // 
            this.btn_fizik_ders.Location = new System.Drawing.Point(675, 44);
            this.btn_fizik_ders.Name = "btn_fizik_ders";
            this.btn_fizik_ders.Size = new System.Drawing.Size(152, 83);
            this.btn_fizik_ders.TabIndex = 6;
            this.btn_fizik_ders.Text = "Fizik";
            this.btn_fizik_ders.UseVisualStyleBackColor = true;
            this.btn_fizik_ders.Click += new System.EventHandler(this.Btn_fizik_ders_Click);
            // 
            // anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 498);
            this.Controls.Add(this.btn_fizik_ders);
            this.Controls.Add(this.btn_cografya_ders);
            this.Controls.Add(this.btn_kimya_ders);
            this.Controls.Add(this.btn_matematik_ders);
            this.Controls.Add(this.btn_turkce_ders);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.kullansali);
            this.Name = "anasayfa";
            this.Text = "anasayfa";
            this.Load += new System.EventHandler(this.Anasayfa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label kullansali;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_turkce_ders;
        private System.Windows.Forms.Button btn_matematik_ders;
        private System.Windows.Forms.Button btn_kimya_ders;
        private System.Windows.Forms.Button btn_cografya_ders;
        private System.Windows.Forms.Button btn_fizik_ders;
    }
}