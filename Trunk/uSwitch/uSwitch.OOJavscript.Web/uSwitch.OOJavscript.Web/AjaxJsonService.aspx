<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxJsonService.aspx.cs" Inherits="uSwitch.OOJavaScript.Web.AjaxJsonService" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>JavaScript, Ajax and services (with a little help from JQuery)</title>
    <link rel="Stylesheet" type="text/css" href="WebResources/core.css" />
    
    <script type="text/javascript" src="WebResources/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="WebResources/AjaxServiceClientScript.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            JavaScript, Ajax and services (with a little help from JQuery)
        </h1>
        <p>
            The following is an example of cascading dropdowns. The top representing suppliers has an
            onchange event that calls into an WCF rest service to retrieve the plans and adds them to the 
            plans dropdown.
        </p>
        
        <asp:ScriptManager ScriptMode="Debug" runat="server">
        </asp:ScriptManager>
        
        <script type="text/javascript">
          $(document).ready(function(){
            var client = new AjaxClient();
            var presentation = new UIPresentation(client);
            
            presentation.addItemsToSupplierDropdown($("#supplierDropdown"));
            presentation.addItemsToPlansDropdown($("#plansDropdown"), 1);
            
            presentation.addChangeEventToDropdown($("#supplierDropdown"), $("#plansDropdown"));
          });
        </script>
        
        <div class="inputdiv">
            Suppliers: <select name="suppliers" id="supplierDropdown">
            </select>
        </div>
        
        <div class="inputdiv">
            Plans: <select name="plans" id="plansDropdown">
            </select>
        </div>
    </div>
    </form>
</body>
</html>
