using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Location_DVD_NS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (ExisteInstance())
                MessageBox.Show("Une autre instance du programme est déjà active !");
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new EcranAccueil());
            }
        }
        static bool ExisteInstance()
        {
            System.Diagnostics.Process actu = System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.Process[] acti = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process p in acti)
                if (p.Id != actu.Id)
                    if (actu.ProcessName == p.ProcessName)
                        return true;
            return false;
        }
    }
}
