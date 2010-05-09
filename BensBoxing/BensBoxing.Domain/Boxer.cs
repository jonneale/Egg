using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BensBoxing.Domain
{
    public class Boxer
    {
        public virtual int Id
        {
            get;
            protected set;
        }

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
    }
}
