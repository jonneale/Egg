Scenario: Im a fan who is browsing the events section of the website
Given I browse to the "home" page
And click on the "All Events" link
When I click on the Find tickets link at the top of the search results table
Then I should see details about that event
