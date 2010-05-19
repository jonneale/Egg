using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Web.Mvc;

namespace uSwitch.MvcBrownBag.Web.Core.ActionResults
{
    public class CsvResult : ContentResult
    {
        private readonly IEnumerable _content;

        public CsvResult(IEnumerable content)
        {
            this._content = content;

            this.ContentType = "text/csv";

            var builder = new StringBuilder();

            foreach (var item in _content)
            {
                var itemAsStrings = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(
                    x => x.GetValue(item, null).ToString()).ToArray();

                builder.AppendLine(string.Join(",", itemAsStrings));
            }

            this.Content = builder.ToString();
        }
    }
}