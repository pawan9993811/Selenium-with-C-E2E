using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects
{
    class HomePage
    {
      
        [FindsBy(How = How.ClassName, Using = "logo")]
        [CacheLookup]
        public IWebElement Logo { get; set; }
    }

    
}
