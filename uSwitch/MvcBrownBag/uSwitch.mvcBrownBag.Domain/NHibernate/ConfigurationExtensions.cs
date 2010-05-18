using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace uSwitch.MvcBrownBag.Domain.NHibernate
{
	public static class ConfigurationExtensions
	{
		public static FluentConfiguration Sqlite(this FluentConfiguration configuration)
		{
			return configuration.Database(SQLiteConfiguration.Standard
											.ShowSql()
			                              	.UsingFile("music.db"));
		}

		public static FluentConfiguration MsSql(this FluentConfiguration configuration)
		{
			return configuration.Database(MsSqlConfiguration.MsSql2008
											.ConnectionString(c => c.FromConnectionStringWithKey("MusicDb")).ShowSql());
		}

		public static FluentConfiguration CreateSchema(this FluentConfiguration configuration)
		{
			return configuration.ExposeConfiguration(x =>
			                                  	{
			                                  		var update = new SchemaUpdate(x);
			                                  		update.Execute(true, false);
			                                  	});
		}
	}
}
