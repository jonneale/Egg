using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace LiveNation.Testing.AcceptanceTests.General
{
	public class UrlFinder
	{
		private readonly IDictionary<string, string> _pageToUrlDictionary;

		public UrlFinder()
		{
			_pageToUrlDictionary = GetAllPageUrls();
		}

		public string FromPageName(string pageName)
		{
			return _pageToUrlDictionary[pageName];
		}

		private static IDictionary<string, string> GetAllPageUrls()
		{
			Stream resource = System.Reflection.Assembly.GetExecutingAssembly()
				.GetManifestResourceStream("LiveNation.Testing.AcceptanceTests.General.PageNameToUrl.xml");

			if (resource != null)
			{
				return GetDictionairyFromStream(resource);
			}

			throw new NullReferenceException("Could not not a LiveNation.Testing.AcceptanceTests.General.PageNameToUrl.xml embedded resource");
		}

		private static IDictionary<string, string> GetDictionairyFromStream(Stream resource)
		{
			XmlReader reader = XmlReader.Create(resource);
			var xml = XDocument.Load(reader);
			var pageNameAndUrls = xml.Descendants("page")
				.Select(x => new { Name = (string)x.Attribute("name"), Url = (string)x.Attribute("url") });

			return pageNameAndUrls.ToDictionary(x => x.Name, y => y.Url);
		}
	}
}
