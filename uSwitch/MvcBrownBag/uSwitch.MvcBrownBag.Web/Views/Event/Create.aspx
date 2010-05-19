<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<uSwitch.MvcBrownBag.Web.Models.CreateEventView>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <% using(Html.BeginForm("Create"))
       { %>
      
        <div>
            <%= Html.EditorFor(x => x.EventName) %>
        </div>
        
        <div>
            <%= Html.EditorFor(x => x.ContactEmail)%>
        </div>
        
        <div>
            <%= Html.EditorFor(x => x.ShowTime)%>
        </div>
           
    <% } %>
</asp:Content>