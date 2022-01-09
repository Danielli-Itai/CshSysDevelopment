using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBasic
{
	class MethodsClass2
	{
		// Declare a method delegate.
		public delegate void PrintDlg(string message);

		// Instance methods.
		public void InstMethod(string message)	{
			Console.WriteLine("Method1 " + message);
		}

		// Static method.
		public static void StaticMethod(string message)	{
			Console.WriteLine("StaticMethod " + message);
		}
	}





	class MultRef
	{
		public static void MultRefExap()
		{
			//	Create a class instance.
			MethodsClass2 obj = new MethodsClass2();

			//	Creatre instance and static method delegates.
			MethodsClass2.PrintDlg d1 = obj.InstMethod;
			MethodsClass2.PrintDlg d3 = MethodsClass2.StaticMethod;

			//	Instance methods manipulation.
			d1 += obj.InstMethod;
			d1("d1.1");
			d1 -= obj.InstMethod;
			d1("d1.2");

			//	Static methods manipulation.
			d3 += MethodsClass2.StaticMethod;
			d3("d3.1");
			d3 -= MethodsClass2.StaticMethod;
			d3("d3.2");

			return;
		}
	}
}
