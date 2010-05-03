<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" action="Default2.aspx">
    <div>
    <asp:Label ID="lblHelloWorld" runat="server"></asp:Label><br />
    <a href="default2.aspx">Default 2 Link</a><br />
    <a href="Silverlight.aspx">Silverlight Demo</a><br />
    <a href="AjaxSample.aspx">Ajax Sample</a>
    </div>
    <input type="submit" value="Default 2 submit" />
    </form>
</body>
</html>
