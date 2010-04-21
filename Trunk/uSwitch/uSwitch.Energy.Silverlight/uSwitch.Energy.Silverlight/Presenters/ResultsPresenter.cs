using System;
using System.Linq;
using System.Windows.Threading;
using uSwitch.Energy.Silverlight.Commands;
using uSwitch.Energy.Silverlight.Core;
using uSwitch.Energy.Silverlight.Events;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Model.Extensions;
using uSwitch.Energy.Silverlight.Rest;
using uSwitch.Energy.Silverlight.Views;
using uSwitch.Energy.Silverlight.Views.PresentationModel;

namespace uSwitch.Energy.Silverlight.Presenters
{
    public class ResultsPresenter
    {
        protected readonly IResultsView View;
        protected readonly IRestClient RestClient;
        protected readonly Dispatcher Dispatcher;
        protected readonly IEventHub EventHub = Core.EventHub.GetCurrent();

        public ResultsPresenter(IResultsView view, Dispatcher dispatcher)
        {
            View = view;
            Dispatcher = dispatcher;
            RestClient = RestClientFactory.GetDefault();
        }

        public void DisplayResults(Comparison comparison)
        {
            View.Results = comparison.ComparisonResults.ToResultsViewItems();
            View.DisplayTable = true;
        }

        public void Loaded()
        {
            Action<CompareEvent> compareEventCallback = CreateCallBackEventInDispatcher();
            EventHub.Register(compareEventCallback);
        }

        private Action<CompareEvent> CreateCallBackEventInDispatcher()
        {
            return @event => Dispatcher.BeginInvoke(() =>
                                                        {
                                                            GetResultsForComparison
                                                                (@event);
                                                        });
        }

        public void GetResultsForComparison(CompareEvent @event)
        {
            ComparisonRequest request = @event.ToRequest();
            var compareCommand = new CompareCommand(request);
            compareCommand.Execute(RestClient, c => Dispatcher.BeginInvoke(() => GetResultsForComparisonCallBack(c)));
        }

        private void GetResultsForComparisonCallBack(Comparison comparison)
        {
            EventHub.Publish(new ComparisonReceivedEvent());
            DisplayResults(comparison);
        }
    }
}