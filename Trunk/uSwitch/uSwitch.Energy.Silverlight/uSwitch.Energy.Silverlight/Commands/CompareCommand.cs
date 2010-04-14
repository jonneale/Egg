using System;
using System.IO;
using System.Runtime.Serialization.Json;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Commands
{
    public class CompareCommand : IAsyncCommand<Comparison>
    {
        private const string RestUrl = Rest.Rest.BaseUrl + "/gas-electricity/comparisons/";
        private readonly ComparisonRequest _comparisonRequest;

        public ComparisonRequest ComparisonRequest
        {
            get { return _comparisonRequest; }
        }

        public CompareCommand(ComparisonRequest comparisonRequest)
        {
            _comparisonRequest = comparisonRequest;
        }

        public void Execute(IRestClient client, Action<Comparison> queryCallback)
        {
            var serializer = new DataContractJsonSerializer(typeof(ComparisonRequest));

            var serializedComparisonRequest = new MemoryStream();
            serializer.WriteObject(serializedComparisonRequest, ComparisonRequest);
            client.Post(new Uri(RestUrl), serializedComparisonRequest, queryCallback);
        }
    }
}