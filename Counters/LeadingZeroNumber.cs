using System;

namespace Counters
{
	[Serializable]
	public class LeadingZeroNumber
	{
		public LeadingZeroNumber(int length)
		{
			Length = length;
		}

		private int _value;

		public int Value
		{
			get { return _value; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException(nameof(value));
				if (NumericsHelper.Length(value) > Length)
					throw new ArgumentOutOfRangeException(nameof(value));
				_value = value;
			}
		}

		public override string ToString()
		{
			return NumericsHelper.ToText(Value, Length);
		}

		public int Length { get; }
	}
}
