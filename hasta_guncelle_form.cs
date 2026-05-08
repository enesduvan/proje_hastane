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
            hasta_detay_form form = new hasta_detay_form();
            form.tc = tcno;
            Application.Run(form);
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
            ModernTheme.StyleForm(this, "Hasta Bilgi Guncelle", "Kayitli hasta verilerini guvenli guncelle ve mevcut profilini koru.");
            txt_sifre.UseSystemPasswordChar = true;
            msk_tc.Text = tcno;
            DataRow reader = baglanti.GetDataRow(
                "select * from Table_hasta where hasta_tc = @hasta_tc",
                new SqlParameter("@hasta_tc", tcno));

            if (reader != null)
            {
                txt_ad.Text = reader["hasta_ad"].ToString();
                txt_soyad.Text = reader["hasta_soyad"].ToString();
                msk_telefon.Text = reader["hasta_telefon"].ToString();
                txt_sifre.Text = reader["hasta_sifre"].ToString();
                cmb_cinsiyet.Text = reader["hasta_cinsiyet"].ToString();
            }
        }


        //günceşşe butonu
        private void button_hasta_kayit_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@hasta_ad", txt_ad.Text),
                new SqlParameter("@hasta_soyad", txt_soyad.Text),
                new SqlParameter("@hasta_telefon", msk_telefon.Text),
                new SqlParameter("@hasta_sifre", txt_sifre.Text),
                new SqlParameter("@hasta_cinsiyet", cmb_cinsiyet.Text),
                new SqlParameter("@hasta_tc", msk_tc.Text)
            };

            if (baglanti.ProcedureExists("sp_HastaGuncelle"))
            {
                baglanti.ExecuteNonQuery("sp_HastaGuncelle", CommandType.StoredProcedure, parameters);
            }
            else
            {
                baglanti.ExecuteNonQuery(
                    "update Table_hasta set hasta_ad=@hasta_ad , hasta_soyad=@hasta_soyad , hasta_telefon=@hasta_telefon , " +
                    "hasta_sifre=@hasta_sifre , hasta_cinsiyet=@hasta_cinsiyet where hasta_tc=@hasta_tc",
                    parameters);
            }

            MessageBox.Show("Kullanıcı bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
