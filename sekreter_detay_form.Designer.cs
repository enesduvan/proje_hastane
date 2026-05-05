namespace proje_hastane
{
    partial class sekreter_detay_form
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
            this.lnk_bilgi = new System.Windows.Forms.LinkLabel();
            this.label_adsoyad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_tc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_olustur = new System.Windows.Forms.Button();
            this.rch_duyuru = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_kaydet = new System.Windows.Forms.Button();
            this.checkBox_durum = new System.Windows.Forms.CheckBox();
            this.msk_tc = new System.Windows.Forms.MaskedTextBox();
            this.cmb_doktor = new System.Windows.Forms.ComboBox();
            this.cmb_brans = new System.Windows.Forms.ComboBox();
            this.msk_saat = new System.Windows.Forms.MaskedTextBox();
            this.msk_tarih = new System.Windows.Forms.MaskedTextBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button_cıkıs = new System.Windows.Forms.Button();
            this.button_randevu_list = new System.Windows.Forms.Button();
            this.button_brans_list = new System.Windows.Forms.Button();
            this.button_doktor_list = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnk_bilgi
            // 
            this.lnk_bilgi.AutoSize = true;
            this.lnk_bilgi.Location = new System.Drawing.Point(8, 112);
            this.lnk_bilgi.Name = "lnk_bilgi";
            this.lnk_bilgi.Size = new System.Drawing.Size(89, 13);
            this.lnk_bilgi.TabIndex = 16;
            this.lnk_bilgi.TabStop = true;
            this.lnk_bilgi.Text = "Bilgilerini Düzenle";
            this.lnk_bilgi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_bilgi_LinkClicked);
            // 
            // label_adsoyad
            // 
            this.label_adsoyad.AutoSize = true;
            this.label_adsoyad.Font = new System.Drawing.Font("Corbel", 14F);
            this.label_adsoyad.Location = new System.Drawing.Point(83, 58);
            this.label_adsoyad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_adsoyad.Name = "label_adsoyad";
            this.label_adsoyad.Size = new System.Drawing.Size(16, 23);
            this.label_adsoyad.TabIndex = 15;
            this.label_adsoyad.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 14F);
            this.label2.Location = new System.Drawing.Point(7, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "TC No :";
            // 
            // label_tc
            // 
            this.label_tc.AutoSize = true;
            this.label_tc.Font = new System.Drawing.Font("Corbel", 14F);
            this.label_tc.Location = new System.Drawing.Point(83, 26);
            this.label_tc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_tc.Name = "label_tc";
            this.label_tc.Size = new System.Drawing.Size(16, 23);
            this.label_tc.TabIndex = 13;
            this.label_tc.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 14F);
            this.label3.Location = new System.Drawing.Point(23, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "İsim :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lnk_bilgi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label_adsoyad);
            this.groupBox1.Controls.Add(this.label_tc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 144);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sekreter Bilgi";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_olustur);
            this.groupBox2.Controls.Add(this.rch_duyuru);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(13, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 258);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Duyuru Oluştur";
            // 
            // button_olustur
            // 
            this.button_olustur.Font = new System.Drawing.Font("Corbel", 14F);
            this.button_olustur.Location = new System.Drawing.Point(45, 224);
            this.button_olustur.Name = "button_olustur";
            this.button_olustur.Size = new System.Drawing.Size(176, 30);
            this.button_olustur.TabIndex = 1;
            this.button_olustur.Text = "Oluştur";
            this.button_olustur.UseVisualStyleBackColor = true;
            this.button_olustur.Click += new System.EventHandler(this.button_olustur_Click);
            // 
            // rch_duyuru
            // 
            this.rch_duyuru.Location = new System.Drawing.Point(7, 20);
            this.rch_duyuru.Name = "rch_duyuru";
            this.rch_duyuru.Size = new System.Drawing.Size(251, 189);
            this.rch_duyuru.TabIndex = 0;
            this.rch_duyuru.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_kaydet);
            this.groupBox3.Controls.Add(this.checkBox_durum);
            this.groupBox3.Controls.Add(this.msk_tc);
            this.groupBox3.Controls.Add(this.cmb_doktor);
            this.groupBox3.Controls.Add(this.cmb_brans);
            this.groupBox3.Controls.Add(this.msk_saat);
            this.groupBox3.Controls.Add(this.msk_tarih);
            this.groupBox3.Controls.Add(this.txt_id);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(283, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 409);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Randevu Paneli";
            // 
            // button_kaydet
            // 
            this.button_kaydet.Font = new System.Drawing.Font("Corbel", 14F);
            this.button_kaydet.Location = new System.Drawing.Point(31, 375);
            this.button_kaydet.Name = "button_kaydet";
            this.button_kaydet.Size = new System.Drawing.Size(176, 30);
            this.button_kaydet.TabIndex = 29;
            this.button_kaydet.Text = "Kaydet";
            this.button_kaydet.UseVisualStyleBackColor = true;
            this.button_kaydet.Click += new System.EventHandler(this.button_kaydet_Click);
            // 
            // checkBox_durum
            // 
            this.checkBox_durum.AutoSize = true;
            this.checkBox_durum.Font = new System.Drawing.Font("Corbel", 14F);
            this.checkBox_durum.Location = new System.Drawing.Point(97, 186);
            this.checkBox_durum.Name = "checkBox_durum";
            this.checkBox_durum.Size = new System.Drawing.Size(84, 27);
            this.checkBox_durum.TabIndex = 27;
            this.checkBox_durum.Text = "Durum";
            this.checkBox_durum.UseVisualStyleBackColor = true;
            // 
            // msk_tc
            // 
            this.msk_tc.Location = new System.Drawing.Point(96, 159);
            this.msk_tc.Mask = "00000000000";
            this.msk_tc.Name = "msk_tc";
            this.msk_tc.Size = new System.Drawing.Size(100, 20);
            this.msk_tc.TabIndex = 26;
            this.msk_tc.ValidatingType = typeof(int);
            // 
            // cmb_doktor
            // 
            this.cmb_doktor.FormattingEnabled = true;
            this.cmb_doktor.Location = new System.Drawing.Point(96, 132);
            this.cmb_doktor.Name = "cmb_doktor";
            this.cmb_doktor.Size = new System.Drawing.Size(100, 21);
            this.cmb_doktor.TabIndex = 25;
            // 
            // cmb_brans
            // 
            this.cmb_brans.FormattingEnabled = true;
            this.cmb_brans.Location = new System.Drawing.Point(96, 105);
            this.cmb_brans.Name = "cmb_brans";
            this.cmb_brans.Size = new System.Drawing.Size(100, 21);
            this.cmb_brans.TabIndex = 24;
            this.cmb_brans.SelectedIndexChanged += new System.EventHandler(this.cmb_brans_SelectedIndexChanged);
            // 
            // msk_saat
            // 
            this.msk_saat.Location = new System.Drawing.Point(96, 78);
            this.msk_saat.Mask = "00:00";
            this.msk_saat.Name = "msk_saat";
            this.msk_saat.Size = new System.Drawing.Size(100, 20);
            this.msk_saat.TabIndex = 23;
            this.msk_saat.ValidatingType = typeof(System.DateTime);
            // 
            // msk_tarih
            // 
            this.msk_tarih.Location = new System.Drawing.Point(97, 52);
            this.msk_tarih.Mask = "00/00/0000";
            this.msk_tarih.Name = "msk_tarih";
            this.msk_tarih.Size = new System.Drawing.Size(100, 20);
            this.msk_tarih.TabIndex = 22;
            this.msk_tarih.ValidatingType = typeof(System.DateTime);
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(97, 26);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(100, 20);
            this.txt_id.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Corbel", 14F);
            this.label9.Location = new System.Drawing.Point(52, 156);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 23);
            this.label9.TabIndex = 20;
            this.label9.Text = "Tc :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Corbel", 14F);
            this.label7.Location = new System.Drawing.Point(16, 130);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "Doktor :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Corbel", 14F);
            this.label6.Location = new System.Drawing.Point(27, 103);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "Branş :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 14F);
            this.label5.Location = new System.Drawing.Point(36, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "Saat :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 14F);
            this.label4.Location = new System.Drawing.Point(31, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tarih :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 14F);
            this.label1.Location = new System.Drawing.Point(56, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "İd :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.groupBox4.Location = new System.Drawing.Point(519, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(407, 152);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Branşlar";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(401, 133);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridView2);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.groupBox5.Location = new System.Drawing.Point(522, 168);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(407, 152);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Doktorlar";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 16);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(401, 133);
            this.dataGridView2.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button_cıkıs);
            this.groupBox6.Controls.Add(this.button_randevu_list);
            this.groupBox6.Controls.Add(this.button_brans_list);
            this.groupBox6.Controls.Add(this.button_doktor_list);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.groupBox6.Location = new System.Drawing.Point(525, 324);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(404, 100);
            this.groupBox6.TabIndex = 22;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Hızlı Erişim";
            // 
            // button_cıkıs
            // 
            this.button_cıkıs.Font = new System.Drawing.Font("Corbel", 14F);
            this.button_cıkıs.Location = new System.Drawing.Point(206, 64);
            this.button_cıkıs.Name = "button_cıkıs";
            this.button_cıkıs.Size = new System.Drawing.Size(176, 30);
            this.button_cıkıs.TabIndex = 32;
            this.button_cıkıs.Text = "Çıkış";
            this.button_cıkıs.UseVisualStyleBackColor = true;
            this.button_cıkıs.Click += new System.EventHandler(this.button_cıkıs_Click);
            // 
            // button_randevu_list
            // 
            this.button_randevu_list.Font = new System.Drawing.Font("Corbel", 14F);
            this.button_randevu_list.Location = new System.Drawing.Point(6, 64);
            this.button_randevu_list.Name = "button_randevu_list";
            this.button_randevu_list.Size = new System.Drawing.Size(176, 30);
            this.button_randevu_list.TabIndex = 31;
            this.button_randevu_list.Text = "Randevu Listesi";
            this.button_randevu_list.UseVisualStyleBackColor = true;
            this.button_randevu_list.Click += new System.EventHandler(this.button_randevu_list_Click);
            // 
            // button_brans_list
            // 
            this.button_brans_list.Font = new System.Drawing.Font("Corbel", 14F);
            this.button_brans_list.Location = new System.Drawing.Point(206, 29);
            this.button_brans_list.Name = "button_brans_list";
            this.button_brans_list.Size = new System.Drawing.Size(176, 30);
            this.button_brans_list.TabIndex = 30;
            this.button_brans_list.Text = "Branş Listesi";
            this.button_brans_list.UseVisualStyleBackColor = true;
            this.button_brans_list.Click += new System.EventHandler(this.button_brans_list_Click);
            // 
            // button_doktor_list
            // 
            this.button_doktor_list.Font = new System.Drawing.Font("Corbel", 14F);
            this.button_doktor_list.Location = new System.Drawing.Point(6, 29);
            this.button_doktor_list.Name = "button_doktor_list";
            this.button_doktor_list.Size = new System.Drawing.Size(176, 30);
            this.button_doktor_list.TabIndex = 29;
            this.button_doktor_list.Text = "Doktor Listesi";
            this.button_doktor_list.UseVisualStyleBackColor = true;
            this.button_doktor_list.Click += new System.EventHandler(this.button_doktor_list_Click);
            // 
            // sekreter_detay_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(938, 434);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Corbel", 14F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "sekreter_detay_form";
            this.Text = "Durum :";
            this.Load += new System.EventHandler(this.sekreter_detay_form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnk_bilgi;
        private System.Windows.Forms.Label label_adsoyad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_tc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_olustur;
        private System.Windows.Forms.RichTextBox rch_duyuru;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox msk_tarih;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_brans;
        private System.Windows.Forms.MaskedTextBox msk_saat;
        private System.Windows.Forms.Button button_kaydet;
        private System.Windows.Forms.CheckBox checkBox_durum;
        private System.Windows.Forms.MaskedTextBox msk_tc;
        private System.Windows.Forms.ComboBox cmb_doktor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button_cıkıs;
        private System.Windows.Forms.Button button_randevu_list;
        private System.Windows.Forms.Button button_brans_list;
        private System.Windows.Forms.Button button_doktor_list;
    }
}