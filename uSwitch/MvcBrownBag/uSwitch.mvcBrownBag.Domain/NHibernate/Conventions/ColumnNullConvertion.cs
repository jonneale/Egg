using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace uSwitch.MvcBrownBag.Domain.NHibernate.Conventions
{
    public class ColumnNullConvertion : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Property.MemberInfo.IsDefined(typeof(NullAttribute), false))
            {
                instance.Nullable();
            } else
            {
                instance.Not.Nullable();
            }
        }
    }

    public class NullAttribute : Attribute
    {

    }
}
