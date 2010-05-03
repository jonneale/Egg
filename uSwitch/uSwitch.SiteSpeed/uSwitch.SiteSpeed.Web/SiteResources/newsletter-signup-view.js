/* =============================================================================
Newsletter Signup View
================================================================================
Script to initialize the Newsletter Signup View
----------------------------------------------------------------------------- */

$(function(){
	var pnlNewsletterSignup = $("div[id$='pnlNewsletterSignup']");
	var txtFirstName = pnlNewsletterSignup.find("input[id$='txtFirstName']");
	var txtEmailAddress = pnlNewsletterSignup.find("input[id$='txtEmailAddress']");
	var txtFirstNameDefaultText = "First name";
	var txtEmailAddressDefaultText = "Email";
	
	txtFirstName
		.bind("click focus", function(){
			if ($(this).val() == txtFirstNameDefaultText)
				$(this).val("");
		})
		.bind("blur", function(){
			if ($(this).val() == "")
				$(this).val(txtFirstNameDefaultText);
		});
		
	txtEmailAddress
		.bind("click focus", function(){
			if ($(this).val() == txtEmailAddressDefaultText)
				$(this).val("");
		})
		.bind("blur", function(){
			if ($(this).val() == "")
				$(this).val(txtEmailAddressDefaultText);
		});
})