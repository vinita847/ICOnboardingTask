Feature: Skills
	In order to manage my skills in my profile
	As a seller
	I want to add, update and delete my skills


Background: successful login 
Given I entered the webaddress on the browser
And I logged in with valid user mane and password


@automation @ chrome @p1
Scenario: Add new skill with valid data
	Given I have opened the browser
	And I sign in on the skillswap web
	And I opened the skills tab
	When I add new skill
	Then A success popup message should be displayed

@automation @ chrome @p1
Scenario: Update skill with valid data
	Given I have opened the chrome browser
	And I have signed in on skill swap web app
	And I oopened the skils section
	When I click on Update button and enter valid data
	Then A success Updated message should be displayed

@automation @ chrome @p1
Scenario: Delete skill
	Given I have opend the chrome browser
	And I have signed in skill swap web page
	And I opened the Skills section
	When I click on delete icon
	Then A delete message should be displayed

@automation @ chrome @p1
Scenario: Add new skill with null data
	Given Click on Add New button
	And Enter null data on skill and skill level fields
	When I click on add button
	Then A error message should be prompted

@automation @ chrome @p1
Scenario: Add new skill with invalid data
	Given Click on Add New button
	And Enter valid skill and skill level
	When I click on add button
	Then Added skill should be displayed in below list




