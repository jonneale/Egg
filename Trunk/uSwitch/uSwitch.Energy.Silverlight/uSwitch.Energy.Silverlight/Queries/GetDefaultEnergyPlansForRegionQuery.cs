using System;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
    public class GetDefaultEnergyPlansForRegionQuery: IAsyncQuery<DefaultEnergyResult>
    {
        private readonly string _regionName;
        private const string RestUrl = Rest.Rest.BaseUrl + "/gas-electricity/regions/{0}/";

        public GetDefaultEnergyPlansForRegionQuery(string regionName)
        {
            _regionName = regionName;
        }

        public string RegionName
        {
            get { return _regionName; }
        }

        public void Execute(IRestClient client, Action<DefaultEnergyResult> queryCallback)
        {
            client.Get(new Uri(string.Format(RestUrl, RegionName)), queryCallback);
        }
    }
}