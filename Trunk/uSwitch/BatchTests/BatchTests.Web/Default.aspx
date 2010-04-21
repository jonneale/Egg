<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BatchTests.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div>
        Old File <asp:FileUpload runat="server" ID="oldFileUpload" />
    </div>
    
    <div>
        New File <asp:FileUpload runat="server" ID="newFileUpload" />
    </div>
    <div>
        <asp:Button runat="server" Text="Compare" ID="compareButton" />
    </div>
    <div>
        <asp:DropDownList runat="server" ID="supplierDropdown">
            <asp:ListItem Value="3" Text="Edf" />
            <asp:ListItem Value="0" Text="Eon" />
        </asp:DropDownList>
    </div>
    
     <div>
        <h2>Differences</h2>
        <asp:GridView runat="server" ID="columnDifferencesGrid" />
    </div>
    
        <asp:GridView runat="server" ID="compareResultsGrid" AutoGenerateColumns="true"></asp:GridView>
    </div>
    
    </form>
</body>
</html>
