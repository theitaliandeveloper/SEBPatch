using System;
using System.Collections.Generic;
using System.IO;
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
			// Checks
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\wpeinit.exe"))
			{
				// Running in Windows PE environment, launch the offline patcher
				Application.Run(new OfflinePatcher());
			}
			else
			{
				// Check if the user wants the offline patcher
				if (args.Length == 1)
				{
					if (args[0] == "/offline" || args[0] == "/Offline")
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
}
