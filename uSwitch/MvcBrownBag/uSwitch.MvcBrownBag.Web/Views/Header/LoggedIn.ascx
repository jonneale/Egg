<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<uSwitch.MvcBrownBag.Web.Models.HeaderView>" %>
 <div id="header">
            <div id="title">
                <h1>My MVC Application - <%= Model.LastUpdated  %> - And Logged In</h1>
            </div>
            
            <div id="menucontainer">
            
                <ul id="menu">              
                    <li><%= Html.ActionLink("Home", "Index", "Home")%></li>
                    <li><%= Html.ActionLink("About", "About", "Home")%></li>
                </ul>
            
            </div>
        </div>