using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using uSwitch.Content.Domain.Attributes;
using uSwitch.Content.Domain.ContentTypes;

namespace uSwitch.Content.Domain
{
	public class ContentBase : IGetPropertiesAsDictionary
	{
		protected virtual ICollection<ContentRevision> Revisions
		{
			get; set;
		}

		public virtual string Title
		{
			get; set;
		}

		public virtual string Path
		{
			get; set;
		}
		
		public virtual string SerializeProperties()
		{
			return string.Empty;
		}

		public ContentRevision GetCurrentRevision()
		{
			return new ContentRevision();
		}

		public virtual IDictionary<string, object> GetDictionary()
		{
			var contentProperties = GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public).Where(
				p => p.GetCustomAttributes(typeof (ContentPropertyAttribute), true).Count() > 0);

			var dictionary = new Dictionary<string, object>(
				contentProperties.ToDictionary(p => p.Name, p => p.GetGetMethod().Invoke(this, null)));

			return dictionary;
		}

		public virtual void Publish()
		{
			
		}
	}
}
