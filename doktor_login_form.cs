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
    public partial class doktor_login_form : Form
    {
        public doktor_login_form()
        {
            InitializeComponent();
        }

        private void doktor_login_form_Load(object sender, EventArgs e)
        {

        }
        Thread thread;
        sql_baglantisi baglanti = new sql_baglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //doktor detay sayfasına gitme-----------------------------------------------------------
        public void sayfa_guncelle()
        {
            Application.Run(new doktor_detay_form());
        }
        private void button_hasta_giris_Click(object sender, EventArgs e)
        { //login işlemi
            SqlCommand komut  = new SqlCommand("select * from Table_doktor where doktor_tc = @doktor_tc and doktor_sifre = @doktor_sifre",baglanti.baglanti());
            komut.Parameters.AddWithValue("doktor_tc",msk_tc.Text.ToString());
            komut.Parameters.AddWithValue("doktor_sifre",txt_sifre.Text.ToString());

            SqlDataReader reader = komut.ExecuteReader();
            if (reader.Read())
            {  //eğer tabloda okuma sırasında aynı satırda şifre ve tc  başarıyla bulunursa
                this.Close();
                thread = new Thread(sayfa_guncelle);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }else
            {
                MessageBox.Show("Kullanıcı Bulunamadı Lütfen Tekrar Deneyin","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            baglanti.baglanti().Close();
        }
        //doktor detay sayfasına gitme-----------------------------------------------------------
    }
}
