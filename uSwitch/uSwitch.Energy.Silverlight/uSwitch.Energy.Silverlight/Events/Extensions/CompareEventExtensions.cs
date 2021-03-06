using uSwitch.Energy.Silverlight.Model;

namespace uSwitch.Energy.Silverlight.Events.Extensions
{
	public static class CompareEventExtensions
	{
		public static ComparisonRequest ToRequest(this CompareEvent compareEvent)
		{
			return new ComparisonRequest
			       	{
			       		ElectricityPlanKey = compareEvent.ElectricityPlan.Key,
			       		ElectricitySupplierName = compareEvent.ElectricitySupplier.Name,
			       		GasPlanKey = compareEvent.GasPlan.Key,
			       		GasSupplierName = compareEvent.GasSupplier.Name,
			       		ComparisonPaymentMethod = compareEvent.ComparisonPaymentMethod,
			       		PostCode = compareEvent.Postcode,
			       		ElectricityPaymentMethod = compareEvent.ElectricityPaymentMethod,
			       		GasPaymentMethod = compareEvent.GasPaymentMethod,
			       		ElectricityAnnualConsumptionKwh = compareEvent.ElectricityAnnualConsumptionKwh,
			       		GasAnnualConsumptionKwh = compareEvent.GasAnnualConsumptionKwh,
                        ElectricityAnnualSpend = compareEvent.ElectricityAnnualSpend,
                        GasAnnualSpend = compareEvent.GasAnnualSpend,
			       		HasGas = compareEvent.HasGas,
			       		IsEconomy7 = compareEvent.IsEconomy7,
                        Ref = "uSwitch"
			       	};
		}
	}
}