using System;
using System.Windows.Forms;

namespace proje_hastane
{
    public partial class duyurular_form : Form
    {
        private readonly sql_baglantisi baglanti = new sql_baglantisi();

        public duyurular_form()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void duyurular_form_Load(object sender, EventArgs e)
        {
            ModernTheme.StyleForm(this, "Duyurular", "Sekreter tarafindan olusturulan idari duyurular tek tabloda listelenir.");

            try
            {
                dataGridView1.DataSource = baglanti.GetDataTable(
                    "select duyuru_id, duyuru, olusturma_tarihi, olusturan_tc from Table_duyuru order by duyuru_id desc");
            }
            catch
            {
                dataGridView1.DataSource = baglanti.GetDataTable("select * from Table_duyuru");
            }
        }
    }
}
