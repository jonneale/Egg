using System;
using System.Collections.Generic;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
	public class PlansForSupplierQuery : IAsyncQuery<IEnumerable<Plan>>
	{
	    private const string RestUrl =
	        Rest.Rest.BaseUrl + "/gas-electricity/regions/southern/products/electricity/suppliers/{0}/payment-methods/{1}/plans/";

		private readonly Supplier _supplier;
	    private readonly string _paymentMethod;

	    public string PaymentMethod
	    {
	        get { return _paymentMethod; }
	    }

	    public Supplier Supplier
		{
			get { return _supplier; }
		}

		public PlansForSupplierQuery(Supplier supplier, string paymentMethod)
		{
		    _supplier = supplier;
		    _paymentMethod = paymentMethod;
		}

		public void Execute(IRestClient client, Action<IEnumerable<Plan>> queryCallback)
		{
            client.Get<Plan[]>(new Uri(string.Format(RestUrl, Supplier.UrlEncodedName(), PaymentMethod.Replace(" ", "%20"))), x => queryCallback(x));
		}
	}
}