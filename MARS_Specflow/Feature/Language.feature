Feature: MARS_language

As a MARS portal admin user
I would like to add, edit, delete language  records
So that as a user I would be able to show what languages and skills I know.
So that the people seeking for skills and languages can look at what details I hold.
@tag1
Scenario: Add new language with valid data
	Given I logged in to MARS portal successfully
	When I navigate to profile page
	When I add new language "French" with a level "Basic"
	Then the language should be added successfully

Scenario: Add new language without selecting a level
   Given I logged in to MARS portal successfully
	When I navigate to profile page
	When I add new language without selecting a level
	Then the language is not added and an error message pops up

Scenario: Edit existing language in the profile
   Given I logged in to MARS portal successfully
	When I navigate to profile page
	When  I update the existing language to a new language name "Mandarin"
	Then the changes should be saved successfully and updated "Mandarin" should be visible in the profile
	

Scenario: Delete an existing language in the profile
   Given I logged in to MARS portal successfully
	When I navigate to profile page
	When  I delete the  language
	Then the language should be removed from the profile
	And a confirmation message should appear

   Scenario: Add a duplicate language with the same level
    Given I logged in to MARS portal successfully
    And I have an existing language added to my profile
    When I try to add the same language "Mandarin" with the same level "Basic"
    And an error message should appear stating that this language already exist

  Scenario: Add a language with unsupported characters  
  Given I logged in to MARS portal successfully  
  When I try to add a language name "@@##$$%%" with unsupported characters with a level "Basic"
  Then the system should not allow it  
  And an error message should appear stating undefined 
	
  Scenario:Verify that the 'Add' button is not available after adding 4 languages  
   Given I logged in to MARS portal successfully
   And I have already added the maximum number of allowed languages   
   Then the Add button should not be visible  

