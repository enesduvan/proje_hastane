using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace proje_hastane
{
    public partial class hasta_detay_form : Form
    {
        
        public hasta_detay_form()
        {
            InitializeComponent();
            
        }

        Thread thread;
        public string tc;
        sql_baglantisi baglanti = new sql_baglantisi();

        //bilgileri güncelle butonu--------------------------------------------------------------------------------
        /*
                public void sayfa_guncelle()
                {
                    Application.Run(new hasta_guncelle_form());
                }
                private void lnk_bilgi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                    this.Close();
                    thread = new Thread(sayfa_guncelle);
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }*/
        private void lnk_bilgi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hasta_guncelle_form hasta_Guncelle_ = new hasta_guncelle_form();
            hasta_Guncelle_.tcno = tc;
            hasta_Guncelle_.Show();
        }

        private void hasta_detay_form_Load(object sender, EventArgs e)
        {
            label_tc.Text = tc;
            SqlCommand komut = new SqlCommand("select hasta_ad , hasta_soyad from Table_hasta where hasta_tc = @hasta_tc", baglanti.baglanti());
            komut.Parameters.AddWithValue("hasta_tc", label_tc.Text);

            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                label_adsoyad.Text = reader[0] + " " + reader[1];
            }
            baglanti.baglanti().Close();


            ///data grid wiew içine sql atma
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Table_randevu WHERE hasta_tc = @hasta_tc",baglanti.baglanti());

            // Parametreyi ekle
            adapter.SelectCommand.Parameters.AddWithValue("@hasta_tc", label_tc.Text);

            // Veriyi doldur ve DataGridView'e ata
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.baglanti().Close();



            //branşları çekme,
            SqlCommand komut2 = new SqlCommand("select brans_ad from Table_brans", baglanti.baglanti());
            SqlDataReader reader2 = komut2.ExecuteReader();
            while (reader2.Read())
            {
                cmb_brans.Items.Add(reader2[0]);
            }
            baglanti.baglanti().Close();
        }

        //--------------------------------------------------------------------------------------------------
        private void button_randevu_Click(object sender, EventArgs e)
        {

        }
         //doktor çekme
        private void cmb_brans_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("select doktor_ad,doktor_soyad from Table_doktor where doktor_brans = @doktor_brans", baglanti.baglanti());
            komut3.Parameters.AddWithValue("doktor_brans",cmb_brans.Text);
            SqlDataReader reader3 = komut3.ExecuteReader();
            cmb_doktor.Items.Clear();
            while (reader3.Read())
            {
                cmb_doktor.Items.Add(reader3[0] + " " + reader3[1]);
            }
            baglanti.baglanti().Close();
        }

        //aktif randevu çekme
        private void cmb_doktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Table_randevu where randevu_brans = '"+ cmb_brans.Text + "'",baglanti.baglanti());
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.baglanti().Close();
        }
        
    }
}
