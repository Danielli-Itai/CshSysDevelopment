using System;
using System.ComponentModel;
using System.Threading;





namespace MultiThreadedUI
{
	class TimerThread
	{
		bool _keepRunning = false;
		BackgroundWorker workerThread = null;




		public delegate void DlgTimerTick(TimeSpan elapsed);
		public DlgTimerTick TimerTick;
		private void TimerTickCall(TimeSpan elapsed)
		{
			if (null != TimerTick)
			{
				TimerTick(elapsed);
			}
		}

		public delegate void DlgTimerUpdate(String text);
		public DlgTimerUpdate TimerUpdate;
		private void TimerUpdateCall(String text)
		{
			if (null != TimerUpdate)
			{
				TimerUpdate(text);
			}
		}

		public TimerThread()
		{
			workerThread = new BackgroundWorker();
			workerThread.ProgressChanged += WorkerThread_ProgressChanged;
			workerThread.DoWork += WorkerThread_DoWork;
			workerThread.RunWorkerCompleted += WorkerThread_RunWorkerCompleted;
			workerThread.WorkerReportsProgress = true;
			workerThread.WorkerSupportsCancellation = true;
		}

		private void WorkerThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			TimerUpdateCall(e.UserState.ToString());
		}

		private void WorkerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)	{
				TimerUpdateCall("Cancelled");
			}
			else {
				TimerUpdateCall("Stopped");
			}
		}

		private void WorkerThread_DoWork(object sender, DoWorkEventArgs e)
		{
			DateTime startTime = DateTime.Now;

			_keepRunning = true;

			while (_keepRunning)
			{
				Thread.Sleep(100);
				TimeSpan elapsed = DateTime.Now - startTime;
				string timeElapsedInstring = elapsed.ToString(@"hh\:mm\:ss");

				this.TimerTickCall(elapsed);
				workerThread.ReportProgress(0, timeElapsedInstring);

				if (workerThread.CancellationPending)
				{
					// this is important as it set the cancelled property of RunWorkerCompletedEventArgs to true
					e.Cancel = true;
					break;
				}
			}
		}




		public void Start()
		{
			workerThread.RunWorkerAsync();
		}

		public void Stop()
		{
			_keepRunning = false;
		}
		public void Cancel()
		{
			workerThread.CancelAsync();
		}
	}
}

