using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace proje_hastane
{
    public partial class sekreter_detay_form : Form
    {
        private readonly sql_baglantisi baglanti = new sql_baglantisi();
        private readonly string tcno;
        private FlowLayoutPanel summaryPanel;
        private Button summaryButton;
        private bool summaryLoaded;

        public sekreter_detay_form()
        {
            InitializeComponent();
        }

        public sekreter_detay_form(string tc) : this()
        {
            tcno = tc;
        }

        private void sekreter_detay_form_Load(object sender, EventArgs e)
        {
            ModernTheme.StyleForm(this, "Sekreter Yonetim Paneli", "Randevu, duyuru, log ve temel CRUD islemleri icin guclendirilmis idari panel.");
            InjectSummaryPanel();
            ConfigureQuickAccessArea();

            label_tc.Text = tcno;
            txt_id.Text = "Oto";
            txt_id.ReadOnly = true;
            lnk_bilgi.Text = "Sunum ozetini ac";

            LoadSecretaryInfo();
            LoadBranchCombo();
            RefreshBranchGrid();
            RefreshDoctorGrid();
            UpdateSummaryCards();
            ArrangeDashboard();

            Resize += (resizeSender, resizeArgs) => ArrangeDashboard();
            Shown += (shownSender, shownArgs) => ArrangeDashboard();
        }

        private void button_cıkıs_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_randevu_list_Click(object sender, EventArgs e)
        {
            randevu_paneli_form randevuPaneli = new randevu_paneli_form();
            randevuPaneli.Show();
        }

        private void button_doktor_list_Click(object sender, EventArgs e)
        {
            doktor_paneli_form doktorPaneli = new doktor_paneli_form();
            doktorPaneli.Show();
        }

        private void button_brans_list_Click(object sender, EventArgs e)
        {
            brans_paneli_form bransPaneli = new brans_paneli_form();
            bransPaneli.Show();
        }

        private void lnk_bilgi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowSummaryForm();
        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(msk_tarih.Text) ||
                string.IsNullOrWhiteSpace(msk_saat.Text) ||
                string.IsNullOrWhiteSpace(cmb_brans.Text) ||
                string.IsNullOrWhiteSpace(cmb_doktor.Text))
            {
                MessageBox.Show("Lutfen randevu bilgilerini eksiksiz girin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlParameter[] parameters =
            {
                new SqlParameter("@randevu_tarih", msk_tarih.Text),
                new SqlParameter("@randevu_saat", msk_saat.Text),
                new SqlParameter("@randevu_brans", cmb_brans.Text),
                new SqlParameter("@randevu_doktor", cmb_doktor.Text),
                new SqlParameter("@randevu_durum", checkBox_durum.Checked),
                new SqlParameter("@hasta_tc", msk_tc.Text),
                new SqlParameter("@sekreter_tc", tcno)
            };

            try
            {
                if (baglanti.ProcedureExists("sp_RandevuOlustur"))
                {
                    baglanti.ExecuteNonQuery("sp_RandevuOlustur", CommandType.StoredProcedure, parameters);
                }
                else
                {
                    baglanti.ExecuteNonQuery(
                        "insert into Table_randevu (randevu_tarih , randevu_saat , randevu_brans , randevu_doktor , randevu_durum , hasta_tc ) values " +
                        "(@randevu_tarih , @randevu_saat , @randevu_brans , @randevu_doktor , @randevu_durum , @hasta_tc)",
                        parameters.Take(6).ToArray());
                }

                UpdateSummaryCards();
                MessageBox.Show("Randevu kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu kaydedilemedi.\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_brans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_doktor.Items.Clear();

            DataTable doctors = baglanti.GetDataTable(
                "select doktor_ad + ' ' + doktor_soyad as doktor_adsoyad from Table_doktor where doktor_brans = @doktor_brans order by doktor_ad, doktor_soyad",
                new SqlParameter("@doktor_brans", cmb_brans.Text));

            foreach (DataRow row in doctors.Rows)
            {
                cmb_doktor.Items.Add(row["doktor_adsoyad"].ToString());
            }

            if (cmb_doktor.Items.Count > 0)
            {
                cmb_doktor.SelectedIndex = 0;
            }
        }

        private void button_olustur_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rch_duyuru.Text))
            {
                MessageBox.Show("Lutfen duyuru metnini girin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlParameter[] parameters =
            {
                new SqlParameter("@duyuru", rch_duyuru.Text.Trim()),
                new SqlParameter("@olusturan_tc", tcno)
            };

            if (baglanti.ProcedureExists("sp_DuyuruOlustur"))
            {
                baglanti.ExecuteNonQuery("sp_DuyuruOlustur", CommandType.StoredProcedure, parameters);
            }
            else
            {
                baglanti.ExecuteNonQuery(
                    "insert into Table_duyuru (duyuru, olusturan_tc) values (@duyuru, @olusturan_tc)",
                    parameters);
            }

            UpdateSummaryCards();
            MessageBox.Show("Duyuru olusturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadSecretaryInfo()
        {
            DataRow row = baglanti.GetDataRow(
                "select top 1 sekreter_adsoyad from Table_sekreter where sekreter_tc = @sekreter_tc",
                new SqlParameter("@sekreter_tc", label_tc.Text));

            if (row != null)
            {
                label_adsoyad.Text = row["sekreter_adsoyad"].ToString();
            }
        }

        private void LoadBranchCombo()
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

        private void RefreshBranchGrid()
        {
            try
            {
                dataGridView1.DataSource = baglanti.GetDataTable(
                    "SELECT b.brans_id, b.brans_ad, p.poliklinik_ad, b.aktif " +
                    "FROM Table_brans b LEFT JOIN Table_poliklinik p ON p.poliklinik_id = b.poliklinik_id " +
                    "ORDER BY b.brans_ad");
            }
            catch
            {
                dataGridView1.DataSource = baglanti.GetDataTable(
                    "SELECT b.brans_id, b.brans_ad, p.poliklinik_ad " +
                    "FROM Table_brans b LEFT JOIN Table_poliklinik p ON p.poliklinik_id = b.poliklinik_id " +
                    "ORDER BY b.brans_ad");
            }
        }

        private void RefreshDoctorGrid()
        {
            try
            {
                dataGridView2.DataSource = baglanti.GetDataTable(
                    "select doktor_ad, doktor_soyad, doktor_brans, poliklinik_ad, oda_kodu, toplam_randevu from vw_DoktorBransListesi order by doktor_ad, doktor_soyad");
            }
            catch
            {
                dataGridView2.DataSource = baglanti.GetDataTable("select * from Table_doktor");
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
                control.Top += 112;
            }

            ClientSize = new Size(ClientSize.Width, ClientSize.Height + 122);

            summaryPanel = ModernTheme.CreateStatsPanel();
            summaryPanel.Location = new Point(12, 98);
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

            DataRow row;

            try
            {
                row = baglanti.GetDataRow("select * from vw_YonetimOzeti");
            }
            catch
            {
                row = CreateFallbackSummary();
            }

            summaryPanel.Controls.Clear();
            summaryPanel.Controls.Add(ModernTheme.CreateStatCard("Toplam Brans", row["toplam_brans"].ToString(), "Sistemde tanimli uzmanlik alani", Color.FromArgb(14, 165, 233)));
            summaryPanel.Controls.Add(ModernTheme.CreateStatCard("Toplam Doktor", row["toplam_doktor"].ToString(), "Branslara dagitilmis aktif doktor", Color.FromArgb(34, 197, 94)));
            summaryPanel.Controls.Add(ModernTheme.CreateStatCard("Bos Randevu", row["bos_randevu"].ToString(), "Hasta atanmamis uygun slotlar", Color.FromArgb(249, 115, 22)));
            summaryPanel.Controls.Add(ModernTheme.CreateStatCard("Toplam Log", row["toplam_log"].ToString(), "Trigger kaynakli kayitlar dahil", Color.FromArgb(168, 85, 247)));
        }

        private DataRow CreateFallbackSummary()
        {
            DataTable table = new DataTable();
            table.Columns.Add("toplam_doktor");
            table.Columns.Add("toplam_brans");
            table.Columns.Add("bos_randevu");
            table.Columns.Add("toplam_log");

            DataRow row = table.NewRow();
            row["toplam_doktor"] = baglanti.ExecuteScalar("select count(*) from Table_doktor").ToString();
            row["toplam_brans"] = baglanti.ExecuteScalar("select count(*) from Table_brans").ToString();
            row["bos_randevu"] = baglanti.ExecuteScalar("select count(*) from Table_randevu where ISNULL(CAST(randevu_durum AS INT), 0) = 0").ToString();

            try
            {
                row["toplam_log"] = baglanti.ExecuteScalar("select count(*) from Table_kullanici_log").ToString();
            }
            catch
            {
                row["toplam_log"] = "0";
            }

            table.Rows.Add(row);
            return row;
        }

        private void ConfigureQuickAccessArea()
        {
            if (summaryButton != null)
            {
                return;
            }

            groupBox6.Height = 144;

            summaryButton = ModernTheme.CreateSecondaryButton("Sunum Ozeti", (sender, args) => ShowSummaryForm());
            groupBox6.Controls.Add(summaryButton);
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
            int totalWidth = Math.Max(980, ClientSize.Width - (margin * 2));
            int availableWidth = totalWidth - (gap * 2);

            int leftWidth = Math.Max(300, (int)(availableWidth * 0.22));
            int middleWidth = Math.Max(320, (int)(availableWidth * 0.24));
            int rawRightWidth = availableWidth - leftWidth - middleWidth;

            int rightWidth = ClientSize.Width - margin - (groupBox1.Right + gap + middleWidth + gap);
            if (rightWidth < 460)
            {
                rightWidth = Math.Max(rawRightWidth, 460);
            }

            summaryPanel.SetBounds(margin, headerHeight + 12, ClientSize.Width - (margin * 2) - SystemInformation.VerticalScrollBarWidth, 112);

            int contentTop = summaryPanel.Bottom + gap;
            int contentHeight = Math.Max(520, ClientSize.Height - contentTop - margin - 8);

            groupBox1.SetBounds(margin, contentTop, leftWidth, 150);
            groupBox2.SetBounds(margin, groupBox1.Bottom + gap, leftWidth, contentHeight - groupBox1.Height - gap);
            groupBox3.SetBounds(groupBox1.Right + gap, contentTop, middleWidth, contentHeight);

            int finalRightWidth = ClientSize.Width - groupBox3.Right - margin - gap;
            groupBox4.SetBounds(groupBox3.Right + gap, contentTop, finalRightWidth, 220);
            groupBox5.SetBounds(groupBox4.Left, groupBox4.Bottom + gap, finalRightWidth, Math.Max(190, contentHeight - 220 - 130 - (gap * 2)));
            groupBox6.SetBounds(groupBox4.Left, groupBox5.Bottom + gap, finalRightWidth, 130);

            LayoutSecretaryInfoGroup();
            LayoutAnnouncementGroup();
            LayoutAppointmentGroup();
            LayoutQuickAccessGroup();

            ResumeLayout();
        }

        private void LayoutSecretaryInfoGroup()
        {
            int labelLeft = 16;
            int valueLeft = 104;
            int usableWidth = groupBox1.ClientSize.Width - valueLeft - 16;

            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label_tc.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            label_adsoyad.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            label2.Location = new Point(labelLeft, 38);
            label_tc.Location = new Point(valueLeft, 38);
            label_tc.MaximumSize = new Size(usableWidth, 0);
            label3.Location = new Point(labelLeft, 76);
            label_adsoyad.Location = new Point(valueLeft, 76);
            label_adsoyad.MaximumSize = new Size(usableWidth, 0);
            lnk_bilgi.Location = new Point(labelLeft, groupBox1.ClientSize.Height - 34);
        }

        private void LayoutAnnouncementGroup()
        {
            int padding = 14;
            rch_duyuru.SetBounds(padding, 30, groupBox2.ClientSize.Width - (padding * 2), Math.Max(120, groupBox2.ClientSize.Height - 92));
            button_olustur.SetBounds(padding, groupBox2.ClientSize.Height - 48, groupBox2.ClientSize.Width - (padding * 2), 34);
        }

        private void LayoutAppointmentGroup()
        {
            int labelLeft = 16;
            int labelWidth = 74;
            int inputLeft = 100;
            int inputWidth = Math.Max(150, groupBox3.ClientSize.Width - inputLeft - 16);
            int top = 34;
            int rowHeight = 34;
            int gap = 10;

            label1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label9.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            checkBox_durum.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            label1.SetBounds(labelLeft, top + 4, labelWidth, 24);
            txt_id.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight;
            label4.SetBounds(labelLeft, top + 4, labelWidth, 24);
            msk_tarih.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight;
            label5.SetBounds(labelLeft, top + 4, labelWidth, 24);
            msk_saat.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight;
            label6.SetBounds(labelLeft, top + 4, labelWidth, 24);
            cmb_brans.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight;
            label7.SetBounds(labelLeft, top + 4, labelWidth, 24);
            cmb_doktor.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight;
            label9.SetBounds(labelLeft, top + 4, labelWidth, 24);
            msk_tc.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight + gap;
            checkBox_durum.SetBounds(inputLeft, top, inputWidth, 28);

            button_kaydet.SetBounds(16, groupBox3.ClientSize.Height - 50, groupBox3.ClientSize.Width - 32, 34);
        }

        private void LayoutQuickAccessGroup()
        {
            int padding = 14;
            int gap = 10;
            int buttonWidth = (groupBox6.ClientSize.Width - (padding * 2) - gap) / 2;

            button_doktor_list.SetBounds(padding, 30, buttonWidth, 34);
            button_brans_list.SetBounds(button_doktor_list.Right + gap, 30, buttonWidth, 34);
            button_randevu_list.SetBounds(padding, button_doktor_list.Bottom + gap, buttonWidth, 34);
            button_cıkıs.SetBounds(button_randevu_list.Right + gap, button_brans_list.Bottom + gap, buttonWidth, 34);
            summaryButton.SetBounds(padding, button_randevu_list.Bottom + gap, groupBox6.ClientSize.Width - (padding * 2), 34);
        }

        private void ShowSummaryForm()
        {
            yonetim_ozeti_form summaryForm = new yonetim_ozeti_form(tcno);
            summaryForm.Show();
        }
    }
}
