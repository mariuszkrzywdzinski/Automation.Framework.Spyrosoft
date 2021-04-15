using Automation.Framework.Spyrosoft.Pages.Interfaces;
using TechTalk.SpecFlow;

namespace Automation.Framework.Spyrosoft.Steps
{
    [Binding]
    public class ProductGridPageSteps
    {
        private readonly IProductGridPage _productGridPage;

        public ProductGridPageSteps(IProductGridPage productGridPage)
        {
            _productGridPage = productGridPage;
        }

        [Then(@"User selects (.*) product")]
        public void ThenUserSelectsProduct(string productName)
        {
            _productGridPage.SelectProduct(productName);
        }
    }
}
