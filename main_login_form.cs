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
    public partial class main_login_form : Form
    {
        public main_login_form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // login sayfalarına gitmek -----------------------------------------------------
        Thread thread;
        public void sayfa_guncelle()
        {
            Application.Run(new hasta_login_form());
        }
        public void sayfa_guncelle2()
        {
            Application.Run(new doktor_login_form());
        }
        public void sayfa_guncelle3()
        {
            Application.Run(new sekreter_login_form());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(sayfa_guncelle);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(sayfa_guncelle2);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            thread = new Thread(sayfa_guncelle3);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

        }
        //login sayfalarına gitmek *------------------------------------------------
    }
}
