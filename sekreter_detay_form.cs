using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace proje_hastane
{
    public partial class sekreter_detay_form : Form
    {
        private string tcno; // TC numarasını saklayacak değişken
        sql_baglantisi baglanti = new sql_baglantisi();

        // Parametresiz constructor (Visual Studionun kullandığı)
        public sekreter_detay_form()
        {
            InitializeComponent();
        }

        // Parametreli constructor (gönderilen TCyi almak için)
        public sekreter_detay_form(string tc) : this() // this() ile yukarıdaki constructorı da çağırır 
        {
            tcno = tc;
        }

        private void sekreter_detay_form_Load(object sender, EventArgs e)
        {
            label_tc.Text = tcno; // TC numarasını labela yaz
            SqlCommand komut = new SqlCommand("select sekreter_adsoyad from Table_sekreter where sekreter_tc = @sekreter_tc", baglanti.baglanti());
            komut.Parameters.AddWithValue("sekreter_tc", label_tc.Text);

            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                label_adsoyad.Text = reader[0].ToString();
            }
            baglanti.baglanti().Close();

            //data grid veri aktarma
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Table_brans",baglanti.baglanti());
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            DataTable dt2 = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter("select * from Table_doktor", baglanti.baglanti());
            adapter1.Fill(dt2);
            dataGridView2.DataSource = dt2;


            //combobox veri aktarımı
            SqlCommand komut2 = new SqlCommand("select brans_ad from Table_brans", baglanti.baglanti());
            SqlDataReader reader2 = komut2.ExecuteReader();
            while (reader2.Read())
            {
                cmb_brans.Items.Add(reader2[0].ToString());
            }
            
            //combobox veri aktarımı
        }

        //çıkış butonu -----------------------------------------------
        private void button_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //çıkış butonu -----------------------------------------------


        //randevu paneli butonu -----------------------------------------------
        private void button_randevu_list_Click(object sender, EventArgs e)
        {
            randevu_paneli_form randevu_Paneli_ = new randevu_paneli_form();
            randevu_Paneli_.Show();
            
        }
        //randevu paneli butonu -----------------------------------------------


        //doktor paneli butonu -----------------------------------------------
        private void button_doktor_list_Click(object sender, EventArgs e)
        {
            doktor_paneli_form doktor_Paneli_ = new doktor_paneli_form();
            doktor_Paneli_.Show();
        }
        //doktor paneli butonu -----------------------------------------------


        //branş paneli butonu -----------------------------------------------
        private void button_brans_list_Click(object sender, EventArgs e)
        {
            brans_paneli_form brans_Paneli_ = new brans_paneli_form();
            brans_Paneli_.Show();
        }

        private void lnk_bilgi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("FATAL ERROR");
        }


        //branş paneli butonu -----------------------------------------------



        //kaydet butonu -----------------------------------------------
        private void button_kaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(
                "insert into Table_randevu (randevu_tarih , randevu_saat , randevu_brans , randevu_doktor , randevu_durum , hasta_tc ) values" +
                "(@randevu_tarih , @randevu_saat , @randevu_brans , @randevu_doktor , @randevu_durum , @hasta_tc)",baglanti.baglanti());
            komut.Parameters.AddWithValue("randevu_tarih",msk_tarih.Text.ToString());
            komut.Parameters.AddWithValue("randevu_saat", msk_saat.Text.ToString());
            komut.Parameters.AddWithValue("hasta_tc", msk_tc.Text.ToString());
            komut.Parameters.AddWithValue("randevu_brans",cmb_brans.Text.ToString());
            komut.Parameters.AddWithValue("randevu_doktor", cmb_doktor.Text.ToString());
            komut.Parameters.AddWithValue("randevu_durum"  , checkBox_durum.Text.ToString());
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("randevu kaydedildi","bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmb_brans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_doktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select doktor_ad from Table_doktor", baglanti.baglanti());
            SqlDataReader reader3 = komut3.ExecuteReader();
            while (reader3.Read())
            {
                cmb_doktor.Items.Add(reader3[0].ToString());
            }
            //combobox veri aktarımı
           
        }


        //duyuru oluşturma
        private void button_olustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("insert into Table_duyuru (duyuru) values (@duyuru)",baglanti.baglanti());
            komut3.Parameters.AddWithValue("duyuru",rch_duyuru.Text.ToString());
            komut3.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu","Bilgi",MessageBoxButtons.OK , MessageBoxIcon.Information);
        }
    }
}
