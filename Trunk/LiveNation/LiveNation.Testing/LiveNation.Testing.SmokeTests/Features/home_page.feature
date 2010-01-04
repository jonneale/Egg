Scenario: Home page "Concert Tickets" links are present and working
Given I browse to the "home" page
Then I should see a list of links in the "Concent Tickets" content box
And each one of the concent ticket links should be clickable

Scenario: Home page "On Sale Now" links are present and working
Given I browse to the "home" page
Then I should see a list of links in the "On Sale Now" content box
And each one of the on sale now links should be clickable
