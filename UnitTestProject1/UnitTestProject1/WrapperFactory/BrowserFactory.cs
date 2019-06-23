﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

namespace UnitTestProject1.WrapperFactory
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

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
            Console.WriteLine("''''''''''''''");
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
                        driver = new ChromeDriver(@"C:\traning\chromedriver_win32");
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