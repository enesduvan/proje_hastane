using System;
using System.Data;
using System.Windows.Forms;

namespace proje_hastane
{
    public partial class randevu_paneli_form : Form
    {
        private readonly sql_baglantisi baglanti = new sql_baglantisi();

        public randevu_paneli_form()
        {
            InitializeComponent();
        }

        private void randevu_paneli_form_Load(object sender, EventArgs e)
        {
            ModernTheme.StyleForm(this, "Randevu Listesi", "Randevulari view uzerinden daha anlamli kolonlarla goruntule.");

            try
            {
                dataGridView1.DataSource = baglanti.GetDataTable(
                    "select * from vw_RandevuSunum order by randevu_id desc");
            }
            catch
            {
                dataGridView1.DataSource = baglanti.GetDataTable(
                    "select * from Table_randevu order by randevu_id desc");
            }
        }
    }
}
