Feature: MARS_language

As a MARS portal admin user
I would like to add, edit, delete language  records
So that as a user I would be able to show what languages and skills I know.
So that the people seeking for skills and languages can look at what details I hold.
@tag1
Scenario: Add new language with valid data
	Given I logged in to MARS portal successfully
	When I navigate to profile page
	When I add new language with a level
	Then the language should be added successfully.

Scenario: Add new language without selecting a level
   Given I logged in to MARS portal successfully
	When I navigate to profile page
	When I add new language without selecting a level
	Then the language is not added
	And an error message pops up

Scenario: Edit existing language in the profile
   Given I logged in to MARS portal successfully
	When I navigate to profile page
	When  I update the existing '<language>' to a new language name or level
	Then thechanges should be saved successfully
	And the updated '<language>' should be visible in the profile

Scenario: Delete an existing language in the profile
   Given I logged in to MARS portal 
	When I navigate to profile page
	When  I delete the  language
	Then the language should be removed from the profile
	And a confirmation message should appear

Scenario: Add more than the maximum number of languages
   Given I logged in to MARS portal 
   When I navigate to profile page
   And I have already added the maximum number of allowed languages
   When I try to add another language
   Then the system should not allow it
   And an error message should appear stating the limit has been reached

   Scenario: Add a duplicate language
    Given I am logged in to the MARS portal
    And I have an existing language added to my profile
    When I try to add the same language with the same level
    Then the system should not allow it
    And an error message should appear stating that duplicate languages are not allowed.

   Scenario: Add a language with unsupported characters
    Given I am logged in to the MARS portal
    When I try to add a language name with unsupported characters
    Then the system should not allow it
    And an error message should appear stating that input is invalid.
