namespace Automation.Framework.Spyrosoft.Pages.Interfaces
{
    public interface ISubPage : IPage
    {
        bool IsSubPageVisible(string name);
        string GetPageHeader();
        void ClickCategory(string option);
    }
}