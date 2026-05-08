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

        Thread thread;
        sql_baglantisi baglanti = new sql_baglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(() => Application.Run(new main_login_form()));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }



        //doktor detay sayfasına gitme-----------------------------------------------------------
        private void button_hasta_giris_Click(object sender, EventArgs e)
        { //login işlemi
            DataRow doktorKaydi = baglanti.GetDataRow(
                "select * from Table_doktor where doktor_tc = @doktor_tc and doktor_sifre = @doktor_sifre",
                new SqlParameter("@doktor_tc", msk_tc.Text),
                new SqlParameter("@doktor_sifre", txt_sifre.Text));

            if (doktorKaydi != null)
            {  //eğer tabloda okuma sırasında aynı satırda şifre ve tc  başarıyla bulunursa
                this.Hide();
                doktor_detay_form fr = new doktor_detay_form(msk_tc.Text);
                fr.FormClosed += (s, args) => this.Close();
                fr.Show();
            }else
            {
                MessageBox.Show("Kullanıcı Bulunamadı Lütfen Tekrar Deneyin","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        //doktor detay sayfasına gitme-----------------------------------------------------------

        private void doktor_login_form_Load(object sender, EventArgs e)
        {
            ModernTheme.StyleForm(this, "Doktor Girisi", "Doktor paneli, hasta randevulari ve duyurulara tek ekrandan eris.");
            txt_sifre.UseSystemPasswordChar = true;
            button_hasta_giris.Text = "Doktor Paneline Gir";
            button1.Text = "Ana Menuye Don";
        }
    }
}
