using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBasic
{
	class MethodsClass3
	{
		// Declare a method delegate.
		public delegate string PrintDlg(ref string message);

		// Instance methods.
		public string InstMethod(ref string message)
		{
			Console.WriteLine(message += " InstMethod ");
			return (message);
		}

		// Static method.
		public static string StaticMethod(ref string message)
		{
			Console.WriteLine(message += " StaticMethod ");
			return (message);
		}
	}





	class MultRefParams
	{
		public static void MultRefParamsExap()
		{
			//	Create a class instance.
			MethodsClass3 obj = new MethodsClass3();

			//	Creatre instance and static method delegates.
			MethodsClass3.PrintDlg d1 = obj.InstMethod;
			MethodsClass3.PrintDlg d2 = MethodsClass3.StaticMethod;

			//	Adding methods.
			d1 += obj.InstMethod;
			d2 += MethodsClass3.StaticMethod;

			//	Pass the parameters by referance.
			string s1 = "d1";
			Console.WriteLine(d1(ref s1));
			string s2 = "d2";
			Console.WriteLine(d2(ref s2));

			return;
		}
	}
}
