using System;
using Automation.Framework.Spyrosoft.Pages.Interfaces;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Automation.Framework.Spyrosoft.Steps
{
    [Binding]
    public class SubPageSteps
    {
        private readonly ISubPage _subPage;

        public SubPageSteps(ISubPage subPage)
        {
            _subPage = subPage;
        }

        [When(@"User selects (.*) category from the left side menu")]
        public void WhenUserSelectsCategoryFromTheLeftSideMenu(string option)
        {
            _subPage.ClickCategory(option);
        }
        
        [Then(@"(.*) page is displayed")]
        public void ThenSubPageIsShown(string expected)
        {
            string reasonOfFailure = expected + " page is not displayed.";
            _subPage.GetPageHeader().Should().Contain(expected.ToUpperInvariant(), reasonOfFailure);
        }
    }
}
