using System;
using System.Threading;
using Automation.Framework.Spyrosoft.Pages;
using TechTalk.SpecFlow;

namespace Automation.Framework.Spyrosoft.Steps
{
    [Binding]
    public class MyselfDescriptionSteps
    {
        private MyselfPage _myselfPage;
        public MyselfDescriptionSteps(MyselfPage page, MyselfPage myselfPage)
        {
            _myselfPage = myselfPage;
        }
        [Given(@"Description of myself is shown interface JSON format")]
        public void GivenDescriptionOfMyselfIsShownInterfaceJSONFormat()
        {
            _myselfPage.MakeOverlayOnPage();
            Thread.Sleep(10000);
        }
    }
}
