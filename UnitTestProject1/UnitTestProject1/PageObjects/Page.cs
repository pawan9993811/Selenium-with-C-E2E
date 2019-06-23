using UnitTestProject1.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;


namespace UnitTestProject1.PageObjects
{
    class Page
    {
        [System.Obsolete]
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        [System.Obsolete]
        public static HomePage Home => GetPage<HomePage>();

        [System.Obsolete]
        public static LogInPage Login => GetPage<LogInPage>();
       
    }
}
