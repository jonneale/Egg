using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace uSwitch.Content.Domain
{
	public class BinaryContentProperty : ContentPropertyValue
	{
		public virtual Stream Stream { get; set; }

		public override string GetPropertyAsString()
		{
			var reader = new StreamReader(Stream);
			byte[] bytedata = Encoding.Default.GetBytes(reader.ReadToEnd());

			return Convert.ToBase64String(bytedata);
		}
	}
}
