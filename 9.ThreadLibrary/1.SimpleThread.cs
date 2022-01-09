using System.Threading;
using System.Diagnostics;





namespace ThreadLibrary
{
    public class SimpleThrad
    {
		public static void ChildThread()
		{
			for (int i = 1; i < 100; i++)
			{
				Debug.WriteLine("Child thread starts " + i);
			}
			return;
		}

		public static void ThreadRun()
		{
			ThreadStart childref = new ThreadStart(ChildThread);

			Debug.WriteLine("In Main: Creating the Child thread");
			Thread childThread = new Thread(childref);

			childThread.Start();
			childThread.Join();
			return;
		}

	}
}
