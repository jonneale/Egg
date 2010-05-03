using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Data;

namespace DynamicSmapleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			//dynamic codeToRun = new ExpandingAnyObjectTest();

			//dynamic temp = new ExpandoObject();
			//temp.Name = "Jamie";
			//temp.PrintName = new Action(() =>
			//{
			//    Console.WriteLine(temp.Name);
			//});

			//temp.PrintName();

			//Console.ReadLine();
			//codeToRun.Run();


			MemberDescription description = new MemberDescription("Some String", "jamie");
        }
    }
}
