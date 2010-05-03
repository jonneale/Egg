using System.Collections.Generic;

namespace uSwitch.Energy.Silverlight.Model
{
    public class Tariff
    {
        public double StandingCharge { get; set; }

        public IEnumerable<Rate> Rates { get; set;}
    }
}