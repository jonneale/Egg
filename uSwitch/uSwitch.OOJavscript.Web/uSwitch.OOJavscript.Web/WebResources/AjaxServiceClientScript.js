/// <reference name="MicrosoftAjax.js"/>
AjaxClient = function() {
    
}
AjaxClient.prototype = {
    ServiceUrl : "http://localhost:1033/Repository.svc",
    
    GetSuppliers : function(callBack) {
        try {
            var requestURL = this.ServiceUrl + "/Suppliers";
            $.getJSON(requestURL, function(json) { callBack(json); });
        } 
        catch(exception) {
            throw exception;
        }
    },
    
    GetSupplier : function(supplierId, callBack) {
        try {
            var requestURL = this.ServiceUrl + "/Suppliers/" + supplierId;
            $.getJSON(requestURL, function(json) { callBack(json); });
        } 
        catch(exception) {
            throw exception;
        }
    }
}

UIPresentation = function(client) {
    this.client = client;
}
UIPresentation.prototype = {
    addItemsToSupplierDropdown : function(dropdown) {
        var ajaxCallBack = function(json) 
        {
            dropdown.empty();
            for(i = 0; i < json.length; i++)
            {
                var elOptNew = document.createElement('option');
                elOptNew.text = json[i].Name;
                elOptNew.value = json[i].Id;
                dropdown.get(0).add(elOptNew);
            }
        };
        this.client.GetSuppliers(ajaxCallBack);
    },
    
    addItemsToPlansDropdown : function(dropdown, supplierId) {
        var ajaxCallBack = function(json) 
        {
            dropdown.empty();
            var allPlans = json.Plans
        
            for(i = 0; i < allPlans.length; i++)
            {
                var elOptNew = document.createElement('option');
                    elOptNew.text = allPlans[i].Name;
                    elOptNew.value = allPlans[i].Id;
                    dropdown.get(0).add(elOptNew);
            }
        };
    
        this.client.GetSupplier(supplierId, ajaxCallBack);
    },
    
    addChangeEventToDropdown : function(supplierDropdown, plansDropdown) {
        supplierDropdown.bind("change", Function.createDelegate(this, function() { 
            var index = supplierDropdown.get(0).selectedIndex;
            this.addItemsToPlansDropdown(plansDropdown, supplierDropdown.get(0)[index].value);
        }));
    }
}