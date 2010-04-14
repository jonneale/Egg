<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="basic-class.aspx.cs" Inherits="uSwitch.OOJavaScript.Web.BasicClassPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>A basic JavaScript class</title>
    
    <script type="text/javascript">
        myClass = function() {
            this.myString = "This is a string";
        
            this.showAlert = function() 
            {
                alert('This is a method on my class');
            };
        }
        
        myClass.prototype = {
            dynamicMethod : function() 
            {
                alert('This is a dynamic method on my class');
            },
            
            dynamicProperty : 'This is a string in a dynamic property'
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <script type="text/javascript">
            var myInstance = new myClass();
        </script>
    </div>
    
    <h1>My simple class</h1>
    <pre>
    <code>
        myClass = function() {
            this.myString = "This is a string";
        
            this.showAlert = function() 
            {
                alert('This is my class');
            };
        }
        
        myClass.prototype = {
            dynamicMethod : function() 
            {
                alert('This is a dynamic method on my class');
            }
            
            dynamicProperty : 'This is a string in a dynamic property'
        }
        <br />
        var myInstance = new myClass();
    </code>
    </pre>
    <br />
    <a onclick="myInstance.showAlert()" href="#">Click here to use ShowAlert on myClass</a><br />
    <br />
    <a onclick="myInstance.dynamicMethod()" href="#">Click here to use dynamic method</a><br />
    <br /> 
    <a onclick="alert(myInstance.myString)" href="#">Click here to display myString property &quot;alert(myInstance.myString)&quot;</a>
    <br /><br />
        <a onclick="alert(myInstance['myString'])" href="#">Click here to display myString property &quot;alert(myInstance["myString"])&quot;</a>
    </form>
</body>
</html>
