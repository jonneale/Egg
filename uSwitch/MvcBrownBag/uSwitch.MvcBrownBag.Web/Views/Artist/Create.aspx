<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<uSwitch.MvcBrownBag.Web.Models.CreateArtistView>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Create</title>
</head>
<body>
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
                     <%= Html.TextBoxFor(x => x.Name) %> %>
                     <%= Html.ValidationMessageFor(x => x.Name) %>
                    </li>
                    
                    <li>
                        BandName <%= Html.TextBoxFor(x => x.BandName)%>
                    </li>
                </ul>
                <input type="submit" value="Create" />
        <%} %>
    </div>
</body>
</html>
