namespace Automation.Framework.Spyrosoft.Pages.Interfaces
{
    public interface IBasketPage : IPage
    {
        void ClickRemoveItem();
        bool IsYourBasketIsEmptyMessageDisplayed();
    }
}