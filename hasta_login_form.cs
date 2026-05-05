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
//using System.Security.Cryptography.X509Certificates;

namespace proje_hastane
{
    public partial class hasta_login_form : Form
    {
        public hasta_login_form()
        {
            InitializeComponent();
        }
        
        sql_baglantisi baglanti = new sql_baglantisi();
        

        /// eğer kullanıcı üye olmak isterse üye ol formuna yollar ----------------------------------------------
        Thread thread;
        public void sayfa_degistir()
        {
            Application.Run(new hasta_kayit_form());
        }
        private void lnk_uyeol_hasta_giris_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();

            thread = new Thread(sayfa_degistir);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        //------------------------------------------------------------------------------------------------------



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //--------------------------------------------------------------------------------------------------------

        public void sayfa_gucelle2(string tc)
        {
            //tc taşıma
            //eğer şifre ve tc doğruysa onları diğer formumuza yolluyoruz
            hasta_detay_form hasta_Detay_ = new hasta_detay_form();
            hasta_Detay_.tc = tc;
            //tc taşıma
            Application.Run(hasta_Detay_);
        }

        private void button_hasta_giris_Click(object sender, EventArgs e)
        {  //login işlemi
            SqlCommand komut = new SqlCommand("select * from Table_hasta where hasta_tc = @hasta_tc and hasta_sifre = @hasta_sifre ", baglanti.baglanti());
            komut.Parameters.AddWithValue("hasta_tc" , msk_tc.Text.ToString());
            komut.Parameters.AddWithValue("hasta_sifre" , txt_sifre.Text.ToString());

            SqlDataReader dataReader = komut.ExecuteReader();
            if (dataReader.Read())
            {//tc taşıma
                string tcValue = msk_tc.Text;
                //eğer şifre ve tc doğruysa onları diğer formumuza yolluyoruz
                hasta_detay_form hasta_Detay_ = new hasta_detay_form();
                hasta_Detay_.tc = msk_tc.Text.ToString();
                //tc taşıma

                this.Close();
                thread = new Thread(() => sayfa_gucelle2(tcValue));  //bu kısım iki form arası thrad la değişken göndermek için
                thread.SetApartmentState (ApartmentState.STA);
                thread.Start();
            }
            else
            {
                MessageBox.Show("kullanıcı bulunumadı lütfen tekrar deneyin","hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            baglanti.baglanti().Close();
        }

        private void hasta_login_form_Load(object sender, EventArgs e)
        {
            
        }
    }



}
