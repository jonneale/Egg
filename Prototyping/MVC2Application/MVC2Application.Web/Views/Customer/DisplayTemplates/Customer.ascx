<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Customer>" %>
<%@ Import Namespace="MVC2Application.Web.PresentationModel"%>

<h2><%= ViewData.ModelMetadata.DisplayName %> - <%= Html.Encode(Model.Name)%></h2>
<p>
		<%= Model.Email %>
</p>
