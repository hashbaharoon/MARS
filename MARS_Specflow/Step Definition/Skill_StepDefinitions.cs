using System;
using TechTalk.SpecFlow;

namespace MARS
{
    [Binding]
    public class Skill_StepDefinitions
    {
        [When(@"I add new skill with a level")]
        public void WhenIAddNewSkillWithALevel()
        {
            throw new PendingStepException();
        }

        [Then(@"the skill should be added successfully\.")]
        public void ThenTheSkillShouldBeAddedSuccessfully_()
        {
            throw new PendingStepException();
        }

        [When(@"I add new skill without selecting a level")]
        public void WhenIAddNewSkillWithoutSelectingALevel()
        {
            throw new PendingStepException();
        }

        [Then(@"the skill is not added")]
        public void ThenTheSkillIsNotAdded()
        {
            throw new PendingStepException();
        }

        [When(@"I update the existing '([^']*)' to a new skill name or level")]
        public void WhenIUpdateTheExistingToANewSkillNameOrLevel(string skill)
        {
            throw new PendingStepException();
        }

        [When(@"I delete the skill")]
        public void WhenIDeleteTheSkill()
        {
            throw new PendingStepException();
        }

        [Then(@"the skill should be removed from the profile")]
        public void ThenTheSkillShouldBeRemovedFromTheProfile()
        {
            throw new PendingStepException();
        }

        [Given(@"I have an existing skill added to my profile")]
        public void GivenIHaveAnExistingSkillAddedToMyProfile()
        {
            throw new PendingStepException();
        }

        [When(@"I try to add the same skill with the same level")]
        public void WhenITryToAddTheSameSkillWithTheSameLevel()
        {
            throw new PendingStepException();
        }

        [Then(@"an error message should appear stating that duplicate skill are not allowed\.")]
        public void ThenAnErrorMessageShouldAppearStatingThatDuplicateSkillAreNotAllowed_()
        {
            throw new PendingStepException();
        }

        [When(@"I try to add a skill name with unsupported characters")]
        public void WhenITryToAddASkillNameWithUnsupportedCharacters()
        {
            throw new PendingStepException();
        }
    }
}
