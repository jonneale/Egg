using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook.Extended.Templates;
using System.Collections;

namespace Facebook.Extended
{
	public interface IFacebookPublishing
	{
		void Publish(ITemplate template, IDictionary<string, string> parameters);
		void Publish(ITemplate template, IDictionary<string, string> parameters, ICollection<string> userIds);
	}
}
