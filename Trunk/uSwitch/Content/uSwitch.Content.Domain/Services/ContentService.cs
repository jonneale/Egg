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
		private readonly IPublisher _publisher;

		public ContentService(ContentRepository repository, IPublisher publisher)
		{
			_repository = repository;
			_publisher = publisher;
		}

		public void Create(ContentBase content)
		{
			_repository.Add(content);
		}

		public ICollection<ContentBase> FindContent(string path, string name)
		{
			return null;
		}

		public void Publish(PublishingList publishList)
		{

		}
	}
}
