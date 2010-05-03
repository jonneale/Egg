using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using LiveNation.Testing.Domain.IOC;

namespace LiveNation.Testing.NBehave
{
	public class Program
	{
		static void Main(string[] args)
		{
		    ConfigureApplication();

		    var process = ServiceLocater.GetInstance<NBehaveProcess>();
            process.Run(Environment.CurrentDirectory, args);
		}

	    private static void ConfigureApplication()
	    {
	        new BootStrapper().Configure();
	    }
	}
}
