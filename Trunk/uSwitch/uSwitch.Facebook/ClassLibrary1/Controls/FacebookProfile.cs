using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Facebook.Extended.Controls
{
	public class FacebookProfile : Control
	{
		protected override void Render(HtmlTextWriter writer)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
			writer.AddAttribute(HtmlTextWriterAttribute.Class, "us-facebook-profile");
			writer.RenderBeginTag(HtmlTextWriterTag.Div);

			FBMLWriter fbmlwriter = new FBMLWriter(writer);
			fbmlwriter.RenderBeginTag(FBMLTag.LoginButton);
			fbmlwriter.RenderEndTag();

			writer.RenderEndTag();
		}
	}
}
