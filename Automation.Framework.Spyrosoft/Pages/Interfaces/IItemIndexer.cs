using Automation.Framework.Spyrosoft.Pages.PartialPages;

namespace Automation.Framework.Spyrosoft.Pages.Interfaces
{
    public interface IItemIndexer
    {
        Item this[string name] { get; }
        Item GetByName(string name);
    }
}
