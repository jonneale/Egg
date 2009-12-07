using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Facebook.Extended
{
	public class FacebookConfig : ConfigurationSection
	{
		public string TempUploadDirectory
		{
			get
			{
				return ConfigurationManager.AppSettings["TempUploadDirectory"];
			}
		}

		[ConfigurationProperty("applicationID", DefaultValue = "", IsRequired = true)]
		public string ApplicationID
		{
			set
			{
				this["applicationID"] = value;
			}
			get
			{
				return this["applicationID"] as string;
			}
		}

		[ConfigurationProperty("applicationUrl", DefaultValue = "", IsRequired = false)]
		public string ApplicationUrl
		{
			set
			{
				this["applicationUrl"] = value;
			}
			get
			{
				return this["applicationUrl"] as string;
			}
		}

		[ConfigurationProperty("restUrl", DefaultValue = "", IsRequired = false)]
		public string RestUrl
		{
			get
			{
				return this["restUrl"] as string;
			}
			set
			{
				this["restUrl"] = value;
			}
		}

		[ConfigurationProperty("namespace", DefaultValue = "", IsRequired = false)]
		public string NameSpace
		{
			get
			{
				return this["namespace"] as string;
			}
			set
			{
				this["namespace"] = value;
			}
		}

		[ConfigurationProperty("applicationkey", DefaultValue = "", IsRequired = true)]
		public string ApplicationKey
		{
			get
			{
				return this["applicationkey"] as string;
			}
			set
			{
				this["applicationkey"] = value;
			}
		}

		[ConfigurationProperty("secretkey", DefaultValue = "", IsRequired = true)]
		public string SecretKey
		{
			get
			{
				return this["secretkey"] as string;
			}
			set
			{
				this["secretkey"] = value;
			}
		}

		[ConfigurationProperty("enablenotifications", DefaultValue = true, IsRequired = false)]
		public bool EnableNotifications
		{
			get
			{
				return (bool)this["enablenotifications"];
			}
			set
			{
				this["enablenotifications"] = value;
			}
		}

		public static FacebookConfig GetConfig()
		{
			return ConfigurationManager.GetSection("facebook") as FacebookConfig;
		}
	}
}
