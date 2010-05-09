using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace BensBoxing.Domain.NHibernate
{
    public static class Configure
    {
        private static ISessionFactory _sessionFactory;

        public static void Setup()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(cs => cs.FromConnectionStringWithKey("BensBoxing")
                ))
                .Mappings(m =>
                  m.FluentMappings.AddFromAssemblyOf<Boxer>())
                .BuildSessionFactory();
        }

        public static ISessionFactory GetSessionFactory()
        {
            return _sessionFactory;
        }
    }
}
