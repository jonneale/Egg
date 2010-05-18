using System.ComponentModel.DataAnnotations;

namespace uSwitch.MvcBrownBag.Web.Models
{
	public class CreateArtistView
	{
		[Required(ErrorMessage = "An artist requires a name to be enter")]
		public string Name
		{
			get; set;
		}

		public string BandName
		{
			get; set;
		}
	}
}