using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System;

public class JSONHelper
{
	public static string Serialize<T>(T obj)
	{
		System.Runtime.Serialization.Json.
		DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
		MemoryStream ms = new MemoryStream();
		serializer.WriteObject(ms, obj);
		string retVal = Encoding.Default.GetString(ms.ToArray());
		return retVal;
	}

	public static T Deserialize<T>(string json)
	{
		T obj = default(T);
		MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
		System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
		obj = (T)serializer.ReadObject(ms);
		ms.Close();
		return obj;
	}
}