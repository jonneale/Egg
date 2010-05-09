using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BensBoxing.Domain
{
    public class Boxer : Entity
    {
        public virtual string FirstName
        {
            get;
            set;
        }

        public virtual string LastName
        {
            get;
            set;
        }

        public virtual DateTime DateOfBirth
        {
            get;
            set;
        }

        public virtual ICollection<Match> Matches
        {
            get;
            set;
        }
		public virtual Record Record
		{
			get; set;
		}
    }
}
