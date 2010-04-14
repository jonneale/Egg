using System;
using System.Collections.Generic;

namespace uSwitch.Energy.Silverlight.Model
{
    public struct Products
    {
        public const string Gas = "gas";
        public const string Electricity = "electricity";

        public static IEnumerable<string> GetAll()
        {
            return new[] {Gas, Electricity};
        }
    }
}
