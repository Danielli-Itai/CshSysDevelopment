using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThreadLibrary;





namespace ThreadTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestThreadRun()
		{
			SimpleThrad.ThreadRun();
		}


		[TestMethod]
		public void ThreadsRun()
		{
			SuspendedThread.ThreadsRun();
		}

		[TestMethod]
		public void ThreadAbort()
		{
			AbortThread.ThreadRun();
		}

	}
}
