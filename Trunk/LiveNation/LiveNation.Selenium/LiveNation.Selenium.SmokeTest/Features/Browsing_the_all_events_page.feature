Scenario: Browsing the all events section of the site

	Given a user lands on the home page
	When I click on the all events page
	Then I should see a list of events
	
Scenario: Be able to use paging on the all events page

	Given a user lands on the home page
	When I click on the all events page
	And click on the next page link
	Then I should see a list of events