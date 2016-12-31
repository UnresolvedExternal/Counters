using System;

namespace Counters
{
	[Serializable]
	public class CounterValue
	{
		public LeadingZeroNumber IntegerPart { get; set; }

		public LeadingZeroNumber FractionPart { get; set; }

		public CounterValue(int integerPartLength, int fractionPartLength)
		{
			IntegerPart = new LeadingZeroNumber(integerPartLength);
			FractionPart = new LeadingZeroNumber(fractionPartLength);
		}

		public CounterValue()
		{
			IntegerPart = new LeadingZeroNumber(1);
			FractionPart = new LeadingZeroNumber(1);
		}

		public static explicit operator decimal(CounterValue value)
		{
			return value.IntegerPart.Value +
				   (decimal)(value.FractionPart.Value / Math.Pow(10, value.FractionPart.Length));
		}

		public CounterValue SetValue(decimal value)
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException(nameof(value));
			IntegerPart.Value = (int)value;
			value -= IntegerPart.Value;
			value *= (decimal)Math.Pow(10, FractionPart.Length);
			value = Math.Round(value);
			try
			{
				FractionPart.Value = (int)value;
			}
			catch (ArgumentOutOfRangeException)
			{
				try
				{
					IntegerPart.Value = IntegerPart.Value + 1;
				}
				catch (ArgumentOutOfRangeException)
				{
					IntegerPart.Value = 0;
				}
				FractionPart.Value = 0;
			}
			return this;
		}

		public CounterValue AddValue(decimal value)
		{
			decimal maxFract = (int)Math.Pow(10, FractionPart.Length);
			decimal maxInt = (int)Math.Pow(10, IntegerPart.Length);
			decimal intPart = IntegerPart.Value + (int)value;
			decimal fractPart = FractionPart.Value + (int)(maxFract * (decimal) (value - (int)value));
			intPart += (int)(fractPart / maxFract);
			fractPart = fractPart - (int)(fractPart / maxFract) * maxFract;
			intPart = intPart - (int)(intPart / maxInt) * maxInt;
			return SetValue(intPart + fractPart / maxFract);
		}
	}
}
