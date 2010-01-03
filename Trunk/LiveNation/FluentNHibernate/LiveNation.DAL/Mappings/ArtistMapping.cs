using FluentNHibernate.Mapping;
using LiveNation.DAL.Model;

namespace LiveNation.DAL.Mappings
{
	public class ArtistMapping : SubclassMap<Artist>
	{
		public ArtistMapping()
		{
			KeyColumn("Id");
			Map(x => x.DateOfBirth);

			HasManyToMany(x => x.Events)
				.Table("ArtistToEvent")
				.ParentKeyColumn("ArtistId")
				.ChildKeyColumn("EventId");

			Component(x => x.Details, m =>
			                          	{
			                          		m.Map(x => x.Content).Column("Details");
			                          	}
				);
		}
	}
}