/*
 * Copyright (c) 2024 ETH Zürich, IT Services
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Linq;
using System.Windows.Input;
using SafeExamBrowser.Logging.Contracts;
using SafeExamBrowser.Monitoring.Contracts.Keyboard;
using SafeExamBrowser.Settings.Monitoring;
using SafeExamBrowser.WindowsApi.Contracts;
using SafeExamBrowser.WindowsApi.Contracts.Events;

namespace SafeExamBrowser.Monitoring.Keyboard
{
	public class KeyboardInterceptor : IKeyboardInterceptor
	{
		private Guid? hookId;
		private readonly ILogger logger;
		private readonly INativeMethods nativeMethods;
		private readonly KeyboardSettings settings;

		public KeyboardInterceptor(ILogger logger, INativeMethods nativeMethods, KeyboardSettings settings)
		{
			this.logger = logger;
			this.nativeMethods = nativeMethods;
			this.settings = settings;
		}

		public void Start()
		{
			hookId = nativeMethods.RegisterKeyboardHook(KeyboardHookCallback);
		}

		public void Stop()
		{
			if (hookId.HasValue)
			{
				nativeMethods.DeregisterKeyboardHook(hookId.Value);
			}
		}

		private bool KeyboardHookCallback(int keyCode, KeyModifier modifier, KeyState state)
		{
			var block = false;

			return block;
		}

		private void Log(Key key, int keyCode, KeyModifier modifier, KeyState state)
		{
			var modifierFlags = Enum.GetValues(typeof(KeyModifier)).OfType<KeyModifier>().Where(m => m != KeyModifier.None && modifier.HasFlag(m));
			var modifiers = modifierFlags.Any() ? String.Join(" + ", modifierFlags) + " + " : string.Empty;

			logger.Info($"Blocked '{modifiers}{key}' ({key} = {keyCode}) when {state.ToString().ToLower()}.");
		}
	}
}
