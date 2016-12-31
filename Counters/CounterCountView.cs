using System.Drawing;
using System.Windows.Forms;

namespace Counters
{
	public sealed partial class CounterCountView : UserControl
	{
		internal static readonly int MaxHeight = 30;
		internal static readonly int CellWidth = 20;

		public static Color FractionColor { get; set; }

		private CounterValue _value;

		public CounterValue Value
		{
			get { return _value; }
			set
			{
				_value = value ?? new CounterValue();
				Size = MinimumSize = MaximumSize = new Size(GetWidth(_value), MaxHeight);
				Parameters?.Update();
				Invalidate();
			}
		}

		private DrawingParameters Parameters { get; }

		public CounterCountView()
		{
			Value = new CounterValue(1, 1);
			ForeColor = Color.White;
			BackColor = Color.Black;
			FractionColor = Color.Red;
			Parameters = new DrawingParameters(this);
			DoubleBuffered = true;
		}

		private static int GetWidth(CounterValue value)
		{
			return CellWidth*(value.IntegerPart.Length + value.FractionPart.Length);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			var g = e.Graphics;
			g.FillRectangle(new SolidBrush(BackColor), ClientRectangle);
			var backColor = BackColor;
			var text = Value.IntegerPart.ToString();
			var regions = Parameters.IntegerPartDigitRegions;
			for (int i = 0; i < text.Length; i++)
			{
				DrawDigit(ForeColor, backColor, regions[i], g, text[i]);
			}
			backColor = FractionColor;
			text = Value.FractionPart.ToString();
			regions = Parameters.FractionPartDigitRegions;
			for (int i = 0; i < text.Length; i++)
			{
				DrawDigit(ForeColor, backColor, regions[i], g, text[i]);
			}
		}

		private void DrawDigit(Color foreColor, Color backColor, RectangleF region, Graphics g, char value)
		{
			g.FillRectangle(new SolidBrush(backColor), region);
			region.Offset(0, 1);
			g.DrawString(value.ToString(), Parameters.Font, new SolidBrush(foreColor), region, 
				new StringFormat
				{
					Alignment = StringAlignment.Center,
					LineAlignment = StringAlignment.Center
				});
		}
	}
}