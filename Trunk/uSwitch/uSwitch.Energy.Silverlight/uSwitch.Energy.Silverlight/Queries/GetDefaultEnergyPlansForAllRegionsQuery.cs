using System;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
    public class GetDefaultEnergyPlansForAllRegionsQuery : IAsyncQuery<DefaultEnergyResult[]>
    {
        private const string RestUrl = Rest.Rest.BaseUrl + "/gas-electricity/regions/";

        public void Execute(IRestClient client, Action<DefaultEnergyResult[]> queryCallback)
        {
            client.Get(new Uri(RestUrl), queryCallback);
        }
    }
}