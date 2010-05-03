<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EonReplaceString.aspx.cs" Inherits="BatchTests.Web.EonReplaceString" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Replace string for eon</h1>
        File to convert <asp:FileUpload runat="server" ID="fileToDoReplaceFileUpload"  />
    </div>
    <div>
        <asp:Button runat="server" ID="convertButton" Text="Convert" />
    </div>
    <div runat="server" id="newFileHyperLinkDiv">
        <asp:HyperLink runat="server" ID="getFileHyperlink" Text="Click here" />
    </div>
    </form>
</body>
</html>
