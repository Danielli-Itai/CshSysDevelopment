using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAbort
{
	class Program
	{
      class ThreadCreationProgram
      {
         public static void CallToChildThread()
         {
            try
            {
               Console.WriteLine("Child thread starts");

               // do some work, like counting to 100
               for (int counter = 0; counter < 10; counter++)
               {
                  Thread.Sleep(500);
                  Console.WriteLine(counter);
               }
               Console.WriteLine("Child Thread Completed");
            }
            catch (ThreadAbortException e){
               Console.WriteLine("Thread Abort Exception" + e.Message);
            }
            finally{
               Console.WriteLine("Couldn't catch the Thread Exception");
            }
            return;
         }


         static void Main(string[] args)
         {
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main: Creating the Child thread");

            Thread childThread = new Thread(childref);
            childThread.Start();

            //stop the main thread for some time
            Thread.Sleep(2000);

            //now abort the child
            Console.WriteLine("In Main: Aborting the Child thread");
//            childThread.Abort();

            childThread.Join();

            Console.ReadKey();
         }
      }
   }
}
