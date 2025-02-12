Feature: MARS_skill

As a MARS portal admin user
I would like to add, edit, delete skills records
So that as a user I would be able to show what skills I know.
So that the people seeking for skills can look at what details I hold.


@tag1
Scenario: Add new skill with valid data
	Given I logged in to MARS portal successfully
	When I navigate to profile page
	When I add new skill "Presentation" with a level "Beginner"
	Then the skill should be added successfully.

Scenario: Add new skill without selecting a level
   Given I logged in to MARS portal successfully
	When I navigate to profile page
	When I add new skill without selecting a level
	Then the skill is not added and an error message pops up

Scenario: Edit existing skill in the profile
   Given I logged in to MARS portal successfully
	When I navigate to profile page
	When  I update the existing skill to a new skill name "Coaching"
	Then the changes should be saved successfully and updated "Coaching" should be visible in the profile
	

Scenario: Delete an existing skill in the profile
   Given I logged in to MARS portal 
	When I navigate to profile page
	When  I delete the skill
	Then the skill should be removed from the profile
	And a confirmation message should appear

   Scenario: Add a duplicate skill with the same level
    Given I logged in to MARS portal successfully
    And I have an existing skill added to my profile
    When I try to add the same skill "Coaching" with the same level "Expert"
    And an error message should appear stating that this skill already exist

   Scenario: Add a skill with unsupported characters  
  Given I logged in to MARS portal successfully  
  When I try to add a skill name "@@##$$%%" with unsupported characters with a level "Basic"
  Then the system should not allow it  
  And an error message should appear stating undefined 
