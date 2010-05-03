using System.Collections.Generic;

namespace uSwitch.Energy.Silverlight.Model
{
    public struct PaymentMethods
    {
        public const string FixedMonthlyDirectDebit = "Fixed Monthly Direct Debit";
        public const string PayOnReceiptOfBill = "Pay On Receipt Of Bill";
        public const string PrepaymentMeter = "Prepayment Meter";
        public const string RegularPaymentScheme = "Regular Payment Scheme";
        public const string VariableDirectDebit = "Variable Direct Debit";

        public static IEnumerable<string> GetAll()
        {
            return new[]
                       {
                           FixedMonthlyDirectDebit, PayOnReceiptOfBill, PrepaymentMeter, RegularPaymentScheme,
                           VariableDirectDebit
                       };
        }
    }
}
