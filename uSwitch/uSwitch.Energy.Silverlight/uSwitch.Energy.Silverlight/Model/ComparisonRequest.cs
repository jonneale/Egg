namespace uSwitch.Energy.Silverlight.Model
{
    public class ComparisonRequest
    {
        public string ElectricityPaymentMethod { get; set; }

        public string PostCode { get; set; }

        public string ElectricityPlanKey { get; set; }

        public string ElectricitySupplierName { get; set; }

        public double ElectricityAnnualConsumptionKwh { get; set; }

        public double GasAnnualConsumptionKwh { get; set; }

        public bool HasGas { get; set; }

        public bool IsEconomy7 { get; set; }

        public string GasSupplierName { get; set; }

        public string GasPlanKey { get; set; }

        public string ComparisonPaymentMethod { get; set; }

        public string GasPaymentMethod { get; set; }

        public double GasMonthlySpend { get; set; }
    }
}