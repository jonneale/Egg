using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace uSwitch.MvcBrownBag.Web.Models
{
    public class CreateEventView
    {
        public string EventName
        {
            get; set;
        }

        public ArtistName HeadLine
        {
            get; set;
        }

        public ArtistName Supporting1
        {
            get; set;
        }

        public ArtistName Supporting2
        {
            get;
            set;
        }

        public DateTime ShowTime
        {
            get; set;
        }

        [DataType(DataType.EmailAddress)]
        public string ContactEmail
        {
            get; set;
        }
    }
}