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
    public partial class brans_paneli_form : Form
    {
        public brans_paneli_form()
        {
            InitializeComponent();
        }
        sql_baglantisi baglanti = new sql_baglantisi();
        private void brans_paneli_form_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Table_brans",baglanti.baglanti());
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.baglanti().Close();
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("insert into Table_brans (brans_ad ) values" +
                "(@brans_ad)", baglanti.baglanti());
            cmd.Parameters.AddWithValue("brans_ad",txt_brans.Text);
            
            cmd.ExecuteNonQuery();
            baglanti.baglanti().Close();

            MessageBox.Show("branş eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Table_brans where brans_ad = @brans_Ad", baglanti.baglanti());
            komut.Parameters.AddWithValue("brans_ad", txt_brans.Text.ToString());
            komut.ExecuteNonQuery();
            baglanti.baglanti().Close();
            MessageBox.Show("branş silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            //sql güncelle
            SqlCommand cmd = new SqlCommand("update Table_brans set brans_ad=@brans_ad where brans_id = @brans_id", baglanti.baglanti());
            cmd.Parameters.AddWithValue("brans_ad", txt_brans.Text);
            cmd.Parameters.AddWithValue("brans_id", txt_id.Text);

            cmd.ExecuteNonQuery();
            baglanti.baglanti().Close();

            MessageBox.Show("kullanıcı güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txt_id.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();  //seçilen satırın 1. sutunuunda ad tutulur bu yüzden cells[1]
            txt_brans.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            
        }
    }
}
