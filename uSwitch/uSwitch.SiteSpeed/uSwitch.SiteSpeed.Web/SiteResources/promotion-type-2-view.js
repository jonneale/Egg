/* =============================================================================
Promotion Type 2 View
================================================================================
Script to initialize the Promotion Type 2 View
----------------------------------------------------------------------------- */

$(function(){
	var pnlPromotion = $("div[id$='pnlPromotion']");
	var txtPostcode = pnlPromotion.find('input[id$=txtPostcode]');
	var txtPostcodeDefaultText = "Enter postcode here";
	
	txtPostcode
		.bind("click focus", function(){
			if ($(this).val() == txtPostcodeDefaultText)
				$(this).val("");
		})
		.bind("blur", function(){
			if ($(this).val() == "")
				$(this).val(txtPostcodeDefaultText);
		});
})