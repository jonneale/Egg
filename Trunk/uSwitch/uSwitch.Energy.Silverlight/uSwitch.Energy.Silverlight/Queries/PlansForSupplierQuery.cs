using System;
using System.Collections.Generic;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
	public class PlansForSupplierQuery : IAsyncQuery<IEnumerable<Plan>>
	{
		private readonly Supplier _supplier;

		public Supplier Supplier
		{
			get { return _supplier; }
		}

		public PlansForSupplierQuery(Supplier supplier)
		{
			_supplier = supplier;
		}

		private static Uri ConstructUri(IRestResource supplier)
		{
			return new Uri(string.Empty + supplier.GetUri());
		}

		public void Execute(IRestClient client, Action<IEnumerable<Plan>> queryCallback)
		{
			client.Get<Plan[]>(ConstructUri(_supplier), x => queryCallback(x));
		}
	}
}