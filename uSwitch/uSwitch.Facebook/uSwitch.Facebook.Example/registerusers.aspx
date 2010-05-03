<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Main.Master" AutoEventWireup="true"
    CodeBehind="registerusers.aspx.cs" Inherits="uSwitch.FacebookApp.Example.registerusers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        Register steve
        <asp:Button Text="Register Steve" runat="server" ID="registerSteveButton" /></div>
    <div>
        Register uSwitch people<asp:Button Text="Register uSwitch" runat="server" ID="registerGeneraluSwitch" /></div>
    <div>
        <asp:Label runat="server" ID="statusLabel" />
    </div>
</asp:Content>
