using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;





namespace MultiThreadedUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}



		private void MyButton_Click(object sender, RoutedEventArgs e)
		{
			Thread thread = new Thread(UpdateText);
			thread.Start();
		}
/*
		private void UpdateText()
		{
			Thread.Sleep(TimeSpan.FromSeconds(5));
			TxtName.Text = "Hello Geeks !";
		}
*/
		private void UpdateText()
		{
			Thread.Sleep(TimeSpan.FromSeconds(1));
			this.Dispatcher.BeginInvoke(new Action(() =>
			{
				TxtName.Text = "Hello Geeks !";
			}));
		}

	}
}
