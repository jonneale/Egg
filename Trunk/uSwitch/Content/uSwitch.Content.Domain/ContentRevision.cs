using System.Collections.Generic;

namespace uSwitch.Content.Domain
{
	public class ContentRevision : Entity
	{
		public virtual ContentBase Content
		{
			get; set;
		}

		public virtual IDictionary<string, string> Properties
		{
			get; set;
		}

		public string RawSource
		{ 
			get; set;
		}
	}
}