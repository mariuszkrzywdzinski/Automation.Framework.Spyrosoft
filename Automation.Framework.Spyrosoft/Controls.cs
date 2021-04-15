namespace Automation.Framework.Spyrosoft
{
    public static class Controls
    {
        public static class XPath
        {
            public const string MenuContainer = "//div[contains(@class,'navigation-navigationPane')]";
            public const string MenuItemLevel1 = "//li[contains(@class,'navigation-item-item')]/a";
            public const string CategoryContainer = "//nav[@class='area-categories-nav']";
            public const string CategoryItemLevel1 = "//li[@class='area-categories-nav-item']/a";
            public const string FlyoutMenuContainer = "//div[contains(@class,'navigation-flyout') and @aria-hidden='false']";
            public const string ProductContainer = "//div[@data-test='component-grid-container']";
            public const string ProductCard = "//section[@data-test='product-card']";
            public const string ProductName = "//section[@data-test='product-card']//h2";

            public const string QuantityDecreaseButton = "//button[@class='quantity-decrease-button']";
            public const string QuantityInput = "//input[contains(@class,'quantity-input')]";
            public const string QuantityIncreaseButton = "//button[@class='quantity-increase-button']";
            public const string AddToYourBasketButton = "//button[@id='button--add-to-basket']";
            public const string GoToYourBasketButton = "//a[contains(@class,'add-to-basket-view-basket-link')]";
            public const string ProductHeaderTitle = "//div[@class='show-on-desktop']//h1[@class='product-header__title']";
            public const string ProductConfirmationMessage = "//div[@class='add-to-basket-confirmation-message__inner']";
            public const string BasketEmptyConfirmationMessage = "//div[@class='basket-empty']/h2";

            //sub-page
            public const string HeaderPage = "//h1[@class='product-list-heading']|//h1[contains(@class,'Header_heading')]/span[@role='text']|//h1[@class='view-basket-main__title']";
            //cookie popup
            public const string AllowAllPopupButton = "//button[@data-test='allow-all']";
            public const string ManageCookiesPopupButton = "//button[@test-data='manage-cookies']";
            public const string CookiesPopupContainer = "//div[@data-test='cookie-banner']";

            //basket
            public const string BasketContainer = "//div[@class='view-basket-list-container']";
            public const string BasketItem = "//li[contains(@class,'basket-list-item')]";
            public const string RemoveItemButton = "//button[@class='remove-basket-item-form-button']";

        }
        public static class StaticText
        {
            public const string YourBasketIsEmpty = "Your basket is empty.";
        }
    }
}
