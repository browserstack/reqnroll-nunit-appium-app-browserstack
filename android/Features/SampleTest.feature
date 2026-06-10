@sample-test
Feature: BrowserStack Sample (Wikipedia App)
	Scenario: Search Wikipedia for BrowserStack
		Given I try to search using the Wikipedia App
		When I search with the keyword BrowserStack
		Then the search results should be listed
