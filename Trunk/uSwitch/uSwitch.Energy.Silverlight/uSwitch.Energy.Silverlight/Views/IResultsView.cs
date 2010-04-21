using System.Collections.Generic;
using uSwitch.Energy.Silverlight.Views.PresentationModel;

namespace uSwitch.Energy.Silverlight.Views
{
    public interface IResultsView
    {
        IEnumerable<ResultsViewItem> Results { get; set; }

        bool DisplayTable
        {
            get; set;
        }
    }
}