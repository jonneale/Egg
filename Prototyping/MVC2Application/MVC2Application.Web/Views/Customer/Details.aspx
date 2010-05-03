<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CreateCustomer>" %>
<%@ Import Namespace="MVC2Application.Web.PresentationModel"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>
	<% Html.EnableClientValidation(); %>
	<%= Html.ValidationSummary() %>
	<div>
		<%= Html.DisplayForModel() %>
	</div>
</asp:Content>
