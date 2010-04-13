<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CreateCustomer>" %>
<%@ Import Namespace="MVC2Application.Web.PresentationModel"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

	<%
		Html.BeginForm(); %>
	<div>
		<%= Html.EditorForModel() %>
	</div>
	<input type="submit" value="Create customer" />
	
	<%Html.EndForm(); %>
</asp:Content>
