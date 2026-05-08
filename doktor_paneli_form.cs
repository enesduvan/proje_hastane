using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace proje_hastane
{
    public partial class doktor_paneli_form : Form
    {
        private readonly sql_baglantisi baglanti = new sql_baglantisi();

        public doktor_paneli_form()
        {
            InitializeComponent();
        }

        private void doktor_paneli_form_Load(object sender, EventArgs e)
        {
            ModernTheme.StyleForm(this, "Doktor Yonetimi", "Stored procedure destekli doktor CRUD akisi ve genis listeleme ekrani.");
            RefreshDoctors();
            LoadBranches();
            ArrangeLayout();

            Resize += (resizeSender, resizeArgs) => ArrangeLayout();
            Shown += (shownSender, shownArgs) => ArrangeLayout();
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            if (!ValidateDoctorForm())
            {
                return;
            }

            SqlParameter[] parameters = BuildDoctorParameters();

            if (baglanti.ProcedureExists("sp_DoktorKaydet"))
            {
                baglanti.ExecuteNonQuery("sp_DoktorKaydet", CommandType.StoredProcedure, parameters);
            }
            else
            {
                baglanti.ExecuteNonQuery(
                    "insert into Table_doktor (doktor_ad , doktor_soyad , doktor_tc , doktor_sifre , doktor_brans ) " +
                    "values (@doktor_ad , @doktor_soyad , @doktor_tc , @doktor_sifre , @doktor_brans)",
                    parameters);
            }

            RefreshDoctors();
            MessageBox.Show("Doktor kaydi eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(msk_tc.Text))
            {
                MessageBox.Show("Silmek icin doktor secin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlParameter parameter = new SqlParameter("@doktor_tc", msk_tc.Text);

            if (baglanti.ProcedureExists("sp_DoktorSil"))
            {
                baglanti.ExecuteNonQuery("sp_DoktorSil", CommandType.StoredProcedure, parameter);
            }
            else
            {
                baglanti.ExecuteNonQuery("delete from Table_doktor where doktor_tc = @doktor_tc", parameter);
            }

            RefreshDoctors();
            MessageBox.Show("Doktor kaydi silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txt_ad.Text = row.Cells["doktor_ad"].Value.ToString();
            txt_soyad.Text = row.Cells["doktor_soyad"].Value.ToString();
            cmb_brans.Text = row.Cells["doktor_brans"].Value.ToString();
            msk_tc.Text = row.Cells["doktor_tc"].Value.ToString();
            txt_sifre.Text = row.Cells["doktor_sifre"].Value.ToString();
        }

        private void button_hasta_kayit_Click(object sender, EventArgs e)
        {
            if (!ValidateDoctorForm())
            {
                return;
            }

            SqlParameter[] parameters = BuildDoctorParameters();

            if (baglanti.ProcedureExists("sp_DoktorGuncelle"))
            {
                baglanti.ExecuteNonQuery("sp_DoktorGuncelle", CommandType.StoredProcedure, parameters);
            }
            else
            {
                baglanti.ExecuteNonQuery(
                    "update Table_doktor set doktor_ad=@doktor_ad , doktor_soyad=@doktor_soyad , " +
                    "doktor_brans=@doktor_brans , doktor_sifre=@doktor_sifre where doktor_tc = @doktor_tc",
                    parameters);
            }

            RefreshDoctors();
            MessageBox.Show("Doktor kaydi guncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private SqlParameter[] BuildDoctorParameters()
        {
            return new[]
            {
                new SqlParameter("@doktor_ad", txt_ad.Text.Trim()),
                new SqlParameter("@doktor_soyad", txt_soyad.Text.Trim()),
                new SqlParameter("@doktor_tc", msk_tc.Text),
                new SqlParameter("@doktor_sifre", txt_sifre.Text),
                new SqlParameter("@doktor_brans", cmb_brans.Text)
            };
        }

        private bool ValidateDoctorForm()
        {
            if (string.IsNullOrWhiteSpace(txt_ad.Text) ||
                string.IsNullOrWhiteSpace(txt_soyad.Text) ||
                string.IsNullOrWhiteSpace(msk_tc.Text) ||
                string.IsNullOrWhiteSpace(txt_sifre.Text) ||
                string.IsNullOrWhiteSpace(cmb_brans.Text))
            {
                MessageBox.Show("Lutfen tum doktor alanlarini doldurun.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void RefreshDoctors()
        {
            try
            {
                dataGridView1.DataSource = baglanti.GetDataTable(
                    "select doktor_id, doktor_ad, doktor_soyad, doktor_brans, doktor_tc, doktor_sifre, poliklinik_ad, oda_kodu, toplam_randevu from vw_DoktorBransListesi order by doktor_ad, doktor_soyad");
            }
            catch
            {
                dataGridView1.DataSource = baglanti.GetDataTable("select * from Table_doktor");
            }
        }

        private void LoadBranches()
        {
            cmb_brans.Items.Clear();

            DataTable branches = baglanti.GetDataTable("select brans_ad from Table_brans order by brans_ad");
            foreach (DataRow row in branches.Rows)
            {
                cmb_brans.Items.Add(row["brans_ad"].ToString());
            }
        }

        private void ArrangeLayout()
        {
            SuspendLayout();

            int margin = 18;
            int gap = 16;
            int headerHeight = ModernTheme.GetHeaderHeight(this);
            int formTop = headerHeight + 24;
            int leftWidth = Math.Max(430, (int)(ClientSize.Width * 0.32));
            int rightWidth = ClientSize.Width - (margin * 2) - gap - leftWidth;
            int contentHeight = Math.Max(360, ClientSize.Height - formTop - margin - 8);

            int labelLeft = margin;
            int labelWidth = 115;
            int inputLeft = labelLeft + labelWidth + 10;
            int inputWidth = leftWidth - labelWidth - 24;
            int top = formTop;
            int rowHeight = 38;

            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);

            label3.SetBounds(labelLeft, top + 6, labelWidth, 24);
            txt_ad.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight;
            label4.SetBounds(labelLeft, top + 6, labelWidth, 24);
            txt_soyad.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight;
            label2.SetBounds(labelLeft, top + 6, labelWidth, 24);
            msk_tc.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight;
            label5.SetBounds(labelLeft, top + 6, labelWidth, 24);
            txt_sifre.SetBounds(inputLeft, top, inputWidth, 28);

            top += rowHeight;
            label6.SetBounds(labelLeft, top + 6, labelWidth, 24);
            cmb_brans.SetBounds(inputLeft, top, inputWidth, 28);

            top += 52;
            int smallButtonWidth = (inputWidth - 12) / 2;
            button_ekle.SetBounds(inputLeft, top, smallButtonWidth, 34);
            button_sil.SetBounds(button_ekle.Right + 12, top, smallButtonWidth, 34);
            button_hasta_kayit.SetBounds(inputLeft, top + 46, inputWidth, 34);

            dataGridView1.SetBounds(margin + leftWidth + gap, formTop, rightWidth, contentHeight);

            ResumeLayout();
        }
    }
}
