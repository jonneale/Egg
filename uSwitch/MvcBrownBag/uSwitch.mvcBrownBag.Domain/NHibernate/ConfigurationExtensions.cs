using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
                                                    using (var connection = new SqlConnection(
                                                            ConfigurationManager.ConnectionStrings["MusicDb"].ConnectionString))
                                                    {
                                                        connection.Open();
                                                        new SchemaExport(x).Execute(true, true, false, connection, null);
                                                    }
			                                  	});
		}

        public static FluentConfiguration UpdateSchema(this FluentConfiguration configuration)
        {
            return configuration.ExposeConfiguration(x =>
            {
                using (var connection = new SqlConnection(
                        ConfigurationManager.ConnectionStrings["MusicDb"].ConnectionString))
                {
                    connection.Open();
                    new SchemaUpdate(x).Execute(true, true);
                }
            });
        }
	}
}
