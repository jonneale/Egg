using System;

namespace uSwitch.Energy.Silverlight.Views
{
	public interface IComparisonView
	{
		string Region { get; set; }
		string Postcode { get; set; }

		event Action<string> FindRegionPressed;
	}
}