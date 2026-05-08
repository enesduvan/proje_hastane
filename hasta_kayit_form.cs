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
            ModernTheme.StyleForm(this, "Hasta Kayit", "Yeni hasta olusturma ekranı, kayitlarin stored procedure ile sisteme eklenmesini destekler.");
            txt_sifre.UseSystemPasswordChar = true;
            button_hasta_kayit.Text = "Kaydi Tamamla";
            button2.Text = "Giris Ekranina Don";
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
            SqlParameter[] parameters =
            {
                new SqlParameter("@hasta_ad", txt_ad.Text),
                new SqlParameter("@hasta_soyad", txt_soyad.Text),
                new SqlParameter("@hasta_tc", msk_tc.Text),
                new SqlParameter("@hasta_telefon", msk_telefon.Text),
                new SqlParameter("@hasta_sifre", txt_sifre.Text),
                new SqlParameter("@hasta_cinsiyet", cmb_cinsiyet.Text)
            };

            if (baglanti.ProcedureExists("sp_HastaKaydet"))
            {
                baglanti.ExecuteNonQuery("sp_HastaKaydet", CommandType.StoredProcedure, parameters);
            }
            else
            {
                baglanti.ExecuteNonQuery(
                    "insert into Table_hasta (hasta_ad , hasta_soyad , hasta_tc , hasta_telefon , hasta_sifre , hasta_cinsiyet) " +
                    "values (@hasta_ad , @hasta_soyad , @hasta_tc , @hasta_telefon , @hasta_sifre , @hasta_cinsiyet)",
                    parameters);
            }

            MessageBox.Show("Kaydınız gerçekleşti: " + txt_ad.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
