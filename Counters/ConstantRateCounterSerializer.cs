using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Counters
{
	internal static class ConstantRateCounterSerializer
	{
		private static readonly BinaryFormatter Formatter;

		static ConstantRateCounterSerializer()
		{
			Formatter = new BinaryFormatter {Context = new StreamingContext(StreamingContextStates.All)};
		}

		public static byte[] Serialize(ConstantRateCounter counter)
		{
			using (var memory = new MemoryStream())
			{
				Formatter.Serialize(memory, counter);
				return memory.GetBuffer();
			}
		}

		public static ConstantRateCounter Deserialize(byte[] buffer)
		{
			using (var memory = new MemoryStream(buffer))
			{
				return (ConstantRateCounter)Formatter.Deserialize(memory);
			}
		}
	}
}
