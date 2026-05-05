using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proje_hastane
{
    public partial class randevu_paneli_form : Form
    {
        public randevu_paneli_form()
        {
            InitializeComponent();
        }

        private void randevu_paneli_form_Load(object sender, EventArgs e)
        {
            sql_baglantisi baglanti = new sql_baglantisi();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter("select * from Table_randevu", baglanti.baglanti());
            adapter2.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
