using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Login_Authenticate;
using Login_Authenticate.Controllers;
using Login_Authenticate.Business;

namespace Login_Authenticate.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(null);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual(string.Empty, result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void TestLogin_Admin_Authenticated_Should_Expect_EnrolView()
        {
            var customerService = new CustomerService();
            var controller = new HomeController(customerService);
            var result = controller.Login("google", "google") as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Enrol", result.ViewName);

        }

        [TestMethod]

        public void TestLogin_Admin_Authenticated_Should_Expect_IndexView()
        {

            var controller = new HomeController();
            var result = controller.Login("admin", "admin") as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);

        }

    }
}