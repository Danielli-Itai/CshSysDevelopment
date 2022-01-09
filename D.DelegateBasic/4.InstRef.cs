using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace DelegateBasic
{
	class MethodsClass1
	{
		// Declare a method delegate.
		public delegate void PrintDlg(string message);

		// Instance methods.
		public void InstMethod1(string message) {
			Console.WriteLine("Method1 " + message);
		}

		// Static method.
		public static void StaticMethod(string message)		{
			Console.WriteLine("StaticMethod " + message);
		}
	}


	class InstRef
	{
		public static void InstRefExamp()
		{
			MethodsClass1 obj = new MethodsClass1();
			MethodsClass1.PrintDlg d1 = obj.InstMethod1;
			d1("d1");

			MethodsClass1.PrintDlg d3 = MethodsClass1.StaticMethod;
			d3("d3");

			return;
		}
	}
}
