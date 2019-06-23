using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject1.TestDataAccess;
using UnitTestProject1.Extensions;

namespace UnitTestProject1.PageObjects
{
    class LogInPage
    {
       [FindsBy(How = How.Id, Using = "txtUserID")]
        [CacheLookup]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "txtPassword")]
        [CacheLookup]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "sub")]
        [CacheLookup]
        public IWebElement Submit { get; set; }


        public void LoginToApplication(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            UserName.EnterText(userData.Username, "UserName");
            Password.EnterText(userData.Password, "Password");
            Submit.ClickOnIt("Submit");
        }

    }


}
