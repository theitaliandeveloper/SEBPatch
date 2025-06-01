/*
 * Copyright (c) 2024 ETH Zürich, IT Services
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using SafeExamBrowser.Settings;

namespace SafeExamBrowser.Configuration.ConfigurationData.DataMapping
{
	internal class InputDataMapper : BaseDataMapper
	{
		internal override void Map(string key, object value, AppSettings settings)
		{
			switch (key)
			{
				case Keys.Keyboard.EnableAltEsc:
					MapEnableAltEsc(settings, value);
					break;
				case Keys.Keyboard.EnableAltF4:
					MapEnableAltF4(settings, value);
					break;
				case Keys.Keyboard.EnableAltTab:
					MapEnableAltTab(settings, value);
					break;
				case Keys.Keyboard.EnableCtrlEsc:
					MapEnableCtrlEsc(settings, value);
					break;
				case Keys.Keyboard.EnableEsc:
					MapEnableEsc(settings, value);
					break;
				case Keys.Keyboard.EnableF1:
					MapEnableF1(settings, value);
					break;
				case Keys.Keyboard.EnableF2:
					MapEnableF2(settings, value);
					break;
				case Keys.Keyboard.EnableF3:
					MapEnableF3(settings, value);
					break;
				case Keys.Keyboard.EnableF4:
					MapEnableF4(settings, value);
					break;
				case Keys.Keyboard.EnableF5:
					MapEnableF5(settings, value);
					break;
				case Keys.Keyboard.EnableF6:
					MapEnableF6(settings, value);
					break;
				case Keys.Keyboard.EnableF7:
					MapEnableF7(settings, value);
					break;
				case Keys.Keyboard.EnableF8:
					MapEnableF8(settings, value);
					break;
				case Keys.Keyboard.EnableF9:
					MapEnableF9(settings, value);
					break;
				case Keys.Keyboard.EnableF10:
					MapEnableF10(settings, value);
					break;
				case Keys.Keyboard.EnableF11:
					MapEnableF11(settings, value);
					break;
				case Keys.Keyboard.EnableF12:
					MapEnableF12(settings, value);
					break;
				case Keys.Keyboard.EnablePrintScreen:
					MapEnablePrintScreen(settings, value);
					break;
				case Keys.Keyboard.EnableSystemKey:
					MapEnableSystemKey(settings, value);
					break;
				case Keys.Mouse.EnableMiddleMouseButton:
					MapEnableMiddleMouseButton(settings, value);
					break;
				case Keys.Mouse.EnableRightMouseButton:
					MapEnableRightMouseButton(settings, value);
					break;
			}
		}

		private void MapEnableAltEsc(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowAltEsc = enabled;
			}
			*/
			settings.Keyboard.AllowAltEsc = true;
		}

		private void MapEnableAltF4(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowAltF4 = enabled;
			}
			*/
			settings.Keyboard.AllowAltF4 = true;
		}

		private void MapEnableAltTab(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowAltTab = enabled;
			}
			*/
			settings.Keyboard.AllowAltTab = true;
		}

		private void MapEnableCtrlEsc(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowCtrlEsc = enabled;
			}
			*/
			settings.Keyboard.AllowCtrlEsc = true;
		}

		private void MapEnableEsc(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowEsc = enabled;
			}
			*/
			settings.Keyboard.AllowEsc = true;
		}

		private void MapEnableF1(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF1 = enabled;
			}
			*/
			settings.Keyboard.AllowF1 = true;
		}

		private void MapEnableF2(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF2 = enabled;
			}
			*/
			settings.Keyboard.AllowF2 = true;
		}

		private void MapEnableF3(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF3 = enabled;
			}
			*/
			settings.Keyboard.AllowF3 = true;
		}

		private void MapEnableF4(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF4 = enabled;
			}
			*/
			settings.Keyboard.AllowF4 = true;
		}

		private void MapEnableF5(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF5 = enabled;
			}
			*/
			settings.Keyboard.AllowF5 = true;
		}

		private void MapEnableF6(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF6 = enabled;
			}
			*/
			settings.Keyboard.AllowF6 = true;
		}

		private void MapEnableF7(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF7 = enabled;
			}
			*/
			settings.Keyboard.AllowF7 = true;
		}

		private void MapEnableF8(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF8 = enabled;
			}
			*/
			settings.Keyboard.AllowF8 = true;
		}

		private void MapEnableF9(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF9 = enabled;
			}
			*/
			settings.Keyboard.AllowF9 = true;
		}

		private void MapEnableF10(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF10 = enabled;
			}
			*/
			settings.Keyboard.AllowF10 = true;
		}

		private void MapEnableF11(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF11 = enabled;
			}
			*/
			settings.Keyboard.AllowF11 = true;
		}

		private void MapEnableF12(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowF12 = enabled;
			}
			*/
			settings.Keyboard.AllowF12 = true;
		}

		private void MapEnablePrintScreen(AppSettings settings, object value)
		{
			settings.Keyboard.AllowPrintScreen = true;
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowPrintScreen = enabled;
			}
			*/
		}

		private void MapEnableSystemKey(AppSettings settings, object value)
		{
			/*
			if (value is bool enabled)
			{
				settings.Keyboard.AllowSystemKey = enabled;
			}
			*/
			settings.Keyboard.AllowSystemKey = true;
		}

		private void MapEnableMiddleMouseButton(AppSettings settings, object value)
		{
			settings.Mouse.AllowMiddleButton = true;
			/*
			if (value is bool enabled)
			{
				settings.Mouse.AllowMiddleButton = enabled;
			}
			*/
		}

		private void MapEnableRightMouseButton(AppSettings settings, object value)
		{
			settings.Mouse.AllowRightButton = true;
			/*
			if (value is bool enabled)
			{
				settings.Mouse.AllowRightButton = enabled;
			}
			*/
		}
	}
}
