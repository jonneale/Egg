using System;
namespace Facebook.Extended
{
	public interface IHttpAuthenication
	{
		bool IsConnected();
		void Authenicate(IFacebookApi api);
	}
}
