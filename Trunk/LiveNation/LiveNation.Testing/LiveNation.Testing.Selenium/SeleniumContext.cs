using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using LiveNation.Testing.Selenium.Factories;
using LiveNation.Testing.Selenium.Model;
using Selenium;

namespace LiveNation.Testing.Selenium
{
	public class SeleniumContext : IDisposable
	{
		private readonly ISeleniumFactory _seleniumFactory;
		private bool _contextOpen;
		private readonly IDictionary<string, object> _contextItems = new Dictionary<string, object>();

		public TReturn GetItem<TReturn>(string key)
		{
			if (!_contextItems.ContainsKey(key))
			{
				return default(TReturn);
			}

			return (TReturn) _contextItems[key];
		}

		public void SetItem(string key, object item)
		{
			_contextItems.Add(key, item);
		}

		public bool IsContextOpen
		{
			get
			{
				return _contextOpen;
			}
		}

		public ISelenium Selenium
		{
			get; set;
		}

		public SeleniumContext(ISeleniumFactory seleniumFactory)
		{
			_seleniumFactory = seleniumFactory;
		}

		public void Open()
		{
			if (Selenium == null)
			{
				Selenium = _seleniumFactory.CreateInstance(new BrowserClient {Address = "localhost", Port = 4444},
				                                           new BrowserSetup("*firefox",
				                                                            new Uri("http://www.livenation.co.uk/")));
			}

			Selenium.Start();
			_contextOpen = true;
		}

		public void Close()
		{
			_contextOpen = false;
			if (Selenium == null)
			{
				return;
			}
			Selenium.Stop();
		}

		public void Dispose()
		{
			Close();
		}
	}
}