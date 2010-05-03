<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Main.Master" AutoEventWireup="true"
    CodeBehind="InviteUsers.aspx.cs" Inherits="uSwitch.FacebookApp.Example.InviteUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <fb:serverfbml style="width: 350px;">
         <script type="text/fbml"> 
             <fb:connect-form action="http://www.example.com/post_invite.php">  
             </fb:connect-form> 
         </script>
    </fb:serverfbml>
    
    <h2>Example of prompt box</h2>
    <a onclick="FB.Connect.inviteConnectUsers()" href="#">Click me to see if i work</a>
</asp:Content>
