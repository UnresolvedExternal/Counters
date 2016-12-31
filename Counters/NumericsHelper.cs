using System;

namespace Counters
{
	public static class NumericsHelper
	{
		public static int Length(int value)
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(value));
			}
			return value.ToString().Length;
		}

		public static string ToText(int value, int length)
		{
			if (Length(value) > length)
			{
				throw new ArgumentOutOfRangeException(nameof(value) + " " + nameof(length));
			}
			return string.Format(@"{0:D" + length + @"}", value);
		}
	}
}
