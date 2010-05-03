using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Facebook.Entity;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Facebook.Extended
{
	public class FacebookConnect : IFacebookConnect
	{
		private IFacebookApi _api;
		private bool _authenicated;

		public static readonly string CacheKey = "Facebook.Extended.IFacebookConnect";

		public bool Authenicated
		{
			get
			{
				return _authenicated;
			}
		}

		public User CurrentUser
		{
			get
			{
				try
				{
					return _api.GetUserInfo();
				}
				catch (Exception inner)
				{
					throw new FacebookException(inner);
				}
			}
		}

		public IList<User> GetFriends()
		{
			try
			{
				return _api.GetFriends();
			}
			catch (Exception inner)
			{
				throw new FacebookException(inner);
			}
		}

		public ICollection<string> RegisterUsers(ICollection<string> emailAddresses)
		{
			var memory = new MemoryStream();
			var hashedEmails = new List<RegisterEmail>();

			foreach (var email in emailAddresses)
			{
				var hashedEmail = new RegisterEmail { HashedEmail = EmailHash(email) };
				hashedEmails.Add(hashedEmail);
			}
			var serializer = new DataContractJsonSerializer(typeof(RegisterEmail[]));
			serializer.WriteObject(memory, hashedEmails.ToArray());

			string json = Encoding.Default.GetString(memory.ToArray());

			IDictionary<string, string> parameters = new Dictionary<string, string>(1);
			parameters.Add("method", "connect.registerUsers");
			parameters.Add("accounts", json);

			XDocument returnXml = _api.ExecuteApiRequest(parameters, false);

			var hashes = from hashNode in returnXml.Descendants(XName.Get("connect_registerUsers_response_elt", "http://api.facebook.com/1.0/"))
						 select hashNode.Value;

			return hashes.ToList();
		}

		public FacebookConnect(IFacebookApi api, bool authenicated)
		{
			_api = api;
			_authenicated = authenicated;
		}

		public static IFacebookConnect GetCurrent(IDictionary cache)
		{
			return cache[CacheKey] as IFacebookConnect;
		}

		public static IFacebookConnect GetCurrent(IDictionary<object, object> cache)
		{
			return cache[CacheKey] as IFacebookConnect;
		}

		public static string EmailHash(string email)
		{
			email = email.ToLower().Trim();
			byte[] rawBytes = System.Text.UTF8Encoding.UTF8.GetBytes(email);

			CRC32 crc = new CRC32();
			UInt32 crcResult = crc.GetCrc32(new System.IO.MemoryStream(rawBytes));

			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] md5Result = md5.ComputeHash(rawBytes);
			string md5Data = ToHexString(md5Result).ToLower();

			return crcResult.ToString() + "_" + md5Data;
		}

		public static string ToHexString(byte[] bytes)
		{
			string hexString = "";
			for (int i = 0; i < bytes.Length; i++)
			{
				hexString += bytes[i].ToString("X2");
			}
			return hexString;
		}
	}

	#region
	[DataContract]
	public class RegisterEmail
	{
		[DataMember(Name = "email_hash")]
		public string HashedEmail
		{
			set;
			get;
		}
	}
	#endregion
}
