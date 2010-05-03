Scenario: Im a fan going to my live nation page to search
Given I browse to the "home" page
When I type "madonna" into the search box
And I click on the search button
Then I should see search results for "madonna"