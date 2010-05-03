using System.Collections.Generic;
using uSwitch.Content.Domain.Factories;

namespace uSwitch.Content.Domain.Ioc
{
	public interface IServiceLocator
	{
		TInstance GetInstance<TInstance>();
		IEnumerable<TInstance> GetInstances<TInstance>();
		TInstance GetInstance<TInstance>(string @default);
	}
}