using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace proje_hastane
{
    public partial class doktor_bilgi_guncelle : Form
    {
        private readonly sql_baglantisi baglanti = new sql_baglantisi();
        private readonly string _doktorTc;

        // Parametre almayan constructor (eski kodla uyumluluk icin)
        public doktor_bilgi_guncelle()
        {
            InitializeComponent();
        }

        // TC alarak baslatan constructor
        public doktor_bilgi_guncelle(string doktorTc)
        {
            InitializeComponent();
            _doktorTc = doktorTc;
        }

        private void doktor_bilgi_guncelle_Load(object sender, EventArgs e)
        {
            ModernTheme.StyleForm(this, "Doktor Bilgi Guncelleme", "Kendi bilgilerinizi guncelleyebilirsiniz.");

            BranslariYukle();

            if (!string.IsNullOrWhiteSpace(_doktorTc))
            {
                MevcutBilgileriYukle(_doktorTc);
            }
        }

        private void BranslariYukle()
        {
            try
            {
                DataTable dt = baglanti.GetDataTable("SELECT brans_ad FROM Table_brans ORDER BY brans_ad");
                cmb_brans.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cmb_brans.Items.Add(row["brans_ad"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Branslar yuklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MevcutBilgileriYukle(string tc)
        {
            try
            {
                DataRow row = baglanti.GetDataRow(
                    "SELECT doktor_ad, doktor_soyad, doktor_tc, doktor_sifre, doktor_brans FROM Table_doktor WHERE doktor_tc = @tc",
                    new SqlParameter("@tc", tc));

                if (row != null)
                {
                    txt_ad.Text = row["doktor_ad"].ToString();
                    txt_soyad.Text = row["doktor_soyad"].ToString();
                    msk_tc.Text = row["doktor_tc"].ToString();
                    txt_sifre.Text = row["doktor_sifre"].ToString();

                    string brans = row["doktor_brans"].ToString();
                    if (cmb_brans.Items.Contains(brans))
                    {
                        cmb_brans.SelectedItem = brans;
                    }
                    else
                    {
                        cmb_brans.Text = brans;
                    }

                    // TC degistirilemez (kimlik)
                    msk_tc.ReadOnly = true;
                    msk_tc.BackColor = System.Drawing.Color.FromArgb(40, 44, 52);
                }
                else
                {
                    MessageBox.Show("Doktor bilgisi bulunamadi.", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler yuklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_hasta_kayit_Click(object sender, EventArgs e)
        {
            string ad = txt_ad.Text.Trim();
            string soyad = txt_soyad.Text.Trim();
            string tc = msk_tc.Text.Trim();
            string sifre = txt_sifre.Text.Trim();
            string brans = cmb_brans.Text.Trim();

            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) ||
                string.IsNullOrWhiteSpace(tc) || string.IsNullOrWhiteSpace(sifre) || string.IsNullOrWhiteSpace(brans))
            {
                MessageBox.Show("Lutfen tum alanlari doldurun.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tc.Length != 11)
            {
                MessageBox.Show("TC Kimlik No 11 haneli olmalidir.", "Gecersiz TC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                baglanti.ExecuteNonQuery(
                    "EXEC sp_DoktorGuncelle @doktor_ad, @doktor_soyad, @doktor_tc, @doktor_sifre, @doktor_brans",
                    new SqlParameter("@doktor_ad", ad),
                    new SqlParameter("@doktor_soyad", soyad),
                    new SqlParameter("@doktor_tc", tc),
                    new SqlParameter("@doktor_sifre", sifre),
                    new SqlParameter("@doktor_brans", brans));

                MessageBox.Show("Bilgileriniz basariyla guncellendi!", "Basarili", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Guncelleme sirasinda hata olustu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_geri_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
