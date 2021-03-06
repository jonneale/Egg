using System.Collections.Generic;

namespace uSwitch.Content.Domain
{
	public class ContentRevision : Entity
	{
		public virtual ContentBase Content
		{
			get; set;
		}

		public virtual ICollection<ContentPropertyValue> Properties
		{
			get; set;
		}

		public virtual string PropertiesSource
		{ 
			get; set;
		}
	}
}