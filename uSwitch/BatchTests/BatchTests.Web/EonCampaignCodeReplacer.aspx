<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EonCampaignCodeReplacer_Page.aspx.cs" Inherits="BatchTests.Web.EonCampaignCodeReplacer_Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Eon campaign code Fixer</h1>
        <div>
            Original file <asp:FileUpload runat="server" ID="originalFileuploader" />
        </div>
        <div>
            <asp:Button runat="server" Text="Create new file" ID="createFileButton" />
        </div>
        
        <div runat="server" id="newFileHyperLinkDiv" visible="false">
            <asp:HyperLink runat="server" Text="New file" ID="newFileHyperLink" />
        </div>
    </div>
    </form>
</body>
</html>
