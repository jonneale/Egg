using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using uSwitch.Energy.Silverlight.Core;
using uSwitch.Energy.Silverlight.Model;

namespace uSwitch.Energy.Silverlight.Events
{
	public class RegionFoundEvent : IEvent
	{
		public string Region
		{
			get; set;
		}

        public DefaultRegionInformation DefaultRegionInfo
        {
            get; set;
        }
	}
}
