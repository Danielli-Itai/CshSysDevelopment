using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace DelegateBasic
{
	class FuncAsParam
	{
		// Declare a method delegate.
		public delegate void PrintDlg(string message);

		// Create a method for a delegate.
		public static void PrintMethod(string message)
		{
			Console.WriteLine(message);
		}


		// Declare the function receiving the delegate.
		public static void MethodWithCallback(int param1, int param2, PrintDlg call_func)
		{
			call_func("The number is: " + (param1 + param2).ToString());
		}

		public static void FuncAsParamExamp()
		{
			// Then pass the handler delegate (created above) to that method
			MethodWithCallback(1, 2, PrintMethod);
		}
	}
}
