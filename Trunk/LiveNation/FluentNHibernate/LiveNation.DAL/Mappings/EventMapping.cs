using FluentNHibernate.Mapping;
using LiveNation.DAL.Model;

namespace LiveNation.DAL.Mappings
{
	public class EventMapping : SubclassMap<Event>
	{
		public EventMapping()
		{
			KeyColumn("Id");
			Map(x => x.DateOfEvent).Nullable();

			HasManyToMany(x => x.Artists)
				.Table("ArtistToEvent")
				.ParentKeyColumn("EventId")
				.ChildKeyColumn("ArtistId");
		}
	}
}
