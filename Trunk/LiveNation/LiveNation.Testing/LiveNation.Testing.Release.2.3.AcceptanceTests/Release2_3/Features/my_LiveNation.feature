Feature: As a user I want to be able to access the features of mylivenation 

Scenario: A new fan I would like to be able to browse to the register page
Given a user browse's to the "home" page
When I click the My Live Nation
And click on No, I'm a new customer option
Then I should see the My Live Nation page
And I can see the register link

Scenario: A new fan comes to livenation and registers to become a my livenation member
Given a user goes to the my livenation register page
When I enter "James" as my first name
And enter "Williamson" as my last name
And enter "TestJames" as my nick name
And enter "15/02/1983" as date of birth
Then the details should validate
And I'm taken to the confirmation page

