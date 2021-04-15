using Automation.Framework.Spyrosoft.Pages.Interfaces;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Automation.Framework.Spyrosoft.Steps
{
    [Binding]
    public class CookiesSteps
    {
        private readonly ICookiePopup _cookiePopup;

        public CookiesSteps(ICookiePopup cookiePopup)
        {
            _cookiePopup = cookiePopup;
        }
        [When(@"User clicks allow all button on Cookies popup")]
        public void WhenUserClicksAllowAllButtonOnCookiesPopup()
        {
            _cookiePopup.ClickAllowAll();
        }
        
        [Then(@"Cookies popup is displayed")]
        public void ThenCookiesPopupIsDisplayed()
        {
            bool expected = true;
            string reasonOfFailure = "Cookies popup should be displayed.";

            _cookiePopup.IsCookiesPopupVisible().Should().Be(expected, reasonOfFailure);
        }
        
        [Then(@"Cookies popup is no longer displayed")]
        public void ThenCookiesPopupIsNoLongerDisplayed()
        {
            bool expected = true;
            string reasonOfFailure = "Cookies popup should not be displayed.";

            _cookiePopup.IsCookiesPopupVisible(false).Should().Be(expected, reasonOfFailure);
        }
    }
}
