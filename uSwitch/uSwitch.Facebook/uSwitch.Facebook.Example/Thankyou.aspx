<%@ Page Title="" Language="C#" MasterPageFile="~/Resources/Main.Master" AutoEventWireup="true" CodeBehind="Thankyou.aspx.cs" Inherits="uSwitch.FacebookApp.Example.Thankyou" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Thank you for switching</h2>

<a href="#" id="shareStory">Click here</a>
<script type="text/javascript">
    $(document).ready(function() {
        $("#shareStory").click(function() {

            var user_message_prompt = "What do you think of this book?";
            var user_message = { value: "has just saved £300 with uSwitch.com" };
            var body_general = "";

            var comment_data = { "savings": '£300',
                "images": [{ 'src': 'http://www.uswitch.com/siteresources/themes/default/controls/header/images/logo.jpg', 'href': 'http://www.uSwitch.com'}]
            };
            FB.Connect.showFeedDialog(59496301129, comment_data, null, null, null, FB.RequireConnect.require, FB.RequireConnect.promptConnect, null, user_message);
        });
    });
</script>
</asp:Content>
