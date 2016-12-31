using System;
using System.Drawing;

namespace Counters
{
	internal class DrawingParameters
	{
		private CounterCountView _view;

		public Font Font { get; private set; }

		public CounterCountView View
		{
			get { return _view; }
			set
			{
				if (value == null)
					throw new ArgumentNullException(nameof(value));
				_view = value;
				Update();
			}
		}

		private RectangleF[] _integerPartDigitRegions;
		private RectangleF[] _fractionPartDigitRegions;

		private float CellWidth { get; set; }

		private float CellHeight { get; set; }

		private RectangleF[] CreateDigitRegions(ref RectangleF startRegion, int count)
		{
			var regions = new RectangleF[count];
			for (var i = 0; i < count; ++i)
			{
				regions[i] = startRegion;
				startRegion.X += CellWidth;
			}
			return regions;
		}

		public void Update()
		{
			Font = new Font(FontFamily.GenericSansSerif, View.Height - 3*Airspace, FontStyle.Bold, GraphicsUnit.Pixel);
			CellWidth = (View.Width-Airspace) / 
				(float)(_view.Value.IntegerPart.Length + _view.Value.FractionPart.Length);
			CellHeight = View.Height - 2*Airspace;
			var startRegion = new RectangleF(0 + Airspace, 0 + Airspace, CellWidth - Airspace, CellHeight);
			_integerPartDigitRegions = CreateDigitRegions(ref startRegion, _view.Value.IntegerPart.Length);
			_fractionPartDigitRegions = CreateDigitRegions(ref startRegion, _view.Value.FractionPart.Length);
		}

		public DrawingParameters(CounterCountView view)
		{
			Airspace = 2;
			View = view;
			Update();
		}

		public int Airspace { get; }

		public RectangleF[] IntegerPartDigitRegions => _integerPartDigitRegions;

		public RectangleF[] FractionPartDigitRegions => _fractionPartDigitRegions;
	}
}
