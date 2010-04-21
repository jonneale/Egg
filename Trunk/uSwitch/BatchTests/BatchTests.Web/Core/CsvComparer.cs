using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace BatchTests.Web.Core
{
    public class CsvComparer
    {
        private readonly string _oldFile = string.Empty;
        private readonly string _newFile = string.Empty;
        private readonly List<CompareResult> _results = new List<CompareResult>();
        private readonly int _unqiueColumn = 0;

        public CsvComparer(string oldFile, string newFile, int unquieColumn)
        {
            _oldFile = oldFile;
            _newFile = newFile;
            _unqiueColumn = unquieColumn;
        }

        public IList<CompareResult> Run()
        {
            var csvToDataTable = new CSVToDataTable();

            var oldTable = csvToDataTable.GetDataTable(_oldFile);
            var newTable = csvToDataTable.GetDataTable(_newFile);

            _results.Clear();

            Comparer(oldTable, newTable);

            return _results;
        }

        private void Comparer(DataTable oldTable, DataTable newTable)
        {
            var oldRows = oldTable.Rows.Cast<DataRow>().OrderBy(x => (string)x[_unqiueColumn]).ToList();
            var newRows = newTable.Rows.Cast<DataRow>().OrderBy(x => (string)x[_unqiueColumn]).ToList();

            for (int i = 0; i < newRows.Count; i++)
            {
                var results = CompareRow(oldRows[i], newRows[i]);
                _results.AddRange(results);
            }
        }

        private List<CompareResult> CompareRow(DataRow rowOld, DataRow rowNew)
        {
            var compareResults = new List<CompareResult>();

            for (int i = 0; i < rowNew.Table.Columns.Count; i++)
            {
                string cellNew = !Convert.IsDBNull(rowNew[i]) ? rowNew[i].ToString() : string.Empty;
                string cellOld = !Convert.IsDBNull(rowOld[i]) ? rowOld[i].ToString() : string.Empty;
                bool equal = CompareCell(cellOld, cellNew);

                if (!equal)
                {
                    var compareResult = new CompareResult
                                            {
                                                AreEqual = false,
                                                Id = (string)rowNew[_unqiueColumn],
                                                ResultsNew = cellNew,
                                                ResultsOld = cellOld,
                                                ColumnNumber = i + 1
                                            };
                    compareResults.Add(compareResult);
                }
            }

            return compareResults;
        }

        private static bool CompareCell(string cellOld, string cellNew)
        {
            return cellOld.Equals(cellNew);
        }
    }
}