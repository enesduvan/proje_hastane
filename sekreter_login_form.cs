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

namespace proje_hastane
{
    public partial class sekreter_login_form : Form
    {
        public sekreter_login_form()
        {
            InitializeComponent();
        }

        sql_baglantisi baglanti = new sql_baglantisi();
        //çıkış butonu **------------------------------------------------------------------ 
        Thread thread;
        public void sayfa_guncelle()
        {
            Application.Run(new main_login_form());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(sayfa_guncelle);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        //çıkış butonu -------------------------------------------------------------------------



        //giriş yap butonu --------------------------------------------------------
        public void sayfa_guncelle2()
        {
            Application.Run(new sekreter_detay_form());
        }
        private void button_hasta_giris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(
                "select sekreter_adsoyad from Table_sekreter where sekreter_tc = @sekreter_tc and sekreter_sifre = @sekreter_sifre",
                baglanti.baglanti());
            komut.Parameters.AddWithValue("@sekreter_tc", msk_tc.Text);
            komut.Parameters.AddWithValue("@sekreter_sifre", txt_sifre.Text);

            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {
                string girilenTC = msk_tc.Text; // TC numarasını alıyoruz

                this.Close();
                thread = new Thread(() =>
                {
                    Application.Run(new sekreter_detay_form(girilenTC)); // 🔹 TC’yi gönderiyoruz
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                MessageBox.Show("Kullanıcı bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglanti.baglanti().Close();
        }


        private void sekreter_login_form_Load(object sender, EventArgs e)
        {

        }
        //giriş yap butonu --------------------------------------------------------
    }
}
