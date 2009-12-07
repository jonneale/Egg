using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook.Entity;
using System.Xml.Linq;

namespace Facebook.Extended
{
	public interface IFacebookConnect
	{
		bool Authenicated
		{
			get;
		}

		User CurrentUser
		{ 
			get;
		}

		IList<User> GetFriends();

		ICollection<string> RegisterUsers(ICollection<string> emailAddresses);
	}
}
