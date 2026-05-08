using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace proje_hastane
{
    public class yonetim_ozeti_form : Form
    {
        private readonly sql_baglantisi baglanti = new sql_baglantisi();
        private readonly string sekreterTc;
        private DataGridView dgvRandevular;
        private DataGridView dgvLoglar;
        private FlowLayoutPanel statsPanel;

        public yonetim_ozeti_form(string sekreterTcNo)
        {
            sekreterTc = sekreterTcNo;
            BuildLayout();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ModernTheme.StyleForm(this, "Yonetim Ozeti", "View, trigger, function, transaction ve log tablolarini tek ekranda izle.");
            LoadSummary();
            LoadGrids();
        }

        private void BuildLayout()
        {
            ClientSize = new Size(1220, 720);
            MinimumSize = new Size(1220, 720);

            statsPanel = ModernTheme.CreateStatsPanel();
            statsPanel.Location = new Point(18, 110);
            Controls.Add(statsPanel);

            GroupBox grpRandevu = new GroupBox
            {
                Text = "Randevu View Sonuclari",
                Location = new Point(18, 228),
                Size = new Size(1168, 220)
            };

            dgvRandevular = new DataGridView
            {
                Dock = DockStyle.Fill
            };
            grpRandevu.Controls.Add(dgvRandevular);

            GroupBox grpLog = new GroupBox
            {
                Text = "Trigger ve Log Kayitlari",
                Location = new Point(18, 462),
                Size = new Size(1168, 210)
            };

            dgvLoglar = new DataGridView
            {
                Dock = DockStyle.Fill
            };
            grpLog.Controls.Add(dgvLoglar);

            Label lblInfo = new Label
            {
                AutoSize = true,
                Text = "Aktif sekreter TC: " + sekreterTc,
                Location = new Point(20, 688)
            };

            Controls.Add(grpRandevu);
            Controls.Add(grpLog);
            Controls.Add(lblInfo);
        }

        private void LoadSummary()
        {
            DataRow row;

            try
            {
                row = baglanti.GetDataRow("SELECT * FROM vw_YonetimOzeti");
            }
            catch
            {
                row = CreateFallbackSummary();
            }

            statsPanel.Controls.Clear();
            statsPanel.Controls.Add(ModernTheme.CreateStatCard("Toplam Hasta", row["toplam_hasta"].ToString(), "Hasta tablosundaki aktif kayitlar", Color.FromArgb(14, 165, 233)));
            statsPanel.Controls.Add(ModernTheme.CreateStatCard("Toplam Doktor", row["toplam_doktor"].ToString(), "Doktor ve brans iliskisi", Color.FromArgb(34, 197, 94)));
            statsPanel.Controls.Add(ModernTheme.CreateStatCard("Bos Randevu", row["bos_randevu"].ToString(), "Hasta atanmamis kontenjan", Color.FromArgb(249, 115, 22)));
            statsPanel.Controls.Add(ModernTheme.CreateStatCard("Toplam Log", row["toplam_log"].ToString(), "Trigger ve islem hareketleri", Color.FromArgb(168, 85, 247)));
        }

        private void LoadGrids()
        {
            try
            {
                dgvRandevular.DataSource = baglanti.GetDataTable("SELECT TOP 20 * FROM vw_RandevuSunum ORDER BY randevu_id DESC");
            }
            catch
            {
                dgvRandevular.DataSource = baglanti.GetDataTable("SELECT TOP 20 * FROM Table_randevu ORDER BY randevu_id DESC");
            }

            try
            {
                dgvLoglar.DataSource = baglanti.GetDataTable("SELECT TOP 20 * FROM Table_kullanici_log ORDER BY log_id DESC");
            }
            catch
            {
                dgvLoglar.DataSource = new DataTable();
            }
        }

        private DataRow CreateFallbackSummary()
        {
            DataTable table = new DataTable();
            table.Columns.Add("toplam_hasta");
            table.Columns.Add("toplam_doktor");
            table.Columns.Add("toplam_brans");
            table.Columns.Add("bos_randevu");
            table.Columns.Add("dolu_randevu");
            table.Columns.Add("toplam_duyuru");
            table.Columns.Add("toplam_log");

            DataRow row = table.NewRow();
            row["toplam_hasta"] = baglanti.ExecuteScalar("SELECT COUNT(*) FROM Table_hasta").ToString();
            row["toplam_doktor"] = baglanti.ExecuteScalar("SELECT COUNT(*) FROM Table_doktor").ToString();
            row["toplam_brans"] = baglanti.ExecuteScalar("SELECT COUNT(*) FROM Table_brans").ToString();
            row["bos_randevu"] = baglanti.ExecuteScalar("SELECT COUNT(*) FROM Table_randevu WHERE ISNULL(CAST(randevu_durum AS INT), 0) = 0").ToString();
            row["dolu_randevu"] = baglanti.ExecuteScalar("SELECT COUNT(*) FROM Table_randevu WHERE ISNULL(CAST(randevu_durum AS INT), 0) = 1").ToString();
            row["toplam_duyuru"] = baglanti.ExecuteScalar("SELECT COUNT(*) FROM Table_duyuru").ToString();
            row["toplam_log"] = "0";

            table.Rows.Add(row);
            return row;
        }
    }
}
