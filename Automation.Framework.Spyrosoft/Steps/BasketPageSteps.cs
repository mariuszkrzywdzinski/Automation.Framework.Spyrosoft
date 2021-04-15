using Automation.Framework.Spyrosoft.Pages.Interfaces;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Automation.Framework.Spyrosoft.Steps
{
    [Binding]
    public class BasketPageSteps
    {
        private IBasketPage _basketPage;

        public BasketPageSteps(IBasketPage basketPage)
        {
            _basketPage = basketPage;
        }

        [When(@"User clicks Remove item")]
        public void WhenUserClicksRemoveItem()
        {
           _basketPage.ClickRemoveItem();
        }
        
        [Then(@"Your basket is empty message is displayed")]
        public void ThenYourBasketIsEmptyMessageIsDisplayed()
        {
            string reasonOfFailure = "Your basket is not empty.";
            _basketPage.IsYourBasketIsEmptyMessageDisplayed().Should().BeTrue(reasonOfFailure);
        }
    }
}
