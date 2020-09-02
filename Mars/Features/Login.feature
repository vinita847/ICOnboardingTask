Feature: Login
	In order to access the skillswap application
	As a seller/user
	I want to access the application with valid credentials

@automation @chrome @p1
Scenario: Login with valid email and valid password
	Given I have entered the web address in browser
	And   I have clicked on Signin button
	When  I provide valid email and password and click login
	Then  I should be able to login in the associated account

@automation @chrome 
Scenario: Login with valid email and null password
	Given I have Entered the URL
	And   I have clicked on the signin button
	When I entered the valid email on email field
	And  leave the password Blank
	And I click on log in 
	Then I should not be able to login 
	And  I should be able to see an error message

@automation @chrome 
Scenario: Login with null email and valid password
     Given  I have entered the valid URL
	 And   I have clicked on signin button
	 When  I leave email Id null
	 And   I have enterd Valid password
	 Then  I should be able to see an error message
	 And   I should not be able to login 

@automation @chrome 
Scenario: Login with null email and null password
	Given I have entered valid URL
	And   I have clicked on signin button
	When  I leave email and password field null
	And   I click on ligin button
	Then  I should be able to see an error message
	And   I should not be able to log in 

@automation @chrome 
Scenario: Login with invalid emailid and password
	Given I have entered a valid Url
	And   I have clickd on signin button
	When  I enter invalid data on email field
	And   I enter invalid data on password field
	And   I click on login button
	Then  I should be able to see some error message
	And   I should not be able to log in

@manual @chrome 
Scenario:  validate UI of login page
    Given  I have entered valid url
    When   I wait for login page load
	Then   I should be able to see the page layout as expected with all possible tabs

@manual @chrome
Scenario: validate refresh button(UX) for login page
    Given I have entered valid url 
	When I refresh the login page
	Then I should be able to see the quick and correct responsivenes of the page 

@maual @mac
Scenario: cross system testing to ensure look and feel and responce of login page 
    Given I have mac OS
	When  I open the login page on mac
	Then  I should found the login page working and looking perfect on mac
	
@maual @linux
Scenario: cross system testing to ensure look and feel and responce of login page 
    Given I have Linux OS
	When  I open the login page on Linux
	Then  I should found the login page working and looking perfect on linux






