using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Environment=System.Environment;

namespace LiveNation.DAL
{
	public class ConfigureNhibernate
	{
		private ISessionFactory sessionFactory;

		public string GetDbFilePath()
		{
			return Path.Combine(Environment.CurrentDirectory, "firstProject.db");
		}

		public ConfigureNhibernate()
		{
			
		}

		public ISessionFactory CreateSessionFactory()
		{
			if (sessionFactory == null)
			{
				sessionFactory = Fluently.Configure().Database(
					MsSqlConfiguration.MsSql2005
						.ConnectionString(x => x.FromConnectionStringWithKey("LiveNationConnectionString")))
					.Mappings(m => m.FluentMappings.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly())).
					BuildSessionFactory();
			}

			return sessionFactory;
			//return Fluently.Configure()
			//  .Database(
			//    SQLiteConfiguration.Standard
			//      .UsingFile(GetDbFilePath())
			//  )
			//  .Mappings(m =>
			//    m.FluentMappings.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly()))
			//    //.ExposeConfiguration(BuildSchema)
			//  .BuildSessionFactory();
		}

		protected void BuildSchema(Configuration config)
		{
			//delete the existing db on each run
			if (File.Exists(GetDbFilePath()))
			    File.Delete(GetDbFilePath());
			
			// this NHibernate tool takes a configuration (with mapping info in)
			// and exports a database schema from it
			new SchemaExport(config)
			  .Create(false, true);
		}
	}
}
