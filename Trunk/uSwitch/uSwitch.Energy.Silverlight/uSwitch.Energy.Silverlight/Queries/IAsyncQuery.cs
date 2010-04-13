using System;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
	public interface IAsyncQuery<TReturn>
	{
		void Execute(IRestClient client, Action<TReturn> queryCallback);
	}
}