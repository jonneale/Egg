using System;
using System.Windows.Threading;
using uSwitch.Energy.Silverlight.Core;
using uSwitch.Energy.Silverlight.Events;
using uSwitch.Energy.Silverlight.Queries;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;

namespace uSwitch.Energy.Silverlight.Presenters
{
	public class ComparisonPresenter
	{
		protected IRestClient RestClient;
		protected readonly Dispatcher Dispatcher;
		protected readonly IEventHub EventHub = Core.EventHub.GetCurrent();

		public IComparisonView View { get; set; }

		public ComparisonPresenter(IComparisonView view, Dispatcher dispatcher)
		{
			View = view;
			RestClient = RestClientFactory.GetDefault();
			Dispatcher = dispatcher;
			view.FindRegionPressed += FindRegion;
		}

		public void FindRegion(string postcode)
		{
			var query = new GetRegionFromPostCodeQuery(postcode);
			query.Execute(RestClient, result => CallDispatcher(
				() =>
				{
					View.Region = result.RegionName;
					EventHub.Publish(new RegionFoundEvent {Region = result.RegionName});

                    if (!string.IsNullOrEmpty(View.Region))
                    {
                        View.UsageFadeInStoryboard.Begin();
                    }
				}));
		}

        public void Compare()
        {
            
        }

		protected void CallDispatcher(Action action)
		{
			Dispatcher.BeginInvoke(action);
		}
	}
}