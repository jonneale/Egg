using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook.Entity;
using Facebook.Extended;

namespace uSwitch.FacebookApp.Example
{
	public partial class FacebookFriends : Page
	{
		public IList<User> GetCachedFriends(string userId)
		{
			return (Cache[string.Format("FBFriends_{0}", userId)] != null) ? (IList<User>)Cache[string.Format("FBFriends_{0}", userId)] : null;
		}

		public void CacheFriends(IList<User> friends, string userId)
		{
			Cache.Add(string.Format("FBFriends_{0}", userId), friends, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			IFacebookConnect facebook = FacebookConnect.GetCurrent(HttpContext.Current.Items);

			if (facebook.Authenicated)
			{
				string userId = facebook.CurrentUser.UserId;
				IList<User> friends = GetCachedFriends(userId);
				if (friends == null)
				{
					friends = facebook.GetFriends();
					CacheFriends(friends, userId);
				}

				ArrayList list = new ArrayList();

				foreach (var user in friends)
				{
					string workHistory = string.Empty;
					if (user.WorkHistory != null)
					{
						foreach (var work in user.WorkHistory)
						{
							workHistory += work.CompanyName + " ";
						}
					}

					var newData = new
									{
										Name = user.FirstName + " " + user.LastName,
										DOB = user.Birthday.HasValue ? user.Birthday.Value.ToShortDateString() : string.Empty,
										Location =
											(user.CurrentLocation != null)
												? GetAddress(user.CurrentLocation)
												: string.Empty,
										Sex = GetSex(user.Sex),
										ImageUrl = (user.PictureSmallUrl != null) ? user.PictureSmallUrl.AbsoluteUri : string.Empty,
										WorkHistory = workHistory
									};
					list.Add(newData);
				}

				MyFriendsGrid.DataSource = list;
				MyFriendsGrid.DataBind();

				MyFriendsGrid.Visible = true;
			}
			else
			{
				MyFriendsGrid.Visible = false;
			}
		}

		private string GetAddress(Location location)
		{
			List<string> address = new List<string>();

			if (!string.IsNullOrEmpty(location.City))
				address.Add(location.City);

			address.Add(Enum.GetName(typeof(Country), location.Country));

			if (!string.IsNullOrEmpty(location.ZipCode))
				address.Add(location.ZipCode);


			string addressStr = string.Join(",", address.ToArray());
			return addressStr == "Unknown" ? string.Empty : addressStr;
		}

		private string GetSex(Gender gender)
		{
			switch (gender)
			{
				case Gender.Male:
					return "Male";
				case Gender.Female:
					return "Female";
				default :
					return "Unknown";
			}
		}
	}
}
