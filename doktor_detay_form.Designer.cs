namespace proje_hastane
{
    partial class doktor_detay_form
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lnk_bilgi = new System.Windows.Forms.LinkLabel();
            this.label_adsoyad = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_tc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rch_sikayet = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_cıkıs = new System.Windows.Forms.Button();
            this.button_duyuru = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lnk_bilgi);
            this.groupBox2.Controls.Add(this.label_adsoyad);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label_tc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 121);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Doktor Bilgi";
            // 
            // lnk_bilgi
            // 
            this.lnk_bilgi.AutoSize = true;
            this.lnk_bilgi.Location = new System.Drawing.Point(8, 102);
            this.lnk_bilgi.Name = "lnk_bilgi";
            this.lnk_bilgi.Size = new System.Drawing.Size(89, 13);
            this.lnk_bilgi.TabIndex = 11;
            this.lnk_bilgi.TabStop = true;
            this.lnk_bilgi.Text = "Bilgilerini Düzenle";
            this.lnk_bilgi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_bilgi_LinkClicked);
            // 
            // label_adsoyad
            // 
            this.label_adsoyad.AutoSize = true;
            this.label_adsoyad.Font = new System.Drawing.Font("Corbel", 14F);
            this.label_adsoyad.Location = new System.Drawing.Point(83, 48);
            this.label_adsoyad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_adsoyad.Name = "label_adsoyad";
            this.label_adsoyad.Size = new System.Drawing.Size(16, 23);
            this.label_adsoyad.TabIndex = 10;
            this.label_adsoyad.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 14F);
            this.label2.Location = new System.Drawing.Point(7, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "TC No :";
            // 
            // label_tc
            // 
            this.label_tc.AutoSize = true;
            this.label_tc.Font = new System.Drawing.Font("Corbel", 14F);
            this.label_tc.Location = new System.Drawing.Point(83, 16);
            this.label_tc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_tc.Name = "label_tc";
            this.label_tc.Size = new System.Drawing.Size(16, 23);
            this.label_tc.TabIndex = 8;
            this.label_tc.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 14F);
            this.label3.Location = new System.Drawing.Point(23, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "İsim :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rch_sikayet);
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 228);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Randevu Detay";
            // 
            // rch_sikayet
            // 
            this.rch_sikayet.Location = new System.Drawing.Point(7, 20);
            this.rch_sikayet.Name = "rch_sikayet";
            this.rch_sikayet.Size = new System.Drawing.Size(329, 202);
            this.rch_sikayet.TabIndex = 0;
            this.rch_sikayet.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(361, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(427, 425);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Randevu Listesi";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(421, 406);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_cıkıs);
            this.groupBox4.Controls.Add(this.button_duyuru);
            this.groupBox4.Location = new System.Drawing.Point(12, 375);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(342, 63);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Hızlı Erişim";
            // 
            // button_cıkıs
            // 
            this.button_cıkıs.Location = new System.Drawing.Point(117, 20);
            this.button_cıkıs.Name = "button_cıkıs";
            this.button_cıkıs.Size = new System.Drawing.Size(75, 23);
            this.button_cıkıs.TabIndex = 1;
            this.button_cıkıs.Text = "Çıkış";
            this.button_cıkıs.UseVisualStyleBackColor = true;
            this.button_cıkıs.Click += new System.EventHandler(this.button_cıkıs_Click);
            // 
            // button_duyuru
            // 
            this.button_duyuru.Location = new System.Drawing.Point(11, 20);
            this.button_duyuru.Name = "button_duyuru";
            this.button_duyuru.Size = new System.Drawing.Size(75, 23);
            this.button_duyuru.TabIndex = 0;
            this.button_duyuru.Text = "Duyurular";
            this.button_duyuru.UseVisualStyleBackColor = true;
            this.button_duyuru.Click += new System.EventHandler(this.button_duyuru_Click);
            // 
            // doktor_detay_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "doktor_detay_form";
            this.Text = "Doktor Sayfası";
            this.Load += new System.EventHandler(this.doktor_detay_form_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel lnk_bilgi;
        private System.Windows.Forms.Label label_adsoyad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_tc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox rch_sikayet;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_cıkıs;
        private System.Windows.Forms.Button button_duyuru;
    }
}