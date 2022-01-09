using System.Threading;
using System.Diagnostics;




namespace ThreadLibrary
{
	public class AbortThread
   {
      public static void ChildThread()
      {
         try
         {
            Debug.WriteLine("Child thread starts");

            // do some work, like counting to 100
            for (int counter = 0; counter < 10; counter++)
            {
               Thread.Sleep(500);
               Debug.WriteLine(counter);
            }
            Debug.WriteLine("Child Thread Completed");
         }
         catch (ThreadAbortException e){
            Debug.WriteLine("Thread Abort Exception" + e.Message);
         }
         finally{
            Debug.WriteLine("Couldn't catch the Thread Exception");
         }
         return;
      }


      public static void ThreadRun()
      {
         ThreadStart childref = new ThreadStart(ChildThread);
         Debug.WriteLine("In Main: Creating the Child thread");

         Thread childThread = new Thread(childref);
         childThread.Start();

         //stop the main thread for some time
         Thread.Sleep(2000);

         //now abort the child
         Debug.WriteLine("In Main: Aborting the Child thread");
         childThread.Abort();

         childThread.Join();

         return;
      }
   }
}

