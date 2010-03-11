using System;

namespace uSwitch.Content.Domain.Factories
{
	public interface IContentCreator<TContent> where TContent : ContentBase
	{
		TContent Create();
	}
}