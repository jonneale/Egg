using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Xml;
using System.Security.Cryptography;
using System.Globalization;
using Facebook.Extended;

namespace Facebook.Extended
{
	public static class RestService
	{
		private static FacebookConfig _config;

		static RestService()
		{
			_config = FacebookConfig.GetConfig();
		}

		public static XmlDocument Request(Dictionary<string, string> parameterList)
		{
			string requestUrl = GetRequestUrl(parameterList);
			string responseXml = GetQueryResponse(requestUrl);
			XmlDocument document = new XmlDocument();
			document.InnerXml = responseXml;
			return document;
		}

		private static string GetRequestUrl(Dictionary<string, string> parameterList)
		{
			StringBuilder builder = new StringBuilder(_config.RestUrl + "?");
			if (parameterList["method"] == "auth.getSession")
			{
				builder.Replace("http", "https");
			}
			parameterList.Add("api_key", _config.ApplicationKey);
			parameterList.Add("v", "1.0");
			parameterList.Add("call_id", DateTime.Now.Ticks.ToString("x", CultureInfo.InvariantCulture));
			parameterList.Add("sig", GenerateSignature(ParameterDictionaryToList(parameterList)));
			foreach (KeyValuePair<string, string> pair in parameterList)
			{
				builder.Append(pair.Key);
				builder.Append("=");
				builder.Append(pair.Value);
				builder.Append("&");
			}
			builder.Remove(builder.Length - 1, 1);
			return builder.ToString();
		}

		private static string GenerateSignature(List<string> parameters)
		{
			StringBuilder builder = new StringBuilder();
			parameters.Sort();
			foreach (string text in parameters)
			{
				builder.Append(text);
			}
			builder.Append(_config.SecretKey);
			byte[] buffer = MD5.Create().ComputeHash(Encoding.Default.GetBytes(builder.ToString().Trim()));
			builder = new StringBuilder();
			foreach (byte num in buffer)
			{
				builder.Append(num.ToString("x2", CultureInfo.InvariantCulture));
			}
			return builder.ToString();
		}

		private static List<string> ParameterDictionaryToList(Dictionary<string, string> parameterDictionary)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, string> pair in parameterDictionary)
			{
				list.Add(string.Format(CultureInfo.InvariantCulture, "{0}={1}", new object[] { pair.Key, pair.Value }));
			}
			return list;
		}

		private static string GetQueryResponse(string requestUrl)
		{
			using (StreamReader reader = new StreamReader(WebRequest.Create(requestUrl).GetResponse().GetResponseStream()))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
