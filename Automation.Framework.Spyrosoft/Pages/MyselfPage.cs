using System;
using System.IO;
using Newtonsoft.Json;
using OpenQA.Selenium;

namespace Automation.Framework.Spyrosoft.Pages
{
    public class MyselfPage
    {
        private readonly IWebDriver _driver;

        public MyselfPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void MakeOverlayOnPage()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;

            string text = "Hello, \n" + LoadJson();

            jsExecutor.ExecuteScript("alert(JSON.stringify('{person:[{firstName:Mariusz, lastName: Krzywdzinski}]}'))");
            //"var elem = document.createElement('div');elem.style.cssText = 'position:absolute;width:100%;height:100%;opacity:0.8;z-index:100;background:#777';document.body.appendChild(elem); "
        }

        private string LoadJson()
        {
            
            var xx = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myself.json");
            //typeof(Automation.Framework.Spyrosoft).Assembly.Location;
            string data = File.ReadAllText(xx);
            //Dictionary<string, object> deserialized = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);

            return JsonConvert.SerializeObject(data, Formatting.Indented);
        }
    }
}
