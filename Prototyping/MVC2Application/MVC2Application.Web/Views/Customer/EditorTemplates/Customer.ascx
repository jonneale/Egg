<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<CreateCustomer>" %>
<%@ Import Namespace="MVC2Application.Web.PresentationModel"%>

<h2><%= ViewData.ModelMetadata.DisplayName %></h2>

<div>
	<%= Html.Label("Name")%>
	<%= Html.TextBox(string.Concat(ViewData.ModelMetadata.ModelType.Name, ".Name"), Model.Name) %>
</div>

<div>
	<%= Html.Label("Email")%>
	<%= Html.TextBox(string.Concat(ViewData.ModelMetadata.ModelType.Name, ".Email"), Model.Email)%>
</div>
