using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace patch_seb
{
    internal static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 1)
			{
				if (args[1] == "/offline" || args[1] == "/Offline")
				{
					Application.Run(new OfflinePatcher());
				}
				else
				{
					Application.Run(new Form1());
				}
			}
			else
			{
				Application.Run(new Form1());
			}
        }
    }
}
