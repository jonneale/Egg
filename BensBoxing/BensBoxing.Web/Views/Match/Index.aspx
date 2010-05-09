<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BensBoxing.Domain.Match>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Match
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Match</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            MatchDate:
            <%= Html.Encode(String.Format("{0:g}", Model.MatchDate)) %>
        </p>
        <p>
            Location:
            <%= Html.Encode(Model.Location) %>
        </p>
        <p>
            Id:
            <%= Html.Encode(Model.Id) %>
        </p>
        
        <%foreach(var b in Model.Boxers){ %>
            <li><%= b.FirstName + " " + b.LastName %></li>
        <%} %>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

