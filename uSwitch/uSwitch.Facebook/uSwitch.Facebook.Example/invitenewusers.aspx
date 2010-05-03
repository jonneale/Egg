<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Main.Master" AutoEventWireup="true" CodeBehind="invitenewusers.aspx.cs" Inherits="uSwitch.FacebookApp.Example.invitenewusers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Invite new users to Facebook</h2>
    <fb:serverfbml style="width: 755px;">  
        <script type="text/fbml">  
            <fb:fbml>
                <fb:request-form action="http://localhost:49652/inviteusers.aspx" method="Get" invite="true" type="uSwitch" content="You wish to save money at uSwitch">  
                    <fb:multi-friend-selector showborder="false" actiontext="Invite your friends to use Connect.">  
                </fb:request-form> 
            </fb:fbml>
        </script>
    </fb:serverfbml>
</asp:Content>
