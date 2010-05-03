using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Dynamic;

namespace DynamicSmapleApp
{
	public class DataSetTests
	{
		public void Run()
		{
			DataTable table = new DataTable("Persons");
			table.Columns.AddRange(
				new[] { 
					new DataColumn("Name", typeof(string)),
					new DataColumn("Age", typeof(int))
				});

			table.Rows.Add("Jamie", 26);

			dynamic jamieObject = table.Rows[0].GetDynamic();

			Console.WriteLine(jamieObject.Name);
			Console.WriteLine(jamieObject.Age);
			Console.ReadLine();
		}
	}
}
