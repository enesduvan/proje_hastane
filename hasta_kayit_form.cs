using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace proje_hastane
{
    public partial class hasta_kayit_form : Form
    {
        public hasta_kayit_form()
        {
            InitializeComponent();
        }

        private void hasta_kayit_form_Load(object sender, EventArgs e)
        {

        }
        sql_baglantisi baglanti = new sql_baglantisi();

        /// eğer kullanıcı zaten üye ise ve butona basarsa üye ol formuna yollar ----------------------------------------------
        Thread thread;
        public void sayfa_degistir()
        {
            Application.Run(new hasta_login_form());
        }
        public void x()
        {
            this.Close();
            thread = new Thread(sayfa_degistir);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            x();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            x();
        }


        //----------------------------------------------------------------------------------------------------------------
        private void button_hasta_kayit_Click(object sender, EventArgs e)
        {
            {
                SqlCommand komut = new SqlCommand("insert into Table_hasta (hasta_ad , hasta_soyad , hasta_tc ," +
                    " hasta_telefon , hasta_sifre , hasta_cinsiyet) values (@hasta_ad , @hasta_soyad , @hasta_tc ," +
                    " @hasta_telefon , @hasta_sifre , @hasta_cinsiyet)", baglanti.baglanti());

                komut.Parameters.AddWithValue("@hasta_ad", txt_ad.Text);
                komut.Parameters.AddWithValue("@hasta_soyad", txt_soyad.Text);
                komut.Parameters.AddWithValue("@hasta_tc", msk_tc.Text.ToString());
                komut.Parameters.AddWithValue("@hasta_telefon", msk_telefon.Text.ToString());
                komut.Parameters.AddWithValue("@hasta_sifre", txt_sifre.Text.ToString());
                komut.Parameters.AddWithValue("@hasta_cinsiyet", cmb_cinsiyet.Text.ToString());

                komut.ExecuteNonQuery();
                baglanti.baglanti().Close();
                MessageBox.Show("Kaydınız Gerçekleşti :"+ txt_ad.Text , "Bilgi" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            }

        }
    }
}
