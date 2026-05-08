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
            ModernTheme.StyleForm(this, "Sea Green Hospital", "Veritabani II donem projesi icin modernlestirilmis hastane otomasyonu");

            label1.Text = "Hasta Modulu";
            label2.Text = "Doktor Modulu";
            label3.Text = "Sekreter Modulu";
            label4.Text = "Merkezi Giris Ekrani";
            label5.Text = "CRUD, view, trigger, transaction ve raporlama destegi";
            label6.Text = "Hazirlayan: Enes Duvan";

            button1.Text = "Hasta Girisi";
            button2.Text = "Sekreter Girisi";
            button3.Text = "Doktor Girisi";

            button1.BackgroundImage = null;
            button2.BackgroundImage = null;
            button3.BackgroundImage = null;
            button1.BackColor = Color.FromArgb(14, 165, 233);
            button2.BackColor = Color.FromArgb(34, 197, 94);
            button3.BackColor = Color.FromArgb(249, 115, 22);
            button1.ForeColor = Color.White;
            button2.ForeColor = Color.White;
            button3.ForeColor = Color.White;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            button3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            ArrangeHomeLayout();

            Resize += (resizeSender, resizeArgs) => ArrangeHomeLayout();
            Shown += (shownSender, shownArgs) => ArrangeHomeLayout();
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

        private void ArrangeHomeLayout()
        {
            SuspendLayout();

            int margin = 24;
            int gap = 20;
            int headerHeight = ModernTheme.GetHeaderHeight(this);
            int contentTop = headerHeight + 34;
            int heroWidth = Math.Max(260, (int)(ClientSize.Width * 0.22));
            int buttonWidth = Math.Max(220, (int)(ClientSize.Width * 0.18));
            int buttonHeight = 130;

            pictureBox1.SetBounds(margin, contentTop, heroWidth, 210);
            label4.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label4.Location = new Point(margin, pictureBox1.Bottom + 12);
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label5.Location = new Point(margin, label4.Bottom + 8);
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            label6.Location = new Point(margin, ClientSize.Height - 48);

            int cardsLeft = pictureBox1.Right + 40;
            int totalButtonArea = (buttonWidth * 3) + (gap * 2);
            if (cardsLeft + totalButtonArea > ClientSize.Width - margin)
            {
                buttonWidth = Math.Max(200, (ClientSize.Width - cardsLeft - margin - (gap * 2)) / 3);
                totalButtonArea = (buttonWidth * 3) + (gap * 2);
            }

            int cardsTop = contentTop + 36;
            button1.SetBounds(cardsLeft, cardsTop, buttonWidth, buttonHeight);
            button3.SetBounds(button1.Right + gap, cardsTop, buttonWidth, buttonHeight);
            button2.SetBounds(button3.Right + gap, cardsTop, buttonWidth, buttonHeight);

            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label1.Location = new Point(button1.Left + ((button1.Width - label1.Width) / 2), button1.Bottom + 14);
            label2.Location = new Point(button3.Left + ((button3.Width - label2.Width) / 2), button3.Bottom + 14);
            label3.Location = new Point(button2.Left + ((button2.Width - label3.Width) / 2), button2.Bottom + 14);

            ResumeLayout();
        }
    }
}
