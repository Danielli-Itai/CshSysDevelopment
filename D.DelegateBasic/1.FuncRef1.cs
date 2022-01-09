using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace DelegateBasic
{
	class FuncRef
	{
		public delegate void PrintDlg(string message);

		private static void PrintHello(string text)
		{
			Console.WriteLine("Hello " + text);
		}

		private static void PrintGoodby(string text)
		{
			Console.WriteLine("Goodby " + text);
		}

		public static void FuncRefExamp()
		{
			PrintDlg[] print_messages = { PrintHello, PrintGoodby };
			foreach (PrintDlg print in print_messages){
				print("student");
			}
			return;
		}
	}
}
