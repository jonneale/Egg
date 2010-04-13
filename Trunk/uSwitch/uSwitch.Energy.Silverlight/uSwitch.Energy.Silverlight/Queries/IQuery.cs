using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
	public interface IQuery<TReturn>
	{
		TReturn Execute(IRestClient client);
	}
}