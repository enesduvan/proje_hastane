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
    public partial class duyurular_form : Form
    {
        public duyurular_form()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        sql_baglantisi baglanti = new sql_baglantisi();
        private void duyurular_form_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Table_duyuru",baglanti.baglanti());
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.baglanti().Close();
        }
    }
}
