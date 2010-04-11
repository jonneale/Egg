using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Testing;
using NUnit.Framework;

namespace uSwitch.Content.IntegrationTests.Nhibernate
{
	[TestFixture]
	public class ContentMappingTest : SqliteTestBase
	{
		[Test]
		public void CanCorrectlyMapEmployee()
		{
			new PersistenceSpecification<ContentBase>(session)
				.CheckProperty(c => c.Id, 1)
				.CheckProperty(c => c.FirstName, "John")
				.CheckProperty(c => c.LastName, "Doe")
				.VerifyTheMappings();
		}
	}
}
