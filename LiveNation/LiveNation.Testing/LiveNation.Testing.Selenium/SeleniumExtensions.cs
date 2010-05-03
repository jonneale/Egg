using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using Selenium;

namespace LiveNation.Selenium.Domain.Acceptance
{
	public static class SeleniumExtensions
	{
		private static readonly int PageLoadTimeout = 30000;

		public static ISelenium ClickAndWait(this ISelenium selenium, string locator)
		{
			selenium.Click(locator);
			selenium.WaitForPageToLoad(PageLoadTimeout.ToString());
			return selenium;
		}

		public static ISelenium ClickButtonWithText(this ISelenium selenium, string text)
		{
			return selenium.ClickAndWait(string.Format("//input[@value='{0}']", text));
		}

		public static ISelenium WaitForText(this ISelenium selenium, string text)
		{
			return WaitForCondition(selenium, () => selenium.IsTextPresent(text));
		}

		public static ISelenium WaitForElement(this ISelenium selenium, string locator)
		{
			return WaitForCondition(selenium, () => selenium.IsElementPresent(locator));
		}

		public static ISelenium AssertTextPresent(this ISelenium selenium, string text)
		{
			Assert.IsTrue(selenium.IsTextPresent(text));
			return selenium;
		}

		public static ISelenium OpenAndWait(this ISelenium selenium, string url)
		{
			selenium.Open(url);
			selenium.WaitForPageToLoad(PageLoadTimeout.ToString());
			return selenium;
		}

		public static ISelenium AndWaitForPageToLoad(this ISelenium selenium)
		{
			selenium.WaitForPageToLoad(PageLoadTimeout.ToString());
			return selenium;
		}

		public static ISelenium AssertElementPresent(this ISelenium selenium, string locator)
		{
			Assert.IsTrue(selenium.IsElementPresent(locator));
			return selenium;
		}

		private static ISelenium WaitForCondition(ISelenium selenium, Func<bool> condition)
		{
			int maxCount = PageLoadTimeout / 1000;
			for (int i = 0; i < maxCount; i++)
			{
				try
				{
					if (condition())
					{
						return selenium;
					}
				}
				catch
				{

				}
				Thread.Sleep(1000);
			}

			Assert.Fail("Timeout");
			return selenium;
		}

		public static ISelenium ClearBrowserSession(this ISelenium selenium)
		{
			selenium.DeleteAllVisibleCookies();
			return selenium;
		}
	}
}
