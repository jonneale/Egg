using System.Collections.Generic;
using System.Linq;
using LiveNation.DAL.Model;
using NHibernate;

namespace LiveNation.DAL.CommandQuery
{
	public class AllArtistsQuery : IQuery<IEnumerable<Artist>>
	{
		public IEnumerable<Artist> Execute(ISession session)
		{
			var criteria = session.CreateCriteria(typeof(Artist));
			var list = criteria.List();

			return list.Cast<Artist>().ToArray();
		}
	}
}