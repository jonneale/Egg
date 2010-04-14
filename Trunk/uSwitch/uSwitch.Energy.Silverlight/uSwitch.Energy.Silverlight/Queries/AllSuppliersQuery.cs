using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
	public class AllSuppliersQuery : IAsyncQuery<IEnumerable<Supplier>>
	{
		public void Execute(IRestClient client, Action<IEnumerable<Supplier>> queryCallback)
		{
			client.Get<Supplier[]>(new Uri(""), x => queryCallback(x));
		}
	}
}