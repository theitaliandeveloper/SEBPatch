/*
 * Copyright (c) 2025 ETH Zürich, IT Services
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using SafeExamBrowser.Configuration.Contracts;

namespace SafeExamBrowser.Runtime
{
	public class App : Application
	{
		private static readonly Mutex Mutex = new Mutex(true, AppConfig.RUNTIME_MUTEX_NAME);
		private readonly CompositionRoot instances = new CompositionRoot();

		[STAThread]
		public static void Main()
		{
			try
			{
				// Safe Exam Browser Patch first use dialog.
				if (!CheckRegistry(Microsoft.Win32.RegistryHive.CurrentUser, @"Software\Vichingo455\SEBPatch", "FirstOpeningDialogShown"))
				{
					MessageBox.Show("This patch has been created by Vichingo455.\nIt patches Safe Exam Browser functions to escape its kiosk mode, as well as allowing copy paste and more.\nAfter you finished using Safe Exam Browser, you can quit it using CTRL+Q or the button at the bottom.\nRemember to never run explorer.exe or you will mess up the mask (I will laugh at you if you get caught this way).\n\nThis message is only shown once, click OK when you finished reading.", "Safe Exam Browser Patch by Vichingo455", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
					try
					{
						Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Vichingo455\SEBPatch");
						rk.SetValue("FirstOpeningDialogShown", 1, Microsoft.Win32.RegistryValueKind.DWord);
						rk.Close();
					}
					catch { }
				}
				StartApplication();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message + "\n\n" + e.StackTrace, "Fatal Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			finally
			{
				Mutex.Close();
			}
		}

		private static void StartApplication()
		{
			if (NoInstanceRunning())
			{
				new App().Run();
			}
			else
			{
				MessageBox.Show("You can only run one instance of SEB at a time.", "Startup Not Allowed", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private static bool NoInstanceRunning()
		{
			return Mutex.WaitOne(TimeSpan.Zero, true);
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			ShutdownMode = ShutdownMode.OnExplicitShutdown;

			instances.BuildObjectGraph(Shutdown);
			instances.LogStartupInformation();

			Task.Run(new Action(TryStart));
		}

		private void TryStart()
		{
			var success = instances.RuntimeController.TryStart();

			if (!success)
			{
				Shutdown();
			}
		}

		public new void Shutdown()
		{
			Task.Run(new Action(ShutdownInternal));
		}

		private void ShutdownInternal()
		{
			instances.RuntimeController.Terminate();
			instances.LogShutdownInformation();

			Dispatcher.Invoke(base.Shutdown);
		}
		private static bool CheckRegistry(Microsoft.Win32.RegistryHive hive, string subKeyPath, string valueName)
		{
			try
			{
				using (var baseKey = Microsoft.Win32.RegistryKey.OpenBaseKey(hive, Microsoft.Win32.RegistryView.Registry64))
				{
					using (var subKey = baseKey.OpenSubKey(subKeyPath, false))
					{
						if (subKey == null)
							return false;

						var value = subKey.GetValue(valueName, null);
						subKey.Close();
						return value is int intValue && intValue == 1;
					}
				}
			}
			catch
			{
				return false;
			}
		}
	}
}
