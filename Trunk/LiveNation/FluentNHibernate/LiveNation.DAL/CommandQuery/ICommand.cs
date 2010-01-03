using NHibernate;

namespace LiveNation.DAL.CommandQuery
{
	public interface ICommand
	{
		void Execute(ISession session);
	}
}