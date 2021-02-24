using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using UITests.Web.Common;
using UITests.Web.DemoWebApp.pages;

namespace UITests.Web.DemoWebApp.tests
{
    public abstract class TestBase
    {
        protected LandingPage _landingPage;
        protected LoginPage _login;
        protected DashBoardPage _dashBoard;
        protected CheckOutPage _checkout;
        private static WebBrowser _browser;
        private static readonly string _demoWebShop = ConfigurationManager.AppSettings["DemoWebShopURL"].ToString();

        //Method for launching browser and navigating to URL
        [TestInitialize]
        public void TestIntialize()
        {
            try
            {
                _browser = new WebBrowser();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex);
            }
            _browser.LaunchBrowser();
            LaunchApplication(_demoWebShop);
        }

        public void LaunchApplication(string URL)
        {
            _browser.NavigateToURL(URL);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _browser.CloseBrowser();
        }
    }
}
