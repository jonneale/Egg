using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace BensBoxing.Domain.NHibernate.Mappings
{
    public class RecordMapping : ClassMap<Record>
    {
        public RecordMapping()
        {
            Id(x => x.Id);
            Map(x => x.Won);
            Map(x => x.Lost);
            Map(x => x.Drawn);
            Map(x => x.KO);
            Map(x => x.BoxerId);
        }
    }
}
