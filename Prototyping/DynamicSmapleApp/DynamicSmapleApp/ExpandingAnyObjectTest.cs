using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicSmapleApp
{
	public class ExpandingAnyObjectTest
	{
		public void Run()
		{
			var me = new Person
			{
				Name = "jamie",
				Age = 26
			};

			dynamic meDynamic = me.GetExpando();

			meDynamic.Gender = "Male";

			meDynamic.Method = new Func<string, bool>(x => true);

			string someString = meDynamic.Get();

			Console.WriteLine(meDynamic.Gender);
			Console.ReadLine();
		}
	}
}
