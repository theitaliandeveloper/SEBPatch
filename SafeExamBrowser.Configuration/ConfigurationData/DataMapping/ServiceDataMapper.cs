/*
 * Copyright (c) 2025 ETH Zürich, IT Services
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using SafeExamBrowser.Settings;
using SafeExamBrowser.Settings.Service;

namespace SafeExamBrowser.Configuration.ConfigurationData.DataMapping
{
	internal class ServiceDataMapper : BaseDataMapper
	{
		internal override void Map(string key, object value, AppSettings settings)
		{
			switch (key)
			{
				case Keys.Service.EnableChromeNotifications:
					MapEnableChromeNotifications(settings, value);
					break;
				case Keys.Service.EnableEaseOfAccessOptions:
					MapEnableEaseOfAccessOptions(settings, value);
					break;
				case Keys.Service.EnableFindPrinter:
					MapEnableFindPrinter(settings, value);
					break;
				case Keys.Service.EnableNetworkOptions:
					MapEnableNetworkOptions(settings, value);
					break;
				case Keys.Service.EnablePasswordChange:
					MapEnablePasswordChange(settings, value);
					break;
				case Keys.Service.EnablePowerOptions:
					MapEnablePowerOptions(settings, value);
					break;
				case Keys.Service.EnableRemoteConnections:
					MapEnableRemoteConnections(settings, value);
					break;
				case Keys.Service.EnableSignout:
					MapEnableSignout(settings, value);
					break;
				case Keys.Service.EnableTaskManager:
					MapEnableTaskManager(settings, value);
					break;
				case Keys.Service.EnableUserLock:
					MapEnableUserLock(settings, value);
					break;
				case Keys.Service.EnableUserSwitch:
					MapEnableUserSwitch(settings, value);
					break;
				case Keys.Service.EnableVmwareOverlay:
					MapEnableVmwareOverlay(settings, value);
					break;
				case Keys.Service.EnableWindowsUpdate:
					MapEnableWindowsUpdate(settings, value);
					break;
				case Keys.Service.IgnoreService:
					MapIgnoreService(settings, value);
					break;
				case Keys.Service.Policy:
					MapPolicy(settings, value);
					break;
				case Keys.Service.SetVmwareConfiguration:
					MapSetVmwareConfiguration(settings, value);
					break;
			}
		}

		private void MapEnableChromeNotifications(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisableChromeNotifications = !enable;
			//}
			settings.Service.DisableChromeNotifications = false;
		}

		private void MapEnableEaseOfAccessOptions(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisableEaseOfAccessOptions = !enable;
			//}
			settings.Service.DisableEaseOfAccessOptions = false;
		}

		private void MapEnableFindPrinter(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisableFindPrinter = !enable;
			//}
			settings.Service.DisableFindPrinter = false;
		}

		private void MapEnableNetworkOptions(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisableNetworkOptions = !enable;
			//}
			settings.Service.DisableNetworkOptions = false;
		}

		private void MapEnablePasswordChange(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisablePasswordChange = !enable;
			//}
			settings.Service.DisablePasswordChange = false;
		}

		private void MapEnablePowerOptions(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisablePowerOptions = !enable;
			//}
			settings.Service.DisablePowerOptions = false;
		}

		private void MapEnableRemoteConnections(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisableRemoteConnections = !enable;
			//}
			settings.Service.DisableRemoteConnections = false;
		}

		private void MapEnableSignout(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisableSignout = !enable;
			//}
			settings.Service.DisableSignout = false;
		}

		private void MapEnableTaskManager(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisableTaskManager = !enable;
			//}
			settings.Service.DisableTaskManager = false;
		}

		private void MapEnableUserLock(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisableUserLock = !enable;
			//}
			settings.Service.DisableUserLock = false;
		}

		private void MapEnableUserSwitch(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisableUserSwitch = !enable;
			//}
			settings.Service.DisableUserSwitch = false;
		}

		private void MapEnableVmwareOverlay(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisableVmwareOverlay = !enable;
			//}
			settings.Service.DisableVmwareOverlay = false;
		}

		private void MapEnableWindowsUpdate(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.Service.DisableWindowsUpdate = !enable;
			//}
			settings.Service.DisableWindowsUpdate = false;
		}

		private void MapIgnoreService(AppSettings settings, object value)
		{
			//if (value is bool ignore)
			//{
			//	settings.Service.IgnoreService = ignore;
			//}
			settings.Service.IgnoreService = true;
		}

		private void MapPolicy(AppSettings settings, object value)
		{
			const int WARN = 1;
			const int FORCE = 2;

			if (value is int policy)
			{
				settings.Service.Policy = policy == FORCE ? ServicePolicy.Mandatory : (policy == WARN ? ServicePolicy.Warn : ServicePolicy.Optional);
			}
		}

		private void MapSetVmwareConfiguration(AppSettings settings, object value)
		{
			//if (value is bool set)
			//{
			//	settings.Service.SetVmwareConfiguration = set;
			//}
			settings.Service.SetVmwareConfiguration = false;
		}
	}
}
