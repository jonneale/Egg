using AutoMapper;

namespace MVC2Application.Web.PresentationModel.Extensions {
	public static class CreateCustomerExtensions {
		public static Persistance.Domain.Customer ToCustomer(this CreateCustomer customer) {
			var domainCustomer = Mapper.Map<CreateCustomer, Persistance.Domain.Customer>(customer);
			return domainCustomer;
		}
	}
}