<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/Resources/Main.Master" Inherits="uSwitch.FacebookApp.Example._Default"  %>
<%@ Register Src="~/WebControls/LoginDetails.ascx" TagPrefix="webcontrols" TagName="FacebookProfile" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<webcontrols:FacebookProfile runat="server" />
	<h1>
		Welcome to uSwitch
	</h1>
	<ul>
	    <li>
	        <a href="FacebookFriends.aspx">Facebook friends</a>
	    </li>
	    <li>
	        <a href="ProcessPage.aspx">Process page</a>
	    </li>
	    <li>
	        <a href="InviteUsers.aspx">Invite existing users of facebook</a>
	    </li>
	    <li>
	        <a href="InviteNewUsers.aspx">Invite new users of facebook</a>
	    </li>
	    <li>
	        <a href="article.aspx">Some article</a>
	    </li>
	</ul>
	
</asp:Content>