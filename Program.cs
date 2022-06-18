using System;
using System.Security;
using System.Windows.Forms;

namespace RegistryEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\nPlease restart application with administrator privilege.", "Application Crash Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
