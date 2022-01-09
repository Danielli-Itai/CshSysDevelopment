using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;





namespace ThreadLibrary
{
	public class SuspendedThread
   {
      public static void MainThread()
      {
         Debug.WriteLine("Main thread starts");

         for (int i = 0; i < 100; i++)
         {
            // the thread is paused for 5000 milliseconds
            int sleepfor = 500;
            Debug.WriteLine("Main Thread Paused for {0} ms", sleepfor);
            Thread.Sleep(sleepfor);

            Debug.WriteLine("Main thread resumes");
         }

         Debug.WriteLine("Main thread terminated");
         return;
      }

      private const int SLEEP_MS = 500;
      public static void ChildThread()
      {
         Debug.WriteLine("Child thread starts");

         for (int i = 0; i < 100; i++)
         {
            // the thread is paused for 5000 milliseconds
            Debug.WriteLine("Child Thread Paused for {0} ms", SLEEP_MS);
            Thread.Sleep(SLEEP_MS);

            Debug.WriteLine("Child thread resumes");
         }

         Debug.WriteLine("Child thread terminated");
         return;
      }


 
      public static void ThreadsRun()
      {
         ThreadStart childref = new ThreadStart(ChildThread);
         Debug.WriteLine("In Main: Creating the Child thread");

         Thread childThread = new Thread(childref);

         childThread.Start();
         Thread.Sleep(500);
         MainThread();

         childThread.Join();
         return;
      }

   }  // Endd of class.
}
