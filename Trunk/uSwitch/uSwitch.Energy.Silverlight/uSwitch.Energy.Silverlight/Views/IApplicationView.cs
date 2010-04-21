using System;
using System.Windows.Media.Animation;

namespace uSwitch.Energy.Silverlight.Views
{
	public interface IApplicationView
	{
		string Region { get; set; }
		string Postcode { get; set; }

		event Action<string> FindRegionPressed;

	    event Action Compare;

        Storyboard UsageFadeInStoryboard { get; }

        IEnergyUsageView GasUsageView
        {
            get;
        }

        IEnergyUsageView ElectricityUsageView
        {
            get;
        }

        bool UsagePanelsVisible
        {
            get; set;
        }
	}
}