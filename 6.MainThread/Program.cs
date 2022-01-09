using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;





namespace MainThread
{
	class Program
	{
		static void Main(string[] args)
		{
			Thread th = Thread.CurrentThread;
			th.Name = "MainThread";

			Console.WriteLine("This is {0}", th.Name);
			Console.ReadKey();

			return;
		}
	}
}
