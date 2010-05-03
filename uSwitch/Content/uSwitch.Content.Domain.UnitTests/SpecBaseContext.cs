using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace uSwitch.Content.Domain.UnitTests
{
	public abstract class SpecBaseContext<TSubject>
	{
		public TSubject Subject
		{
			get; private set;
		}

		public abstract TSubject CreateSubject();

		[SetUp]
		public void SetUpTest()
		{
			EstablishContext();
			Subject = CreateSubject();
			When();
		}

		public virtual void CleanUp()
		{
			
		}

		[TearDown]
		public void TearDownTest()
		{
			CleanUp();
		}

		protected virtual void When()
		{
			
		}

		public virtual void EstablishContext()
		{
			
		}
	}
}
