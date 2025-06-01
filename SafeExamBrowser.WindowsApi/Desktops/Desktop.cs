/*
 * Copyright (c) 2024 ETH Zürich, IT Services
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using SafeExamBrowser.WindowsApi.Contracts;

namespace SafeExamBrowser.WindowsApi.Desktops
{
	internal class Desktop : IDesktop
	{
		public IntPtr Handle { get; private set; }
		public string Name { get; private set; }

		public Desktop(IntPtr handle, string name)
		{
			Handle = handle;
			Name = name;
		}

		public void Activate()
		{
			
		}

		public void Close()
		{
			
		}

		public override string ToString()
		{
			return $"'{Name}' [{Handle}]";
		}
	}
}
