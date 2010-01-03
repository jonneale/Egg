using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Testing.Domain.IOC;
using Selenium;

namespace LiveNation.Testing.AcceptanceTests.General
{
	public static class SeleniumExtensions
	{
		private static UrlFinder UrlFinder
		{
			get
			{
				return ServiceLocater.GetInstance<UrlFinder>();
			}
		}

		static SeleniumExtensions()
		{
			ServiceLocater.GetContainer().Configure(x => x.ForRequestedType<UrlFinder>()
				.TheDefault.Is.OfConcreteType<UrlFinder>());
		}

		public static ISelenium NavigateToPage(this ISelenium selenium, string pageName)
		{
			selenium.Open(UrlFinder.FromPageName(pageName));
			return selenium;
		}
	}
}
