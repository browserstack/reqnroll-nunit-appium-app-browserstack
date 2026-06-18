@sample-local-test
Feature: BrowserStack Local Testing (Local Sample App)
	Scenario: Verify the BrowserStack Local tunnel from the device
		Given I start the test on the Local Sample App
		Then I should see the connection is up and running
