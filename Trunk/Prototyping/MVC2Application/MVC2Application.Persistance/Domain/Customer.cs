using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC2Application.Persistance.Domain {
	public class Customer {
		public virtual string FirstName {
			get; set;
		}

		public virtual string LastName {
			get; set;
		}

		public virtual string Email {
			get; set;
		}

		public Customer(string firstName, string lastName, string email) {
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}
	}
}