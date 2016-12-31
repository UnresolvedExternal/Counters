using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Counters.Properties;

namespace Counters
{
	public sealed partial class MainForm : Form, IView
	{
		private ControlAutoUpdater _updater;

		public MainForm()
		{
			InitializeComponent();
			_gpView.BackColor = Color.Transparent;
			_gpControl.BackColor = Color.Transparent;
			foreach (Button control in _gpControl.Controls)
			{
				control.ForeColor = Color.DarkGreen;
			}
			MinimumSize = Size;
			FormBorderStyle = FormBorderStyle.FixedSingle;
			//BackgroundImage = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Hydrangeas.jpg");

			_lbCounters.SelectedIndexChanged += _lbCounters_SelectedIndexChanged;
			_lbCounters.SelectedIndex = -1;
			_btnEdit.Click += _btnEdit_Click;
			_btnRemove.Click += _btnRemove_Click;
			_btnAdd.Click += _btnAdd_Click;
			Load += MainForm_Load;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			LoadRequested?.Invoke();
		}

		private void _btnAdd_Click(object sender, EventArgs e)
		{
			AddCounterRequested?.Invoke();
		}

		private void _btnRemove_Click(object sender, EventArgs e)
		{
			NoCounterSelected();
			RemoveCounterRequested?.Invoke();
		}

		private void _btnEdit_Click(object sender, EventArgs e)
		{
			EditCounterRequested?.Invoke();
		}

		private void _lbCounters_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_lbCounters.SelectedIndex == -1)
			{
				NoCounterSelected();
			}
			else
			{
				NoCounterSelected();
				_btnEdit.Enabled = AllowEdit;
				_btnRemove.Enabled = AllowEdit;
				var counter = _counters.First(pair => pair.Key == (string)_lbCounters.SelectedItem).Value;
				var uiCounter = new CounterCountView
				{
					Location = new Point(20, 20),
					Value = counter.ExpectedCounterValue
				};
				_updater?.Dispose();
				_updater = new ControlAutoUpdater(
					() =>
					{
						uiCounter.Value = counter.ExpectedCounterValue;
					},
					() => true,
					1);
				_gpView.Controls.Add(uiCounter);
			}
		}

		private bool _allowEdit;

		public bool AllowEdit
		{
			private get { return _allowEdit; }
			set
			{
				_allowEdit = value;
				_btnLoad.Enabled = value;
				_btnSave.Enabled = value;
				_btnAdd.Enabled = value;
				if (value == false)
				{
					_btnEdit.Enabled = false;
					_btnAdd.Enabled = false;
					_btnRemove.Enabled = false;
				}
				else
				{
					var enabled = _lbCounters.SelectedIndex != -1;
					_btnEdit.Enabled = enabled;
					_btnRemove.Enabled = enabled;
				}
			}
		}

		private Dictionary<string, ConstantRateCounter> _counters;

		public IEnumerable<KeyValuePair<string, ConstantRateCounter>> Counters
		{
			set
			{
				_counters = value?.ToDictionary(pair => pair.Key, pair => pair.Value) ?? new Dictionary<string, ConstantRateCounter>();
				_lbCounters.Items.Clear();
				foreach (var pair in _counters)
					_lbCounters.Items.Add(pair.Key);
			}
		}

		public event Action AddCounterRequested;
		public event Action EditCounterRequested;
		public event Action LoadRequested;
		public event Action RemoveCounterRequested;
		public event Action SaveRequested;

		public KeyValuePair<string, ConstantRateCounter> AddCounter()
		{
			var editor = new CounterEditor(new KeyValuePair<string, ConstantRateCounter>(null, null))
			{
				Text = Resources.MainForm_EditCounter_Добавление_счётчика_
			};
			ShowDialogSmartly(editor);
			return new KeyValuePair<string, ConstantRateCounter>(editor.CounterName, editor.Counter);
		}

		public KeyValuePair<string, ConstantRateCounter> EditCounter(out string oldName)
		{
			var name = (string)_lbCounters.SelectedItem;
			oldName = name;
			var counter = _counters.First(c => c.Key == name);
			var pair = new KeyValuePair<string, ConstantRateCounter>(name, counter.Value);
			var editor = new CounterEditor(pair) { Text = Resources.MainForm_EditCounter_Добавление_счётчика_ };
			ShowDialogSmartly(editor);
			return editor.CounterName == null ? pair : new KeyValuePair<string, ConstantRateCounter>(editor.CounterName, editor.Counter);
		}

		private void ShowDialogSmartly(Form form)
		{
			form.ShowDialog();
			NoCounterSelected();
		}

		private void NoCounterSelected()
		{
			_btnEdit.Enabled = false;
			_btnRemove.Enabled = false;
			_updater?.Dispose();
			_updater = null;
			_gpView.Controls.Clear();
		}

		public void Log(string message)
		{
			MessageBox.Show(message);
		}

		public string RemoveCounter()
		{
			var result = MessageBox.Show(Resources.MainForm_RemoveCounter_Вы_действительно_хотите_удалить_счётчик_,
				Resources.MainForm_RemoveCounter_Удаление, MessageBoxButtons.YesNo);
			return result == DialogResult.Yes ? (string)_lbCounters.SelectedItem : null;
		}

		private void _btnSave_Click(object sender, EventArgs e)
		{
			SaveRequested?.Invoke();
		}

		private void _btnLoad_Click(object sender, EventArgs e)
		{
			NoCounterSelected();
			LoadRequested?.Invoke();
		}
	}
}
