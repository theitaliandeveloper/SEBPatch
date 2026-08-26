using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patch_seb
{
    internal class Variables
    {
		// Supported SEB version
		public static readonly string SupportedSEB = "3.10.2.920";
		// Files to patch
		public static readonly string[] files =
		{
			"SafeExamBrowser.exe",
			"SafeExamBrowser.Client.exe",
			"SafeExamBrowser.Configuration.dll",
			"SafeExamBrowser.Monitoring.dll",
			"SafeExamBrowser.Browser.dll"
		};
		// Patched files (64-bit and 32-bit)
		public static readonly byte[][] patchedFiles64 =
		{
			Properties.Resources.SafeExamBrowser,
			Properties.Resources.SafeExamBrowser_Client,
			Properties.Resources.SafeExamBrowser_Configuration,
			Properties.Resources.SafeExamBrowser_Monitoring,
			Properties.Resources.SafeExamBrowser_Browser
		};
		public static readonly byte[][] patchedFiles32 =
		{
			Properties.Resources.SafeExamBrowser1,
			Properties.Resources.SafeExamBrowser_Client1,
			Properties.Resources.SafeExamBrowser_Configuration1,
			Properties.Resources.SafeExamBrowser_Monitoring1,
			Properties.Resources.SafeExamBrowser_Browser1
		};
		// Various other variables
		public static bool isBackup;
		public static bool started = false;
		public static bool alreadyPatched = false;
		public static int something = 0;
		public static bool isCert;
		public static string SEBPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\SafeExamBrowser\Application\";
		public static string installation = "";
		public static bool is64bits = false;
	}
}
