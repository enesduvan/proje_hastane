namespace proje_hastane
{
    partial class doktor_paneli_form
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
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_brans = new System.Windows.Forms.ComboBox();
            this.button_ekle = new System.Windows.Forms.Button();
            this.button_hasta_kayit = new System.Windows.Forms.Button();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_soyad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.msk_tc = new System.Windows.Forms.MaskedTextBox();
            this.txt_ad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_sil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Corbel", 14F);
            this.label6.Location = new System.Drawing.Point(132, 179);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 23);
            this.label6.TabIndex = 69;
            this.label6.Text = "Branş :";
            // 
            // cmb_brans
            // 
            this.cmb_brans.FormattingEnabled = true;
            this.cmb_brans.Location = new System.Drawing.Point(202, 183);
            this.cmb_brans.Name = "cmb_brans";
            this.cmb_brans.Size = new System.Drawing.Size(147, 21);
            this.cmb_brans.TabIndex = 68;
            // 
            // button_ekle
            // 
            this.button_ekle.BackColor = System.Drawing.Color.Snow;
            this.button_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ekle.Location = new System.Drawing.Point(201, 231);
            this.button_ekle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_ekle.Name = "button_ekle";
            this.button_ekle.Size = new System.Drawing.Size(73, 30);
            this.button_ekle.TabIndex = 65;
            this.button_ekle.Text = "Ekle";
            this.button_ekle.UseVisualStyleBackColor = false;
            this.button_ekle.Click += new System.EventHandler(this.button_ekle_Click);
            // 
            // button_hasta_kayit
            // 
            this.button_hasta_kayit.BackColor = System.Drawing.Color.White;
            this.button_hasta_kayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_hasta_kayit.Location = new System.Drawing.Point(202, 277);
            this.button_hasta_kayit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_hasta_kayit.Name = "button_hasta_kayit";
            this.button_hasta_kayit.Size = new System.Drawing.Size(150, 30);
            this.button_hasta_kayit.TabIndex = 64;
            this.button_hasta_kayit.Text = "Güncelle";
            this.button_hasta_kayit.UseVisualStyleBackColor = false;
            this.button_hasta_kayit.Click += new System.EventHandler(this.button_hasta_kayit_Click);
            // 
            // txt_sifre
            // 
            this.txt_sifre.Location = new System.Drawing.Point(201, 149);
            this.txt_sifre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.Size = new System.Drawing.Size(148, 20);
            this.txt_sifre.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 14F);
            this.label5.Location = new System.Drawing.Point(141, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 23);
            this.label5.TabIndex = 67;
            this.label5.Text = "Şifre :";
            // 
            // txt_soyad
            // 
            this.txt_soyad.Location = new System.Drawing.Point(201, 80);
            this.txt_soyad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_soyad.Name = "txt_soyad";
            this.txt_soyad.Size = new System.Drawing.Size(148, 20);
            this.txt_soyad.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 14F);
            this.label4.Location = new System.Drawing.Point(121, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 23);
            this.label4.TabIndex = 66;
            this.label4.Text = "Soy Ad :";
            // 
            // msk_tc
            // 
            this.msk_tc.Location = new System.Drawing.Point(201, 116);
            this.msk_tc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.msk_tc.Mask = "00000000000";
            this.msk_tc.Name = "msk_tc";
            this.msk_tc.Size = new System.Drawing.Size(148, 20);
            this.msk_tc.TabIndex = 60;
            this.msk_tc.ValidatingType = typeof(int);
            // 
            // txt_ad
            // 
            this.txt_ad.Location = new System.Drawing.Point(201, 44);
            this.txt_ad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(148, 20);
            this.txt_ad.TabIndex = 58;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 14F);
            this.label3.Location = new System.Drawing.Point(154, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 23);
            this.label3.TabIndex = 63;
            this.label3.Text = "Ad :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 14F);
            this.label2.Location = new System.Drawing.Point(74, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 62;
            this.label2.Text = "TC Kimlik No :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(373, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(391, 160);
            this.dataGridView1.TabIndex = 70;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // button_sil
            // 
            this.button_sil.BackColor = System.Drawing.Color.Snow;
            this.button_sil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sil.Location = new System.Drawing.Point(280, 231);
            this.button_sil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_sil.Name = "button_sil";
            this.button_sil.Size = new System.Drawing.Size(72, 30);
            this.button_sil.TabIndex = 71;
            this.button_sil.Text = "Sil";
            this.button_sil.UseVisualStyleBackColor = false;
            this.button_sil.Click += new System.EventHandler(this.button_sil_Click);
            // 
            // doktor_paneli_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(828, 317);
            this.Controls.Add(this.button_sil);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_brans);
            this.Controls.Add(this.button_ekle);
            this.Controls.Add(this.button_hasta_kayit);
            this.Controls.Add(this.txt_sifre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_soyad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.msk_tc);
            this.Controls.Add(this.txt_ad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "doktor_paneli_form";
            this.Text = "doktor_paneli_form";
            this.Load += new System.EventHandler(this.doktor_paneli_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_brans;
        private System.Windows.Forms.Button button_ekle;
        private System.Windows.Forms.Button button_hasta_kayit;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_soyad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox msk_tc;
        private System.Windows.Forms.TextBox txt_ad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_sil;
    }
}