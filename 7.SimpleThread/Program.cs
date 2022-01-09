using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThread
{

	class Program
	{
		public static void ChildThread()
		{
			for (int i = 1; i < 100; i++)	{
				Console.WriteLine("Child thread starts " + i);
			}
			return;
		}

		static void Main(string[] args)
		{
			ThreadStart childref = new ThreadStart(ChildThread);

			Console.WriteLine("In Main: Creating the Child thread");
			Thread childThread = new Thread(childref);

			childThread.Start();
			Console.ReadKey();
			return;
		}
	}
}
