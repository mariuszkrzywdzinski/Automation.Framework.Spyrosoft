namespace Automation.Framework.Spyrosoft.Pages.Interfaces
{
    public interface ICookiePopup
    {
        bool IsCookiesPopupVisible(bool shouldBe = true);
        void ClickAllowAll();
    }
}