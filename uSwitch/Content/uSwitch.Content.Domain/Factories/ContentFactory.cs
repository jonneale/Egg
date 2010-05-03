using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uSwitch.Content.Domain.Ioc;

namespace uSwitch.Content.Domain.Factories
{
	public class ContentFactory
	{
		private readonly IServiceLocator _serviceLocator;

		public ContentFactory(IServiceLocator serviceLocator)
		{
			_serviceLocator = serviceLocator;
		}

		public ContentBase Create<TContent>() where TContent : ContentBase
		{
			var contentCreator = _serviceLocator.GetInstance<IContentCreator<TContent>>() ??
			                     _serviceLocator.GetInstance<IContentCreator<TContent>>("Default");

			return contentCreator.Create();
		}
	}
}
