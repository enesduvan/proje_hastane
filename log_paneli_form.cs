using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace proje_hastane
{
    public class log_paneli_form : Form
    {
        private readonly sql_baglantisi baglanti = new sql_baglantisi();
        private DataGridView dgvKullaniciLog;
        private DataGridView dgvRandevuLog;

        public log_paneli_form()
        {
            BuildLayout();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ModernTheme.StyleForm(this, "Sistem Loglari", "Tüm kullanici hareketleri ve randevu degisiklikleri triggerlar vasitasiyla izlenmektedir.");
            LoadGrids();
        }

        private void BuildLayout()
        {
            ClientSize = new Size(1100, 700);
            MinimumSize = new Size(1100, 700);
            StartPosition = FormStartPosition.CenterScreen;

            int topMargin = ModernTheme.GetHeaderHeight(this) + 20;

            GroupBox grpKullanici = new GroupBox
            {
                Text = "Kullanici Hareket Loglari (Table_kullanici_log)",
                Location = new Point(18, topMargin),
                Size = new Size(1060, 250),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            dgvKullaniciLog = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            grpKullanici.Controls.Add(dgvKullaniciLog);

            GroupBox grpRandevu = new GroupBox
            {
                Text = "Randevu Degisim Loglari (Table_randevu_log)",
                Location = new Point(18, topMargin + 270),
                Size = new Size(1060, 250),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };

            dgvRandevuLog = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            grpRandevu.Controls.Add(dgvRandevuLog);

            Controls.Add(grpKullanici);
            Controls.Add(grpRandevu);
        }

        private void LoadGrids()
        {
            try
            {
                dgvKullaniciLog.DataSource = baglanti.GetDataTable("SELECT TOP 100 log_id, tablo_adi, islem_turu, islem_tarihi, islem_yapan, aciklama FROM Table_kullanici_log ORDER BY log_id DESC");
            }
            catch
            {
                dgvKullaniciLog.DataSource = new DataTable();
            }

            try
            {
                dgvRandevuLog.DataSource = baglanti.GetDataTable("SELECT TOP 100 randevu_log_id, randevu_id, onceki_durum, yeni_durum, log_tarihi, log_mesaji FROM Table_randevu_log ORDER BY randevu_log_id DESC");
            }
            catch
            {
                dgvRandevuLog.DataSource = new DataTable();
            }
        }
    }
}
