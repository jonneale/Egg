using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain
{
	public class Site : Entity
	{
		public virtual ICollection<ContentBase> Content { get; set; }

		public virtual IList<Folder> GetFolders()
		{
			return new List<Folder>();
		}

		public ContentBase CreateContent(string name)
		{
			
		}
	}
}
