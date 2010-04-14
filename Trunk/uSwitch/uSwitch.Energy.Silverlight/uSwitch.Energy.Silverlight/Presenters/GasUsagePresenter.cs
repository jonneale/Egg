using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight.Presenters
{
	public class GasUsagePresenter : EnergyUsagePresenter
	{
		public GasUsagePresenter(IEnergyUsageView view) : base(view)
		{
		}

		public GasUsagePresenter(IEnergyUsageView view, IRestClient restClient) : base(view, restClient)
		{
		}
	}
}
