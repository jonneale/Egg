Type.registerNamespace("uSwitch.Web.UI.WebControls");

// Constructor
uSwitch.Web.UI.WebControls.Button = function(element) {
    uSwitch.Web.UI.WebControls.Button.initializeBase(this, [element]);

    this._validateDelegate = null;
    this._MultipleGroupValidation = false;
    this._ValidationGroup = "";
    this._CausesValidation = false;
    this._elementId = null;
}
uSwitch.Web.UI.WebControls.Button.prototype = {
    get_MultipleGroupValidation: function() {
        return this._MultipleGroupValidation;
    },
    set_MultipleGroupValidation: function(value) {
        this._MultipleGroupValidation = value;
    },

    get_ValidationGroup: function() {
        return this._ValidationGroup;
    },
    set_ValidationGroup: function(value) {
        this._ValidationGroup = value;
    },

    get_CausesValidation: function() {
        return this._CausesValidation;
    },
    set_CausesValidation: function(value) {
        this._CausesValidation = value;
    },

    // Bind and unbind to click event.
    add_click: function(handler) {
        this.get_events().addHandler('click', handler);
    },
    remove_click: function(handler) {
        this.get_events().removeHandler('click', handler);
    },

    _validateClick: function(event) {
        if (this.control.get_CausesValidation()) {
            var jE = $('#' + this.control._elementId);
            var element = jE.get(0);
                        
            var groups;

            if (this.control.get_MultipleGroupValidation()) {
                groups = this.control.get_ValidationGroup().split(',');
            } else {
                groups = new Array();
                groups[0] = this.control.get_ValidationGroup();
            }

            var valids = new Array();
			if (typeof(Page_Validators)!="undefined") {
            for (var j = 0; j < Page_Validators.length; j++) { //reset this so we know if something has already been marked invalid in this validation session
                var validator = Page_Validators[j];

                var element = $('#' + validator.controltovalidate);

                if (typeof (element[0]) !== 'undefined') {
                    element[0].hookIsInvalid = false;
                }
            }
            }
            if (typeof(Page_ClientValidate)!="undefined") {
                for (var i = 0; i < groups.length; i++) {

                valids[i] = Page_ClientValidate(groups[i].trim()); //validate all groups in the list
            }

            var allValid = true;

            var firstInvalidSummary = null;

            for (var x = 0; x < valids.length; x++) {
                if (!valids[x]) {
                    allValid = false;

                    var summary = null;

                    for (var y = 0; y < Page_ValidationSummaries.length; y++) {
                        if (IsValidationGroupMatch(Page_ValidationSummaries[y], groups[x].trim())) {
                            summary = Page_ValidationSummaries[y];
                            break;
                        }
                    }

                    if (summary != null) {
                        summary.style.display = "";

                        if (firstInvalidSummary == null) {
                            firstInvalidSummary = summary;
                        }
                    }
                }
            }

            if (firstInvalidSummary != null && !allValid) {
                $.scrollTo(firstInvalidSummary, 500, { offset: -70 });
				Page_BlockSubmit = true;
            }
            }
        }
    },

    initialize: function() {
        uSwitch.Web.UI.WebControls.Button.callBaseMethod(this, 'initialize');

        var that = this;
        
        this._elementId = this.get_element().id;
        
        var init = function () {
            var element = $('#' + that._elementId);
            
            $(element).click(that._validateClick);
        };

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function() {
                var element = $('#' + that._elementId);
                
                if (element.length > 0) {
                    element.get(0).control = that;
                    init();
                }
            });
        }
        
        $(document).ready(function () {
            init();
        });
    },

    // Release resources before control is disposed.
    dispose: function() {
        var element = this.get_element();

        /*if (this._validateDelegate) {
            Sys.UI.DomEvent.removeHandler(element, 'click', this._validateDelegate);
            delete this._validateDelegate;
        }*/

        uSwitch.Web.UI.WebControls.Button.callBaseMethod(this, 'dispose');
    }
}
uSwitch.Web.UI.WebControls.Button.registerClass('uSwitch.Web.UI.WebControls.Button', Sys.UI.Control);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
/* ----------------------------------------------------------------------------------------------------

	DoublePanel

---------------------------------------------------------------------------------------------------- */

Type.registerNamespace("uSwitch.Web.UI.WebControls");

uSwitch.Web.UI.WebControls.DoublePanel = function(element) {
    uSwitch.Web.UI.WebControls.DoublePanel.initializeBase(this, [element]);

    this._divDoublePanel = null;
    this._divPanels = null;
    this._divPanelLeft = null;
    this._divPanelRight = null;

    this._timerDelegate = null;
}

uSwitch.Web.UI.WebControls.DoublePanel.prototype = {
    initialize: function() {
        uSwitch.Web.UI.WebControls.DoublePanel.callBaseMethod(this, 'initialize');

        this._divDoublePanel = $(this.get_element());
        this._divPanels = new Array();

        var that = this;

        this._divDoublePanel.find("div[class*='us-panel']").each(function() {
            that._divPanels.push($(this));
        })

        if (this._divPanels.length < 2)
            return;

        this._divPanelLeft = this._divPanels[0].find("div[class='inner-content']");
        this._divPanelRight = this._divPanels[1].find("div[class='inner-content']");

        this._timerDelegate = Function.createDelegate(this, this.resetPanelHeights);

        $(window).load(this._timerDelegate);

        var that = this;

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function() {
                that.resetPanelHeights();
            });
        }
    },

    resetPanelHeights: function() {
        this._divPanelLeft.height('');
        this._divPanelRight.height('');
    
        if (this._divPanelLeft.height() < this._divPanelRight.height())
            this._divPanelLeft.height(this._divPanelRight.height());
        else
            this._divPanelRight.height(this._divPanelLeft.height());
    },

    dispose: function() {
        var element = this.get_element();

        delete this._timerDelegate;

        uSwitch.Web.UI.WebControls.DoublePanel.callBaseMethod(this, 'dispose');
    }
}

uSwitch.Web.UI.WebControls.DoublePanel.registerClass("uSwitch.Web.UI.WebControls.DoublePanel", Sys.UI.Control);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();Type.registerNamespace("uSwitch.Web.UI.WebControls");

// Constructor
uSwitch.Web.UI.WebControls.HyperLink = function(element) {
    uSwitch.Web.UI.WebControls.HyperLink.initializeBase(this, [element]);
    
    this._clickDelegate = null;
    this._isPopup = null;
    this._popupWidth = null;
}
uSwitch.Web.UI.WebControls.HyperLink.prototype = {

    get_PopupSize: function() {
        return this._popupSize;
    },
    set_PopupSize: function(value) {
        this._popupSize = value;
    },

    get_IsPopup: function() {
        return this._isPopup;
    },
    set_IsPopup: function(value) {
        this._isPopup = value;
    },

    _popUpClicked: function(eventElement) {
        var element = this.get_element();

        showPopup(element, this.get_PopupSize());
        
        eventElement.preventDefault();
    },

    initialize: function() {
        uSwitch.Web.UI.WebControls.HyperLink.callBaseMethod(this, 'initialize');

        var element = this.get_element();

        if (this._clickDelegate === null) {
            this._clickDelegate = Function.createDelegate(this, this._popUpClicked);
        }
        Sys.UI.DomEvent.addHandler(element, 'click', this._clickDelegate);

        if (this.get_IsPopup()) {
            this.get_events().addHandler('click', this._clickDelegate);
        }
    },

    // Release resources before control is disposed.
    dispose: function() {
        var element = this.get_element();

        if (this._clickDelegate) {
            Sys.UI.DomEvent.removeHandler(element, 'click', this._clickDelegate);
            delete this._clickDelegate;
        }

        uSwitch.Web.UI.WebControls.HyperLink.callBaseMethod(this, 'dispose');
    }
}
uSwitch.Web.UI.WebControls.HyperLink.registerClass('uSwitch.Web.UI.WebControls.HyperLink', Sys.UI.Control);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();Type.registerNamespace("uSwitch.Web.UI.WebControls");

// Constructor
uSwitch.Web.UI.WebControls.HelpLink = function(element) {
    uSwitch.Web.UI.WebControls.HelpLink.initializeBase(this, [element]);
    this._mouseoverDelegate=null;
    this._mouseoutDelegate=null;
    this._hoverText=null;
    this._bubbleWidth=null;
    this._bubble=null;
    this._bubbleID=null;
    this._offsetX = 17;
}

uSwitch.Web.UI.WebControls.HelpLink.prototype = {
    get_HoverText: function() {
        return this._hoverText;
    },

    set_HoverText: function(value) {
        this._hoverText = value;
    },

    get_BubbleWidth: function() {
        return this._bubbleWidth;
    },

    set_BubbleWidth: function(value) {
        this._bubbleWidth = value;
    },

    get_BubbleID: function() {
        return this._bubbleID;
    },

    set_BubbleID: function(value) {
        this._bubbleID = value;
    },

    _mouseOver: function(eventElement) {
        var element = this.get_element();

        if (this._hoverText != null && this._bubbleID != null) {
            this._bubble = Sys.UI.DomElement.getElementById(this._bubbleID);

            if (this._bubble) {
                Sys.UI.DomElement.removeCssClass(this._bubble, "hidden");

                if (this._bubbleWidth != null) {
                    this._bubble.style.width = this._bubbleWidth + "px";

                    var docWidth = $(window).width();

                    var left = eventElement.clientX + parseInt(this._offsetX);

                    var bubbleRight = parseInt(left) + parseInt(this._bubbleWidth);

                    if (bubbleRight >= docWidth) 
                    {
                        this._bubble.style.left = (left - parseInt(this._bubbleWidth)) + "px";
                    } 
                    else 
                    {
                        this._bubble.style.left = left + "px";
                    }
                }
            }
        }
        eventElement.preventDefault();
    },

    _mouseOut: function(eventElement) {
        var element = this.get_element();
        if (!this._bubble && this._bubbleID != null) {
            this._bubble = Sys.UI.DomElement.getElementById(this._bubbleID);
        }
        if (this._bubble) {
            Sys.UI.DomElement.addCssClass(this._bubble, "hidden");
        }
    },

    initialize: function() {
        uSwitch.Web.UI.WebControls.HelpLink.callBaseMethod(this, 'initialize');
        var element = this.get_element();

        if (this._mouseoverDelegate === null) {
            this._mouseoverDelegate = Function.createDelegate(this, this._mouseOver);
        }
        Sys.UI.DomEvent.addHandler(element, 'mouseover', this._mouseoverDelegate);
        if (this._mouseoutDelegate === null) {
            this._mouseoutDelegate = Function.createDelegate(this, this._mouseOut);
        }
        Sys.UI.DomEvent.addHandler(element, 'mouseout', this._mouseoutDelegate);
		
		 $(element).removeAttr('href');
    },

    // Release resources before control is disposed.
    dispose: function() {
        var element = this.get_element();

        if (this._mouseoverDelegate) {
            Sys.UI.DomEvent.removeHandler(element, 'mouseover', this._mouseoverDelegate);
            delete this._mouseoverDelegate;
        }

        if (this._mouseoutDelegate) {
            Sys.UI.DomEvent.removeHandler(element, 'mouseout', this._mouseoutDelegate);
            delete this._mouseoutDelegate;
        }

        uSwitch.Web.UI.WebControls.HyperLink.callBaseMethod(this, 'dispose');
    }
}

uSwitch.Web.UI.WebControls.HelpLink.registerClass('uSwitch.Web.UI.WebControls.HelpLink', uSwitch.Web.UI.WebControls.HyperLink);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();/* ----------------------------------------------------------------------------------------------------

Navigation

---------------------------------------------------------------------------------------------------- */

Type.registerNamespace("uSwitch.Web.UI.Composite");

uSwitch.Web.UI.Composite.Navigation = function(element) {
    uSwitch.Web.UI.Composite.Navigation.initializeBase(this, [element]);

    this._categories = null;
    this._divNavigation = null;
    this._divCategories = null;
    this._divChannels = null;
    this._defaultCategory = null;
    this._defaultChannel = null;
    this._defaultChannels = null;
    this._previousCategoryClass = null;
    this._currentCategoryClass = null;
    this._showDynamicNavigation = null;
}

uSwitch.Web.UI.Composite.Navigation.prototype = {
    get_ShowDynamicNavigation: function() {
        return this._showDynamicNavigation;
    },
    set_ShowDynamicNavigation: function(value) {
        this._showDynamicNavigation = value;
    },

    get_Categories: function() {
        return eval("(" + this._categories + ")");
    },
    set_Categories: function(value) {
        this._categories = value;
    },

    initialize: function() {
        uSwitch.Web.UI.Composite.Navigation.callBaseMethod(this, 'initialize');

        if (this.get_ShowDynamicNavigation()) {
            this._divNavigation = $(this.get_element());
            this._divCategories = this._divNavigation.find("div[class='categories']");
            this._divChannels = this._divNavigation.find("div[class^='channels']");
            this._defaultCategory = this._divCategories.find("a[class='on']").text();
            this._defaultChannel = this._divChannels.find("a[class='on']").text();
            this._defaultChannels = this.getDefaultChannels();
            this._previousCategoryClass = this._currentCategoryClass = this._defaultCategory.toLowerCase();

            var that = this;

            this._divCategories.find("a").each(function(i) {
                this.category = that.get_Categories()[i].category;
                this.channels = that.get_Categories()[i].channels;

                $(this).bind("click", function() {
                    if (this.channels.length == 0)
                        return true;

                    that.resetCategories();
                    that.loadCategories(this.category);
                    that.resetChannels();
                    that.loadChannels(this.channels);

                    this.blur();

                    return false;
                });
            })
        }
    },

    getDefaultChannels: function() {
        var that = this;
        var defaultChannels;

        $(this.get_Categories()).each(function(i) {
            if (this.category == that._defaultCategory)
                defaultChannels = this.channels;
        })

        return defaultChannels;
    },

    resetCategories: function() {
        this._divCategories.find("li[class^='" + this._previousCategoryClass + "']").children("a").removeClass("on");

        this._divChannels.removeClass(this._previousCategoryClass)
    },

    loadCategories: function(category) {
        this._previousCategoryClass = this._currentCategoryClass = category.toLowerCase();
        this._divCategories.find("li[class^='" + this._currentCategoryClass + "']").children("a").addClass("on");
    },

    resetChannels: function() {
        this._divChannels.addClass(this._currentCategoryClass)
        this._divChannels.empty();
    },

    loadChannels: function(channels) {
        if (channels.length > 0) {
            var that = this;
            var ul = $("<ul></ul>");

            $(channels).each(function() {
                var li = $("<li></li>").addClass(this.channel.toLowerCase());
                var a = $("<a></a>").text(this.channel).attr("href", this.linkUrl)

                if (this.channel == that._defaultChannel)
                    a.addClass("on");

                ul.append(li.append(a));
            });

            this._divChannels.append(ul);
            this._divChannels.find("ul li:last-child").addClass("last-child");
        }
    },

    dispose: function() {
        var element = this.get_element();
        uSwitch.Web.UI.Composite.Navigation.callBaseMethod(this, 'dispose');
    }
}

uSwitch.Web.UI.Composite.Navigation.registerClass("uSwitch.Web.UI.Composite.Navigation", Sys.UI.Control);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
/* ----------------------------------------------------------------------------------------------------

   uSwitch.Web.UI.Composite.TopSearchBox JavaScript

---------------------------------------------------------------------------------------------------- */

Type.registerNamespace("uSwitch.Web.UI.Composite");

uSwitch.Web.UI.Composite.TopSearchBox = function(element) {
    uSwitch.Web.UI.Composite.TopSearchBox.initializeBase(this, [element]);
    this._footerLink = null;
    this._hiddenLinks = null;
    this._showHideDelegate = null;
}

uSwitch.Web.UI.Composite.TopSearchBox.prototype = {
    get_footerLink: function() {
        return this._footerLink;
    },
    set_footerLink: function(value) {
        this._footerLink = value;
    },

    get_hiddenLinks: function() {
        return this._hiddenLinks;
    },
    set_hiddenLinks: function(value) {
        this._hiddenLinks = value;
    },

    _showHideClick: function(e) {
        var hiddenLinksDiv = this.get_hiddenLinks();

        $(hiddenLinksDiv).toggle("fast");

        if (this._footerLink.text().trim() == "More") {
            this._footerLink.text("Hide");
        } else {
            this._footerLink.text("More");
        }

        return false;
    },

    initialize: function() {
        uSwitch.Web.UI.Composite.TopSearchBox.callBaseMethod(this, 'initialize');
		if (this._footerLink!=null) {
        this._footerLink = $(this.get_footerLink());

        var hiddenLinksDiv = this.get_hiddenLinks();
        $(hiddenLinksDiv).hide();

        if (this._showHideDelegate === null) {
            this._showHideDelegate = Function.createDelegate(this, this._showHideClick);
        }

        this._footerLink.click(this._showHideDelegate);
        }
    },

    dispose: function() {
        var element = this.get_element();

        if (this._showHideDelegate !== null) {
            delete this._showHideDelegate;
        }

        uSwitch.Web.UI.Composite.TopSearchBox.callBaseMethod(this, 'dispose');
    }
}

uSwitch.Web.UI.Composite.TopSearchBox.registerClass("uSwitch.Web.UI.Composite.TopSearchBox", Sys.UI.Control);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();
Type.registerNamespace("uSwitch.Web.UI.WebControls");

// Constructor
uSwitch.Web.UI.WebControls.ValidationStyler = function(element) {
    uSwitch.Web.UI.WebControls.ValidationStyler.initializeBase(this, [element]);

    this.originalValidatorOnChange = null;
}

uSwitch.Web.UI.WebControls.ValidationStyler.prototype = {
    validateHook: function(validator) {
        var originalIsValid = validator.__originalEvaluationFunction(validator);

        var summary = null;

        for (var y = 0; y < Page_ValidationSummaries.length; y++) {
            if (IsValidationGroupMatch(Page_ValidationSummaries[y], validator.validationGroup)) {
                summary = Page_ValidationSummaries[y];
                break;
            }
        }

        var setupClasses = function(isAlreadyInvalid, el) {

            if (!isAlreadyInvalid) {
                if (originalIsValid)
                    el.removeClass('invalid');
                else {
                    el.addClass('invalid');
                }
            }
        }

        var element = $('#' + validator.controltovalidate);
        var isAlreadyInvalid = false;
        if (typeof (element[0]) !== 'undefined') {
            isAlreadyInvalid = typeof (element[0].hookIsInvalid) !== 'undefined' && element[0].hookIsInvalid == true;
        }

        if (element != null) {
            var li = $(element.parents('li'));

            if (li != null)
                setupClasses(isAlreadyInvalid, li);

            setupClasses(isAlreadyInvalid, element);

            var lbl = $("label[for='" + element.attr('id') + "']");

            if (lbl != null)
                setupClasses(isAlreadyInvalid, lbl);
        }

        if (!originalIsValid && typeof (element[0]) !== 'undefined')
            element[0].hookIsInvalid = true;

        return originalIsValid;
    },

    ValidatorOnChangehook: function(event) {
        if (!event) {
            event = window.event;
        }

        var targetedControl;
        if ((typeof (event.srcElement) != "undefined") && (event.srcElement != null)) {
            targetedControl = event.srcElement;
        } else {
            targetedControl = event.target;
        }

        targetedControl.hookIsInvalid = false;

        return this.originalValidatorOnChange(event);
    },

    initialize: function() {
        uSwitch.Web.UI.WebControls.ValidationStyler.callBaseMethod(this, 'initialize');

        var t = this;

        $(document).ready(function() {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function() {
                    // Re-register validator hooks after ASP.NET AJAX UpdatePanel refresh
                    t.addHookToPageValidators(t);

                    t.refreshValidationSummaryElements();
                    t.fixScrollTo();
                });
            }
            t.addHookToPageValidators(t);
            t.fixScrollTo();

            if (typeof (Page_Validators) !== 'undefined') {
                t.originalValidatorOnChange = ValidatorOnChange;
            }
            ValidatorOnChange = function(event) { return t.ValidatorOnChangehook(event); };
        });
    },

    addHookToPageValidators: function(styler) {

        if (typeof (Page_Validators) !== 'undefined') {
            for (var j = 0; j < Page_Validators.length; j++) {
                var validator = Page_Validators[j];

                if (typeof (validator.isHooked) === 'undefined') {
                    validator.__originalEvaluationFunction = validator.evaluationfunction;
                    validator.evaluationfunction = styler.validateHook;
                    validator.isHooked = true;
                }
            }
        }
    },

    refreshValidationSummaryElements: function() {
        if (typeof (Page_ValidationSummaries) !== 'undefined') {
            for (var i = 0; i < Page_ValidationSummaries.length; i++) {
                var valSummary = Page_ValidationSummaries[i];

                var newElement = $get(valSummary.id);

                newElement.validationGroup = valSummary.validationGroup;
                newElement.headertext = valSummary.headertext;

                Page_ValidationSummaries[i] = newElement;
            }
        }
    },

    fixScrollTo: function() {
        //disable asp.net's validation jumping to the top of the page!
        var oldScrollTo = window.scrollTo;

        window.scrollTo = function(x, y) {
            if (x == 0 && y == 0) {
                return true;
            }

            return oldScrollTo(x, y);
        };
    },

    // Release resources before control is disposed.
    dispose: function() {
        uSwitch.Web.UI.WebControls.ValidationStyler.callBaseMethod(this, 'dispose');
    }
}
uSwitch.Web.UI.WebControls.ValidationStyler.registerClass('uSwitch.Web.UI.WebControls.ValidationStyler', Sys.UI.Control);
if (typeof (Sys) !== 'undefined') Sys.Application.notifyScriptLoaded();