using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace proje_hastane
{
    public partial class brans_paneli_form : Form
    {
        private readonly sql_baglantisi baglanti = new sql_baglantisi();

        public brans_paneli_form()
        {
            InitializeComponent();
        }

        private void brans_paneli_form_Load(object sender, EventArgs e)
        {
            ModernTheme.StyleForm(this, "Brans Yonetimi", "Brans ekleme, guncelleme ve silme islemleri merkezi tablo uzerinden yonetilir.");
            RefreshBranches();
            ArrangeLayout();

            Resize += (resizeSender, resizeArgs) => ArrangeLayout();
            Shown += (shownSender, shownArgs) => ArrangeLayout();
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_brans.Text))
            {
                MessageBox.Show("Lutfen brans adini girin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlParameter parameter = new SqlParameter("@brans_ad", txt_brans.Text.Trim());

            if (baglanti.ProcedureExists("sp_BransKaydet"))
            {
                baglanti.ExecuteNonQuery("sp_BransKaydet", CommandType.StoredProcedure, parameter);
            }
            else
            {
                baglanti.ExecuteNonQuery("insert into Table_brans (brans_ad) values (@brans_ad)", parameter);
            }

            RefreshBranches();
            MessageBox.Show("Brans eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_brans.Text))
            {
                MessageBox.Show("Silmek icin bir brans secin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlParameter parameter = new SqlParameter("@brans_ad", txt_brans.Text.Trim());

            if (baglanti.ProcedureExists("sp_BransSil"))
            {
                baglanti.ExecuteNonQuery("sp_BransSil", CommandType.StoredProcedure, parameter);
            }
            else
            {
                baglanti.ExecuteNonQuery("delete from Table_brans where brans_ad = @brans_ad", parameter);
            }

            RefreshBranches();
            MessageBox.Show("Brans silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_id.Text) || string.IsNullOrWhiteSpace(txt_brans.Text))
            {
                MessageBox.Show("Guncellemek icin once bir satir secin.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlParameter[] parameters =
            {
                new SqlParameter("@brans_id", txt_id.Text),
                new SqlParameter("@brans_ad", txt_brans.Text.Trim())
            };

            if (baglanti.ProcedureExists("sp_BransGuncelle"))
            {
                baglanti.ExecuteNonQuery("sp_BransGuncelle", CommandType.StoredProcedure, parameters);
            }
            else
            {
                baglanti.ExecuteNonQuery("update Table_brans set brans_ad=@brans_ad where brans_id=@brans_id", parameters);
            }

            RefreshBranches();
            MessageBox.Show("Brans guncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            txt_id.Text = dataGridView1.Rows[e.RowIndex].Cells["brans_id"].Value.ToString();
            txt_brans.Text = dataGridView1.Rows[e.RowIndex].Cells["brans_ad"].Value.ToString();
        }

        private void RefreshBranches()
        {
            dataGridView1.DataSource = baglanti.GetDataTable(
                "SELECT brans_id, brans_ad FROM dbo.Table_brans ORDER BY brans_ad");
        }

        private void ArrangeLayout()
        {
            SuspendLayout();

            int margin = 18;
            int gap = 16;
            int headerHeight = ModernTheme.GetHeaderHeight(this);
            int contentTop = headerHeight + 26;
            int leftWidth = Math.Max(380, (int)(ClientSize.Width * 0.28));
            int rightWidth = ClientSize.Width - (margin * 2) - gap - leftWidth;
            int contentHeight = Math.Max(320, ClientSize.Height - contentTop - margin - 8);

            int labelLeft = margin;
            int labelWidth = 100;
            int inputLeft = labelLeft + labelWidth + 10;
            int inputWidth = leftWidth - labelWidth - 24;

            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);

            label3.SetBounds(labelLeft, contentTop + 6, labelWidth, 24);
            txt_id.SetBounds(inputLeft, contentTop, inputWidth, 28);
            label4.SetBounds(labelLeft, contentTop + 46, labelWidth, 24);
            txt_brans.SetBounds(inputLeft, contentTop + 40, inputWidth, 28);

            int halfButton = (inputWidth - 12) / 2;
            button_ekle.SetBounds(inputLeft, contentTop + 92, halfButton, 34);
            button_sil.SetBounds(button_ekle.Right + 12, contentTop + 92, halfButton, 34);
            button_guncelle.SetBounds(inputLeft, contentTop + 138, inputWidth, 34);

            dataGridView1.SetBounds(margin + leftWidth + gap, contentTop, rightWidth, contentHeight);

            ResumeLayout();
        }
    }
}
