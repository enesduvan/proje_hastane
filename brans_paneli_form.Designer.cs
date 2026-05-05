namespace proje_hastane
{
    partial class brans_paneli_form
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
            this.button_sil = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_ekle = new System.Windows.Forms.Button();
            this.button_guncelle = new System.Windows.Forms.Button();
            this.txt_brans = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_sil
            // 
            this.button_sil.BackColor = System.Drawing.Color.Snow;
            this.button_sil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_sil.Location = new System.Drawing.Point(249, 171);
            this.button_sil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_sil.Name = "button_sil";
            this.button_sil.Size = new System.Drawing.Size(69, 30);
            this.button_sil.TabIndex = 85;
            this.button_sil.Text = "Sil";
            this.button_sil.UseVisualStyleBackColor = false;
            this.button_sil.Click += new System.EventHandler(this.button_sil_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(342, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(399, 160);
            this.dataGridView1.TabIndex = 84;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button_ekle
            // 
            this.button_ekle.BackColor = System.Drawing.Color.Snow;
            this.button_ekle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ekle.Location = new System.Drawing.Point(170, 171);
            this.button_ekle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_ekle.Name = "button_ekle";
            this.button_ekle.Size = new System.Drawing.Size(73, 30);
            this.button_ekle.TabIndex = 79;
            this.button_ekle.Text = "Ekle";
            this.button_ekle.UseVisualStyleBackColor = false;
            this.button_ekle.Click += new System.EventHandler(this.button_ekle_Click);
            // 
            // button_guncelle
            // 
            this.button_guncelle.BackColor = System.Drawing.Color.White;
            this.button_guncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_guncelle.Location = new System.Drawing.Point(171, 217);
            this.button_guncelle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_guncelle.Name = "button_guncelle";
            this.button_guncelle.Size = new System.Drawing.Size(147, 30);
            this.button_guncelle.TabIndex = 78;
            this.button_guncelle.Text = "Güncelle";
            this.button_guncelle.UseVisualStyleBackColor = false;
            this.button_guncelle.Click += new System.EventHandler(this.button_guncelle_Click);
            // 
            // txt_brans
            // 
            this.txt_brans.Location = new System.Drawing.Point(170, 125);
            this.txt_brans.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_brans.Name = "txt_brans";
            this.txt_brans.Size = new System.Drawing.Size(148, 20);
            this.txt_brans.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 14F);
            this.label4.Location = new System.Drawing.Point(76, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 80;
            this.label4.Text = "Brans Ad :";
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(170, 89);
            this.txt_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(148, 20);
            this.txt_id.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 14F);
            this.label3.Location = new System.Drawing.Point(82, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 77;
            this.label3.Text = "Brans İd :";
            // 
            // brans_paneli_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tomato;
            this.ClientSize = new System.Drawing.Size(806, 327);
            this.Controls.Add(this.button_sil);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_ekle);
            this.Controls.Add(this.button_guncelle);
            this.Controls.Add(this.txt_brans);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.label3);
            this.Name = "brans_paneli_form";
            this.Text = "brans_paneli_form";
            this.Load += new System.EventHandler(this.brans_paneli_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_sil;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_ekle;
        private System.Windows.Forms.Button button_guncelle;
        private System.Windows.Forms.TextBox txt_brans;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Label label3;
    }
}