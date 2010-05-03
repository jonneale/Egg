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

namespace uSwitch.Energy.Silverlight.Events
{
	public class HasGasChangedEvent : IEvent
	{
		public bool HasGas
		{
			get; set;
		}
	}
}
