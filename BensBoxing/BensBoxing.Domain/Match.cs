using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BensBoxing.Domain
{
    public class Match : Entity
    {
        public virtual DateTime MatchDate
        {
            get;
            set;
        }

        public virtual ICollection<Boxer> Boxers
        {
            get;
            set;
        }

        public virtual string Location
        {
            get;
            set;
        }
    }
}
