using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.DAL.Model;
using NHibernate;

namespace LiveNation.DAL.CommandQuery
{
	public class InsertNewArtistCommand : ICommand
	{
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }

		public InsertNewArtistCommand(string name, DateTime dateOfBirth)
		{
			Name = name;
			DateOfBirth = dateOfBirth;
		}

		public void Execute(ISession session)
		{
			var artist = new Artist {Name = Name, DateOfBirth = DateOfBirth};
			session.SaveOrUpdate(artist);
		}
	}
}
