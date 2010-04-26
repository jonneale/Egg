using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace BatchTests.Web.Core
{
    public class DataTableToCSV
    {
        public Stream GenerateCSVStream(DataTable table)
        {
            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);

            writer.AutoFlush = true;

            foreach (DataRow row in table.Rows)
            {
                string[] itemArray =
                    row.ItemArray.Select(x => string.Format("\"{0}\"", !Convert.IsDBNull(x) ? x : string.Empty)).ToArray();
                writer.WriteLine(string.Join(",", itemArray));
            }

            memoryStream.Position = 0;
            return memoryStream;
        }
    }
}