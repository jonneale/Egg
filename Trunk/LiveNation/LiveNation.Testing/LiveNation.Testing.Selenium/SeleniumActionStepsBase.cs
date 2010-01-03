using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain;
using LiveNation.Testing.Domain.IOC;
using LiveNation.Testing.Selenium.Config;
using LiveNation.Testing.Selenium.IOC;
using NBehave.Narrator.Framework;
using NUnit.Framework;
using Selenium;

namespace LiveNation.Testing.Selenium
{
	public abstract class SeleniumActionStepsBase
	{
		protected SeleniumContext Context
		{
			get 
			{
				var context = ServiceLocater.GetInstance<SeleniumContext>();
				if (!context.IsContextOpen)
				{
					context.Open();
				}
				return context;
			}
		}

		public ISelenium Selenium
		{
			get
			{
				return Context.Selenium;
			}
		}

		public ISelenium selenium
		{
			get
			{
				return Context.Selenium;
			}
		}

		public void SaveScreenShot()
		{
			string fileName = Path.Combine(Environment.CurrentDirectory,
			                               string.Format("{0}-{1:dd-MM-yyyy-hhmm}.{2}", GetType().Name, DateTime.Now, "jpg")
				);

			int counter = 2;
			while (File.Exists(fileName))
			{
				fileName = string.Format("{0}-{1}.{2}", Path.GetFileNameWithoutExtension(fileName), counter, "jpg");
				counter++;
			}

			Selenium.CaptureEntirePageScreenshot(fileName, "");
		}

		public IAppConfig Config
		{
			get;
			set;
		}

		static SeleniumActionStepsBase()
		{
			new BootScrapper().Configure();
		}

		[AfterScenario]
		public void CloseContext()
		{
			Context.Close();
		}
	}
}