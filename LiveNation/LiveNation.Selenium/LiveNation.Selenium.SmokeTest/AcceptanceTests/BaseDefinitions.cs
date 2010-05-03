using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using LiveNation.Selenium.Domain;
using LiveNation.Selenium.Domain.Factories;
using LiveNation.Selenium.Domain.Model;
using NUnit.Framework;
using Selenium;

namespace LiveNation.Selenium.SmokeTest.AcceptanceTests
{
    public abstract class BaseDefinitions
    {
        protected ISelenium _selenium;

        protected static ISeleniumFactory SeleniumFactory
        {
            get; set;
        }
        protected StringBuilder verificationErrors
        {
            get; 
            set;
        }

        protected ISelenium selenium
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
            BootStapper.Configure();
            SeleniumFactory = ServiceLocater.GetInstance<ISeleniumFactory>();
        }

        protected BaseDefinitions()
		{
			Config = ServiceLocater.GetInstance<IAppConfig>();
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
            Assert.AreEqual("", verificationErrors.ToString());

            _selenium = null;
            verificationErrors = null;
        }

        protected void CreateNewInstanceOfBrowser()
        {
			//Environment.GetEnvironmentVariable("", EnvironmentVariableTarget.
            _selenium = SeleniumFactory.CreateInstance(new BrowserClient { Address = "localhost", Port = 4444 },
                                                          new BrowserSetup("*firefox", 
                                                          new Uri("http://www.livenation.co.uk/")));

            selenium.Start();
            verificationErrors = new StringBuilder();
        }
    }
}
