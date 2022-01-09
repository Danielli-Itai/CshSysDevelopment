using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace DelegateBasic
{
	class AnonRef
	{
		delegate void PrintDlg(string message);

		public static void AnonRefExamp()
		{
			// Instantiate Del by using an anonymous method.
			PrintDlg del3 = delegate (string name)	{ 
				Console.WriteLine($"Notification received for: {name}"); 
			};

			// Instantiate Del by using a lambda expression.
			PrintDlg del4 = name => {
				Console.WriteLine($"Notification received for: {name}"); 
			};

			del3("Student");
			del4("Student");
			return;
		}
	}
}
