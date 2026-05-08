using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace proje_hastane
{
    internal static class DatabaseBootstrapper
    {
        public static void Initialize()
        {
            sql_baglantisi helper = new sql_baglantisi();

            EnsureDatabaseExists(helper);
            RunEmbeddedScript(helper);
        }

        private static void EnsureDatabaseExists(sql_baglantisi helper)
        {
            string createDatabaseSql =
                "IF DB_ID(@databaseName) IS NULL " +
                "BEGIN " +
                "EXEC('CREATE DATABASE [" + sql_baglantisi.DatabaseName + "]') " +
                "END";

            using (SqlConnection connection = new SqlConnection(helper.GetMasterConnectionString()))
            using (SqlCommand command = new SqlCommand(createDatabaseSql, connection))
            {
                command.Parameters.AddWithValue("@databaseName", sql_baglantisi.DatabaseName);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static void RunEmbeddedScript(sql_baglantisi helper)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly
                .GetManifestResourceNames()
                .FirstOrDefault(name => name.EndsWith("Database.hastane_donem_projesi.sql", StringComparison.OrdinalIgnoreCase));

            if (string.IsNullOrWhiteSpace(resourceName))
            {
                return;
            }

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string script = reader.ReadToEnd();
                string[] batches = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                using (SqlConnection connection = new SqlConnection(helper.GetDatabaseConnectionString()))
                {
                    connection.Open();

                    foreach (string batch in batches)
                    {
                        string trimmedBatch = batch.Trim();
                        if (string.IsNullOrWhiteSpace(trimmedBatch))
                        {
                            continue;
                        }

                        try
                        {
                            using (SqlCommand command = new SqlCommand(trimmedBatch, connection))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (SqlException)
                        {
                            // Script is written to be idempotent, but existing user schemas may vary.
                            // We skip incompatible batches so the application can still open and use fallback SQL.
                        }
                    }
                }
            }
        }
    }
}
