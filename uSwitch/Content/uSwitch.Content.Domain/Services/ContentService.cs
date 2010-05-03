using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uSwitch.Content.Domain.Inferstructure;
using uSwitch.Content.Domain.Persistance;

namespace uSwitch.Content.Domain.Services
{
	public class ContentService
	{
		private readonly ContentRepository _repository;
		private readonly IContentPublisher _contentPublisher;

		public ContentService(ContentRepository repository, IContentPublisher contentPublisher)
		{
			_repository = repository;
			_contentPublisher = contentPublisher;
		}

		public void Create<TContent>(TContent content) where TContent : ContentBase
		{
			_repository.Add(content);
		}

		public ContentBase FindContent(string name, string path)
		{
			return _repository.FindByNameAndPath(name, path);
		}

		public void Publish(PublishingList publishList)
		{

		}
	}
}
