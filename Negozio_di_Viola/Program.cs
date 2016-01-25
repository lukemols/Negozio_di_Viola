using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Negozio_di_Viola
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.SetApartmentState(ApartmentState.STA);

            HomePage home = new HomePage();
            Application.Run(home);
            
        }
    }
}
