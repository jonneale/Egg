namespace uSwitch.MvcBrownBag.Domain
{
	public class EventLineUp : Entity
	{
		public virtual Artist Artist
		{
			get; set;
		}

		public virtual Artist Event
		{
			get;
			set;
		}
	}
}