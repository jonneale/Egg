$(document).ready(function() {
    applyVolitality();
    applyShowJs();
    applyHideJs();
    testCookies();

    var prm = Sys.WebForms.PageRequestManager.getInstance();
    if (prm != null) {
        prm.add_endRequest(function() {
            applyVolitality();
            applyShowJs();
            applyHideJs();
        });
    }
});


function applyVolitality() 
{
    var items = $('input.volatile-text');

    items.each(function() {
        var item = $(this);

        item.focus(function() {
            if (item.attr('value') == item.attr('title')) {
                item.attr('value', '');
				item.removeClass('contains-default-value');
            }
        });

        item.blur(function() {
            if (item.attr('value') == '') {
                item.attr('value', item.attr('title'));
				item.addClass('contains-default-value');
            }
        });
		
		if (item.attr('value') == item.attr('title')) {
			item.addClass('contains-default-value');
		}
    });
}

function applyShowJs() {
    var items = $('.show-js');

    $(items).removeClass('show-js');
}

function applyHideJs() {
    var items = $('.hide-js');

    $(items).hide();
}

function showPopup(element, size) {
    if (element.href && element.href != "") {
        var popupAttributes = 'scrollbars=1,';

        switch (size) {
            case "Large":
                popupAttributes += 'width=800,height=800';
                break;
            case "Medium":
                popupAttributes += 'width=600,height=600';
                break;
            case "Small":
                popupAttributes += 'width=400,height=400';
                break;
        }

        window.open(element.href, 'popupwindow' + Math.floor(Math.random() * 5000), popupAttributes);
    }
}

function testCookies() {
    var tmpcookie = new Date();

    chkcookie = (tmpcookie.getTime() + '');

    document.cookie = "chkcookie=" + chkcookie + "; path=/";

    if (document.cookie.indexOf(chkcookie, 0) < 0) {
        alert('To use this website, your web browser must accept cookies.\n\nIf they are disabled, please enable them now.\nIf you are using an outdated version of your web browser, please update it now.');
    }
}