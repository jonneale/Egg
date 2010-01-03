Scenario: Im a fan who has just arrived on the livenation home page
Given I browse to the "home" page
Then I should see a list of links in the content box
And each one should be clickable

Scenario: Im a fan who comes to the home page and expects to see the hero player
Given I browse to the "home" page
Then I should see the Hero player