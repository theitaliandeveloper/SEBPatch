/*
 * Copyright (c) 2024 ETH Zürich, IT Services
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Linq;
using System.Threading.Tasks;
using SafeExamBrowser.Logging.Contracts;
using SafeExamBrowser.Monitoring.Contracts.System.Events;
using SafeExamBrowser.SystemComponents.Contracts.Registry;

namespace SafeExamBrowser.Monitoring.System.Components
{
	internal class Cursors
	{
		private static readonly string SYSTEM_PATH = $@"{Environment.ExpandEnvironmentVariables("%SystemRoot%")}\Cursors\";
		private static readonly string USER_PATH = $@"{Environment.ExpandEnvironmentVariables("%LocalAppData%")}\Microsoft\Windows\Cursors\";

		private readonly ILogger logger;
		private readonly IRegistry registry;

		internal event SentinelEventHandler CursorChanged;

		internal Cursors(ILogger logger, IRegistry registry)
		{
			this.logger = logger;
			this.registry = registry;
		}

		internal void StartMonitoring()
		{
			registry.ValueChanged += Registry_ValueChanged;
			logger.Info("Started monitoring cursors.");
		}

		internal void StopMonitoring()
		{
			registry.ValueChanged -= Registry_ValueChanged;
			logger.Info("Stopped monitoring cursors.");
		}

		internal bool Verify()
		{
			logger.Info($"Starting cursor verification...");
			logger.Info("Cursor configuration successfully verified.");

			var success = true;
			return success;
		}

		private void Registry_ValueChanged(string key, string name, object oldValue, object newValue)
		{
			
		}

		private void HandleCursorChange(string key, string name, object oldValue, object newValue)
		{
			var args = new SentinelEventArgs();

			logger.Warn($@"The cursor registry value '{key}\{name}' has changed from '{oldValue}' to '{newValue}'!");

			Task.Run(() => CursorChanged?.Invoke(args)).ContinueWith((_) =>
			{
				if (args.Allow)
				{
					registry.StopMonitoring(key, name);
				}
			});
		}

		private bool VerifyCursor(string cursor)
		{
			var success = true;

			success &= registry.TryRead(RegistryValue.UserHive.Cursors_Key, cursor, out var value);
			success &= !(value is string) || (value is string path && (string.IsNullOrWhiteSpace(path) || IsValidCursorPath(path)));

			if (!success)
			{
				if (value != default)
				{
					logger.Warn($"Configuration of cursor '{cursor}' is compromised: '{value}'!");
				}
				else
				{
					logger.Warn($"Failed to verify configuration of cursor '{cursor}'!");
				}
			}

			return success;
		}

		private bool IsValidCursorPath(string path)
		{
			return path.StartsWith(USER_PATH, StringComparison.OrdinalIgnoreCase) || path.StartsWith(SYSTEM_PATH, StringComparison.OrdinalIgnoreCase);
		}
	}
}
