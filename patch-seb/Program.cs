using System;
using System.IO;
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
			// Warn the user if running a debug/beta build
#if DEBUG
			var dialog = MessageBox.Show("You're about to run a Debug/Beta build. These builds are NOT production ready, and you should be using them only for testing.\n\nARE YOU SURE TO CONTINUE, KNOWING THE AUTHOR WILL PROVIDE NO SUPPORT FOR YOU?","Safe Exam Browser Patcher",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
			if (dialog == DialogResult.No)
			{
				return;
			}
#endif
			// Check if we're running in Windows PE
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
