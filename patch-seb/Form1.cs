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
using static patch_seb.Variables;

namespace patch_seb
{
    public partial class Form1 : Form
    {
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
				AddLog("Safe Exam Browser Patch (Debug/Beta) v" + Application.ProductVersion + " (Safe Exam Browser v" + SupportedSEB + ")");
			#else
				AddLog("Safe Exam Browser Patch v" + Application.ProductVersion + " (Safe Exam Browser v" + SupportedSEB + ")");
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
				if (SEBVersion.FileVersion != SupportedSEB)
				{
					AddLog("[ERROR] Found unsupported Safe Exam Browser version.");
					button1.Enabled = false;
				}
				else if (SEBVersion.ProductVersion == SupportedSEB || SEBDLLVersion.ProductVersion == "1.0.0.0") // Somehow the patched version string differs from the official version string.
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
					for (int i = 0; i < files.Length; i++)
					{
#if DEBUG
						AddLog($"[DEBUG] Backing up {files[i]}...");
#endif
						Helpers.BackupFile(SEBPath + files[i], SEBPath + files[i] + ".backup");
					}
				}
				catch (Exception ex)
				{
					AddLog("[ERROR] " + ex.Message);
				}
			}
			try
			{
				if (Environment.Is64BitOperatingSystem) // 64 bits patch
				{
					for (int i = 0; i < files.Length; i++)
					{
#if DEBUG
						AddLog($"[DEBUG] Patching {files[i]}...");
#endif
						Helpers.PatchFile(SEBPath + files[i],patchedFiles64[i]);
					}
				}
				else // 32 bits patch
				{
					for (int i = 0; i < files.Length; i++)
					{
#if DEBUG
						AddLog($"[DEBUG] Patching {files[i]}...");
#endif
						Helpers.PatchFile(SEBPath + files[i], patchedFiles32[i]);
					}
				}
				if (isCert)
				{
#if DEBUG
					AddLog("[DEBUG] Installing certificate...");
#endif
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
					MessageBox.Show("Safe Exam Browser Patch (Debug/Beta) v" + Application.ProductVersion + "\nFor Safe Exam Browser version " + SupportedSEB + "\nCreated with love by Vichingo455\n\nBecause Freedom is a right, respect it.", "Safe Exam Browser Patch", MessageBoxButtons.OK, MessageBoxIcon.Information);
				#else
					MessageBox.Show("Safe Exam Browser Patch v" + Application.ProductVersion + "\nFor Safe Exam Browser version " + SupportedSEB + "\nCreated with love by Vichingo455\n\nBecause Freedom is a right, respect it.", "Safe Exam Browser Patch", MessageBoxButtons.OK, MessageBoxIcon.Information);
				#endif
			}
			else
			{
				something++;
			}
		}
	}
}
