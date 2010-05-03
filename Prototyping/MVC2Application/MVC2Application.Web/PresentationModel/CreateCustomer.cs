using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVC2Application.Web.Validators;

namespace MVC2Application.Web.PresentationModel {
	[DisplayName("Customer")]
	public class CreateCustomer {
		[Required(ErrorMessage = "I must have a name")]
		[CustomerNameValidation(ErrorMessage = "Name is entered wrong, eg Steve Smith")]
		public string Name {
			get; set;
		}

		[Required(ErrorMessage = "I must have a email")]
		public string Email {
			get; set;
		}
	}
}