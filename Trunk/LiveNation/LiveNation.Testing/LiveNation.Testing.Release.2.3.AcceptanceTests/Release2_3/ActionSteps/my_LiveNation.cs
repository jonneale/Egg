using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using LiveNation.Selenium.Domain.Acceptance;
using LiveNation.Testing.Selenium;
using NBehave.Narrator.Framework;
using NUnit.Framework;

namespace LiveNation.Testing.Release.v2_3.AcceptanceTests.ActionSteps
{
	[ActionSteps]
	public class my_LiveNation : SeleniumActionStepsBase
    {
		[Given]
		public void Given_a_user_goes_to_the_my_livenation_register_page()
		{
			string emailAddress = "test11111@livenation.co.uk";

			Selenium.Open("/Account/LoginOrRegister");
			Selenium.Type("Email", emailAddress);
			Selenium.Click("IsAccountHolder");
			Selenium.ClickButtonWithText("Sign Up");
			
			Selenium.Type("EmailAgain", emailAddress);
			Selenium.Type("Password", "password");
			Selenium.Type("PasswordAgain", "password");
			Selenium.ClickButtonWithText("Continue")
				.AndWaitForPageToLoad();
		}

		[When("I enter \"$name\" as my nick name")]
		public void When_I_enter_a_name_as_my_nick_name(string name)
		{
			Selenium.Type("Nickname", "testnickname");
		}

		[When("I enter \"$name\" as my first name")]
		public void When_I_enter_a_name_as_my_first_name(string name)
		{
			Selenium.Type("FirstName", "testfirstname");
		}

		[When("enter \"$name\" as my last name")]
		public void When_I_Enter_an_name_as_last_name(string name)
		{
			Selenium.Type("LastName", "testfirstname");
		}

		[When("enter \"$dateofbirth\" as date of birth")]
		public void When_I_enter_dateofbirth_as_date_of_birth(string dateOfBirth)
		{
			DateTime dob = DateTime.Parse(dateOfBirth);
			
			Selenium.Type("Day", string.Format("label={0}", dob.Day));
			Selenium.Type("Month", string.Format("label={0}", DateTimeFormatInfo.CurrentInfo.MonthNames[dob.Month]));
			Selenium.Type("Year", string.Format("label={0}", dob.Day));
		}

		[When("click on No, I'm a new customer option")]
		public void When_I_click_on_No_Im_a_new_customer_option()
		{
			Selenium.Click("IsAccountHolder");
		}

		[Then]
		public void Then_the_details_should_validate()
		{
			
		}

		[Then("I'm taken to the confirmation page")]
		public void Then_Im_taken_to_the_confirmation_page()
		{
			
		}

    	[When]
        public void When_I_click_the_My_Live_Nation()
        {
			Selenium.ClickAndWait("link=My Live Nation");;
        }

        [Then]
        public void Then_I_should_see_the_My_Live_Nation_page()
        {
			Selenium.AssertTextPresent("Welcome to My Live Nation");
        }

		[Then("I can see the register link")]
		public void Then_I_can_see_the_register_link()
		{
			Selenium.WaitForElement("//input[@value='Sign Up']");
		}
    }
}
