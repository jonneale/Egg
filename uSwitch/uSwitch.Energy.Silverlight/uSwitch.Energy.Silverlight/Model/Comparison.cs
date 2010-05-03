namespace uSwitch.Energy.Silverlight.Model
{
    public class Comparison
    {
        public string ComparsionId
        {
            get; set;
        }

        public string CompareUrl
        {
            get; set;
        }

        public string PartnerReference
        {
            get; set;
        }

        public ComparisonResult[] ComparisonResults
        {
            get; set;
        }
    }
}