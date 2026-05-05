namespace proje_hastane
{
    partial class doktor_login_form
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
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_hasta_giris = new System.Windows.Forms.Button();
            this.lnk_uyeol_hasta_giris = new System.Windows.Forms.LinkLabel();
            this.msk_tc = new System.Windows.Forms.MaskedTextBox();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(222, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = " Çıkış";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mistral", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(503, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "ENES DUVAN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mistral", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(9, 353);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "SEA GREEN HOSPİTAL LOGIN PAGE ";
            // 
            // button_hasta_giris
            // 
            this.button_hasta_giris.Location = new System.Drawing.Point(222, 197);
            this.button_hasta_giris.Name = "button_hasta_giris";
            this.button_hasta_giris.Size = new System.Drawing.Size(148, 23);
            this.button_hasta_giris.TabIndex = 15;
            this.button_hasta_giris.Text = "Giriş Yap";
            this.button_hasta_giris.UseVisualStyleBackColor = true;
            this.button_hasta_giris.Click += new System.EventHandler(this.button_hasta_giris_Click);
            // 
            // lnk_uyeol_hasta_giris
            // 
            this.lnk_uyeol_hasta_giris.AutoSize = true;
            this.lnk_uyeol_hasta_giris.Location = new System.Drawing.Point(393, 156);
            this.lnk_uyeol_hasta_giris.Name = "lnk_uyeol_hasta_giris";
            this.lnk_uyeol_hasta_giris.Size = new System.Drawing.Size(39, 13);
            this.lnk_uyeol_hasta_giris.TabIndex = 16;
            this.lnk_uyeol_hasta_giris.TabStop = true;
            this.lnk_uyeol_hasta_giris.Text = "Üye Ol";
            this.lnk_uyeol_hasta_giris.Visible = false;
            // 
            // msk_tc
            // 
            this.msk_tc.Location = new System.Drawing.Point(222, 120);
            this.msk_tc.Mask = "00000000000";
            this.msk_tc.Name = "msk_tc";
            this.msk_tc.Size = new System.Drawing.Size(148, 20);
            this.msk_tc.TabIndex = 10;
            this.msk_tc.ValidatingType = typeof(int);
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(222, 150);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.Size = new System.Drawing.Size(148, 20);
            this.txt_sifre.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 14F);
            this.label3.Location = new System.Drawing.Point(137, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Şifre :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 14F);
            this.label2.Location = new System.Drawing.Point(70, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "TC Kimlik No :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 15.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "DOKTOR GİRİŞ PANELİ";
            // 
            // doktor_login_form
            // 
            this.AcceptButton = this.button_hasta_giris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(571, 368);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_hasta_giris);
            this.Controls.Add(this.lnk_uyeol_hasta_giris);
            this.Controls.Add(this.msk_tc);
            this.Controls.Add(this.txt_sifre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "doktor_login_form";
            this.Text = "Doktor Giriş Sayfası";
            this.Load += new System.EventHandler(this.doktor_login_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_hasta_giris;
        private System.Windows.Forms.LinkLabel lnk_uyeol_hasta_giris;
        private System.Windows.Forms.MaskedTextBox msk_tc;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}