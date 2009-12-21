using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium;

namespace LiveNation.Selenium.Domain.Utilities
{
	public static class SeleniumExtensions
	{
		public static void ClearBrowserSession(this ISelenium selenium)
		{
			selenium.DeleteAllVisibleCookies();
		}
	}
}
