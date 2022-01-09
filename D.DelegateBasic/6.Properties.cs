using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace DelegateBasic
{
	class Properties
	{
		// Declare a method delegate.
		delegate void PrintDlg(string message);

		// Instance methods.
		static void StaticMethod(string message)
		{
			Console.WriteLine("Method1 " + message);
		}


		delegate void Delegate1();
		delegate void Delegate2();

		static void method(Delegate1 d, Delegate2 e, System.Delegate f)
		{
			// Compile-time error.
			//Console.WriteLine(d == e);

			// OK at compile-time. False if the run-time type of f is not the same as that of d.
			Console.WriteLine(d == f);
		}

		public static void PropertiesExap()
		{
			PrintDlg d1 = StaticMethod;

			//	Static methods manipulation.
			d1 += MethodsClass2.StaticMethod;

			int invocationCount = d1.GetInvocationList().GetLength(0);
			Console.WriteLine($"invocationCount = { invocationCount}");

			return;
		}
	}
}
