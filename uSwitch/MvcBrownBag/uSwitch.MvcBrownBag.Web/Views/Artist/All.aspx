<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<uSwitch.MvcBrownBag.Domain.Artist>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All</h2>
    
    <ul>
        <% foreach (var artist in Model)
        {
            Html.RenderPartial("DisplayArtist", artist);
        } %>
    </ul>
</asp:Content>
