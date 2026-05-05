using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace proje_hastane
{
    internal class sql_baglantisi
    {
        public SqlConnection baglanti()
        {
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=hastane_proje;Integrated Security=True
            SqlConnection baglan = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hastane_proje");
            baglan.Open();
            return baglan;
        }
    }
}
