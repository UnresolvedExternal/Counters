using System;

namespace Counters
{
	[Serializable]
	public class ConstantRateCounter
	{
		private DateTime _lastFixingTime;

		private CounterValue _fixedCounterValue;

		public CounterValue FixedCounterValue
		{
			get { return _fixedCounterValue; }
			set { _fixedCounterValue = value ?? new CounterValue(1, 1); }
		}

		public CounterValue ExpectedCounterValue
		{
			get
			{
				var prev = (decimal) FixedCounterValue;
				var offset = GainPerMounth*(decimal) (DateTime.Now - _lastFixingTime).TotalDays/30;
				var result = new CounterValue(FixedCounterValue.IntegerPart.Length,
					FixedCounterValue.FractionPart.Length);
				result.SetValue(prev);
				return result.AddValue((decimal)offset);
			}
		}

		public decimal GainPerMounth { get; set; }

		public DateTime FixingDate { get { return _lastFixingTime; } set { _lastFixingTime = value; } }

		public ConstantRateCounter(CounterValue fixedCounterValue, decimal gainPerMonth)
		{
			FixedCounterValue = fixedCounterValue;
			GainPerMounth = gainPerMonth;
			_lastFixingTime = DateTime.Now;
		}
	}
}
