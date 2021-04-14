using System;
using System.Linq;
using Autofac;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace Automation.Framework.Spyrosoft.Configuration
{
    class AutofacConfig
    {
        [ScenarioDependencies]
        private static ContainerBuilder ContainerConfig()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ChromeDriver>().As<IWebDriver>().SingleInstance();

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
