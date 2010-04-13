using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace uSwitch.Energy.Silverlight.Rest
{
	public class JsonRestClient : IRestClient
	{
		public void Get<T>(Uri url, Action<T> callback)
		{
			var request = WebRequest.Create(url);
			var result = request.BeginGetResponse(x => GetWebRequestComplete(x, callback), request);
		}

		public void Post<T>(Uri url, Stream content, Action<T> callback)
		{
			var reader = new StreamReader(content);
			var client = new WebClient();
			client.UploadStringCompleted += (sender, e) => PostWebRequestComplete(sender, e, callback);
			client.UploadStringAsync(url, "POST", reader.ReadToEnd());
		}

		private static void PostWebRequestComplete<TJson>(object sender, UploadStringCompletedEventArgs e, Action<TJson> callback)
		{
			var stream = new MemoryStream();
			var memoryReader = new StreamWriter(stream);
			memoryReader.Write(e.Result);

			var serializer = new DataContractJsonSerializer(typeof(TJson));
			var jsonResult = (TJson)serializer.ReadObject(stream);
			callback(jsonResult);
		}

		private static void GetWebRequestComplete<TJson>(IAsyncResult a, Action<TJson> callback)
		{
			HttpWebResponse res = GetResponse(a);
			TJson jsonObject = default(TJson);

			jsonObject = DeSerializeResponse<TJson>(res);

			callback(jsonObject);
			//Dispatcher.BeginInvoke(x => )
		}

		private static TJson DeSerializeResponse<TJson>(WebResponse res)
		{
			TJson jsonObject;
			using (var stream =res.GetResponseStream())
			{
				var serializer = new DataContractJsonSerializer(typeof(TJson));
				jsonObject = (TJson)serializer.ReadObject(stream);
			}
			return jsonObject;
		}

		private static HttpWebResponse GetResponse(IAsyncResult a)
		{
			var req = (HttpWebRequest)a.AsyncState;
			return (HttpWebResponse)req.EndGetResponse(a);
		}
	}
}
