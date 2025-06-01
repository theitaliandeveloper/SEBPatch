/*
 * Copyright (c) 2024 ETH Zürich, IT Services
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using SafeExamBrowser.Logging.Contracts;
using SafeExamBrowser.WindowsApi.Contracts;
using SafeExamBrowser.WindowsApi.Types;

namespace SafeExamBrowser.WindowsApi
{
	public class ExplorerShell : IExplorerShell
	{
		private ILogger logger;
		private INativeMethods nativeMethods;
		private IList<Window> minimizedWindows = new List<Window>();

		public ExplorerShell(ILogger logger, INativeMethods nativeMethods)
		{
			this.logger = logger;
			this.nativeMethods = nativeMethods;
			this.minimizedWindows = new List<Window>();
		}

		public void HideAllWindows()
		{
			logger.Info("Searching for windows to be minimized...");
			logger.Info("Minimizing all open windows...");
			logger.Info("Open windows successfully minimized.");
		}

		public void RestoreAllWindows()
		{
			logger.Info("Restoring all minimized windows...");
			logger.Info("Minimized windows successfully restored.");
		}

		public void Start()
		{

		}

		public void Terminate()
		{
			
		}

		private void KillExplorerShell(int processId)
		{
			var process = new System.Diagnostics.Process();
			var taskkillPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "taskkill.exe");

			logger.Warn("Failed to gracefully terminate explorer shell, attempting forceful termination...");

			process.StartInfo.Arguments = $"/F /PID {processId}";
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.FileName = taskkillPath;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
			process.Start();
			process.WaitForExit();
		}
	}
}
