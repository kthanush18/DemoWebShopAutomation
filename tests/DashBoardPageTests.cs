﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using UITests.Web.DemoWebApp.pages;

namespace UITests.Web.DemoWebApp.tests
{
    [TestClass]
    public class DashBoardPageTests : TestBase
    {

        [TestInitialize]
        public new void TestIntialize()
        {
            base.TestIntialize();
            _landingPage = new LandingPage();
            _login = _landingPage.NavigateToLoginPage();
            _dashBoard = _login.EnterCredentialsAndLogin();
        }

        [TestMethod]
        [Description("Add products to cart and verify message displayed after adding products")]
        public void TC_AddProductToCart_VerifyProductAddedMessage()
        {
            //Arrange
            string productAddedMessage = "The product has been added to your shopping cart";

            //Act
            _dashBoard.ClearShoppingCart();
            _dashBoard.SelectFictionBook();
            _dashBoard.EnterRandomQuantity();
            _dashBoard.AddToCart();

            //Assert
            Assert.AreEqual(_dashBoard.GetProductAddedMessage(), productAddedMessage);
        }

        [TestMethod]
        [Description("Open shopping cart and verify sub total price for products added in the cart")]
        public void TC_OpenShoppingCart_VerifySubTotalPrice()
        {
            //Arrange

            //Act
            _dashBoard.ClearShoppingCart();
            _dashBoard.SelectFictionBook();
            _dashBoard.EnterRandomQuantity();
            _dashBoard.AddToCart();
            _dashBoard.NavigateToShoppingCart();

            //Assert
            Assert.AreEqual(_dashBoard.GetSubTotalFromUI(), _dashBoard.GetSubTotalFromPriceAndQuantity());
        }

        [TestCleanup]
        public new void TestCleanup()
        {
            _dashBoard.LogOut();
            base.TestCleanup();
        }
    }
}
