using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace UnitTestProject1.WrapperFactory
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;
        //private static string driverPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        private static string GetCurrentProjectPath()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectpath = appDirectory.Substring(0, appDirectory.IndexOf("\\bin"));

            return projectpath;
        }


        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            
            switch (browserName)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                        driver.Manage().Window.Maximize();
                    }
                    break;

                case "IE":
                    if (driver == null)
                    {
                        driver = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");
                        Drivers.Add("IE", Driver);
                        driver.Manage().Window.Maximize();
                    }
                    break;

                case "Chrome":
                     if (driver == null)
                        {
                       
                        driver = new ChromeDriver(GetCurrentProjectPath() + @"\Driver");
                        Drivers.Add("Chrome", Driver);
                        driver.Manage().Window.Maximize();
                    }
                    break;
            }
        }


        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}