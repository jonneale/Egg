<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<uSwitch.MvcBrownBag.Web.Models.CreateArtistView>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
<% Html.EnableClientValidation(); %> 

    <div>
    <div>
        <%= Html.ValidationSummary() %>
    </div>
    
        <% using (Html.BeginForm())
          { %>
                <ul>
                    <li>
                     <%= Html.LabelFor(x => x.Name) %>
                     <%= Html.EditorFor(x => x.Name) %>
                     <%= Html.ValidationMessageFor(x => x.Name) %>
                    </li>
                    
                    <li>
                     <%= Html.LabelFor(x => x.BandName) %>
                     <%= Html.EditorFor(x => x.BandName) %>
                     <%= Html.ValidationMessageFor(x => x.BandName) %>
                    </li>
                    
                     <li>
                     <%= Html.LabelFor(x => x.DOB) %>
                     <%= Html.EditorFor(x => x.DOB) %>
                     <%= Html.ValidationMessageFor(x => x.DOB) %>
                    </li>
                </ul>
                <input type="submit" value="Create" />
        <%} %>
</asp:Content>
