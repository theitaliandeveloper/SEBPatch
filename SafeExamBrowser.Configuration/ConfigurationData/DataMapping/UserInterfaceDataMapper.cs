/*
 * Copyright (c) 2025 ETH Zürich, IT Services
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using SafeExamBrowser.Settings;
using SafeExamBrowser.Settings.UserInterface;

namespace SafeExamBrowser.Configuration.ConfigurationData.DataMapping
{
	internal class UserInterfaceDataMapper : BaseDataMapper
	{
		internal override void Map(string key, object value, AppSettings settings)
		{
			switch (key)
			{
				case Keys.UserInterface.ActionCenter.EnableActionCenter:
					MapEnableActionCenter(settings, value);
					break;
				case Keys.UserInterface.LockScreen.BackgroundColor:
					MapLockScreenBackgroundColor(settings, value);
					break;
				case Keys.UserInterface.SystemControls.Audio.Show:
					MapShowAudio(settings, value);
					break;
				case Keys.UserInterface.SystemControls.Clock.Show:
					MapShowClock(settings, value);
					break;
				case Keys.UserInterface.SystemControls.KeyboardLayout.Show:
					MapShowKeyboardLayout(settings, value);
					break;
				case Keys.UserInterface.SystemControls.Network.Show:
					MapShowNetwork(settings, value);
					break;
				case Keys.UserInterface.SystemControls.PowerSupply.ChargeThresholdCritical:
					MapChargeThresholdCritical(settings, value);
					break;
				case Keys.UserInterface.SystemControls.PowerSupply.ChargeThresholdLow:
					MapChargeThresholdLow(settings, value);
					break;
				case Keys.UserInterface.Taskbar.EnableTaskbar:
					MapEnableTaskbar(settings, value);
					break;
				case Keys.UserInterface.Taskbar.ShowApplicationLog:
					MapShowApplicationLog(settings, value);
					break;
				case Keys.UserInterface.UserInterfaceMode:
					MapUserInterfaceMode(settings, value);
					break;
			}
		}

		private void MapEnableActionCenter(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.UserInterface.ActionCenter.EnableActionCenter = enable;
			//}
			settings.UserInterface.ActionCenter.EnableActionCenter = false;
		}

		private void MapLockScreenBackgroundColor(AppSettings settings, object value)
		{
			if (value is string color)
			{
				settings.UserInterface.LockScreen.BackgroundColor = color;
			}
		}

		private void MapShowAudio(AppSettings settings, object value)
		{
			//if (value is bool show)
			//{
			//	settings.UserInterface.ActionCenter.ShowAudio = show;
			//	settings.UserInterface.Taskbar.ShowAudio = show;
			//}
			settings.UserInterface.ActionCenter.ShowAudio = false;
			settings.UserInterface.Taskbar.ShowAudio = false;
		}

		private void MapShowClock(AppSettings settings, object value)
		{
			//if (value is bool show)
			//{
			//	settings.UserInterface.ActionCenter.ShowClock = show;
			//	settings.UserInterface.Taskbar.ShowClock = show;
			//}
			settings.UserInterface.ActionCenter.ShowClock = false;
			settings.UserInterface.Taskbar.ShowClock = false;
		}

		private void MapShowKeyboardLayout(AppSettings settings, object value)
		{
			//if (value is bool show)
			//{
			//	settings.UserInterface.ActionCenter.ShowKeyboardLayout = show;
			//	settings.UserInterface.Taskbar.ShowKeyboardLayout = show;
			//}
			settings.UserInterface.ActionCenter.ShowKeyboardLayout = false;
			settings.UserInterface.Taskbar.ShowKeyboardLayout = false;
		}

		private void MapShowNetwork(AppSettings settings, object value)
		{
			//if (value is bool show)
			//{
			//	settings.UserInterface.ActionCenter.ShowNetwork = show;
			//	settings.UserInterface.Taskbar.ShowNetwork = show;
			//}
			settings.UserInterface.ActionCenter.ShowNetwork = false;
			settings.UserInterface.Taskbar.ShowNetwork = false;
		}

		private void MapChargeThresholdCritical(AppSettings settings, object value)
		{
			if (value is double threshold)
			{
				settings.PowerSupply.ChargeThresholdCritical = threshold;
			}
		}

		private void MapChargeThresholdLow(AppSettings settings, object value)
		{
			if (value is double threshold)
			{
				settings.PowerSupply.ChargeThresholdLow = threshold;
			}
		}

		private void MapEnableTaskbar(AppSettings settings, object value)
		{
			//if (value is bool enable)
			//{
			//	settings.UserInterface.Taskbar.EnableTaskbar = enable;
			//}
			settings.UserInterface.Taskbar.EnableTaskbar = false;
		}

		private void MapShowApplicationLog(AppSettings settings, object value)
		{
			//if (value is bool show)
			//{
			//	settings.UserInterface.Taskbar.ShowApplicationLog = show;
			//}
			settings.UserInterface.Taskbar.ShowApplicationLog = false;
		}

		private void MapUserInterfaceMode(AppSettings settings, object value)
		{
			if (value is bool mobile)
			{
				settings.UserInterface.Mode = mobile ? UserInterfaceMode.Mobile : UserInterfaceMode.Desktop;
			}
		}
	}
}
