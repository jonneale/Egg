using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace BensBoxing.Domain.NHibernate.Mappings
{
    public class BoxerMapping : ClassMap<Boxer>
    {
        public BoxerMapping()
        {
            Id(x => x.Id);
        	Map(x => x.DateOfBirth);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        	HasOne(x => x.Record);
            HasManyToMany(x => x.Matches)
                .Table("Boxer_Match")
                .ParentKeyColumn("boxerid")
                .ChildKeyColumn("matchid")
                .AsSet()
                .Cascade.All();
        }
    }
}
