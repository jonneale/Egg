<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="uSwitch.OOJavaScript.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link rel="Stylesheet" type="text/css" href="WebResources/core.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Object oriented JavaScript</h1>
        <ul>
            <li>Why build a class in JavaScript?</li>
            <li>Does inheritance exist?</li>
            <li>JavaScript is a dynamic language, why not take advantage?</li>
            <li>How can librarys like Ajax.Net and JQuery help?</li>
        </ul>
        
        <p>
            <a href="http://weblogs.asp.net/bleroy/archive/2008/11/07/visual-studio-patched-for-better-jquery-intellisense.aspx">
                How to setup intellisense for jquery
            </a>
        </p>
        
        <h2>Why build a class in JavaScript?</h2>
        <p>Does your JavaScript have to look like script, would it not be nicer to have a clean client 
        code base as well as server-side. JavaScript only really looks messy because its mixed into the html
         markup of the page. Seperating code into JS files and calling method on classes on the page will look
         alot neater.</p>
         
         <h2>Does inheritance exist?</h2>
         <p>Yes it does, however why do you need it. In todays world of development we are encourage to use
         composition of inheritance. Which leads me to my next point.</p>
         
         <h2>JavaSCript is a dynamic language, why not take advantage></h2>
         <p>In JavaScript the is actually no need to create a set of dumb domain model classes. Why not just
          make them on the fly when you need them. This is very easy using the <strong>prototype</strong> property and <strong>
          JSON</strong> markup. As I will demostrate later.</p>
          
          <h2>How can librarys like Ajax.Net and JQuery help?</h2>
          <p>
            One of the main problems with running JavaScript on a client-side browser is how they run your code. What
             works in one browser may not in another. Cross-browser scripting is what these Library gears towards helping
             a developer with. When you write query in JQuery you don't actually care how
          </p>
    </div>
    </form>
</body>
</html>
