using System;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
    public class GetDefaultEnergyPlansForAllRegionsQuery : IAsyncQuery<DefaultRegionInformation[]>
    {
        private const string RestUrl = Rest.Rest.BaseUrl + "/gas-electricity/regions/";

        public void Execute(IRestClient client, Action<DefaultRegionInformation[]> queryCallback)
        {
            client.Get(new Uri(RestUrl), queryCallback);
        }
    }
}