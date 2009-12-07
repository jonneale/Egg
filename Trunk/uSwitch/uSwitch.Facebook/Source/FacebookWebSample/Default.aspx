<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Facebook.WebControls" Namespace="Facebook.WebControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Facebook developer sample page</title>
<link rel="stylesheet" href="styles.css" type="text/css"/>    
</head>
<body>
    <form id="form1" runat="server">
    <cc1:FriendList ID="MyFriendList" runat="server" OnFriendClick="MyFriendList_FriendClick" />
    <cc1:UserProfile ID="MyUserProfile" runat="server" />
    <cc1:PhotoAlbum ID="MyPhotoAlbum" runat="server" />
    </form>
</body>
</html>
