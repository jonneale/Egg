using System;
using AutoMapper;
using MVC2Application.Web.PresentationModel;
using Customer=MVC2Application.Persistance.Domain.Customer;

namespace MVC2Application.Web {
	public class BootStrapper {
		public BootStrapper ConfigureAll() {
			SetupAutoMapper();

			return this;
		}

		public BootStrapper SetupNhibernate() {
			return this;
		}

		public BootStrapper SetupAutoMapper() {
			Mapper.CreateMap<Customer, PresentationModel.Customer>()
				.ForMember(d => d.Name, o => o.MapFrom(s => s.FirstName + " " + s.LastName));

			Mapper.CreateMap<CreateCustomer, Customer>()
				.ForMember(d => d.FirstName, o => o.MapFrom(s => s.Name.Split(' ')[0]))
				.ForMember(d => d.LastName, o => o.MapFrom(s => s.Name.Split(' ')[1]))
				.ConstructUsing(s => {
				                	var customer = new Customer(s.Name.Split(' ')[0], s.Name.Split(' ')[1], s.Email);
				                	return customer;
				                }
				);

			return this;
		}
	}
}