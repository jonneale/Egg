namespace uSwitch.Content.Domain.Persistance
{
	public interface IUnitOfWorkFactory
	{
		UnitOfWork Create();
	}
}