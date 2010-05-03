using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Data;
using System.Linq;
using System.Data;

namespace DynamicSmapleApp
{
    public static class DataRowExtensions
    {
        public static dynamic GetDynamic(this DataRow row) 
        {
			dynamic dataObject = dataObject = new ExtendedDynamicObject();
			foreach (DataColumn column in row.Table.Columns)
			{
				dataObject[column.ColumnName] = row[column];
			}
			return dataObject;
        }
    }
}
