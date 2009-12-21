using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain;
using LiveNation.Selenium.Domain.Factories;
using LiveNation.Selenium.Domain.Model;
using LiveNation.Testing.Domain.IOC;
using NUnit.Framework;
using Selenium;

namespace LiveNation.Selenium.Domain.Acceptance
{
    public abstract class BaseDefinitions
    {
		protected static ISelenium _selenium;
    	protected static StringBuilder _verificationErrors;

        protected static ISeleniumFactory SeleniumFactory
        {
            get
            {
            	return ServiceLocater.GetInstance<ISeleniumFactory>();
            }
        }

		protected static StringBuilder verificationErrors
        {
            get
            {
            	if (_verificationErrors == null)
            	{
            		_verificationErrors = new StringBuilder();
            	}
            	return _verificationErrors;
            }
        }

        protected static ISelenium selenium
        {
            get
            {
                if (_selenium == null)
                {
                    CreateNewInstanceOfBrowser();
                }
                return _selenium;
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

            selenium.CaptureEntirePageScreenshot(fileName, "");
        }

        public IAppConfig Config
        {
            get;
            set;
        }

        static BaseDefinitions()
        {
            new IOC.BootScrapper().Configure();
        }

        public void CloserBrowserAndAssertVerifies()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual(string.Empty, verificationErrors.ToString());

            _selenium = null;
			_verificationErrors = null;
        }

        protected static void CreateNewInstanceOfBrowser()
        {
            _selenium = SeleniumFactory.CreateInstance(new BrowserClient { Address = "localhost", Port = 4444 },
                                                          new BrowserSetup("*firefox",
                                                          new Uri("http://www.livenation.co.uk/")));

            selenium.Start();
        }
    }
}
