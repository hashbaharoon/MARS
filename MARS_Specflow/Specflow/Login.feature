Feature: Login

To ensure that the login page works as expected
 As a user
 I want to verify various scenarios for logging in

@SmokeTest
Scenario: Successfull login with valid username and password
    Given  I am on the login page
	When I enter a valid username "hashba95@gmail.com" and password "Hashsab@95"
	And I click the login button
	Then I should be redirected to the dashboard

@SmokeTest
Scenario: Login with already used username
    Given  I am on the login page
	When I enter the username that is already registered
	 And I enter a valid password
    And I click the login button
    Then I should see a send verification email dialog box


  @RegressionTest
  Scenario: Login with blank fields/empty fields
    Given I am on the login page
    When I leave the username and password fields blank
    And I click the login button
    Then I should see an error message asking to enter a valid email address and password

  @NegativeTest
Scenario: Login with invalid credentials
    Given  I am on the login page
	When I enter invalid username "asdfgh@gmail.com" and password "Shib"
	And I click the login button
	Then an error message Please Enter a valid email address shows

  @NegativeTest
  Scenario: Login with wrong email format
    Given I am on the login page
    When I enter "Testing" as the username
    And I enter a valid password
    And I click the login button
    Then an error message Please Enter a valid email address shows

  @NegativeTest
  Scenario: Login with password less than 6 characters
    Given I am on the login page
    When I enter a valid username "Nivin@gmail.com"
    And I enter "12345" as the password
    And I click the login button
    Then I should see an error message saying Password must be at least 6 characters

  @NegativeTest
  Scenario: Login with password that doesn't contain numbers
    Given I am on the login page
    When I enter a valid username "Nivin@gmail.com"
    And I enter "Password!" as the password
    And I click the login button
    Then a Send verification email dialogue box pops up

  @NegativeTest
  Scenario: Login with password that doesn't contain special characters
    Given I am on the login page
    When I enter a valid username "Nivin@gmail.com"
    And I enter "Password123" as the password
    And I click the login button
    Then a Send verification email dialogue box pops up

  @NegativeTest
  Scenario: Login with password that doesn't begin with a capital letter
    Given I am on the login page
    When I enter a valid username "Nivin@gmail.com"
    And I enter "password123!" as the password
    And I click the login button
   Then a Send verification email dialogue box pops up

  @SmokeTest
  Scenario: Login with Remember Me functionality
    Given I am on the login page
    When I enter a valid username "hashba95@gmail.com" and password "Hashsab@95"
    And I select the Remember_Me checkbox
    And I click the login button
    Then I should remain logged in even after reopening the browser

  @SmokeTest
  Scenario: Login with "Forgot your password?" link
    Given I am on the login page
    When I click on the Forgot your password? link
    Then a Send verification email dialogue box pops up

  @SmokeTest
  Scenario: Login with "Join" link functionality
    Given I am on the login page
    When I click on the Join link
    Then I should be redirected to the join page

 
	


