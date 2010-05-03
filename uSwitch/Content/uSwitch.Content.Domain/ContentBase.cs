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
	public abstract class ContentBase : Entity
	{
		public virtual Folder Folder
		{
			get
			{
				return new Folder();
			}
		}

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

		public virtual string Path
		{
			get; set;
		}

		public virtual DateTime Created
		{
			get; set;
		}

		public virtual DateTime LastModified
		{
			get; set;
		}

		public virtual bool IsLocked
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
			return string.Empty;
		}

		public void Lock()
		{
			
		}

		public void Unlock()
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
	}
}
