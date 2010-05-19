using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Config = NHibernate.Cfg.Configuration;
using NHibernate.Tool.hbm2ddl;
using uSwitch.MvcBrownBag.Domain;
using uSwitch.MvcBrownBag.Domain.IOC;

namespace uSwitch.MvcBrownBag.Domain.NHibernate
{
	public static class Configuration
	{
		private static ISessionFactory _factory;
		private static Config _config;

		public static void Setup()
		{

			_factory = Fluently.Configure()
				.MsSql()
				.Mappings(x => 
					x.AutoMappings.Add(
					AutoMap.AssemblyOf<Entity>().Where(t => t.IsSubclassOf(typeof(Entity)))
						.Conventions.AddFromAssemblyOf<Entity>()))
					.ExposeConfiguration(x =>
					                     	{
					                     		_config = x;
					                     	})
					.UpdateSchema()
				.BuildSessionFactory();
		}

		public static ISessionFactory GetSessionFactory()
		{
			return _factory;
		}
	}
}