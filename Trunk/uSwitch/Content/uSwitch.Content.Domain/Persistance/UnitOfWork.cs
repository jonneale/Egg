using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace uSwitch.Content.Domain.Persistance
{
	public class UnitOfWork : IDisposable
	{
		private readonly ISession _session;
		private ITransaction _transaction;

		public UnitOfWork(ISession session)
		{
			_session = session;
		}

		public void Begin()
		{
			_transaction = _session.BeginTransaction();
		}



		public void Dispose()
		{
			
		}
	}
}
