using System;
using TechTalk.SpecFlow;

namespace MARS
{
    [Binding]
    public class Language_StepDefinition
    {
        [Given(@"I logged in to MARS portal successfully")]
        public void GivenILoggedInToMARSPortalSuccessfully()
        {
            throw new PendingStepException();
        }

        [When(@"I navigate to profile page")]
        public void WhenINavigateToProfilePage()
        {
            throw new PendingStepException();
        }

        [When(@"I add new language with a level")]
        public void WhenIAddNewLanguageWithALevel()
        {
            throw new PendingStepException();
        }

        [Then(@"the language should be added successfully\.")]
        public void ThenTheLanguageShouldBeAddedSuccessfully_()
        {
            throw new PendingStepException();
        }
        [When(@"I add new language without selecting a level")]
        public void WhenIAddNewLanguageWithoutSelectingALevel()
        {
            throw new PendingStepException();
        }

        [Then(@"the language is not added")]
        public void ThenTheLanguageIsNotAdded()
        {
            throw new PendingStepException();
        }

        [Then(@"an error message pops up")]
        public void ThenAnErrorMessagePopsUp()
        {
            throw new PendingStepException();
        }

        [When(@"I update the existing '([^']*)' to a new language name or level")]
        public void WhenIUpdateTheExistingToANewLanguageNameOrLevel(string language)
        {
            throw new PendingStepException();
        }


        [Then(@"thechanges should be saved successfully")]
        public void ThenThechangesShouldBeSavedSuccessfully()
        {
            throw new PendingStepException();
        }

        [Then(@"the updated '([^']*)' should be visible in the profile")]
        public void ThenTheUpdatedShouldBeVisibleInTheProfile(string language)
        {
            throw new PendingStepException();
        }


        [Given(@"I logged in to MARS portal")]
        public void GivenILoggedInToMARSPortal()
        {
            throw new PendingStepException();
        }

        [When(@"I delete the  language")]
        public void WhenIDeleteTheLanguage()
        {
            throw new PendingStepException();
        }

        [Then(@"the language should be removed from the profile")]
        public void ThenTheLanguageShouldBeRemovedFromTheProfile()
        {
            throw new PendingStepException();
        }

        [Then(@"a confirmation message should appear")]
        public void ThenAConfirmationMessageShouldAppear()
        {
            throw new PendingStepException();
        }

        [When(@"I have already added the maximum number of allowed languages")]
        public void WhenIHaveAlreadyAddedTheMaximumNumberOfAllowedLanguages()
        {
            throw new PendingStepException();
        }

        [When(@"I try to add another language")]
        public void WhenITryToAddAnotherLanguage()
        {
            throw new PendingStepException();
        }

        [Then(@"the system should not allow it")]
        public void ThenTheSystemShouldNotAllowIt()
        {
            throw new PendingStepException();
        }

        [Then(@"an error message should appear stating the limit has been reached")]
        public void ThenAnErrorMessageShouldAppearStatingTheLimitHasBeenReached()
        {
            throw new PendingStepException();
        }

        [Given(@"I am logged in to the MARS portal")]
        public void GivenIAmLoggedInToTheMARSPortal()
        {
            throw new PendingStepException();
        }

        [Given(@"I have an existing language added to my profile")]
        public void GivenIHaveAnExistingLanguageAddedToMyProfile()
        {
            throw new PendingStepException();
        }

        [When(@"I try to add the same language with the same level")]
        public void WhenITryToAddTheSameLanguageWithTheSameLevel()
        {
            throw new PendingStepException();
        }

        [Then(@"an error message should appear stating that duplicate languages are not allowed\.")]
        public void ThenAnErrorMessageShouldAppearStatingThatDuplicateLanguagesAreNotAllowed_()
        {
            throw new PendingStepException();
        }

        [When(@"I try to add a language name with unsupported characters")]
        public void WhenITryToAddALanguageNameWithUnsupportedCharacters()
        {
            throw new PendingStepException();
        }

        [Then(@"an error message should appear stating that input is invalid\.")]
        public void ThenAnErrorMessageShouldAppearStatingThatInputIsInvalid_()
        {
            throw new PendingStepException();
        }
        


    }

}
