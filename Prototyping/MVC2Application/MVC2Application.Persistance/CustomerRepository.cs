using System.Collections.Generic;
using System.Linq;
using MVC2Application.Persistance.Domain;

namespace MVC2Application.Web.Core.Persistance {
	public class CustomerRepository {
		private static CustomerRepository _current;

		private List<Customer> _internalList;

		protected CustomerRepository() {
			
		}

		public static CustomerRepository GetSingleton() {
			if (_current == null) {
				_current = new CustomerRepository();
				_current._internalList = (new[] {
				                                	new Customer("James", "Williamson", "jwilliamson@gmail.com"),
													new Customer("Nicky", "Williamson", "nicky.williamson@hotmail.com")
				                                }).ToList();
			}
			return _current;
		}


		public IEnumerable<Customer> All() {
			return _internalList.AsEnumerable();
		}

		public void Add(Customer customer) {
			_internalList.Add(customer);
		}
	}
}