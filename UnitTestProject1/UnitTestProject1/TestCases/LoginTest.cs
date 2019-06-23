using System;
using NUnit.Framework;
using UnitTestProject1.PageObjects;
using System.Configuration;
using UnitTestProject1.WrapperFactory;

namespace UnitTestProject1.TestCases
{
    
    public class LoginTest
    {
       

        [Test]
        [Obsolete]
        public void Test()
        {
        
            BrowserFactory.InitBrowser("Chrome");
            BrowserFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            Page.Login.LoginToApplication("LogInTest");

            BrowserFactory.CloseAllDrivers();






        }
    }
}
