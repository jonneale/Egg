using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace uSwitch.Content.Domain.Persistance.NHibernate
{
	public class NHibernateConfiguration
	{
		private static ISessionFactory _factory;

		public static void Configure()
		{
			_factory = Fluently.Configure()
				.Database(SQLiteConfiguration.Standard
				          	.UsingFile("content.db")
				          	.ShowSql())
							.Mappings(x => x.AutoMappings.Add(GetAutoPersistenceModel()))
				.BuildSessionFactory();
		}

		private static AutoPersistenceModel GetAutoPersistenceModel()
		{


			return new AutoPersistenceModel().AddEntityAssembly(Assembly.GetExecutingAssembly())
				.Where(type => typeof (Entity).IsAssignableFrom(type)
				               && type.IsClass
							   && !type.IsAbstract)
				.Conventions.AddFromAssemblyOf<NHibernateConfiguration>();
		}

		public static ISessionFactory GetFactory()
		{
			return _factory;
		}
	}
}