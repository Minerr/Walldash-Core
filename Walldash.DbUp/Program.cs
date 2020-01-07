using DbUp;
using System;
using System.Configuration;
using System.Reflection;

namespace Walldash.DbUp
{
	class Program
	{
		static int Main(string[] args)
		{
			var upgrader =
				DeployChanges.To
					.SqlDatabase(ConfigurationManager.ConnectionStrings["WalldashDb"].ConnectionString)
					.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
					.LogToConsole()
					.Build();

			var result = upgrader.PerformUpgrade();

			if(!result.Successful)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(result.Error);
				Console.ResetColor();
#if DEBUG
				Console.ReadLine();
#endif
				return -1;
			}

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Success!");
			Console.ResetColor();
			// ### End of DbUP ###


			return 0;
		}
	}
}
