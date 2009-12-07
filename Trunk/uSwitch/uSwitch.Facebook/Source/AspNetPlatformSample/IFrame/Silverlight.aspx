<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Silverlight.aspx.cs" Inherits="Silverlight" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Silverlight Project Test Page </title>
    <script type="text/javascript" src="Silverlight.js"></script>
    <script type="text/javascript" src="CreateSilverlight.js"></script>
</head>
<body>
<form id="Form1" runat="server">
<asp:HiddenField ID="hidAPI" runat="server" />
<asp:HiddenField ID="hidSecret" runat="server" />
<asp:HiddenField ID="hidSession" runat="server" />
<asp:HiddenField ID="hidUser" runat="server" />
    <div id="SilverlightControlHost" >
        <script type="text/javascript">
            createSilverlight();
        </script>
    </div>
</form>
</body>
</html>
