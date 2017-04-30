﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Base.Layout;

namespace Wordclock.Shared.SharedInterfaces
{
	[ServiceContract]
	public interface IWordclockService
	{
		[OperationContract]
		bool IsConnectionEstablished();

		[OperationContract]
		SettingsData Data();

		[OperationContract]
		void SetPowerState(PowerState state);

		[OperationContract]
		void SetShowPrefix(bool value);

		[OperationContract]
		void SetClockColor(ColorSurrogate color);

		[OperationContract]
		ClockSettings GetWordclockSettings();
	}
}
