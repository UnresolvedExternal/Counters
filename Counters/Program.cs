using System;
using System.Windows.Forms;

namespace Counters
{
	internal static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var view = new MainForm();
			var model = new Model();
			var presentor = new Presentor(view, model);
			Application.Run(view);
		}
	}
}
