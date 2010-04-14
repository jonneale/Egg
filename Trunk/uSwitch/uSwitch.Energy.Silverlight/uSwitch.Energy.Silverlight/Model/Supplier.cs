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

namespace uSwitch.Energy.Silverlight.Model
{
	public class Supplier : IRestResource
	{
		public string Name
		{
			get; set;
		}

		public string ResourceLocation
		{
			get; set;
		}

		public string GetUri()
		{
			return ResourceLocation;
		}
	}
}