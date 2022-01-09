using System;
using MySql.Data.MySqlClient;





namespace MySqlConnect
{
	class Program
	{
		static void Main(string[] args)
		{

			string cs = @"server=localhost;userid=root;password=MySqlPassword;database=vstestdb";

			using var con = new MySqlConnection(cs);
			con.Open();

			Console.WriteLine($"MySQL version : {con.ServerVersion}");
		}
	}
}
