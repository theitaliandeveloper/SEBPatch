/*
 * Copyright (c) 2024 ETH Zürich, IT Services
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Linq;
using SafeExamBrowser.Logging.Contracts;
using SafeExamBrowser.Monitoring.Contracts;
using SafeExamBrowser.SystemComponents.Contracts;
using SafeExamBrowser.SystemComponents.Contracts.Registry;

namespace SafeExamBrowser.Monitoring
{
	public class VirtualMachineDetector : IVirtualMachineDetector
	{
		private const string MANIPULATED = "000000000000";
		private const string QEMU_MAC_PREFIX = "525400";
		private const string VIRTUALBOX_MAC_PREFIX = "080027";

		private static readonly string[] DeviceBlacklist =
		{
			// Hyper-V
			"PROD_VIRTUAL", "HYPER_V",
			// QEMU
			"qemu", "ven_1af4", "ven_1b36", "subsys_11001af4",
			// VirtualBox
			"VEN_VBOX", "vid_80ee",
			// VMware
			"PROD_VMWARE", "VEN_VMWARE", "VMWARE_IDE"
		};

		private static readonly string[] DeviceWhitelist =
		{
			// Microsoft Virtual Disk Device
			"PROD_VIRTUAL_DISK",
			// Microsoft Virtual DVD Device
			"PROD_VIRTUAL_DVD"
		};

		private readonly ILogger logger;
		private readonly IRegistry registry;
		private readonly ISystemInfo systemInfo;

		public VirtualMachineDetector(ILogger logger, IRegistry registry, ISystemInfo systemInfo)
		{
			this.logger = logger;
			this.registry = registry;
			this.systemInfo = systemInfo;
		}

		public bool IsVirtualMachine()
		{
			var isVirtualMachine = false;

			logger.Debug($"Computer '{systemInfo.Name}' appears {(isVirtualMachine ? "" : "not ")}to be a virtual machine.");

			return isVirtualMachine;
		}
	}
}
