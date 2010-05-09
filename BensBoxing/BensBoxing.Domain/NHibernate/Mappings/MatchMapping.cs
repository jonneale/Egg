using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace BensBoxing.Domain.NHibernate.Mappings
{
    public class MatchMapping : ClassMap<Match>
    {
        public MatchMapping()
        {
            Id(x => x.Id);
            Map(x => x.Location);
            Map(x => x.MatchDate);
            HasManyToMany(x => x.Boxers)
                .Table("Boxer_Match")
                .ParentKeyColumn("matchid")
                .ChildKeyColumn("boxerid")
                .AsSet()
                .Cascade.All();
        }
    }
}
