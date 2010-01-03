using System;
using System.Collections.Generic;
using System.Linq;
using LiveNation.DAL.CommandQuery;
using LiveNation.DAL.Model;
using NHibernate;

namespace LiveNation.DAL
{
	static class Program
	{
		public static ISession CurrentSession;

		public static ISession GetCurrentSession()
		{
			if (CurrentSession == null)
			{
				var configure = new ConfigureNhibernate();
				var sessionFactory = configure.CreateSessionFactory();
				CurrentSession = sessionFactory.OpenSession();
			}

			return CurrentSession;
		}

		static void Main()
		{
			Console.WriteLine("Lets start this bitch");

			//CreateArtists(sessionFactory);
			//RunCommand(sessionFactory, new InsertNewArtistCommand("Tupac", new DateTime(1973, 6, 5)));
			var result = RunQuery(new AllEventsQuery());
			result.ToList().ForEach(x =>
			                        	{
			                        		Console.WriteLine("Event name: {0}", x.Name);
											Console.WriteLine("Artist count : {0}", x.Artists.Count);
			                        	});

			Console.WriteLine("Press enter to continue");

			Console.ReadLine();
			CurrentSession.Flush();
			CurrentSession.Close();
		}

		private static void RunCommand(ICommand command)
		{
			command.Execute(GetCurrentSession());
		}

		private static TReturn RunQuery<TReturn>(IQuery<TReturn> query)
		{
			return query.Execute(GetCurrentSession());
		}
	}
}