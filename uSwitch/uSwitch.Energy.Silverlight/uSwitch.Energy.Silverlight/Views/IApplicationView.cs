using System;
using System.Windows.Media.Animation;
using uSwitch.Energy.Silverlight.Model;

namespace uSwitch.Energy.Silverlight.Views
{
	public interface IApplicationView
	{
        DefaultRegionInformation DefaultUsage { get; set; }
		string Region { get; set; }
		string Postcode { get; set; }

        bool HasGas { get; set; }

		bool HasEconomy7 { get; set; }

		string PaymentMethod { get; set; }

		event Action<string> FindRegionPressed;

	    event Action<bool> HasGasChanged;

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

        bool InitialQuestionsVisible
        {
            get; set;
        }

        bool DisplayResultsOnly
        {
            get; set;
        }
	}
}