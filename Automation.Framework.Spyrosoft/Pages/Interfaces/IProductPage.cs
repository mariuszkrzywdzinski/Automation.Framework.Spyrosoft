namespace Automation.Framework.Spyrosoft.Pages.Interfaces
{
    public interface IProductPage
    {
        void ClickIncreaseTo(int quantity = 1);
        void ClickAddToYourBasket();
        void ClickGoToYourBasket();
        bool IsConfirmationMessageDisplayed();
    }
}