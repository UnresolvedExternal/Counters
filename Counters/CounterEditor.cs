using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Counters
{
	public sealed partial class CounterEditor : Form
	{
		public string CounterName { get; private set; }

		public ConstantRateCounter Counter { get; private set; }

		public CounterEditor(KeyValuePair<string, ConstantRateCounter> initial)
		{
			InitializeComponent();

			_dtpDate.CustomFormat = @"HH:mm:ss dd MMMM yyyy г.";

			MinimumSize = MaximumSize = Size;
			MaximizeBox = false;
			_tbName.Text = initial.Key ?? "Введите название";

			Counter = initial.Value ?? new ConstantRateCounter(new CounterValue(1,1).SetValue(0), 0);

			_dtpDate.Value = Counter.FixingDate;

			_nudFracCapacity.ValueChanged += (s, a) => CapacityChanged();
			_nudIntCapacity.ValueChanged += (s, a) => CapacityChanged();

			_nudIntCapacity.Value = Counter.FixedCounterValue.IntegerPart.Length;
			_nudFracCapacity.Value = Counter.FixedCounterValue.FractionPart.Length;

			_nudIntValue.Value = Counter.FixedCounterValue.IntegerPart.Value;
			_nudFracValue.Value = Counter.FixedCounterValue.FractionPart.Value;
			_nudIntPerMonth.Value = (int) Counter.GainPerMounth;
			_nudFracPerMonth.Value = (int) ((Counter.GainPerMounth - (int)Counter.GainPerMounth)*
			                                (decimal) Math.Pow(10, Counter.FixedCounterValue.FractionPart.Length));

			_btnOk.Click += OkClicked;
			_btnCancel.Click += CancelClicked;
			_chbUseCurrentDate.CheckedChanged += _chbUseCurrentDate_CheckedChanged;
		}

		private void _chbUseCurrentDate_CheckedChanged(object sender, EventArgs e)
		{
			_dtpDate.Enabled = !_chbUseCurrentDate.Checked;
			_dtpDate.Value = DateTime.Now;
		}

		private void OkClicked(object sender, EventArgs e)
		{
			CounterName = _tbName.Text;
			var counterValue = new CounterValue((int) _nudIntCapacity.Value, (int) _nudFracCapacity.Value)
			{
				IntegerPart = {Value = (int) _nudIntValue.Value},
				FractionPart = {Value = (int) _nudFracValue.Value}
			};
			var perMonthGain = (decimal) (_nudIntPerMonth.Value + 
				_nudFracPerMonth.Value/(decimal)Math.Pow(10, (double)_nudFracCapacity.Value));
			Counter = new ConstantRateCounter(counterValue, perMonthGain)
			{
				FixingDate = _chbUseCurrentDate.Checked ? DateTime.Now : _dtpDate.Value
			};
			Close();
		}

		private void CancelClicked(object sender, EventArgs e)
		{
			CounterName = null;
			Counter = null;
			Close();
		}

		private void CapacityChanged()
		{
			_nudIntValue.Maximum = (decimal)Math.Pow(10, (double)_nudIntCapacity.Value) - 1;
			_nudFracValue.Maximum = (decimal) Math.Pow(10, (double) _nudFracCapacity.Value) - 1;
			_nudFracPerMonth.Maximum = (decimal) Math.Pow(10, (double) _nudFracCapacity.Value) - 1;
		}
	}
}
