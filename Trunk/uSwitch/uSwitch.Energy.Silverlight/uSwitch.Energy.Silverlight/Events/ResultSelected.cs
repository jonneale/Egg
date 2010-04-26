using uSwitch.Energy.Silverlight.Core;

namespace uSwitch.Energy.Silverlight.Events
{
    public class ResultSelected : IEvent
    {
        public string SupplierName { get; set; }
        public string PlanName { get; set; }
    }
}