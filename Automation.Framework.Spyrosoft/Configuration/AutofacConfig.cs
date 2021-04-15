using System;
using System.Configuration;
using System.Linq;
using Autofac;
using Automation.Framework.Spyrosoft.Pages;
using Automation.Framework.Spyrosoft.Pages.Interfaces;
using Automation.Framework.Spyrosoft.Pages.PartialPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace Automation.Framework.Spyrosoft.Configuration
{
    public class AutofacConfig
    {
        //Class responsible for registering classes, interfaces
        [ScenarioDependencies]
        private static ContainerBuilder ContainerConfig()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Register(c =>
            {
                var browser = ConfigurationManager.AppSettings["BrowserType"];

                if (browser.Equals("Chrome"))
                    return new ChromeDriver();
                else
                {
                    throw new NotImplementedException("Not yet implemented, please change [BrowserType] key in app.config");
                }
            }).As<IWebDriver>().SingleInstance();

            //Register pages & interfaces
            //TODO: needs to be changed to more generic approach instead of registering one by one 

            containerBuilder.RegisterType<MainPage>().As<IMainPage>();
            containerBuilder.RegisterType<SubPage>().As<ISubPage>();
            containerBuilder.RegisterType<BasketPage>().As<IBasketPage>();
            containerBuilder.RegisterType<ProductPage>().As<IProductPage>();
            containerBuilder.RegisterType<ProductGridPage>().As<IProductGridPage>();
            containerBuilder.RegisterType<CookiePopup>().As<ICookiePopup>();
            containerBuilder.RegisterType<MenuItem>().As<IMenuItem>();
            containerBuilder.RegisterType<CategoryItem>().As<ICategoryItem>();
            containerBuilder.RegisterType<ProductItem>().As<IProductItem>();

            //Registering all test classes from assembly with [Binding] annotation
            containerBuilder
                .RegisterTypes(typeof(AutofacConfig).Assembly.GetTypes()
                    .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute)))
                    .ToArray())
                .SingleInstance().InstancePerLifetimeScope();

            return containerBuilder;
        }
    }
}
