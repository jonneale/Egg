using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.IO;

namespace Facebook.Extended
{
	public class FBMLWriter : HtmlTextWriter
	{
		private static Dictionary<FBMLTag, string> _tags;
		private static Dictionary<FBMLAttribute, string> _attributes;

		static FBMLWriter()
		{
			CreateTagArray();
			CreateAttributeArray();
		}

		public FBMLWriter(StringBuilder builder)
			: base(new StringWriter(builder))
		{

		}

		public FBMLWriter(TextWriter writer) : base(writer)
		{
			
		}

		public void RenderBeginTag(FBMLTag tag)
		{
			RenderBeginTag(_tags[tag]);
		}

		public void AddAttribute(FBMLAttribute attribute, string value)
		{
			AddAttribute(_attributes[attribute], value);
		}

		private static void CreateAttributeArray()
		{
			_attributes = new Dictionary<FBMLAttribute, string>();
			_attributes.Add(FBMLAttribute.Href, "href");
			_attributes.Add(FBMLAttribute.Title, "title");
			_attributes.Add(FBMLAttribute.PId, "pid");
			_attributes.Add(FBMLAttribute.UId, "uid");
			_attributes.Add(FBMLAttribute.Size, "size");
			_attributes.Add(FBMLAttribute.Url, "url");
			_attributes.Add(FBMLAttribute.Icon, "icon");

			_attributes.Add(FBMLAttribute.Condition, "condition");
		}

		private static void CreateTagArray()
		{
			_tags = new Dictionary<FBMLTag, string>();
			_tags.Add(FBMLTag.Title, "fb:title");
			_tags.Add(FBMLTag.SubTitle, "fb:subtitle");
			_tags.Add(FBMLTag.Wide, "fb:wide");
			_tags.Add(FBMLTag.IfIsOwnProfile, "fb:if-is-own-profile");
			_tags.Add(FBMLTag.Else, "fb:else");
			_tags.Add(FBMLTag.Help, "fb:help");
			_tags.Add(FBMLTag.Action, "fb:action");
			_tags.Add(FBMLTag.Header, "fb:header");
			_tags.Add(FBMLTag.Narrow, "fb:narrow");
			_tags.Add(FBMLTag.Photo, "fb:photo");
			_tags.Add(FBMLTag.UserLink, "fb:userlink");
			_tags.Add(FBMLTag.Name, "fb:name");
			
			//New tags recently added
			_tags.Add(FBMLTag.ConnectForm, "fb:connect-form");
			_tags.Add(FBMLTag.LoginButton, "fb:login-button");
		}
	}

	public enum FBMLTag
	{
		Title,
		SubTitle,
		Wide,
		IfIsOwnProfile,
		Else,
		Help,
		Action,
		Header,
		Narrow,
		Photo,
		UserLink,
		Name,
		ConnectForm,
		LoginButton
	}

	public enum FBMLAttribute
	{
		Href,
		Title,
		PId,
		UId,
		Size,
		Url,
		Icon,
		Condition
	}
}
