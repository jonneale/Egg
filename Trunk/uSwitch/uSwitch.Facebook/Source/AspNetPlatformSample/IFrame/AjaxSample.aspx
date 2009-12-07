<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AjaxSample.aspx.cs" Inherits="IFrame_AjaxSample" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
        <asp:Label id="lblUpdate" runat="server" Text="Before click" />
        <asp:Button ID="btnAjax" runat="server" Text="Fire Ajax" OnClick="btnAjax_Click" />
       
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
