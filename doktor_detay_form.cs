using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace proje_hastane
{
    public partial class doktor_detay_form : Form
    {
        private sql_baglantisi baglanti = new sql_baglantisi();
        private string _tc;

        public doktor_detay_form()
        {
            InitializeComponent();
        }

        public doktor_detay_form(string tc)
        {
            InitializeComponent();
            _tc = tc;
        }


        //doktor bilgi güncelleme sayfasına gidiş --------------------------------------------
        Thread thread;
        public void sayfa_degistir()
        {
            Application.Run(new doktor_bilgi_guncelle(_tc));
        }
        private void lnk_bilgi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            thread = new Thread(sayfa_degistir);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void button_duyuru_Click(object sender, EventArgs e)
        {
            duyurular_form duyurular_ = new duyurular_form();
            duyurular_.Show();
        }

        private void button_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ArrangeLayout()
        {
            SuspendLayout();

            int margin = 16;
            int gap = 16;
            int headerHeight = ModernTheme.GetHeaderHeight(this);
            int contentTop = headerHeight + 20;

            int leftWidth = Math.Max(340, (int)(ClientSize.Width * 0.30));
            int rightWidth = ClientSize.Width - (margin * 2) - gap - leftWidth;
            int contentHeight = Math.Max(380, ClientSize.Height - contentTop - margin);

            groupBox1.SetBounds(margin, contentTop, leftWidth, 140);

            int quickAccessHeight = 80;
            groupBox4.SetBounds(margin, contentTop + contentHeight - quickAccessHeight, leftWidth, quickAccessHeight);

            groupBox2.SetBounds(margin, groupBox1.Bottom + gap, leftWidth, contentHeight - groupBox1.Height - groupBox4.Height - (gap * 2));
            groupBox3.SetBounds(groupBox1.Right + gap, contentTop, rightWidth, contentHeight);

            // group 1 (info)
            int labelLeft = 16;
            int valueLeft = 100;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_tc.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label_adsoyad.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label2.Location = new Point(labelLeft, 36);
            label_tc.Location = new Point(valueLeft, 36);
            label3.Location = new Point(labelLeft, 74);
            label_adsoyad.Location = new Point(valueLeft, 74);
            lnk_bilgi.Location = new Point(labelLeft, groupBox1.ClientSize.Height - 34);

            // group 2
            rch_sikayet.SetBounds(14, 24, groupBox2.ClientSize.Width - 28, groupBox2.ClientSize.Height - 38);

            // group 4
            int btnWidth = (groupBox4.ClientSize.Width - 28 - gap) / 2;
            button_duyuru.SetBounds(14, 30, btnWidth, 34);
            button_cıkıs.SetBounds(14 + btnWidth + gap, 30, btnWidth, 34);

            ResumeLayout();
        }

        private void GetDoctorInfo()
        {
            label_tc.Text = _tc;
            System.Data.DataRow row = baglanti.GetDataRow("SELECT doktor_ad, doktor_soyad FROM Table_doktor WHERE doktor_tc = @tc", new System.Data.SqlClient.SqlParameter("@tc", _tc));
            if(row != null) {
                label_adsoyad.Text = row["doktor_ad"].ToString() + " " + row["doktor_soyad"].ToString();
            }

            // Get Randevus
            dataGridView1.DataSource = baglanti.GetDataTable(
                "SELECT randevu_id, randevu_tarih, randevu_saat, hasta_tc, randevu_sikayet, randevu_durum FROM Table_randevu WHERE randevu_doktor = @doktor_adsoyad", 
                new System.Data.SqlClient.SqlParameter("@doktor_adsoyad", label_adsoyad.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            rch_sikayet.Text = dataGridView1.Rows[e.RowIndex].Cells["randevu_sikayet"].Value.ToString();
        }

        private void doktor_detay_form_Load(object sender, EventArgs e)
        {
            ModernTheme.StyleForm(this, "Doktor Paneli", "Tum randevularinizi goruntuleyin ve sikayetleri okuyun.");
            GetDoctorInfo();
            ArrangeLayout();

            dataGridView1.CellClick += dataGridView1_CellClick;

            Resize += (s, args) => ArrangeLayout();
            Shown += (s, args) => ArrangeLayout();
        }
    }
}
