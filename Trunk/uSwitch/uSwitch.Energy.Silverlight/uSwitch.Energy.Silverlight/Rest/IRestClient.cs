using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace uSwitch.Energy.Silverlight.Rest
{
	public interface IRestClient
	{
		void Get<T>(Uri url, Action<T> callback);

		void Post<T>(Uri url, Stream content, Action<T> callback);
	}
}
