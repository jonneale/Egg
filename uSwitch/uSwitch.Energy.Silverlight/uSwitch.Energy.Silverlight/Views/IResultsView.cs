using System;
using System.Collections.Generic;
using uSwitch.Energy.Silverlight.Views.PresentationModel;

namespace uSwitch.Energy.Silverlight.Views
{
    public interface IResultsView
    {
        IEnumerable<ResultsViewItem> Results { get; set; }

        event Action<ResultsViewItem> ResultSelected;

        bool DisplayTable
        {
            get; set;
        }

        string Region { get; set; }
    }
}