using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using patch_seb.Properties;

namespace patch_seb
{
    public partial class Form1 : Form
    {
		public static bool isBackup;
		public static bool started = false;
		public static bool alreadyPatched = false;
		public static string SEBPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\SafeExamBrowser\Application\";
		public static int something = 0;
		public static bool isCert;

		public Form1()
        {
            InitializeComponent();
        }
		public void AddLog(string log)
		{
			this.textBox1.Text += log + Environment.NewLine;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			#if DEBUG
				AddLog("Safe Exam Browser Patch (Debug/Beta) v" + Application.ProductVersion + " (Safe Exam Browser v" + Variables.SupportedSEB + ")");
			#else
				AddLog("Safe Exam Browser Patch v" + Application.ProductVersion + " (Safe Exam Browser v" + Variables.SupportedSEB + ")");
			#endif
			AddLog("");
			if (Environment.Is64BitOperatingSystem)
			{
				AddLog("[INFO] Detected x64 operating system.");
			}
			else
			{
				AddLog("[INFO] Detected x86 operating system.");
			}

			if (Environment.OSVersion.Version.Major != 10)
			{
				AddLog("[ERROR] Supported Windows version not found.");
				button1.Enabled = false;
			}
			else if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\SafeExamBrowser\Application\SafeExamBrowser.exe"))
			{
				AddLog("[ERROR] Safe Exam Browser not found.");
				button1.Enabled = false;
			}
			else
			{
				FileVersionInfo SEBVersion = FileVersionInfo.GetVersionInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\SafeExamBrowser\Application\SafeExamBrowser.exe");
				FileVersionInfo SEBDLLVersion = FileVersionInfo.GetVersionInfo(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\SafeExamBrowser\Application\SafeExamBrowser.Configuration.dll");
				if (SEBVersion.FileVersion != Variables.SupportedSEB)
				{
					AddLog("[ERROR] Found unsupported Safe Exam Browser version.");
					button1.Enabled = false;
				}
				else if (SEBVersion.ProductVersion == Variables.SupportedSEB || SEBDLLVersion.ProductVersion == "1.0.0.0") // Somehow the patched version string differs from the official version string.
				{
					checkBox1.Checked = false;
					checkBox1.Enabled = false;
					isBackup = false;
					alreadyPatched = true;
					button1.Text = "PATCH AGAIN/UPDATE";
					AddLog("[WARNING] Found an already patched Safe Exam Browser.");
					AddLog("READY TO UPDATE PATCH");
				}
				else
				{
					AddLog("[INFO] Supported Safe Exam Browser version found.");
					AddLog("READY TO PATCH");
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (alreadyPatched)
			{
				var dialog = MessageBox.Show("An already patched Safe Exam Browser has been found. Are you sure to continue?","Safe Exam Browser Patch",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
				if (dialog == DialogResult.No)
				{
					return;
				}
			}
			isBackup = checkBox1.Checked;
			isCert = checkBox2.Checked;
			if (!started)
			{
				started = true;
				Thread thr = new Thread(PatchThread);
				thr.Start();
			}
		}
		private void PatchThread()
		{
			if (isBackup)
			{
				try
				{
					if (File.Exists(SEBPath + @"SafeExamBrowser.exe.backup"))
					{
						File.Delete(SEBPath + @"SafeExamBrowser.exe.backup");
					}
					File.Copy(SEBPath + @"SafeExamBrowser.exe", SEBPath + @"SafeExamBrowser.exe.backup");
					if (File.Exists(SEBPath + @"SafeExamBrowser.Client.exe.backup"))
					{
						File.Delete(SEBPath + @"SafeExamBrowser.Client.exe.backup");
					}
					File.Copy(SEBPath + @"SafeExamBrowser.Client.exe", SEBPath + @"SafeExamBrowser.Client.exe.backup");
					if (File.Exists(SEBPath + @"SafeExamBrowser.Configuration.dll.backup"))
					{
						File.Delete(SEBPath + @"SafeExamBrowser.Configuration.dll.backup");
					}
					File.Copy(SEBPath + @"SafeExamBrowser.Configuration.dll", SEBPath + @"SafeExamBrowser.Configuration.dll.backup");
					if (File.Exists(SEBPath + @"SafeExamBrowser.Monitoring.dll.backup"))
					{
						File.Delete(SEBPath + @"SafeExamBrowser.Monitoring.dll.backup");
					}
					File.Copy(SEBPath + @"SafeExamBrowser.Monitoring.dll", SEBPath + @"SafeExamBrowser.Monitoring.dll.backup");
				}
				catch (Exception ex)
				{
					AddLog("[ERROR] " + ex.Message);
				}
			}
			try
			{
				File.Delete(SEBPath + @"SafeExamBrowser.exe");
				File.Delete(SEBPath + @"SafeExamBrowser.Client.exe");
				File.Delete(SEBPath + @"SafeExamBrowser.Configuration.dll");
				File.Delete(SEBPath + @"SafeExamBrowser.Monitoring.dll");
				if (Environment.Is64BitOperatingSystem) // 64 bits patch
				{
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.exe", Resources.SafeExamBrowser);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Client.exe", Resources.SafeExamBrowser_Client);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Configuration.dll", Resources.SafeExamBrowser_Configuration);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Monitoring.dll", Resources.SafeExamBrowser_Monitoring);
				}
				else // 32 bits patch
				{
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.exe", Resources.SafeExamBrowser1);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Client.exe", Resources.SafeExamBrowser_Client1);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Configuration.dll", Resources.SafeExamBrowser_Configuration1);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Monitoring.dll", Resources.SafeExamBrowser_Monitoring1);
				}
				if (isCert)
				{
					File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Temp\SEB.reg", Resources.cert);
					ProcessStartInfo info = new ProcessStartInfo
					{
						FileName = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\regedit.exe",
						Arguments = $@"/s {Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Temp\SEB.reg"}",
						CreateNoWindow = true,
						WindowStyle = ProcessWindowStyle.Hidden
					};
					Process.Start(info).WaitForExit();
					File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Temp\SEB.reg");
				}
				AddLog("PATCHING DONE");
				button1.Text = "PATCH DONE";
			}
			catch (Exception ex)
			{
				AddLog("[ERROR] " + ex.Message);
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{
			if (something == 4)
			{
				something = 0;
				#if DEBUG
					MessageBox.Show("Safe Exam Browser Patch (Debug/Beta) v" + Application.ProductVersion + "\nFor Safe Exam Browser version " + Variables.SupportedSEB + "\nCreated with love by Vichingo455\n\nBecause Freedom is a right, respect it.", "Safe Exam Browser Patch", MessageBoxButtons.OK, MessageBoxIcon.Information);
				#else
					MessageBox.Show("Safe Exam Browser Patch v" + Application.ProductVersion + "\nFor Safe Exam Browser version " + Variables.SupportedSEB + "\nCreated with love by Vichingo455\n\nBecause Freedom is a right, respect it.", "Safe Exam Browser Patch", MessageBoxButtons.OK, MessageBoxIcon.Information);
				#endif
			}
			else
			{
				something++;
			}
		}
	}
}
