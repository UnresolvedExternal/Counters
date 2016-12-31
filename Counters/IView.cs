using System;
using System.Collections.Generic;

namespace Counters
{
	internal enum OperationStatus
	{
		Required, Rejected
	}

	internal interface IView
	{
		event Action SaveRequested;
		event Action LoadRequested;
		event Action EditCounterRequested;
		event Action AddCounterRequested;
		event Action RemoveCounterRequested;
		void Log(string message);
		IEnumerable<KeyValuePair<string, ConstantRateCounter>> Counters { set; }
		KeyValuePair<string, ConstantRateCounter> EditCounter(out string oldName);
		KeyValuePair<string, ConstantRateCounter> AddCounter();
		string RemoveCounter();
		bool AllowEdit { set; }
	}
}
