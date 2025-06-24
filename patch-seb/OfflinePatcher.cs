using patch_seb.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace patch_seb
{
	public partial class OfflinePatcher : Form
	{
		public static string installation = "";
		public static bool isBackup;
		public static bool started = false;
		public static bool alreadyPatched = false;
		public static bool is64bits = false;
		public static string SEBPath = "";
		public static int something = 0;
		public static bool isCert;
		public OfflinePatcher()
		{
			InitializeComponent();
		}
		public void AddLog(string log)
		{
			this.textBox1.Text += log + Environment.NewLine;
		}

		private void button1_Click(object sender, EventArgs e)
        {
			installation = partitionComboBox.SelectedItem.ToString();
			selectedinstallation.Text = $"Selected Installation: {installation}";
			AddLog($"[INFO] Selected {installation}");
			groupBox2.Enabled = true;
			button2.Enabled = true;
			if (File.Exists(installation + @"Windows\SysWOW64\cmd.exe"))
			{
				AddLog($"[INFO] Detected x64 installation on {installation}.");
				is64bits = true;
			}
			else
			{
				AddLog($"[INFO] Detected x86 installation on {installation}.");
			}
			FileVersionInfo SEBVersion = FileVersionInfo.GetVersionInfo(installation + @"Program Files\SafeExamBrowser\Application\SafeExamBrowser.exe");
			FileVersionInfo SEBDLLVersion = FileVersionInfo.GetVersionInfo(installation + @"Program Files\SafeExamBrowser\Application\SafeExamBrowser.Configuration.dll");
			if (SEBVersion.ProductVersion == Variables.SupportedSEB || SEBDLLVersion.ProductVersion == "1.0.0.0") // Somehow the patched version string differs from the official version string.
			{
				alreadyPatched = true;
				isBackup = false;
				checkBox1.Enabled = false;
				button2.Text = "PATCH AGAIN/UPDATE";
				AddLog($"READY TO UPDATE/PATCH AGAIN {installation}.");
			}
			else
			{
				AddLog($"READY TO PATCH {installation}.");
			}
			started = false;
		}

        private void OfflinePatcher_Load(object sender, EventArgs e)
        {
			#if DEBUG
				AddLog("Safe Exam Browser Offline Patch (Debug/Beta) v" + Application.ProductVersion + " (Safe Exam Browser v" + Variables.SupportedSEB + ")");
			#else
				AddLog("Safe Exam Browser Offline Patch v" + Application.ProductVersion + " (Safe Exam Browser v" + Variables.SupportedSEB + ")");
			#endif
			AddLog("");
			partitionComboBox.Items.Clear();
			AddLog("[INFO] Searching for suitable partitions...");
			DriveInfo[] allDrives = DriveInfo.GetDrives();
			foreach (DriveInfo drive in allDrives)
			{
				if (drive.IsReady && drive.Name != @"X:\" && File.Exists(drive.Name + @"Program Files\SafeExamBrowser\Application\SafeExamBrowser.exe"))
				{
					FileVersionInfo SEBVersion = FileVersionInfo.GetVersionInfo(drive.Name + @"Program Files\SafeExamBrowser\Application\SafeExamBrowser.exe");
					FileVersionInfo SEBDLLVersion = FileVersionInfo.GetVersionInfo(drive.Name + @"Program Files\SafeExamBrowser\Application\SafeExamBrowser.Configuration.dll");
					if (SEBVersion.FileVersion != Variables.SupportedSEB)
					{
						AddLog($"[WARNING] Partition {drive.Name} contains unsupported Safe Exam Browser version, not adding to the list.");
					}
					else if (drive.Name + @"Windows" == Environment.GetFolderPath(Environment.SpecialFolder.Windows) || drive.Name + @"windows" == Environment.GetFolderPath(Environment.SpecialFolder.Windows))
					{
						AddLog($"[WARNING] Partition {drive.Name} is an online image, not adding to the list.");
					}
					else if (SEBVersion.ProductVersion == Variables.SupportedSEB || SEBDLLVersion.ProductVersion == "1.0.0.0") // Somehow the patched version string differs from the official version string.
					{
						AddLog($"[WARNING] Partition {drive.Name} contains an already patched Safe Exam Browser, adding to the list anyway.");
						string label = $"{drive.Name}";
						partitionComboBox.Items.Add(label);
					}
					else
					{
						AddLog($"[INFO] Partition {drive.Name} contains a supported Safe Exam Browser version, adding to the list.");
						string label = $"{drive.Name}";
						partitionComboBox.Items.Add(label);
					}
				}
				else
				{
					AddLog($"[WARNING] Partition {drive.Name} doesn't contain an installed Safe Exam Browser version or is not formatted correctly, not adding to the list.");
				}
			}

			if (partitionComboBox.Items.Count > 0)
			{
				AddLog($"[INFO] Found {partitionComboBox.Items.Count} partitions suitable for the patch.");
				partitionComboBox.SelectedIndex = 0;
			}
			else
			{
				AddLog("[ERROR] Found 0 partitions suitable for the patch.");
				button1.Enabled = false;
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
			SEBPath = installation + @"Program Files\SafeExamBrowser\Application\";
			if (alreadyPatched)
			{
				var dialog = MessageBox.Show("An already patched Safe Exam Browser has been found. Are you sure to continue?", "Safe Exam Browser Offline Patch", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
					if (File.Exists(SEBPath + @"SafeExamBrowser.UserInterface.Desktop.dll.backup"))
					{
						File.Delete(SEBPath + @"SafeExamBrowser.UserInterface.Desktop.dll.backup");
					}
					File.Copy(SEBPath + @"SafeExamBrowser.UserInterface.Desktop.dll", SEBPath + @"SafeExamBrowser.UserInterface.Desktop.dll.backup");
					if (File.Exists(SEBPath + @"SafeExamBrowser.UserInterface.Mobile.dll.backup"))
					{
						File.Delete(SEBPath + @"SafeExamBrowser.UserInterface.Mobile.dll.backup");
					}
					File.Copy(SEBPath + @"SafeExamBrowser.UserInterface.Mobile.dll", SEBPath + @"SafeExamBrowser.UserInterface.Mobile.dll.backup");
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
				File.Delete(SEBPath + @"SafeExamBrowser.UserInterface.Desktop.dll");
				File.Delete(SEBPath + @"SafeExamBrowser.UserInterface.Mobile.dll");
				if (autodetect.Checked) // Autodetect
				{
					if (is64bits) // 64 bits patch
					{
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.exe", Resources.SafeExamBrowser);
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Client.exe", Resources.SafeExamBrowser_Client);
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Configuration.dll", Resources.SafeExamBrowser_Configuration);
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Monitoring.dll", Resources.SafeExamBrowser_Monitoring);
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.UserInterface.Desktop.dll", Resources.SafeExamBrowser_UserInterface_Desktop);
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.UserInterface.Mobile.dll", Resources.SafeExamBrowser_UserInterface_Mobile);
					}
					else // 32 bits patch
					{
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.exe", Resources.SafeExamBrowser1);
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Client.exe", Resources.SafeExamBrowser_Client1);
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Configuration.dll", Resources.SafeExamBrowser_Configuration1);
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Monitoring.dll", Resources.SafeExamBrowser_Monitoring1);
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.UserInterface.Desktop.dll", Resources.SafeExamBrowser_UserInterface_Desktop1);
						File.WriteAllBytes(SEBPath + @"SafeExamBrowser.UserInterface.Mobile.dll", Resources.SafeExamBrowser_UserInterface_Mobile1);
					}
				}
				else if (x64.Checked) // 64 bits patch
				{
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.exe", Resources.SafeExamBrowser);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Client.exe", Resources.SafeExamBrowser_Client);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Configuration.dll", Resources.SafeExamBrowser_Configuration);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Monitoring.dll", Resources.SafeExamBrowser_Monitoring);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.UserInterface.Desktop.dll", Resources.SafeExamBrowser_UserInterface_Desktop);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.UserInterface.Mobile.dll", Resources.SafeExamBrowser_UserInterface_Mobile);
				}
				else // 32 bits patch
				{
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.exe", Resources.SafeExamBrowser1);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Client.exe", Resources.SafeExamBrowser_Client1);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Configuration.dll", Resources.SafeExamBrowser_Configuration1);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.Monitoring.dll", Resources.SafeExamBrowser_Monitoring1);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.UserInterface.Desktop.dll", Resources.SafeExamBrowser_UserInterface_Desktop1);
					File.WriteAllBytes(SEBPath + @"SafeExamBrowser.UserInterface.Mobile.dll", Resources.SafeExamBrowser_UserInterface_Mobile1);
				}
				if (isCert)
				{
					// Load offline registry
					ProcessStartInfo load = new ProcessStartInfo
					{
						FileName = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\reg.exe",
						Arguments = $@"load HKLM\OFFSOFTWARE {installation}Windows\System32\config\software",
						CreateNoWindow = true,
						WindowStyle = ProcessWindowStyle.Hidden
					};
					Process.Start(load).WaitForExit();
					// Add certificate to offline registry
					File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Temp\SEB.reg", Resources.cert_offline);
					ProcessStartInfo info = new ProcessStartInfo
					{
						FileName = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\regedit.exe",
						Arguments = $@"/s {Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Temp\SEB.reg"}",
						CreateNoWindow = true,
						WindowStyle = ProcessWindowStyle.Hidden
					};
					Process.Start(info).WaitForExit();
					File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\Temp\SEB.reg");
					// Unload offline registry
					ProcessStartInfo unload = new ProcessStartInfo
					{
						FileName = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\System32\reg.exe",
						Arguments = $@"unload HKLM\OFFSOFTWARE",
						CreateNoWindow = true,
						WindowStyle = ProcessWindowStyle.Hidden
					};
					Process.Start(unload).WaitForExit();
				}
				AddLog($"PATCHING DONE ON {installation}.");
				button2.Text = "PATCH DONE";
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
					MessageBox.Show("Safe Exam Browser Offline Patch (Debug/Beta) v" + Application.ProductVersion + "\nFor Safe Exam Browser version " + Variables.SupportedSEB + "\nCreated with love by Vichingo455\n\nBecause Freedom is a right, respect it.", "Safe Exam Browser Patch", MessageBoxButtons.OK, MessageBoxIcon.Information);
				#else
					MessageBox.Show("Safe Exam Browser Offline Patch v" + Application.ProductVersion + "\nFor Safe Exam Browser version " + Variables.SupportedSEB + "\nCreated with love by Vichingo455\n\nBecause Freedom is a right, respect it.", "Safe Exam Browser Patch", MessageBoxButtons.OK, MessageBoxIcon.Information);
				#endif
			}
			else
			{
				something++;
			}
		}
    }
}
