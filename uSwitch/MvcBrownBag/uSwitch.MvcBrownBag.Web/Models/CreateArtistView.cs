using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using uSwitch.MvcBrownBag.Web.Core.Validation;

namespace uSwitch.MvcBrownBag.Web.Models
{
	public class CreateArtistView
	{
		[Required(ErrorMessage = "An artist requires a name to be enter")]
        [DisplayName("Artist name")]
        [UnqiueArtistName]
		public string Name
		{
			get; set;
		}

        [DisplayName("Band name")]
		public string BandName
		{
			get; set;
		}

        [DisplayName("Date of Birth")]
        [DateValidator]
        public DateTime DOB
        {
            get;
            set;
        }
	}
}