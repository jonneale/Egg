using System;
using System.ComponentModel.DataAnnotations;

namespace uSwitch.MvcBrownBag.Web.Core.Validation
{
    public class DateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var returnResult = false;

            if (value != null)
            {
                DateTime date;
                returnResult = DateTime.TryParse(value.ToString(), out date);
            }

            return returnResult;
        }
    }
}