using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using BatchTests.Web.Core;

namespace BatchTests.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            compareButton.Click += compareButton_Click;
        }

        void compareButton_Click(object sender, EventArgs e)
        {
            string fullFileNameOld = Path.GetTempFileName();
            string fullfileNameNew = Path.GetTempFileName();
            oldFileUpload.PostedFile.SaveAs(fullFileNameOld);
            newFileUpload.PostedFile.SaveAs(fullfileNameNew);

            var comparer = new CsvComparer(fullFileNameOld, fullfileNameNew, int.Parse(supplierDropdown.SelectedValue));
            IList<CompareResult> results = comparer.Run();

            compareResultsGrid.DataSource = comparer.Run();
            compareResultsGrid.DataBind();

            var distinctColumnNumbers = results.Select(x => x.ColumnNumber).Distinct().OrderBy(x => x);
            columnDifferencesGrid.DataSource =
                distinctColumnNumbers.Select(x => new ColumnCompareResult { ColumnNumber = x });
            columnDifferencesGrid.DataBind();
        }
    }
}
