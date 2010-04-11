using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using uSwitch.Content.Domain.Persistance.NHibernate;

namespace uSwitch.Content.IntegrationTests.Nhibernate
{
	public class SqliteTestBase
	{
		[SetUp]
		public void Setup()
		{
			NHibernateConfiguration.Configure();
		}
	}
}
