using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;

namespace BatchTests.Web.Core
{
    public class CSVToDataTable
    {
        public DataTable GetDataTable(string fullFilePath)
        {
            var dataTable = new DataTable();
            var sql = @"SELECT * FROM [" + Path.GetFileName(fullFilePath) + "]";

            using (var connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Path.GetDirectoryName(fullFilePath) + @";Extended Properties=""Text;HDR=" + "No" + @""""))
            {
                using (var command = new OleDbCommand(sql, connection))
                {
                    using (var adapter = new OleDbDataAdapter(command))
                    {

                        dataTable.Locale = CultureInfo.CurrentCulture;
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }
    }
}