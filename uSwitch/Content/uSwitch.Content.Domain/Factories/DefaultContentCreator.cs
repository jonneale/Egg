using System;

namespace uSwitch.Content.Domain.Factories
{
	public class DefaultContentCreator<TContent> : IContentCreator<TContent> where TContent : ContentBase, new()
	{
		public TContent Create()
		{
			return new TContent();
		}
	}
}