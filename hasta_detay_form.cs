using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace proje_hastane
{
    public partial class hasta_detay_form : Form
    {
        private readonly sql_baglantisi baglanti = new sql_baglantisi();
        private FlowLayoutPanel summaryPanel;
        private bool summaryLoaded;

        public hasta_detay_form()
        {
            InitializeComponent();
        }

        public string tc;

        private void lnk_bilgi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hasta_guncelle_form hastaGuncelle = new hasta_guncelle_form();
            hastaGuncelle.tcno = tc;
            hastaGuncelle.Show();
        }

        private void hasta_detay_form_Load(object sender, EventArgs e)
        {
            ModernTheme.StyleForm(this, "Hasta Detay", "Randevu gecmisi, uygun kontenjanlar ve yeni randevu islemleri tek ekranda.");
            InjectSummaryPanel();
            txt_id.ReadOnly = true;

            dataGridView2.CellClick += dataGridView2_CellClick;

            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;

            LoadPatientCard();
            LoadBranches();
            RefreshAppointmentHistory();
            RefreshAvailableAppointments();
            ArrangeDashboard();

            Resize += (resizeSender, resizeArgs) => ArrangeDashboard();
            Shown += (shownSender, shownArgs) => ArrangeDashboard();
        }

        private void button_randevu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_id.Text))
            {
                MessageBox.Show("Lutfen aktif randevulardan bir slot secin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlParameter[] parameters =
            {
                new SqlParameter("@randevu_id", txt_id.Text),
                new SqlParameter("@hasta_tc", tc),
                new SqlParameter("@randevu_sikayet", rch_sikayet.Text.Trim())
            };

            try
            {
                if (baglanti.ProcedureExists("sp_HastaRandevuAl"))
                {
                    baglanti.ExecuteNonQuery("sp_HastaRandevuAl", CommandType.StoredProcedure, parameters);
                }
                else
                {
                    baglanti.ExecuteNonQuery(
                        "update Table_randevu set hasta_tc=@hasta_tc, randevu_sikayet=@randevu_sikayet, randevu_durum=1 where randevu_id=@randevu_id",
                        parameters);
                }

                RefreshAppointmentHistory();
                RefreshAvailableAppointments();
                UpdateSummaryCards();
                MessageBox.Show("Randevu basariyla alindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu olusturulurken hata olustu.\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_brans_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable doctors = baglanti.GetDataTable(
                "select doktor_ad + ' ' + doktor_soyad as doktor_adsoyad from Table_doktor where doktor_brans = @doktor_brans order by doktor_ad, doktor_soyad",
                new SqlParameter("@doktor_brans", cmb_brans.Text));

            cmb_doktor.Items.Clear();
            foreach (DataRow row in doctors.Rows)
            {
                cmb_doktor.Items.Add(row["doktor_adsoyad"].ToString());
            }

            if (cmb_doktor.Items.Count > 0)
            {
                cmb_doktor.SelectedIndex = 0;
            }
            else
            {
                RefreshAvailableAppointments();
            }
        }

        private void cmb_doktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAvailableAppointments();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            txt_id.Text = dataGridView2.Rows[e.RowIndex].Cells["randevu_id"].Value.ToString();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            txt_id.Text = dataGridView2.Rows[e.RowIndex].Cells["randevu_id"].Value.ToString();
        }

        private void LoadPatientCard()
        {
            label_tc.Text = tc;

            DataRow row = baglanti.GetDataRow(
                "select hasta_ad, hasta_soyad from Table_hasta where hasta_tc = @hasta_tc",
                new SqlParameter("@hasta_tc", tc));

            if (row != null)
            {
                label_adsoyad.Text = row["hasta_ad"] + " " + row["hasta_soyad"];
            }

            UpdateSummaryCards();
        }

        private void LoadBranches()
        {
            DataTable branches = baglanti.GetDataTable("select brans_ad from Table_brans order by brans_ad");
            cmb_brans.Items.Clear();

            foreach (DataRow row in branches.Rows)
            {
                cmb_brans.Items.Add(row["brans_ad"].ToString());
            }

            if (cmb_brans.Items.Count > 0)
            {
                cmb_brans.SelectedIndex = 0;
            }
        }

        private void RefreshAppointmentHistory()
        {
            try
            {
                dataGridView1.DataSource = baglanti.GetDataTable(
                    "select randevu_id, randevu_tarih, randevu_saat, randevu_brans, randevu_doktor, randevu_durum, randevu_sikayet " +
                    "from vw_HastaRandevuGecmisi where hasta_tc = @hasta_tc order by randevu_id desc",
                    new SqlParameter("@hasta_tc", tc));
            }
            catch
            {
                dataGridView1.DataSource = baglanti.GetDataTable(
                    "select randevu_id, randevu_tarih, randevu_saat, randevu_brans, randevu_doktor, hasta_tc from Table_randevu where hasta_tc = @hasta_tc order by randevu_id desc",
                    new SqlParameter("@hasta_tc", tc));
            }
        }

        private void RefreshAvailableAppointments()
        {
            string doctor = cmb_doktor.Text;
            string branch = cmb_brans.Text;

            if (string.IsNullOrWhiteSpace(branch))
            {
                dataGridView2.DataSource = new DataTable();
                return;
            }

            string selectedDoctor = string.IsNullOrWhiteSpace(doctor) ? "%" : doctor;

            try
            {
                dataGridView2.DataSource = baglanti.GetDataTable(
                    "select randevu_id, randevu_tarih, randevu_saat, randevu_brans, randevu_doktor, randevu_durum " +
                    "from vw_RandevuSunum where randevu_brans = @brans and randevu_doktor like @doktor and randevu_durum = N'Bos' order by randevu_tarih, randevu_saat",
                    new SqlParameter("@brans", branch),
                    new SqlParameter("@doktor", selectedDoctor));
            }
            catch
            {
                dataGridView2.DataSource = baglanti.GetDataTable(
                    "select randevu_id, randevu_tarih, randevu_saat, randevu_brans, randevu_doktor, randevu_durum " +
                    "from Table_randevu where randevu_brans = @brans and randevu_doktor like @doktor and ISNULL(CAST(randevu_durum AS INT), 0) = 0 order by randevu_tarih, randevu_saat",
                    new SqlParameter("@brans", branch),
                    new SqlParameter("@doktor", selectedDoctor));
            }
        }

        private void InjectSummaryPanel()
        {
            if (summaryLoaded)
            {
                return;
            }

            Control[] movableControls = Controls.Cast<Control>()
                .Where(control => !(control is Panel panel && panel.Dock == DockStyle.Top))
                .ToArray();

            foreach (Control control in movableControls)
            {
                control.Top += 110;
            }

            ClientSize = new Size(ClientSize.Width, ClientSize.Height + 110);

            summaryPanel = ModernTheme.CreateStatsPanel();
            summaryPanel.Location = new Point(12, 100);
            summaryPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Controls.Add(summaryPanel);
            summaryPanel.BringToFront();
            summaryLoaded = true;
        }

        private void UpdateSummaryCards()
        {
            if (summaryPanel == null)
            {
                return;
            }

            int patientAppointments = Convert.ToInt32(baglanti.ExecuteScalar("select count(*) from Table_randevu where hasta_tc = @hasta_tc", new SqlParameter("@hasta_tc", tc)));
            int openAppointments = Convert.ToInt32(baglanti.ExecuteScalar("select count(*) from Table_randevu where ISNULL(CAST(randevu_durum AS INT), 0) = 0"));

            int announcementCount;
            try
            {
                announcementCount = Convert.ToInt32(baglanti.ExecuteScalar("select count(*) from Table_duyuru"));
            }
            catch
            {
                announcementCount = 0;
            }

            summaryPanel.Controls.Clear();
            summaryPanel.Controls.Add(ModernTheme.CreateStatCard("Hasta Randevusu", patientAppointments.ToString(), "Bu hasta icin kayitli toplam randevu", Color.FromArgb(14, 165, 233)));
            summaryPanel.Controls.Add(ModernTheme.CreateStatCard("Bos Kontenjan", openAppointments.ToString(), "Alinabilecek aktif randevular", Color.FromArgb(34, 197, 94)));
            summaryPanel.Controls.Add(ModernTheme.CreateStatCard("Duyuru Sayisi", announcementCount.ToString(), "Sekreter tarafindan olusturulan duyurular", Color.FromArgb(249, 115, 22)));
        }

        private void ArrangeDashboard()
        {
            if (summaryPanel == null)
            {
                return;
            }

            SuspendLayout();

            int margin = 16;
            int gap = 14;
            int headerHeight = ModernTheme.GetHeaderHeight(this);
            int leftWidth = Math.Max(360, (int)((ClientSize.Width - (margin * 2) - gap) * 0.32));
            int rightWidth = ClientSize.Width - (margin * 2) - gap - leftWidth;

            summaryPanel.SetBounds(margin, headerHeight + 12, ClientSize.Width - (margin * 2) - SystemInformation.VerticalScrollBarWidth, 112);

            int contentTop = summaryPanel.Bottom + gap;
            int contentHeight = Math.Max(500, ClientSize.Height - contentTop - margin - 8);

            groupBox1.SetBounds(margin, contentTop, leftWidth, 155);
            groupBox2.SetBounds(margin, groupBox1.Bottom + gap, leftWidth, contentHeight - groupBox1.Height - gap);
            groupBox3.SetBounds(groupBox1.Right + gap, contentTop, rightWidth, Math.Max(240, (int)(contentHeight * 0.52)));
            groupBox4.SetBounds(groupBox3.Left, groupBox3.Bottom + gap, rightWidth, contentHeight - groupBox3.Height - gap);

            LayoutInfoGroup();
            LayoutAppointmentGroup();

            ResumeLayout();
        }

        private void LayoutInfoGroup()
        {
            int labelLeft = 16;
            int valueLeft = 108;
            int usableWidth = groupBox1.ClientSize.Width - valueLeft - 16;

            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_tc.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label_adsoyad.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            label2.Location = new Point(labelLeft, 36);
            label_tc.Location = new Point(valueLeft, 36);
            label_tc.MaximumSize = new Size(usableWidth, 0);
            label3.Location = new Point(labelLeft, 74);
            label_adsoyad.Location = new Point(valueLeft, 74);
            label_adsoyad.MaximumSize = new Size(usableWidth, 0);
            lnk_bilgi.Location = new Point(labelLeft, groupBox1.ClientSize.Height - 34);
        }

        private void LayoutAppointmentGroup()
        {
            int padding = 16;
            int labelWidth = 80;
            int inputLeft = padding + labelWidth + 10;
            int inputWidth = groupBox2.ClientSize.Width - inputLeft - padding;
            int top = 34;
            int rowHeight = 34;
            int gap = 10;

            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);

            label1.SetBounds(padding, top + 4, labelWidth, 24);
            txt_id.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight;
            label5.SetBounds(padding, top + 4, labelWidth, 24);
            cmb_brans.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight;
            label6.SetBounds(padding, top + 4, labelWidth, 24);
            cmb_doktor.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight + gap;
            label7.SetBounds(padding, top, labelWidth, 24);
            rch_sikayet.SetBounds(inputLeft, top, inputWidth, Math.Max(120, groupBox2.ClientSize.Height - top - 74));

            button_randevu.SetBounds(padding, groupBox2.ClientSize.Height - 48, groupBox2.ClientSize.Width - (padding * 2), 34);
        }
    }
}
