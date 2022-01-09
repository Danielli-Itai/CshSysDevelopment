using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuspendedThread
{
	class Program
	{
      public static void MainThread()
      {
         Console.WriteLine("Main thread starts");

         for (int i = 0; i < 100; i++)
         {
            // the thread is paused for 5000 milliseconds
            int sleepfor = 500;
            Console.WriteLine("Main Thread Paused for {0} ms", sleepfor);
            Thread.Sleep(sleepfor);

            Console.WriteLine("Main thread resumes");
         }

         Console.WriteLine("Main thread terminated");
         return;
      }

      public static void ChildThread()
      {
         Console.WriteLine("Child thread starts");

         for (int i = 0; i < 100; i++)
         {
            // the thread is paused for 5000 milliseconds
            int sleepfor = 500;
            Console.WriteLine("Child Thread Paused for {0} ms", sleepfor);
            Thread.Sleep(sleepfor);

            Console.WriteLine("Child thread resumes");
         }

         Console.WriteLine("Child thread terminated");
         return;
      }


 
      static void Main(string[] args)
      {
         ThreadStart childref = new ThreadStart(ChildThread);
         Console.WriteLine("In Main: Creating the Child thread");

         Thread childThread = new Thread(childref);

         childThread.Start();
         Thread.Sleep(500);


         //MainThread();

         Console.ReadKey();
         return;
      }

   }  // Endd of class.
}
