using System;
using System.Collections.Generic;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
	public class AllSuppliersForProductAndRegionQuery : IAsyncQuery<IEnumerable<Supplier>>
	{
	    private readonly string _product;
	    private readonly string _region;

	    private const string RestUrl = Rest.Rest.BaseUrl + "/gas-electricity/regions/{0}/products/{1}/suppliers/";

	    public string Region
	    {
	        get { return _region; }
	    }

	    public string Product
	    {
	        get { return _product; }
	    }

        public AllSuppliersForProductAndRegionQuery(string product, string region)
        {
            _product = product;
            _region = region;
        }

	    public void Execute(IRestClient client, Action<IEnumerable<Supplier>> queryCallback)
		{
            client.Get<Supplier[]>(new Uri(string.Format(RestUrl, Region, Product)), x => queryCallback(x));
		}
	}
}