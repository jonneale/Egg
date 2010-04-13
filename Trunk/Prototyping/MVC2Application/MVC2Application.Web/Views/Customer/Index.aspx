<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Customer>>" %>
<%@ Import Namespace="MVC2Application.Web.PresentationModel"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
	
	<div>
		<%
			foreach (var customer in Model) { %>
				<%= Html.DisplayFor(model => customer)%>
		<%} %>
	</div>
</asp:Content>
