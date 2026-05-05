using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proje_hastane
{
    public partial class hasta_guncelle_form : Form
    {
        public hasta_guncelle_form()
        {
            InitializeComponent();
        }
        public string tcno;
        sql_baglantisi baglanti = new sql_baglantisi();
        //geri butonu--------------------------------------------------------------------------------
        Thread thread;
        public void sayfa_guncelle()
        {
            Application.Run(new hasta_detay_form());
        }
        private void button_geri_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(sayfa_guncelle);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        //geri butonu ^^--------------------------------------------------------------------------------

        

        private void hasta_guncelle_form_Load(object sender, EventArgs e)
        {
            msk_tc.Text = tcno;
            SqlCommand komut = new SqlCommand("select * from Table_hasta where hasta_tc =@hasta_tc", baglanti.baglanti());
            komut.Parameters.AddWithValue("hasta_tc", tcno);

            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                txt_ad.Text = reader[1].ToString();
                txt_soyad.Text = reader[2].ToString();
                msk_telefon.Text = reader[4].ToString();
                txt_sifre.Text = reader[5].ToString();
                cmb_cinsiyet.Text = reader[6].ToString();
            }
            baglanti.baglanti().Close();
        }


        //günceşşe butonu
        private void button_hasta_kayit_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Table_hasta set hasta_ad=@hasta_ad , hasta_soyad=@hasta_soyad ," +
                "hasta_telefon=@hasta_telefon , hasta_sifre=@hasta_sifre , hasta_cinsiyet = @hasta_cinsiyet , hasta_tc = @hasta_tc",baglanti.baglanti());

            komut.Parameters.AddWithValue("hasta_ad",txt_ad.Text);
            komut.Parameters.AddWithValue("hasta_soyad", txt_soyad.Text);
            komut.Parameters.AddWithValue("hasta_telefon", msk_telefon.Text.ToString());
            komut.Parameters.AddWithValue("hasta_sifre", txt_sifre.Text.ToString());
            komut.Parameters.AddWithValue("hasta_cinsiyet", cmb_cinsiyet.Text);
            komut.Parameters.AddWithValue("hasta_tc", msk_tc.Text.ToString());
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("kullanıcı güncellendi");
        }
    }
}
