using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BensBoxing.Domain
{
    public class Record : Entity
    {
        public virtual int Won
        {
            get;
            set;
        }
        public virtual int Lost
        {
            get;
            set;
        }
        public virtual int Drawn
        {
            get;
            set;
        }
        public virtual int KO
        {
            get;
            set;
        }
		public virtual Boxer Boxer
		{
			get; set;
		}
    }
}
