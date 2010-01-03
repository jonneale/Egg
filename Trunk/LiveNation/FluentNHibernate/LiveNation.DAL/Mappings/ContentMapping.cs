using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using LiveNation.DAL.Model;

namespace LiveNation.DAL.Mappings
{
	public class ContentMapping : ClassMap<Content>
	{
		public ContentMapping()
		{
			Id(x => x.Id);
			Map(x => x.Name);
		}
	}
}
