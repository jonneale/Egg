using System;
using System.Collections.Generic;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
	public class PlansForSupplierQuery : IAsyncQuery<IEnumerable<Plan>>
	{
	    private const string RestUrl =
			Rest.Rest.BaseUrl + "/gas-electricity/regions/{0}/products/{1}/suppliers/{2}/payment-methods/{3}/plans/";

		private readonly Supplier _supplier;
	    private readonly string _paymentMethod;
		private readonly string _product;
		private readonly string _region;

		public string Region
		{
			get { return _region; }
		}

		public string Product
		{
			get { return _product; }
		}

		public string PaymentMethod
	    {
	        get { return _paymentMethod; }
	    }

	    public Supplier Supplier
		{
			get { return _supplier; }
		}

		public PlansForSupplierQuery(Supplier supplier, string paymentMethod, string product, string region)
		{
		    _supplier = supplier;
			_region = region.ToLower();
			_product = product.ToLower();
			_paymentMethod = paymentMethod.ToLower();
		}

		public void Execute(IRestClient client, Action<IEnumerable<Plan>> queryCallback)
		{
            client.Get<Plan[]>(new Uri(string.Format(RestUrl, Region, Product, Supplier.UrlEncodedName(), PaymentMethod.Replace(" ", "%20"))), x => queryCallback(x));
		}
	}
}