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
	public class ContentBase : Entity
	{
		public virtual ICollection<ContentRelationship> Relationships
		{
			get;
			set;
		}

		protected virtual ICollection<ContentRevision> Revisions
		{
			get; set;
		}

		protected virtual ContentRevision Current
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

		public virtual string Name { get; set; }

		protected virtual string SerializedProperties
		{
			get; set;
		}

		public virtual string GetSerializedProperties()
		{
			
		}

		public ContentRevision GetCurrentRevision()
		{
			return Current;
		}

		protected virtual IEnumerable<PropertyInfo> GetPropertys()
		{
			return GetType().GetProperties(BindingFlags.GetProperty | BindingFlags.Public).Where(
				p => p.GetCustomAttributes(typeof(ContentPropertyAttribute), true).Count() > 0);
		}

		public virtual void Publish()
		{
			
		}
	}
}
