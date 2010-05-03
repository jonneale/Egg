using System;
using System.Collections.Generic;
using Facebook.Extended.Templates;

namespace Facebook.Extended
{
	public class FacebookPublishing : IFacebookPublishing
	{
		private IFacebookApi _api;

		public FacebookPublishing(IFacebookApi api)
		{
			_api = api;
		}

		public void Publish(ITemplate template, IDictionary<string, string> parameters)
		{
		}

		public void Publish(ITemplate template, IDictionary<string, string> parameters, ICollection<string> userIds)
		{
			
		}
	}
}