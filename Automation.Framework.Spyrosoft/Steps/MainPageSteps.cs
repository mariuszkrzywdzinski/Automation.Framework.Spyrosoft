using Automation.Framework.Spyrosoft.Pages.Interfaces;
using TechTalk.SpecFlow;

namespace Automation.Framework.Spyrosoft.Steps
{
    [Binding]
    public class MainPageSteps
    {
        private readonly IMainPage _mainPage;

        public MainPageSteps(IMainPage mainPage)
        {
            _mainPage = mainPage;
        }

        [Given(@"User is on my page")]
        public void GivenUserIsOnMyPage()
        {
           // _mainPage.
        }

        [When(@"User clicks (.*) option from main menu")]
        public void WhenUserClicksOptionFromMainMenu(string option)
        {
            _mainPage.SelectMainMenuOption(option);
        }
    }
}
