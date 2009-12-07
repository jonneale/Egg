<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="basic-json-objects.aspx.cs" Inherits="uSwitch.OOJavaScript.Web.basic_json_objects" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Json and expando functions</title>
    <link rel="Stylesheet" type="text/css" href="WebResources/core.css" />
    <script type="text/javascript">
        var jamie = { Name : 'Jamie', Age : 26, Address : '2 Moat Place, Ub9 4dw' };
        
        var people = [jamie, 
                        { Name : 'Nicky', Age : 24, Address : '10 Little tree road' },
                        { Name : 'Steve', Age : 21, Address : '313 upmystreet lane' },
                        { Name : 'John', Age : 25, Address : '100b astra drive' } ];
        
        window.peopleRepository = people;

        function SomeFunction()
        {
            for(i = 0; i < arguments.length; i++)
            {
                document.write(arguments[i]);
                document.write("<br />");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Display names from json array</h2>
        <script type="text/javascript">
            for ( i = 0; i < 4; i++) 
            {
                document.write(window.peopleRepository[i].Name);
                document.write("<br />");
            }
        </script>
        
        <h2>Display arguments from expando function</h2>
        <script type="text/javascript">
            SomeFunction("A random argument", "mySecondRandomArgument");
        </script>
    </div>
    </form>
</body>
</html>
