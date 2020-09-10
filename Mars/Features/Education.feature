Feature: Education
	In order to perform CRUD operation
	As a seller
	I want to be Add, Delete and Update my education

Background: Successful login
Given open browser and enter url
When  login to your account
And   click on education tab
  
@mytag
Scenario: Add Education
Given I have clicked on Add New button
When  I enter the required details for education
And   I click on Add button
Then  I should be able to see a success Add message
 
@mytag
Scenario: Update Education
Given I have clicked on Update icon
When  I enter the update the desired fields
Then  I should be able to see a Success Update message

@mytag
Scenario: Delete Education
When I have clicked on the delete icon
Then I should be able to see a delete success message 



	