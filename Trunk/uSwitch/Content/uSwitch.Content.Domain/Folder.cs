using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain
{
	public class Folder
	{
		public virtual string FullyQualifiedName
		{
			get; set;
		}

		public virtual string Name
		{
			get;
			set;
		}

		public virtual IList<ContentBase> GetContent()
		{
			return new List<ContentBase>();
		}

		public virtual IList<ContentBase> GetPublishableContent()
		{
			return new List<ContentBase>();
		}

		public virtual ICollection<Folder> GetChildFolders()
		{
			return new Collection<Folder>();
		}

		public virtual ICollection<Folder> GetParentFolder()
		{
			return new Collection<Folder>();
		}

		public static string Concat(params string[] names)
		{
			return names.Aggregate(names.First(), (previous, next) => string.Concat(previous, ".", next));
		}
	}
}
