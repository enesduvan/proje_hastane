using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace proje_hastane
{
    public partial class doktor_detay_form : Form
    {
        public doktor_detay_form()
        {
            InitializeComponent();
        }


        //doktor bilgi günceleme sayfasına gidiş --------------------------------------------
        Thread thread;
        public void sayfa_degistir()
        {
            Application.Run(new doktor_bilgi_guncelle());
        }
        private void lnk_bilgi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                this.Close();
                thread = new Thread(sayfa_degistir);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }

        private void button_duyuru_Click(object sender, EventArgs e)
        {
            duyurular_form duyurular_ = new duyurular_form();
            duyurular_.Show();
        }

        private void button_cıkıs_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void doktor_detay_form_Load(object sender, EventArgs e)
        {

        }
    }
}
