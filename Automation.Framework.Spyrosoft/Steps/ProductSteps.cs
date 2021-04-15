using Automation.Framework.Spyrosoft.Pages.Interfaces;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Automation.Framework.Spyrosoft.Steps
{
    [Binding]
    public class ProductSteps
    {
        private readonly IProductPage _productPage;

        public ProductSteps(IProductPage productPage)
        {
            _productPage = productPage;
        }

        [When(@"User sets quantity to (.*)")]
        public void WhenUserSetsQuantityTo(int quantity)
        {
            _productPage.ClickIncreaseTo(quantity);
        }

        [When(@"User clicks Add to your basket button")]
        public void WhenUserClicksAddToYourBasketButton()
        {
            _productPage.ClickAddToYourBasket();
        }
        
        [Then(@"Product page with (.*) item is displayed")]
        public void ThenProductPageWithItemIsShown(string productName)
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"Confirmation message is displayed")]
        public void ThenConfirmationMessageIsDisplayed()
        {
            bool expected = true;
            string reasonOfFailure = "Confirmation message should be displayed.";

            _productPage.IsConfirmationMessageDisplayed().Should().Be(expected, reasonOfFailure);
        }

        [When(@"User clicks Go to your basket")]
        public void WhenUserClicksGoToYourBasket()
        {
            _productPage.ClickGoToYourBasket();
        }


    }
}
