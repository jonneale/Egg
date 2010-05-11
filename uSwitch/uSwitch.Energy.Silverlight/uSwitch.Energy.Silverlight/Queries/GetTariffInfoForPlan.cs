using System;
using uSwitch.Energy.Silverlight.Model;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Queries
{
    public class GetTariffInfoForPlan : IAsyncQuery<Tariff>
    {
        private const string RestUrl =
            Rest.Rest.BaseUrl + "/gas-electricity/regions/{0}/products/{1}/suppliers/{2}/payment-methods/{3}/plans/{4}/tariff/";

        private readonly string _supplier;
        private readonly string _planKey;
        private readonly string _paymentMethod;
        private readonly string _product;
        private readonly string _region;

        public GetTariffInfoForPlan(string supplier, string planKey, string paymentMethod, string product, string region)
        {
            _supplier = supplier.Replace(" ", "%20").ToLower();
            _planKey = planKey.ToLower();
            _paymentMethod = paymentMethod.ToLower();
            _product = product;
            _region = region;
        }

        public string PlanKey
        {
            get { return _planKey; }
        }

        public string Region
        {
            get { return _region; }
        }

        public string Product
        {
            get { return _product; }
        }

        public string PaymentMethod
        {
            get { return _paymentMethod; }
        }

        public string Supplier
        {
            get { return _supplier; }
        }

        public void Execute(IRestClient client, Action<Tariff> queryCallback)
        {
            client.Get(new Uri(string.Format(RestUrl, Region, Product, Supplier, PaymentMethod.Replace(" ", "%20"), PlanKey)), queryCallback);
        }
    }
}