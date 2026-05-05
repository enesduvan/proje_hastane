using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proje_hastane
{
    public partial class doktor_paneli_form : Form
    {
        public doktor_paneli_form()
        {
            InitializeComponent();
        }
        sql_baglantisi baglanti = new sql_baglantisi();
        private void doktor_paneli_form_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Table_doktor", baglanti.baglanti());
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.baglanti().Close();


            SqlCommand komut = new SqlCommand("select brans_ad from Table_brans", baglanti.baglanti());
            SqlDataReader reader = komut.ExecuteReader();
            cmb_brans.Items.Clear();
            while (reader.Read())
            {//combobox doldurma
                cmb_brans.Items.Add(reader[0].ToString());
            }
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Table_doktor (doktor_ad , doktor_soyad , doktor_tc , doktor_sifre , doktor_brans ) values" +
                "(@doktor_ad , @doktor_soyad , @doktor_tc , @doktor_sifre , @doktor_brans)", baglanti.baglanti());
            cmd.Parameters.AddWithValue("doktor_ad", txt_ad.Text);
            cmd.Parameters.AddWithValue("doktor_soyad", txt_soyad.Text);
            cmd.Parameters.AddWithValue("doktor_sifre", txt_sifre.Text.ToString());
            cmd.Parameters.AddWithValue("doktor_tc", msk_tc.Text.ToString());
            cmd.Parameters.AddWithValue("doktor_brans", cmb_brans.Text.ToString());
            cmd.ExecuteNonQuery();
            baglanti.baglanti().Close();

            MessageBox.Show("kullanıcı eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_sil_Click(object sender, EventArgs e)
        {//sql delete
            SqlCommand komut = new SqlCommand("delete from Table_doktor where doktor_tc = @doktor_tc", baglanti.baglanti());
            komut.Parameters.AddWithValue("doktor_tc", msk_tc.Text.ToString());
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("kullanıcı silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txt_ad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();  //seçilen satırın 1. sutunuunda ad tutulur bu yüzden cells[1]
            txt_soyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmb_brans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msk_tc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txt_sifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button_hasta_kayit_Click(object sender, EventArgs e)
        {//sql güncelle
            SqlCommand cmd = new SqlCommand("update Table_doktor set doktor_ad=@doktor_ad , doktor_soyad=@doktor_soyad ," +
                "doktor_brans=@doktor_brans , doktor_sifre=@doktor_sifre where doktor_tc = @doktor_tc", baglanti.baglanti());
            cmd.Parameters.AddWithValue("doktor_ad",txt_ad.Text);
            cmd.Parameters.AddWithValue("doktor_soyad", txt_soyad.Text);
            cmd.Parameters.AddWithValue("doktor_sifre", txt_sifre.Text.ToString());
            cmd.Parameters.AddWithValue("doktor_tc", msk_tc.Text.ToString());
            cmd.Parameters.AddWithValue("doktor_brans", cmb_brans.Text.ToString());
            cmd.ExecuteNonQuery();
            baglanti.baglanti().Close();

            MessageBox.Show("kullanıcı güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
