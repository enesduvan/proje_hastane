using System;
using System.Data;
using System.Data.SqlClient;

namespace proje_hastane
{
    internal class sql_baglantisi
    {
        public const string DatabaseName = "hastane_proje";

        private const string ServerName = @"(localdb)\MSSQLLocalDB";
        private const string MasterConnectionString = "Data Source=" + ServerName + ";Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True";
        private const string DatabaseConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=True;MultipleActiveResultSets=True";

        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(DatabaseConnectionString);
            baglan.Open();
            return baglan;
        }

        public string GetMasterConnectionString()
        {
            return MasterConnectionString;
        }

        public string GetDatabaseConnectionString()
        {
            return DatabaseConnectionString;
        }

        public DataTable GetDataTable(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = baglanti())
            using (SqlCommand command = new SqlCommand(commandText, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.CommandType = commandType;
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable GetDataTable(string commandText, params SqlParameter[] parameters)
        {
            return GetDataTable(commandText, CommandType.Text, parameters);
        }

        public DataRow GetDataRow(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            DataTable table = GetDataTable(commandText, commandType, parameters);
            return table.Rows.Count > 0 ? table.Rows[0] : null;
        }

        public DataRow GetDataRow(string commandText, params SqlParameter[] parameters)
        {
            return GetDataRow(commandText, CommandType.Text, parameters);
        }

        public int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = baglanti())
            using (SqlCommand command = new SqlCommand(commandText, connection))
            {
                command.CommandType = commandType;
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                return command.ExecuteNonQuery();
            }
        }

        public int ExecuteNonQuery(string commandText, params SqlParameter[] parameters)
        {
            return ExecuteNonQuery(commandText, CommandType.Text, parameters);
        }

        public object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = baglanti())
            using (SqlCommand command = new SqlCommand(commandText, connection))
            {
                command.CommandType = commandType;
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                return command.ExecuteScalar();
            }
        }

        public object ExecuteScalar(string commandText, params SqlParameter[] parameters)
        {
            return ExecuteScalar(commandText, CommandType.Text, parameters);
        }

        public bool ProcedureExists(string procedureName)
        {
            object result = ExecuteScalar(
                "SELECT COUNT(*) FROM sys.objects WHERE type = 'P' AND name = @name",
                new SqlParameter("@name", procedureName));
            return Convert.ToInt32(result) > 0;
        }

        public bool ViewExists(string viewName)
        {
            object result = ExecuteScalar(
                "SELECT COUNT(*) FROM sys.views WHERE name = @name",
                new SqlParameter("@name", viewName));
            return Convert.ToInt32(result) > 0;
        }
    }
}
