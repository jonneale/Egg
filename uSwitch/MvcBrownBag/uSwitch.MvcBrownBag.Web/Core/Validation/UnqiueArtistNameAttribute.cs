using System;
using System.Linq;

namespace uSwitch.MvcBrownBag.Web.Core.Validation
{
    public class UnqiueArtistNameAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        private readonly string[] _existingNames = new[] {"John", "Daniel"};

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string artistName = value.ToString();
            return !_existingNames.Any(x => x.Equals(artistName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}