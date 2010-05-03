using System.Collections.Generic;

namespace uSwitch.Energy.Silverlight.Views
{
	public interface IRefineView
	{
		IEnumerable<string> PaymentMethods
		{
			get; set;
		}

		bool IsVisible
		{
			get; set;
		}
	}
}