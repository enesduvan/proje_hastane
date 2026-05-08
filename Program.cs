using System;
using System.Windows.Forms;

namespace proje_hastane
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DatabaseBootstrapper.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Veritabani ilk kurulumu tamamlanamadi. Uygulama mevcut yapida devam edecek.\n\n" + ex.Message,
                    "Baslangic Uyarisi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            Application.Run(new main_login_form());
        }
    }
}
