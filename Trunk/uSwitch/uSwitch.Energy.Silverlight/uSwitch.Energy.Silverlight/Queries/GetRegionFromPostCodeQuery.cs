using System;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
    public class GetRegionFromPostCodeQuery : IAsyncQuery<PostcodeLookupResult>
    {
        private readonly string _postcode;
        private const string Resturl = Rest.Rest.BaseUrl + "/gas-electricity/postcodes/{0}/";

        public GetRegionFromPostCodeQuery(string postcode)
        {
            _postcode = postcode;
        }

        public void Execute(IRestClient client, Action<PostcodeLookupResult> queryCallback)
        {
            client.Get(new Uri(string.Format(Resturl, _postcode)), queryCallback);
        }
    }
}
