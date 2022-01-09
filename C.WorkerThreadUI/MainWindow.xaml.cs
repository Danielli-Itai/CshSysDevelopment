using System;
using System.Windows;





namespace MultiThreadedUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		TimerThread MyTimer = null;

		private void UpdateTick(TimeSpan elapsed)
		{
			this.Dispatcher.BeginInvoke(new Action<TimeSpan>((new_elapsed) =>
			{
				TxtTick.Text = new_elapsed.ToString();
			}), new object[] { elapsed });
		}


		private void UpdateText(Object text)
		{
			this.Dispatcher.BeginInvoke(new Action<String>((new_text) =>
			{
				TxtName.Text = new_text;
			}), new object[] { text });
		}

		public MainWindow()
		{
			InitializeComponent();

			this.MyTimer = new TimerThread();

			this.MyTimer.TimerTick += UpdateTick;
			this.MyTimer.TimerUpdate += UpdateText;
		}



		private void btnStart_Click(object sender, EventArgs e)
		{
			this.MyTimer.Start();
		}
		private void btnStop_Click(object sender, EventArgs e)
		{
			this.MyTimer.Stop();
		}
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.MyTimer.Cancel();
		}
	}
}
