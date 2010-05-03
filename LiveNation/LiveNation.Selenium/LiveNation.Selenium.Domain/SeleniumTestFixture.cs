using System;
using System.IO;
using System.Text;
using LiveNation.Selenium.Domain.Factories;
using LiveNation.Selenium.Domain.Model;
using NUnit.Framework;
using Selenium;

namespace LiveNation.Selenium.Domain
{
    [TestFixture]
    public abstract class SeleniumTestFixture
    {
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
            set;
            get;
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

        static SeleniumTestFixture()
        {
            BootStapper.Configure();
            SeleniumFactory = ServiceLocater.GetInstance<ISeleniumFactory>();
        }

		public SeleniumTestFixture()
		{
			Config = ServiceLocater.GetInstance<IAppConfig>();
		}

        [TearDown]
        public void Teardown()
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
        }

        [SetUp]
        public void NUnitTestSetup()
        {
			//Environment.GetEnvironmentVariable("", EnvironmentVariableTarget.

            selenium = SeleniumFactory.CreateInstance(new BrowserClient {Address = "localhost", Port = 4444},
                                                          new BrowserSetup("*firefox", 
                                                          new Uri("http://www.livenation.co.uk/")));
            StartTest();
        }

        public void StartTest()
        {
            selenium.Start();
            verificationErrors = new StringBuilder();
        }
    }
}
