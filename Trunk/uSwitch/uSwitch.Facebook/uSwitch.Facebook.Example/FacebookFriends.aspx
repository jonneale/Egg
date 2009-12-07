<%@ Page MasterPageFile="~/Resources/Main.Master" Language="C#" AutoEventWireup="true" CodeBehind="FacebookFriends.aspx.cs" Inherits="uSwitch.FacebookApp.Example.FacebookFriends" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<asp:GridView runat="server" ID="MyFriendsGrid" AutoGenerateColumns="false">
		<Columns>
			<asp:ImageField DataImageUrlField="ImageUrl" HeaderText="Image" />
			<asp:BoundField DataField="Name" HeaderText="Name" />
			<asp:BoundField DataField="Sex" HeaderText="Sex" />
			<asp:BoundField DataField="DOB" HeaderText="Date of birth" />
			<asp:BoundField DataField="Location" HeaderText="Location" />
		</Columns>
	</asp:GridView>
</asp:Content>
