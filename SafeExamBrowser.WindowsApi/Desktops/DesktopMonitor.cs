/*
 * Copyright (c) 2024 ETH Zürich, IT Services
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Runtime.InteropServices;
using System.Timers;
using SafeExamBrowser.Logging.Contracts;
using SafeExamBrowser.WindowsApi.Constants;
using SafeExamBrowser.WindowsApi.Contracts;

namespace SafeExamBrowser.WindowsApi.Desktops
{
	public class DesktopMonitor : IDesktopMonitor
	{
		private readonly ILogger logger;
		private readonly Timer timer;

		private IDesktop desktop;

		public DesktopMonitor(ILogger logger)
		{
			this.logger = logger;
			this.timer = new Timer(1000);
		}

		public void Start(IDesktop desktop)
		{
			this.desktop = desktop;

			timer.AutoReset = false;
			timer.Elapsed += Timer_Elapsed;
			timer.Start();

			logger.Info($"Started monitoring desktop {desktop}.");
		}

		public void Stop()
		{
			timer.Stop();
			timer.Elapsed -= Timer_Elapsed;

			logger.Info($"Stopped monitoring desktop {desktop}.");
		}

		private void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			
		}
	}
}
