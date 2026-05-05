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
    public partial class doktor_bilgi_guncelle : Form
    {
        public doktor_bilgi_guncelle()
        {
            InitializeComponent();
        }
        //geri butonu ------------------------------------------------------------------------------------

        Thread thread;
        public void sayfa_degistir()
        {
            Application.Run(new doktor_detay_form());
        }

        private void button_geri_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(sayfa_degistir);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
