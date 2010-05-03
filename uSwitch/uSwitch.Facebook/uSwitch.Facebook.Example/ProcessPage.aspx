<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Resources/Main.Master" CodeBehind="ProcessPage.aspx.cs" Inherits="uSwitch.FacebookApp.Example.ProcessPage" %>


<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<h1></h1>

<div>
	First name: <asp:TextBox runat="server" ID="FirstNameText" />
</div>
<div>
	Last name: <asp:TextBox runat="server" ID="LastNameText" />
</div>
<div>
	Sex: <asp:RadioButtonList runat="server" ID="SexRadio">
		<asp:ListItem Text="Male" Value="m"></asp:ListItem>
		<asp:ListItem Text="Female" Value="f"></asp:ListItem>
	</asp:RadioButtonList>
</div>
<div>
	Date of birth <asp:TextBox runat="server" ID="DOBText" />
</div>

<div>
    <asp:Button runat="server" ID="ContinueButton" Text="Contine" />
</div>
</asp:Content>