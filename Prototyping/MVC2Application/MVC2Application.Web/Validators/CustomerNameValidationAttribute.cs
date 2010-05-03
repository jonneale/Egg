using System;
using System.ComponentModel.DataAnnotations;
using MVC2Application.Web.PresentationModel;

namespace MVC2Application.Web.Validators {
	public class CustomerNameValidationAttribute : ValidationAttribute {
		public override bool IsValid(object value) {
			var customerName = value as string;

			if (customerName.Split(' ').Length != 2) {
				return false;
			}

			return true;
		}
	}
}